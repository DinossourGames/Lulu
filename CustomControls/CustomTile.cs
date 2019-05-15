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
        [Browsable(true)]
        [Category("CustomProps")]
        public int x { get; set; }

        [Browsable(true)]
        [Category("CustomProps")]
        public int y { get; set; }

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
            this.Height = size;
            this.Width = size;
            this.BackColor = back;
            this.Location = new Point(coordenadaX, coordenadaY);
            
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

        public void PutMonster()
        {
            isMonster = true;
            this.BackColor = Color.DarkCyan;
            isLocked = true;
        }
    }
}
