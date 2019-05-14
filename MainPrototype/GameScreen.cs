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

namespace MainPrototype
{
    
    public partial class GameScreen : Form
    {
        int speed = 5;
        private int linhas = 17;
        private int colunas = 24;

        public int Colunas { get => colunas; set => colunas = value; }
        public int Linhas { get => linhas; set => linhas = value; }

        CustomTile[,] MatrizTiles;

        public GameScreen()
        {
            InitializeComponent();
            MatrizTiles = new CustomTile[Colunas, Linhas];
        }

        public void TileClick(Object sender, EventArgs e)
        {
            CustomTile c = sender as CustomTile;
            //MessageBox.Show("" + c.x + "  "+c.y);
            
            if (c.isPlayer) {
                for (int i = 0; i < Colunas; i++)
                {
                    for (int j = 0; j < Linhas; j++)
                    {

                        if (Math.Abs(MatrizTiles[i, j].x - c.x) + Math.Abs(MatrizTiles[i, j].y - c.y) < speed && Math.Abs(c.x - MatrizTiles[i, j].x) + Math.Abs(c.y - MatrizTiles[i, j].y) < speed)
                        {

                            MatrizTiles[i, j].BackColor = Color.Chocolate;
                            if(MatrizTiles[i,j].isPlayer)
                                MatrizTiles[i, j].BackColor = Color.Red;
                        }

                    }
                }
            }
            else
            {
                CleanTilesMinusPlayer();
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int PlayerX = r.Next(0, Colunas);
            r = new Random();
            int PlayerY = r.Next(0, Linhas);
            for (int i =0; i<Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    
                    var a = new CustomTile(i, j, false, false, 32, BorderStyle.Fixed3D, i*33, j*33, Color.CadetBlue);
                    if (a.x == PlayerX && a.y == PlayerY)
                        a.PutPlayer();
                    a.Click += new EventHandler(TileClick);
                    MatrizTiles[i, j] = a;
                    Controls.Add(a);
                }
            }       
        }

        public void CleanTiles()
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    
                    MatrizTiles[i, j].BackColor = Color.CadetBlue;
                   
                }
            }
        }
        public void CleanTilesMinusPlayer()
        {
            for (int i = 0; i < Colunas; i++)
            {
                for (int j = 0; j < Linhas; j++)
                {
                    
                    MatrizTiles[i, j].BackColor = Color.CadetBlue;
                    if (MatrizTiles[i, j].isPlayer)
                        MatrizTiles[i, j].BackColor = Color.Red;
                }
            }
        }
    }
}
