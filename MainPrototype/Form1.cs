using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPrototype
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
          
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Statics.t = new Thread(() =>
            {
                //Thread.Sleep(5000);
                //Thread.Sleep(1000);
                //Invoke((MethodInvoker)delegate
                //{
                //    Statics.BgScreen.pbBG.Image = Properties.Resources.lastOne ;
                //});
                //Thread.Sleep(3000);
                //Invoke((MethodInvoker)delegate
                //{
                //    Statics.BgScreen.pbBG.Image = null;
                //});
                Application.Run(Statics.MenuScreen);
        });
            Statics.t.Start();
        }
    }
}
