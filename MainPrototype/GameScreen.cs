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
using System.Threading;
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
            ENEMY
        }

        Phase phase;
        int speed = 5;
        int speedLeft;
        int range = 3;
        int NumMonters = 6;
        int monsterMov = 4;
        int count = 0;
        public int TileSize { get; private set; } = 32;
        private int linhas = 17;
        private int colunas = 24;

        public int Colunas { get => colunas; set => colunas = value; }
        public int Linhas { get => linhas; set => linhas = value; }
        public int atualFrame { get; private set; }

        CustomTile[,] MatrizTiles;
        List<Monster> monsters;
        private bool locker;
        private int tries;
        private int deltaX;
        private int deltaY;

        public GameScreen()
        {
            InitializeComponent();
            Statics.CreateNewPlayer();
            MatrizTiles = new CustomTile[Colunas, Linhas];
            monsters = new List<Monster>();
            phase = Phase.INICIO;

            timer1.Interval = 33;
            timer1.Start();
        }

        public void TileClick(Object sender, EventArgs e)
        {
            if (locker)
            {
                return;
            }
            CustomTile c = sender as CustomTile;
            if (phase == Phase.INICIO && !c.isLocked)
            {
                c.PutPlayer();
                Statics.UpdatePlayer(c.x, c.y);
                phase = Phase.MOVIMENTACAO;
            }
            //Turno de movimento
            else if (phase == Phase.MOVIMENTACAO)
            {
                speedLeft = speed;
                if (c.isPlayer)
                {
                    phase = Phase.ATAQUE;
                }
                else if (c.isLocked == false)
                {
                    //Mover player
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {
                            MatrizTiles[i, j].isPlayer = false;
                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                    speedLeft = speed - (Math.Abs(Statics.Player.X - c.x) + Math.Abs(Statics.Player.Y - c.y));
                    c.PutPlayer();
                    Statics.UpdatePlayer(c.x, c.y);
                    phase = Phase.ATAQUE;                   
                }
                
            }
            //Turno de ataque
            else if (phase == Phase.ATAQUE)
            {
                if (c.isLocked == false)
                {
                    if (c.isMonster)
                    {
                        foreach (var m in monsters)
                        {
                            if (c.x == m.X && c.y == m.Y)
                            {

                                m.Hp -= Statics.Player.Atk;
                                if (m.Hp <= 0)
                                {
                                    monsters.Remove(m);
                                    c.BackColor = Color.CadetBlue;
                                    c.isMonster = false;
                                    count++;
                                    NumMonters--;
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
                    phase = Phase.ENEMY;
                }

                //for (int i = 0; i < Colunas; i++)
                //{
                //    for (int j = 0; j < Linhas; j++)
                //    {

                //        MatrizTiles[i, j].isLocked = true;
                //    }
                //}
                //choosingMov = false;

                //Enemy Turn - Movement
                //for (int i = 0; i < Colunas; i++)
                //{
                //    for (int j = 0; j < Linhas; j++)
                //    {
                //        MatrizTiles[i, j].isMonster = false;
                //        MatrizTiles[i, j].isLocked = true;
                //    }
                //}

            }
            else if (phase == Phase.RECUO)
            {
                CleanTilesMinusEntities();
                if (c.isLocked == false)
                {
                    //Mover player
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {
                            MatrizTiles[i, j].isPlayer = false;
                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                    c.PutPlayer();
                    Statics.UpdatePlayer(c.x, c.y);
                }
                else
                {
                    //for (int i = 0; i < Colunas; i++)
                    //{
                    //    for (int j = 0; j < Linhas; j++)
                    //    {

                    //        MatrizTiles[i, j].isLocked = true;
                    //    }
                    //}
                }
                phase = Phase.ENEMY;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int MonsX, MonsY; double MonsHp = 10;
            for (int i = 0; i < NumMonters; i++)
            {
                MonsHp = Math.Ceiling(MonsHp * (1 + (count / 10)));
                MonsHp = r.Next(Convert.ToInt32(MonsHp) - 5, Convert.ToInt32(MonsHp) + 6);
                MonsX = r.Next(0, colunas);
                MonsY = r.Next(0, linhas);
                var m = new Monster(Convert.ToInt32(MonsHp), MonsX, MonsY);
                //monsters[i] = m;
                monsters.Add(m);
            }
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    var a = new CustomTile(i, j, false, TileSize, BorderStyle.Fixed3D, i * (TileSize + 1), j * (TileSize + 1), Color.CadetBlue);
                    for (int k = 0; k < NumMonters; k++)
                    {
                        if (a.x == monsters[k].X && a.y == monsters[k].Y)
                            a.PutMonster();

                    }
                    a.Click += new EventHandler(TileClick);
                    MatrizTiles[i, j] = a;
                    Controls.Add(a);
                }
            }
        }


        //public void CleanAllTiles()
        //{
        //    for (int i = 0; i < Colunas; i++)
        //    {
        //        for (int j = 0; j < Linhas; j++)
        //        {

        //            MatrizTiles[i, j].BackColor = Color.CadetBlue;

        //        }
        //    }
        //}
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


        public void ShowMovementOptions(CustomTile c, int distancia)
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {

                    if (Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < distancia)
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
            if(phase == Phase.INICIO)
            {
                CleanTilesMinusEntities();
            }else if(phase == Phase.MOVIMENTACAO)
            {
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
                        // choosingAtk = true;
                    }
                }
            }
            else if(phase == Phase.RECUO)
            {
                ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], speedLeft);
            }else if(phase == Phase.ENEMY)
            {
                BackColor = Color.MediumVioletRed;
                for (int m = 0; m < NumMonters; m++)
                {

                    //Mover monster
                    tries = 0;
                    deltaX = monsters[m].X - Statics.Player.X;
                    deltaY = monsters[m].Y - Statics.Player.Y;
                    tries = 0;
                    timer1.Start();
                    for (int i = 0; i < monsterMov; i++)
                    {
                        
                        MatrizTiles[monsters[m].X, monsters[m].Y].isMonster = false;
                        if (!(((deltaX == -1 || deltaX == 1) && deltaY == 0) || ((deltaY == -1 || deltaY == 1) && deltaX == 0)))
                        {
                            Random r = new Random();
                            if (deltaX == 0)
                            {
                                if (deltaY < 0)
                                {
                                    if (!MatrizTiles[monsters[m].X, monsters[m].Y + 1].isMonster)
                                    {
                                        monsters[m].Y++;
                                    }
                                    else
                                    {
                                        tries++;
                                    }
                                }
                                else
                                {
                                    if (!MatrizTiles[monsters[m].X, monsters[m].Y - 1].isMonster)
                                    {
                                        monsters[m].Y--;
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
                                    if (!MatrizTiles[monsters[m].X + 1, monsters[m].Y].isMonster)
                                    {
                                        monsters[m].X++;
                                    }
                                    else
                                    {
                                        tries++;
                                    }
                                }
                                else
                                {
                                    if (!MatrizTiles[monsters[m].X - 1, monsters[m].Y].isMonster)
                                    {
                                        monsters[m].X--;
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
                                    if (!MatrizTiles[monsters[m].X, monsters[m].Y + 1].isMonster)
                                    {
                                        monsters[m].Y++;
                                    }
                                    else
                                    {
                                        tries++;
                                    }
                                }
                                else
                                {
                                    if (!MatrizTiles[monsters[m].X, monsters[m].Y - 1].isMonster)
                                    {
                                        monsters[m].Y--;
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
                                    if (!MatrizTiles[monsters[m].X + 1, monsters[m].Y].isMonster)
                                    {
                                        monsters[m].X++;
                                    }
                                    else
                                    {
                                        tries++;
                                    }
                                }
                                else
                                {
                                    if (!MatrizTiles[monsters[m].X - 1, monsters[m].Y].isMonster)
                                    {
                                        monsters[m].X--;
                                    }
                                    else
                                    {
                                        tries++;
                                    }
                                }
                            }
                            deltaX = monsters[m].X - Statics.Player.X;
                            deltaY = monsters[m].Y - Statics.Player.Y;
                        }
                        MatrizTiles[monsters[m].X, monsters[m].Y].PutMonster();
                        CleanTilesMinusEntities();

                    }



                    deltaX = monsters[m].X - Statics.Player.X;
                    deltaY = monsters[m].Y - Statics.Player.Y;
                    //Ataque monster
                    if (((deltaX == -1 || deltaX == 1) && deltaY == 0) || ((deltaY == -1 || deltaY == 1) && deltaX == 0))
                    {
                        Statics.UpdatePlayer(monsters[m].Attack(Statics.Player));
                        MessageBox.Show(Statics.Player.Hp + "");
                    }
                }
                BackColor = Color.AliceBlue;
                phase = Phase.MOVIMENTACAO;
            }

        }
    }
}
