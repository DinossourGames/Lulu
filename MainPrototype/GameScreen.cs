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
        bool phase = true; //true = Movimentação, false=ataque
        bool choosingMov = false;
       // bool choosingAtk = false;
        int speed = 5;
        int range = 3;
        int NumMonters = 6;
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
        }

        public void TileClick(Object sender, EventArgs e)
        {
            CustomTile c = sender as CustomTile;
            //Turno de movimento
            if (phase)
            {
                if (c.isPlayer)
                {
                    if (choosingMov)
                    {
                        //Fechar opções de movimento
                        CleanTilesMinusPlayer();
                        choosingMov = false;
                    }
                    else
                    {
                        //Mostrar opções de movimento
                        for (int i = 0; i < Colunas; i++)
                        {
                            for (int j = 0; j < Linhas; j++)
                            {

                                if (Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < speed && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < speed)
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
                                choosingMov = true;
                            }
                        }
                    }

                }
                else if (c.isLocked == false)
                {
                    //Mover plyer
                    for (int i = 0; i < Colunas; i++)
                    {
                        for (int j = 0; j < Linhas; j++)
                        {
                            MatrizTiles[i, j].isPlayer = false;
                            MatrizTiles[i, j].isLocked = true;
                        }
                    }
                    CleanTilesMinusPlayer();
                    c.PutPlayer();
                    Statics.UpdatePlayer(c.x, c.y);
                    choosingMov = false;
                    phase = false;
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
                }
                else
                {
                    CleanTilesMinusPlayer();
                    phase = true;
                    //choosingMov = false;
                    
                }
            }
            //Turno de ataque
            else
            {
                
                CleanTilesMinusPlayer();
                //if (c.isPlayer)
                //{
                //   // choosingAtk = false;
                //    phase = true;

                //}
                //else 
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
                phase = true;
                for (int i = 0; i < Colunas; i++)
                {
                    for (int j = 0; j < Linhas; j++)
                    {

                        MatrizTiles[i, j].isLocked = true;
                    }
                }
                //choosingMov = false;

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
        public void CleanTilesMinusPlayer()
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
    }
}
