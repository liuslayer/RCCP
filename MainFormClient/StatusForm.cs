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

namespace DeviceBaseData
{
    public partial class StatusForm : Form
    {
        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion

        public StatusForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void StatusForm_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        private delegate void ShowResultDelegate(string text);
        public void ShowResult(string text)
        {
            if (listBox1 != null)
            {
                //if (listBox1.InvokeRequired)
                //    listBox1.Invoke(new ShowResultDelegate(ShowResult), text);
                //else
                //    listBox1.Items.Add(text);
                Action action = delegate () { listBox1.Items.Add(text); };
                Invoke(action);
            }
        }

        private void StatusForm_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DarkGray, 0, 0, Width - 1, Height - 1);
        }
    }
}
