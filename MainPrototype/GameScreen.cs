using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomControls;
using ClassModels;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace MainPrototype
{



    public partial class GameScreen : Form
    {

        #region Window Drag And Shadows
        private void Screen_MouseDown(object sender, MouseEventArgs e)
        {

        }

        internal static class NativeWinAPI
        {
            internal static readonly int GWL_EXSTYLE = -20;
            internal static readonly int WS_EX_COMPOSITED = 0x02000000;

            [DllImport("user32")]
            internal static extern int GetWindowLong(IntPtr hWnd, int nIndex);

            [DllImport("user32")]
            internal static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        }




        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
           (
               int nLeftRect, // x-coordinate of upper-left corner
               int nTopRect, // y-coordinate of upper-left corner
               int nRightRect, // x-coordinate of lower-right corner
               int nBottomRect, // y-coordinate of lower-right corner
               int nWidthEllipse, // height of ellipse
               int nHeightEllipse // width of ellipse
            );

        [DllImport("dwmapi.dll")]
        public static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS pMarInset);

        [DllImport("dwmapi.dll")]
        public static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("dwmapi.dll")]
        public static extern int DwmIsCompositionEnabled(ref int pfEnabled);

        private bool m_aeroEnabled;                     // variables for box shadow
        private const int CS_DROPSHADOW = 0x00020000;
        private const int WM_NCPAINT = 0x0085;
        private const int WM_ACTIVATEAPP = 0x001C;

        public struct MARGINS                           // struct for box shadow
        {
            public int leftWidth;
            public int rightWidth;
            public int topHeight;
            public int bottomHeight;
        }
        //private const int WM_NCHITTEST = 0x84;          // variables for dragging the form
        //private const int HTCLIENT = 0x1;
        //private const int HTCAPTION = 0x2;

        protected override CreateParams CreateParams
        {
            get
            {
                m_aeroEnabled = CheckAeroEnabled();

                CreateParams cp = base.CreateParams;
                if (!m_aeroEnabled)
                    cp.ClassStyle |= CS_DROPSHADOW;

                return cp;
            }
        }
        private bool CheckAeroEnabled()
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                int enabled = 0;
                DwmIsCompositionEnabled(ref enabled);
                return (enabled == 1) ? true : false;
            }
            return false;
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case WM_NCPAINT:                        // box shadow
                    if (m_aeroEnabled)
                    {
                        var v = 2;
                        DwmSetWindowAttribute(this.Handle, 2, ref v, 4);
                        MARGINS margins = new MARGINS()
                        {
                            bottomHeight = 1,
                            leftWidth = 1,
                            rightWidth = 1,
                            topHeight = 1
                        };
                        DwmExtendFrameIntoClientArea(this.Handle, ref margins);

                    }
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);

            //if (m.Msg == WM_NCHITTEST && (int)m.Result == HTCLIENT)     // drag the form
            //    m.Result = (IntPtr)HTCAPTION;

        }

        #endregion


        public enum Phase
        {
            INICIO,
            MOVIMENTACAO,
            ATAQUE,
            RECUO,
            ENEMYMOV,
            ENEMYATK
        }

        Random r = new Random();

        Phase phase;
        int speedLeft;
        int NumMonters = 4;
        int monsterMov = 4;
        int score = 0;
        int range;
        public int TileSize { get; private set; } = 32;
        private int linhas = 17;
        private int colunas = 24;

        public int Colunas { get => colunas; set => colunas = value; }
        public int Linhas { get => linhas; set => linhas = value; }
        public int passosdados { get; private set; } = 0;
        public int monstercounter { get; private set; } = 0;
        public int turn { get; private set; }

        public CustomTile TargetTile;

        CustomTile[,] MatrizTiles;
        List<Monster> monsters;

        private int tries;
        private int deltaX;
        private int deltaY;
        public bool moved = false;

        public GameScreen()
        {
            InitializeComponent();
            Statics.CreateNewPlayer();
            MatrizTiles = new CustomTile[Colunas, Linhas];
            monsters = new List<Monster>();
            patricioPic.Image = Properties.Resources.Patricio;
            phase = Phase.INICIO;
            Statics.CreateNewPlayer(20, 10, 2, 0, 0, 4, 2, 20);
            Statics.GenerateModifiers();
            speedLeft = Statics.Player.Speed + Statics.Player.ItemAtual.StatBonus.MovSpeed;
            Statics.StartGame();
            timer1.Interval = 33;
            timer1.Start();
        }

        public void TileClick(Object sender, EventArgs e)
        {

            CustomTile c = sender as CustomTile;
            if (phase == Phase.INICIO && !c.isLocked)
            {
                TargetTile = c;
                c.PutPlayer();
                Statics.UpdatePlayer(c.x, c.y);
                phase = Phase.MOVIMENTACAO;
                turn++;
            }
            //Turno de movimento
            else if (phase == Phase.MOVIMENTACAO)
            {
                speedLeft = Statics.Player.Speed + Statics.Player.ItemAtual.StatBonus.MovSpeed;
                if (c.isLocked == false)
                {
                    //Mover player
                    TargetTile = c;
                }
                moved = true;
            }
            //Turno de ataque
            else if (phase == Phase.ATAQUE)
            {
                if (c.isLocked == false)
                {
                    if (c.isMonster)
                    {
                        if (Statics.Player.ItemAtual.Nome == "Luva do Thanos")
                        {
                            double actualHalf = NumMonters / 2;
                            int half = Convert.ToInt32(Math.Round(actualHalf));
                            for (int i = 0; i < half; i++)
                            {
                                monsters.RemoveAt(0);
                                NumMonters--;
                            }
                        }
                        else
                        {
                            foreach (var M in monsters)
                            {
                                if (c.x == M.X && c.y == M.Y)
                                {
                                    MatrizTiles[M.X, M.Y].Vida = M.Hp.ToString();

                                    Statics.Player.ItemAtual.Durability--;
                                    if (Statics.Player.ItemAtual.Durability == 0)
                                        Statics.BreakWeapon();
                                    M.Hp -= Statics.Player.Atk + Statics.Player.ItemAtual.StatBonus.Atk;
                                    if (M.Hp <= 0)
                                    {
                                        score++;
                                        SpawnRandomMonster();
                                        if (score > 0 && score % 5 == 0)
                                        {
                                            SpawnRandomMonster();
                                            NumMonters++;
                                        }
                                        var actualLuck = Statics.Player.Luck + Statics.Player.ItemAtual.StatBonus.Luck;
                                        if (actualLuck >= r.Next(1, 101))
                                        {
                                            Statics.UpdatePlayer(Convert.ToInt32(Math.Round((Statics.Player.MaxHp + Statics.Player.ItemAtual.StatBonus.Hp) * 0.1)));
                                        }
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }

                if (speedLeft > 0)
                {
                    phase = Phase.RECUO;
                }
                else
                {
                    phase = Phase.ENEMYMOV;
                }

            }
            else if (phase == Phase.RECUO)
            {

                if (c.isLocked == false)
                {
                    //Mover player
                    TargetTile = c;
                }
                moved = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    var a = new CustomTile(i, j, false, TileSize, BorderStyle.Fixed3D, i * (TileSize + 1), j * (TileSize + 1), Statics.emptyTileColor);
                    a.Click += new EventHandler(TileClick);
                    MatrizTiles[i, j] = a;
                    Controls.Add(a);
                }
            }
            for (int i = 0; i < NumMonters; i++)
            {

                SpawnRandomMonster();
            }
        }

        public void CleanTilesMinusEntities()
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {

                    MatrizTiles[i, j].BackColor = Statics.emptyTileColor;
                    if (MatrizTiles[i, j].isPlayer)
                        MatrizTiles[i, j].BackColor = Statics.playerColor;
                    if (MatrizTiles[i, j].isMonster)
                    {
                        MatrizTiles[i, j].BackColor = Statics.enemyColor;
                    }
                    else
                    {
                        MatrizTiles[i, j].Vida = "";
                    }
                }
            }
        }

        public void SpawnRandomMonster()
        {
            bool free = false;
            int MonsX = 0, MonsY = 0; double MonsHp, monsAtk;
            MonsHp = Math.Ceiling(10.0 * (1 + (score / 10)));
            MonsHp = r.Next(Convert.ToInt32(MonsHp) - 5, Convert.ToInt32(MonsHp) + 6);
            monsAtk = Math.Ceiling(1.0 + (score / 10));
            while (!free)
            {
                MonsX = r.Next(0, colunas);
                MonsY = r.Next(0, linhas);
                if (!MatrizTiles[MonsX, MonsY].isMonster && !MatrizTiles[MonsX, MonsY].isPlayer)
                    free = true;
            }
            var monsterToAdd = new Monster(Convert.ToInt32(MonsHp), Convert.ToInt32(monsAtk), MonsX, MonsY);
            monsters.Add(monsterToAdd);
            MatrizTiles[monsterToAdd.X, monsterToAdd.Y].PutMonster(monsterToAdd.Hp);
            MatrizTiles[monsterToAdd.X, monsterToAdd.Y].isLocked = true;
        }

        public void ShowMovementOptions(CustomTile c, int distancia)
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {

                    if (Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < distancia + 1)
                    {

                        if (MatrizTiles[i, j].isPlayer)
                            MatrizTiles[i, j].BackColor = Statics.playerColor;
                        else if (MatrizTiles[i, j].isMonster)
                        {
                            MatrizTiles[i, j].BackColor = Statics.enemyColor;
                            MatrizTiles[i, j].isLocked = true;
                        }
                        else
                        {
                            MatrizTiles[i, j].BackColor = Statics.MovColor;
                            MatrizTiles[i, j].isLocked = false;
                        }
                    }
                    else
                    {
                        if (MatrizTiles[i, j].isMonster)
                            MatrizTiles[i, j].BackColor = Statics.enemyColor;
                        else
                        {
                            MatrizTiles[i, j].BackColor = Statics.emptyTileColor;
                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                }
            }
        }

        public void UpdateUI()
        {
            if (Statics.Player.ItemAtual == null)
            {
                Statics.GenerateModifiers();
            }
            if (Statics.Player.Hp <= (Statics.Player.MaxHp + Statics.Player.ItemAtual.StatBonus.Hp) * 0.25)
            {
                patricioPic.Image = Properties.Resources.Machucado;
                if (hpLabel.ForeColor == Color.DarkRed)
                    hpLabel.ForeColor = Color.Red;
                else
                    hpLabel.ForeColor = Color.DarkRed;
            }
            else
                patricioPic.Image = Properties.Resources.Patricio;

            turnLabel.Text = "Turno: " + turn;
            PointLabel.Text = "Pontos: " + score;

            hpLabel.Text = Statics.Player.Hp + "/" + (Statics.Player.MaxHp + Statics.Player.ItemAtual.StatBonus.Hp);
            AtkLabel.Text = (Statics.Player.Atk + Statics.Player.ItemAtual.StatBonus.Atk).ToString();
            DefLabel.Text = (Statics.Player.Def + Statics.Player.ItemAtual.StatBonus.Def).ToString();
            SpeedLabel.Text = speedLeft + "/" + (Statics.Player.Speed + Statics.Player.ItemAtual.StatBonus.MovSpeed);
            RangeLabel.Text = Statics.Player.ItemAtual.StatBonus.AtkRange.ToString();
            LuckLabel.Text = (Statics.Player.Luck + Statics.Player.ItemAtual.StatBonus.Luck) + "%";

            if (Statics.Player.ItemAtual.StatBonus.Hp != 0)
            {
                HpModLbl.Text = "+" + Statics.Player.ItemAtual.StatBonus.Hp;
                HpModLbl.Visible = true;
            }
            else
                HpModLbl.Visible = false;

            if (Statics.Player.ItemAtual.StatBonus.Atk != 0)
            {
                AtkModLbl.Text = "+" + Statics.Player.ItemAtual.StatBonus.Atk;
                AtkModLbl.Visible = true;
            }
            else
                AtkModLbl.Visible = false;

            if (Statics.Player.ItemAtual.StatBonus.Def != 0)
            {
                DefModLbl.Text = "+" + Statics.Player.ItemAtual.StatBonus.Def;
                DefModLbl.Visible = true;
            }
            else
                DefModLbl.Visible = false;

            if (Statics.Player.ItemAtual.StatBonus.MovSpeed != 0)
            {
                SpeedModLbl.Text = "+" + Statics.Player.ItemAtual.StatBonus.MovSpeed;
                SpeedModLbl.Visible = true;
            }
            else
                SpeedModLbl.Visible = false;

            if (Statics.Player.ItemAtual.StatBonus.Luck != 0)
            {
                LuckModLbl.Text = "+" + Statics.Player.ItemAtual.StatBonus.Luck;
                LuckModLbl.Visible = true;
            }
            else
                LuckModLbl.Visible = false;

            if (phase == Phase.ENEMYMOV || phase == Phase.ENEMYATK || phase == Phase.INICIO)
            {
                passTurn.Enabled = false;
                passTurn.Visible = false;
            }
            else
            {
                passTurn.Enabled = true;
                passTurn.Visible = true;
            }

            LblItemAtual.Text = Statics.Player.ItemAtual.Nome;
            LblDescAtual.Text = Statics.Player.ItemAtual.Description;

            if (Statics.Player.ItemAtual.URL == null)
            {
                ItemAtualPic.Image = Properties.Resources.Nadadeira;
            }
            else
            {

                LblDurabilty.Text = Statics.Player.ItemAtual.Durability.ToString();
                ItemAtualPic.ImageLocation = Statics.Player.ItemAtual.URL;
            }

            if (Statics.Player.PoolResult == null)
            {
                PoolItemPic.Image = Properties.Resources.suchEmpty;
                LblPoolItem.Text = "Ajuda a caminho!";
                lblPoolAtk.Visible = false; lblPoolDef.Visible = false; lblPoolHp.Visible = false;
                lblPoolLuck.Visible = false; lblPoolRange.Visible = false; lblPoolSpeed.Visible = false;
                poolAtk.Visible = false; poolDef.Visible = false; poolHp.Visible = false;
                poolLuck.Visible = false; poolRange.Visible = false; poolSpeed.Visible = false;
            }
            else
            {
                try
                {
                    PoolItemPic.ImageLocation = Statics.Player.PoolResult.URL;
                    LblPoolItem.Text = Statics.Player.PoolResult.Nome;
                    lblPoolAtk.Visible = true; lblPoolDef.Visible = true; lblPoolHp.Visible = true;
                    lblPoolLuck.Visible = true; lblPoolRange.Visible = true; lblPoolSpeed.Visible = true;
                    lblPoolAtk.Text = Statics.Player.PoolResult.StatBonus.Atk.ToString();
                    lblPoolDef.Text = Statics.Player.PoolResult.StatBonus.Def.ToString();
                    lblPoolHp.Text = Statics.Player.PoolResult.StatBonus.Hp.ToString();
                    lblPoolLuck.Text = Statics.Player.PoolResult.StatBonus.Luck.ToString();
                    lblPoolRange.Text = Statics.Player.PoolResult.StatBonus.AtkRange.ToString();
                    lblPoolSpeed.Text = Statics.Player.PoolResult.StatBonus.MovSpeed.ToString();
                    poolAtk.Visible = true; poolDef.Visible = true; poolHp.Visible = true;
                    poolLuck.Visible = true; poolRange.Visible = true; poolSpeed.Visible = true;
                }
                catch
                {
                    throw;
                }
            }
        }

        private async void timer1_TickAsync(object sender, EventArgs e)
        {
            range = Statics.Player.ItemAtual.StatBonus.AtkRange;
            switch (phase)
            {
                case (Phase.INICIO):
                    CleanTilesMinusEntities();
                    break;
                case (Phase.MOVIMENTACAO):
                    if (moved)
                    {
                        deltaX = Statics.Player.X - TargetTile.x;
                        deltaY = Statics.Player.Y - TargetTile.y;
                        if (!(deltaX == 0 && deltaY == 0))
                        {
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].isPlayer = false;
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].BackColor = Statics.MovColor;
                            if (deltaX < 0)
                            {
                                Statics.Player.X++;
                            }
                            else if (deltaX > 0)
                            {
                                Statics.Player.X--;
                            }
                            else if (deltaY < 0)
                            {
                                Statics.Player.Y++;
                            }
                            else if (deltaY > 0)
                            {
                                Statics.Player.Y--;
                            }
                            speedLeft--;
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].PutPlayer();
                        }
                        else
                        {
                            moved = false;
                            phase = Phase.ATAQUE;
                        }
                    }
                    else
                        ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], Statics.Player.Speed + Statics.Player.ItemAtual.StatBonus.MovSpeed);
                    break;
                case (Phase.ATAQUE):
                    for (int i = 0; i < Colunas; i++)
                {
                    for (int j = 0; j < Linhas; j++)
                    {

                        if (Math.Abs(Statics.Player.X - MatrizTiles[i, j].x) + Math.Abs(Statics.Player.Y - MatrizTiles[i, j].y) < Statics.Player.ItemAtual.StatBonus.AtkRange + 1)
                        {

                            if (MatrizTiles[i, j].isPlayer)
                                MatrizTiles[i, j].BackColor = Statics.playerColor;
                            else if (MatrizTiles[i, j].isMonster)
                            {
                                MatrizTiles[i, j].BackColor = Statics.enemyColor;
                                MatrizTiles[i, j].isLocked = false;
                            }
                            else
                            {
                                MatrizTiles[i, j].BackColor = Statics.AtkRangeColor;
                                MatrizTiles[i, j].isLocked = false;
                            }
                        }
                        else
                        {
                            if (MatrizTiles[i, j].isMonster)
                                MatrizTiles[i, j].BackColor = Statics.enemyColor;
                            else
                            {
                                MatrizTiles[i, j].BackColor = Statics.emptyTileColor;
                                MatrizTiles[i, j].isLocked = true;
                            }
                        }
                    }
                }
                    break;
                case (Phase.RECUO):
                    if (moved)
                    {
                        deltaX = Statics.Player.X - TargetTile.x;
                        deltaY = Statics.Player.Y - TargetTile.y;
                        if (!(deltaX == 0 && deltaY == 0))
                        {
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].isPlayer = false;
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].BackColor = Statics.MovColor;
                            if (deltaX < 0)
                            {
                                Statics.Player.X++;
                            }
                            else if (deltaX > 0)
                            {
                                Statics.Player.X--;
                            }
                            else if (deltaY < 0)
                            {
                                Statics.Player.Y++;
                            }
                            else if (deltaY > 0)
                            {
                                Statics.Player.Y--;
                            }
                            MatrizTiles[Statics.Player.X, Statics.Player.Y].PutPlayer();
                        }
                        else
                        {
                            moved = false;
                            speedLeft = Statics.Player.Speed + Statics.Player.ItemAtual.StatBonus.MovSpeed;
                            phase = Phase.ENEMYMOV;
                        }
                    }
                    else
                        ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], speedLeft);
                    break;
                case (Phase.ENEMYMOV):
                    BackColor = Color.FromArgb(70, 44, 99);
                    if (monstercounter < NumMonters)
                    {
                        //Mover monster
                        tries = 0;
                        deltaX = monsters[monstercounter].X - Statics.Player.X;
                        deltaY = monsters[monstercounter].Y - Statics.Player.Y;
                        timer1.Start();
                        if (passosdados < monsterMov)
                        {

                            MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y].isMonster = false;
                            if (!(((deltaX == -1 || deltaX == 1) && deltaY == 0) || ((deltaY == -1 || deltaY == 1) && deltaX == 0)))
                            {
                                Random r = new Random();
                                if (deltaX == 0)
                                {
                                    if (deltaY < 0)
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y + 1].isMonster)
                                        {
                                            monsters[monstercounter].Y++;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                    else
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y - 1].isMonster)
                                        {
                                            monsters[monstercounter].Y--;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                }
                                else if (deltaY == 0)
                                {
                                    if (deltaX < 0)
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X + 1, monsters[monstercounter].Y].isMonster)
                                        {
                                            monsters[monstercounter].X++;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                    else
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X - 1, monsters[monstercounter].Y].isMonster)
                                        {
                                            monsters[monstercounter].X--;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                }
                                else if (r.Next(1, 3) == 1)
                                {
                                    if (deltaY < 0)
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y + 1].isMonster)
                                        {
                                            monsters[monstercounter].Y++;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                    else
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y - 1].isMonster)
                                        {
                                            monsters[monstercounter].Y--;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }

                                }
                                else
                                {
                                    if (deltaX < 0)
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X + 1, monsters[monstercounter].Y].isMonster)
                                        {
                                            monsters[monstercounter].X++;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                    else
                                    {
                                        if (!MatrizTiles[monsters[monstercounter].X - 1, monsters[monstercounter].Y].isMonster)
                                        {
                                            monsters[monstercounter].X--;
                                        }
                                        else
                                        {
                                            tries++;
                                        }
                                    }
                                }
                                deltaX = monsters[monstercounter].X - Statics.Player.X;
                                deltaY = monsters[monstercounter].Y - Statics.Player.Y;
                            }
                            MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y].PutMonster(monsters[monstercounter].Hp);
                            CleanTilesMinusEntities();
                            passosdados++;
                        }
                        else
                        {
                            passosdados = 0;
                            monstercounter++;
                        }
                    }
                    else
                    {
                        monstercounter = 0;
                        BackColor = Color.AliceBlue;
                        phase = Phase.ENEMYATK;
                    }
                    break;
                case (Phase.ENEMYATK):
                    if (monstercounter < NumMonters)
                    {
                        deltaX = monsters[monstercounter].X - Statics.Player.X;
                        deltaY = monsters[monstercounter].Y - Statics.Player.Y;
                        //Ataque monster
                        if (((deltaX == -1 || deltaX == 1) && deltaY == 0) || ((deltaY == -1 || deltaY == 1) && deltaX == 0))
                        {
                            Statics.UpdatePlayer(monsters[monstercounter].Attack(Statics.Player));
                            hpLabel.ForeColor = Color.DarkRed;
                            hpLabel.Font = new Font("Arial", 24, FontStyle.Bold);
                            ShakeScreen();
                        }
                        monstercounter++;
                    }
                    else
                    {
                        hpLabel.ForeColor = Color.Black;
                        hpLabel.Font = new Font("Arial", 16, FontStyle.Regular);
                        monstercounter = 0;
                        phase = Phase.MOVIMENTACAO;
                        turn++;
                        if(Statics.Player.ItemAtual.Nome == "A foice e o martelo")
                        {
                            foreach(var m in monsters)
                            {
                                m.Hp--;
                            }
                        }
                    }
                    break;
            }
            UpdateUI();
            foreach (var m in monsters)
            {
                if (m.Hp <= 0)
                {
                    MatrizTiles[m.X, m.Y].isMonster = false;
                    MatrizTiles[m.X, m.Y].BackColor = Color.White;
                    MatrizTiles[m.X, m.Y].Vida = "";
                    monsters.Remove(m);
                    break;
                }
                else
                {
                    MatrizTiles[m.X, m.Y].PutMonster(m.Hp);
                }
            }
            if (Statics.Player.Hp <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Game over");
                Statics.Player.IsPlaying = false;
                await Statics.UpdateGame();
                this.Hide();
                Statics.MenuScreen.Show();
            }
        }

        public void ShakeScreen()
        {
            int xCoord = this.Left;
            int yCoord = this.Top;
            int rnd = 0;

            Random RandomClass = new Random();


            for (int i = 0; i <= 100; i++)
            {
                rnd = RandomClass.Next(xCoord - 15, xCoord + 15);
                this.Left = rnd;
                rnd = RandomClass.Next(yCoord - 15, yCoord + 15);
                this.Top = rnd;
            }

            this.Left = xCoord;
            this.Top = yCoord;
        }

        private async void close_Click(object sender, EventArgs e)
        {
            Statics.Player.IsPlaying = false;
            await Statics.UpdateGame();
            this.Hide();
            Statics.MenuScreen.Show();

        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private async void UpdatePlayer_Tick(object sender, EventArgs e)
        {
            if (Statics.ServerPlayer != null)
            {
                //Debug.WriteLine(Statics.ServerPlayer.R);
                if (Statics.ServerPlayer.R == 1)
                {
                    Statics.UpdatePlayer();
                    UpdateUI();
                    await Statics.UpdateGame();
                }
                else
                {
                    await Statics.UpdateGame();
                }


            }
        }

        private void GameScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.MenuScreen.Close();
            Application.Exit();

        }

        private void passTurn_Click(object sender, EventArgs e)
        {
            phase = Phase.ENEMYMOV;
        }

        private async void PoolItemPic_Click(object sender, EventArgs e)
        {
            if (Statics.Player.PoolResult != null)
            {
                Statics.UpdatePlayer(true);
                await Statics.UpdateGame();
                UpdateUI();
                //Statics.UpdatePlayer(Statics.Player.PoolResult.StatBonus.Hp);
            }
        }

        private async void ItemAtualPic_Click(object sender, EventArgs e)
        {
            if (Statics.Player.PoolResult != null)
            {
                Statics.UpdatePlayer(false);
                await Statics.UpdateGame();
                UpdateUI();
            }
        }
    }
}
