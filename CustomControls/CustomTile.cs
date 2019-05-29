using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class CustomTile : PictureBox
    {
        private string vida;

        public string Vida
        {
            get { return monsterHp.Text; }
            set { monsterHp.Text = value; }
        }


        [Browsable(true)]
        [Category("CustomProps")]
        public int x { get; private set; }

        [Browsable(true)]
        [Category("CustomProps")]
        public int y { get; private set; }

        [Browsable(true)]
        [Category("CustomProps")]
        public bool isLocked { get; set; }

        [Browsable(true)]
        [Category("CustomProps")]
        public bool isPlayer { get; set; } = false;

        [Browsable(true)]
        [Category("CustomProps")]
        public bool isMonster { get; set; } = false;
        public CustomTile()
        {
            
            InitializeComponent();
        }

        public CustomTile(int x, int y, bool isLocked, int size, BorderStyle b, int coordenadaX, int coordenadaY, Color back)
        {
            this.x = x;
            this.y = y;
            this.isLocked = isLocked;
            Height = size;
            Width = size;
            BackColor = back;
            Location = new Point(coordenadaX, coordenadaY);
            
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        public void PutPlayer()
        {
            isPlayer = true;
            this.BackColor = Color.Red;
        }

        public void PutMonster(int hp)
        {
            isMonster = true;
            vida = hp.ToString();
        }
    }
}
