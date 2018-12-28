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

namespace AccessOperation
{
    public partial class CaptureForm1 : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion
        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion

        public delegate void SetupValueDelegate(string eventType,string Description);
        public event SetupValueDelegate SetupValueEvent;
        public CaptureForm1()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }

        private void CaptureForm1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            SetupValueEvent(comboBox1.Text, textBox1.Text);
            Close();
        }
    }
}
