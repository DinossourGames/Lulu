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
namespace MainPrototype
{



    public partial class GameScreen : Form
    {
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
        int NumMonters = 6;
        int monsterMov = 4;
        int score = 0;
        public int TileSize { get; private set; } = 32;
        private int linhas = 17;
        private int colunas = 24;

        public int Colunas { get => colunas; set => colunas = value; }
        public int Linhas { get => linhas; set => linhas = value; }
        public int passosdados { get; private set; } = 0;
        public int monstercounter { get; private set; } = 0;
        public CustomTile TargetTile;

        CustomTile[,] MatrizTiles;
        List<Monster> monsters;
        Point initialPosition;

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
            phase = Phase.INICIO;
            initialPosition = this.Location;

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
            }
            //Turno de movimento
            else if (phase == Phase.MOVIMENTACAO)
            {
                speedLeft = Statics.Player.Speed;
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
                        foreach (var M in monsters)
                        {
                            if (c.x == M.X && c.y == M.Y)
                            {

                                M.Hp -= Statics.Player.Atk;
                                if (M.Hp <= 0)
                                {                                   
                                    score++;
                                    SpawnRandomMonster();
                                    if(score > 0 && score%5 == 0)
                                    {
                                        SpawnRandomMonster();
                                        NumMonters++;
                                    }
                                    break;
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
                    var a = new CustomTile(i, j, false, TileSize, BorderStyle.Fixed3D, i * (TileSize + 1), j * (TileSize + 1), Color.CadetBlue);                   
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

                    MatrizTiles[i, j].BackColor = Color.CadetBlue;
                    if (MatrizTiles[i, j].isPlayer)
                        MatrizTiles[i, j].BackColor = Color.Red;
                    if (MatrizTiles[i, j].isMonster)
                        MatrizTiles[i, j].BackColor = Color.DarkCyan;
                }
            }
        }

        public void SpawnRandomMonster()
        {
            bool free = false;
            int MonsX= 0, MonsY =0; double MonsHp;
            MonsHp = Math.Ceiling(10.0 * (1 + (score / 10)));
            MonsHp = r.Next(Convert.ToInt32(MonsHp) - 5, Convert.ToInt32(MonsHp) + 6);
            while (!free)
            {
                MonsX = r.Next(0, colunas);
                MonsY = r.Next(0, linhas);
                if (!MatrizTiles[MonsX, MonsY].isMonster && !MatrizTiles[MonsX, MonsY].isPlayer)
                    free = true;
            }
            var monsterToAdd = new Monster(Convert.ToInt32(MonsHp), MonsX, MonsY);
            Debug.WriteLine($"Monster (hp):" + monsterToAdd.Hp);
            monsters.Add(monsterToAdd);
            MatrizTiles[monsterToAdd.X, monsterToAdd.Y].PutMonster();
        }

        public void ShowMovementOptions(CustomTile c, int distancia)
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {

                    if (Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < distancia+1)
                    {

                        if (MatrizTiles[i, j].isPlayer)
                            MatrizTiles[i, j].BackColor = Color.Red;
                        else if (MatrizTiles[i, j].isMonster)
                        {
                            MatrizTiles[i, j].BackColor = Color.DarkCyan;
                            MatrizTiles[i, j].isLocked = true;
                        }
                        else
                        {
                            MatrizTiles[i, j].BackColor = Color.Chocolate;
                            MatrizTiles[i, j].isLocked = false;
                        }
                    }
                    else
                    {
                        if (MatrizTiles[i, j].isMonster)
                            MatrizTiles[i, j].BackColor = Color.DarkCyan;
                        else
                        {
                            MatrizTiles[i, j].BackColor = Color.CadetBlue;
                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (phase == Phase.INICIO)
            {
                CleanTilesMinusEntities();
            } else if (phase == Phase.MOVIMENTACAO)
            {
                if (moved)
                {
                    deltaX = Statics.Player.X - TargetTile.x;
                    deltaY = Statics.Player.Y - TargetTile.y;
                    if (!(deltaX == 0 && deltaY == 0))
                    {
                        MatrizTiles[Statics.Player.X, Statics.Player.Y].isPlayer = false;
                        MatrizTiles[Statics.Player.X, Statics.Player.Y].BackColor = Color.Chocolate;
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
                    ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], Statics.Player.Speed);

                

            }else if(phase == Phase.ATAQUE)
            {
                for (int i = 0; i < Colunas; i++)
                {
                    for (int j = 0; j < Linhas; j++)
                    {

                        if ( Math.Abs(Statics.Player.X - MatrizTiles[i, j].x) + Math.Abs(Statics.Player.Y - MatrizTiles[i, j].y) < Statics.Player.Range)
                        {

                            if (MatrizTiles[i, j].isPlayer)
                                MatrizTiles[i, j].BackColor = Color.Red;
                            else if (MatrizTiles[i, j].isMonster)
                            {
                                MatrizTiles[i, j].BackColor = Color.DarkCyan;
                                MatrizTiles[i, j].isLocked = false;
                            }
                            else
                            {
                                MatrizTiles[i, j].BackColor = Color.Aqua;
                                MatrizTiles[i, j].isLocked = false;
                            }
                        }
                        else
                        {
                            if (MatrizTiles[i, j].isMonster)
                                MatrizTiles[i, j].BackColor = Color.DarkCyan;
                            else
                            {
                                MatrizTiles[i, j].BackColor = Color.CadetBlue;
                                MatrizTiles[i, j].isLocked = true;
                            }
                        }
                    }
                }
            }
            else if(phase == Phase.RECUO)
            {
                
                if (moved)
                {
                    deltaX = Statics.Player.X - TargetTile.x;
                    deltaY = Statics.Player.Y - TargetTile.y;
                    if (!(deltaX == 0 && deltaY == 0))
                    {
                        MatrizTiles[Statics.Player.X, Statics.Player.Y].isPlayer = false;
                        MatrizTiles[Statics.Player.X, Statics.Player.Y].BackColor = Color.Chocolate;
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
                        phase = Phase.ENEMYMOV;
                    }
                }
                else
                    ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], speedLeft);
            }else if(phase == Phase.ENEMYMOV)
            {
                BackColor = Color.Black;
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
                        MatrizTiles[monsters[monstercounter].X, monsters[monstercounter].Y].PutMonster();
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
            }
            else if(phase == Phase.ENEMYATK)
            {
                if (monstercounter < NumMonters)
                {
                    deltaX = monsters[monstercounter].X - Statics.Player.X;
                    deltaY = monsters[monstercounter].Y - Statics.Player.Y;
                    //Ataque monster
                    if (((deltaX == -1 || deltaX == 1) && deltaY == 0) || ((deltaY == -1 || deltaY == 1) && deltaX == 0))
                    {
                        Statics.UpdatePlayer(monsters[monstercounter].Attack(Statics.Player));
                        ShakeScreen();
                    }
                    monstercounter++;
                }
                else
                {
                    Debug.WriteLine(Statics.Player.Hp.ToString());
                    monstercounter = 0;
                    phase = Phase.MOVIMENTACAO;
                }
            }
            if(Statics.Player.Hp <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Game over");
                this.Close();
            }
            foreach(var m in monsters)
            {
                if (m.Hp <= 0)
                {
                    MatrizTiles[m.X, m.Y].isMonster = false;
                    MatrizTiles[m.X, m.Y].BackColor = Color.CadetBlue;
                    monsters.Remove(m);
                    break;
                }
                else
                {
                    MatrizTiles[m.X, m.Y].PutMonster();
                }
            }

            initialPosition = this.Location;
        }

        public void ShakeScreen()
        {
            int xCoord = this.Left;
            int yCoord = this.Top;
            int rnd = 0;
            
            Random RandomClass = new Random();


            for (int i = 0; i <= 100; i++)
            {
                rnd = RandomClass.Next(xCoord + 1, xCoord + 15);
                this.Left = rnd;
                rnd = RandomClass.Next(yCoord + 1, yCoord + 15);
                this.Top = rnd;
            }

            this.Left = xCoord;
            this.Top = yCoord;
        }

        //public void FocusHere(int x, int y)
        //{
        //    timer1.Stop();

        //    Point focus = new Point(x, y);

        //    int difX = this.Location.X - focus.X;
        //    int difY = this.Location.Y - focus.Y;

        //    while(difX != 0 || difY != 0)
        //    {
        //        if(difX != 0 && difY != 0)
        //        {
        //            if (difX < 0)
        //                this.Location = new Point(this.Location.X - 1, this.Location.Y);
        //            else
        //                this.Location = new Point(this.Location.X + 1, this.Location.Y);

        //            if (difY < 0)
        //                this.Location = new Point(this.Location.X, this.Location.Y - 1);
        //            else
        //                this.Location = new Point(this.Location.X, this.Location.Y + 1);

        //        }
        //        else if(difX != 0)
        //        {
        //            if (difX < 0)
        //                this.Location = new Point(this.Location.X - 1, this.Location.Y);
        //            else
        //                this.Location = new Point(this.Location.X + 1, this.Location.Y);
        //        }
        //        else if(difY != 0)
        //        {
        //            if (difY < 0)
        //                this.Location = new Point(this.Location.X, this.Location.Y - 1);
        //            else
        //                this.Location = new Point(this.Location.X, this.Location.Y + 1);
        //        }
        //        difX = this.Location.X - focus.X;
        //        difY = this.Location.Y - focus.Y;
        //    }


        //}

        //public void Unfocus()
        //{
        //    int difX = this.Location.X - initialPosition.X;
        //    int difY = this.Location.Y - initialPosition.Y;

        //    while (difX != 0 || difY != 0)
        //    {
        //        if (difX != 0 && difY != 0)
        //        {
        //            if (difX < 0)
        //                this.Location = new Point(this.Location.X - 1, this.Location.Y);
        //            else
        //                this.Location = new Point(this.Location.X + 1, this.Location.Y);

        //            if (difY < 0)
        //                this.Location = new Point(this.Location.X, this.Location.Y - 1);
        //            else
        //                this.Location = new Point(this.Location.X, this.Location.Y + 1);

        //        }
        //        else if (difX != 0)
        //        {
        //            if (difX < 0)
        //                this.Location = new Point(this.Location.X - 1, this.Location.Y);
        //            else
        //                this.Location = new Point(this.Location.X + 1, this.Location.Y);
        //        }
        //        else if (difY != 0)
        //        {
        //            if (difY < 0)
        //                this.Location = new Point(this.Location.X, this.Location.Y - 1);
        //            else
        //                this.Location = new Point(this.Location.X, this.Location.Y + 1);
        //        }
        //        difX = this.Location.X - initialPosition.X;
        //        difY = this.Location.Y - initialPosition.Y;
        //    }
        //    timer1.Start();
        //}
    }
}
