using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainPrototype
{
    public partial class Tutorial : Form
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

        public Image[] tutorials;
        int count;

        public Tutorial()
        {
            InitializeComponent();
            tutorials = new Image[10];
            count = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (count == 0)
            {
                Statics.MenuScreen.Show();
                this.Hide();
                
            }
            else
            {
                count--;
                BackgroundImage = tutorials[count];
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {           
            if (count == 9)
            {
                this.Hide();
                new GameScreen().Show();
            }
            else
            {
                count++;
                BackgroundImage = tutorials[count];
            }
        }

        private void Tutorial_FormClosing(object sender, FormClosingEventArgs e)
        {
            Statics.MenuScreen.Close();
            Application.Exit();

        }

        private void Tutorial_Load(object sender, EventArgs e)
        {
            tutorials[0] = Properties.Resources._1_Intro;
            tutorials[1] = Properties.Resources._2_Sobre;
            tutorials[2] = Properties.Resources._3_Move;
            tutorials[3] = Properties.Resources._4_Atk;
            tutorials[4] = Properties.Resources._5_MoveAgain;
            tutorials[5] = Properties.Resources._6_Inimigos;
            tutorials[6] = Properties.Resources._7_Ajudantes;
            tutorials[7] = Properties.Resources._8_Itens;
            tutorials[8] = Properties.Resources._9_Amigos;
            tutorials[9] = Properties.Resources._10_TheEnd;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            new GameScreen().Show();
        }
    }
}
