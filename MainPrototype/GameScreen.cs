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
namespace MainPrototype
{



    public partial class GameScreen : Form
    {
        public enum Phase {
            INICIO,
            MOVIMENTACAO,
            ATAQUE,
            RECUO 
        }

        Phase phase;
        //bool phase = true; //true = Movimentação, false=ataque
        bool choosingMov = false;
       // bool choosingAtk = false;
        int speed = 5;
        int speedLeft;
        int range = 3;
        int NumMonters = 6;
        int monsterMov = 4;
        public int TileSize { get; private set; } = 32;
        private int linhas = 17;
        private int colunas = 24;

        public int Colunas { get => colunas; set => colunas = value; }
        public int Linhas { get => linhas; set => linhas = value; }

        CustomTile[,] MatrizTiles;
        Monster[] monsters;
        
        public GameScreen()
        {
            InitializeComponent();
            Statics.CreateNewPlayer();
            MatrizTiles = new CustomTile[Colunas, Linhas];
            monsters = new Monster[NumMonters];
            phase = Phase.INICIO;
        }

        public void TileClick(Object sender, EventArgs e)
        {
            
            CustomTile c = sender as CustomTile;
            if (phase == Phase.INICIO && !c.isLocked)
            {
                c.PutPlayer();
                phase = Phase.MOVIMENTACAO;
            }
            //Turno de movimento
            else if (phase == Phase.MOVIMENTACAO)
            {
                speedLeft = speed;
                if (c.isPlayer)
                {
                    if (choosingMov)
                    {
                        //Fechar opções de movimento
                        CleanTilesMinusEntities();
                        choosingMov = false;
                        
                        for (int i = 0; i < Colunas; i++)
                        {
                            for (int j = 0; j < Linhas; j++)
                            {

                                if (Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < speed && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < range)
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
                        phase = Phase.ATAQUE;
                    }
                    else
                    {
                        //Mostrar opções de movimento
                        ShowMovementOptions(c, speed);
                        choosingMov = true;
                    }

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
                    CleanTilesMinusEntities();
                    c.PutPlayer();
                    Statics.UpdatePlayer(c.x, c.y);
                    choosingMov = false;
                    phase = Phase.ATAQUE;
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {

                            if (Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < speed && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < range)
                            {

                                if (MatrizTiles[i, j].isPlayer)
                                {
                                    MatrizTiles[i, j].BackColor = Color.Red;
                                    MatrizTiles[i, j].isLocked = true;
                                }
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
                                }
                                MatrizTiles[i, j].isLocked = true;
                            }
                           // choosingAtk = true;
                        }
                    }
                }
                else
                {
                    CleanTilesMinusEntities();
                    //phase = true;
                    choosingMov = false;
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {

                            MatrizTiles[i, j].isLocked = true;
                        }
                    }

                }
            }
            //Turno de ataque
            else if(phase == Phase.ATAQUE)
            {
                
                CleanTilesMinusEntities();
                if (c.isPlayer)
                {
                   
                    
                }
                else
                if (c.isLocked == false)
                {
                    
                    if (c.isMonster)
                    {
                        for(int i=0; i < NumMonters; i++)
                        {
                            if(c.x == monsters[i].X && c.y == monsters[i].Y)
                            {
                                monsters[i].Hp -= Statics.Player.Atk;
                                if (monsters[i].Hp <= 0) {
                                    c.BackColor = Color.CadetBlue;
                                    c.isMonster = false;
                                }
                                
                            }
                        }
                    }

                }

                if (speedLeft > 0)
                {
                    ShowMovementOptions(MatrizTiles[Statics.Player.X, Statics.Player.Y], speedLeft);
                    phase = Phase.RECUO;
                }
                else
                {
                    phase = Phase.MOVIMENTACAO;
                    EnemyTurn();
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
            else if(phase == Phase.RECUO)
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
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {

                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                }
                phase = Phase.MOVIMENTACAO;
                EnemyTurn();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int MonsX, MonsY;
            for(int i=0; i<NumMonters; i++)
            {
                MonsX = r.Next(0,colunas);
                MonsY = r.Next(0, linhas);
                var m = new Monster(MonsX, MonsY);
                monsters[i] = m;
            }
            for (int i =0; i<Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    var a = new CustomTile(i, j, false, TileSize, BorderStyle.Fixed3D, i*(TileSize+1), j*(TileSize+1), Color.CadetBlue);
                    for (int k = 0; k<NumMonters; k++)
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

        public void EnemyTurn()
        {
            for (int m = 0; m < NumMonters; m++)
            {
                int tries = 0;
                //Mover monster
                CleanTilesMinusEntities();
                //Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < speed && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < range
                int deltaX = monsters[m].X - Statics.Player.X;
                int deltaY = monsters[m].Y - Statics.Player.Y;
                MatrizTiles[monsters[m].X, monsters[m].Y].isMonster = false;
                tries = 0;
                for (int i = 0; i < monsterMov; i++)
                {
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


                }
                MatrizTiles[monsters[m].X, monsters[m].Y].PutMonster();

            }
        }

        public void ShowMovementOptions(CustomTile c, int distancia)
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {

                    if (Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < distancia && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < distancia)
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
    }
}
