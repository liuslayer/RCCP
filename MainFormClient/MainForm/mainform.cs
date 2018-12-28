using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MyButton;
using DeviceBaseData;

namespace Client
{
    public partial class mainform : Form
    {
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion
        ContentForm1 contentForm;

        VScrollBar vScrollBar1;
        
        StatusForm sf = new StatusForm();//服务状态窗口
        bool b_showSF = false;//服务状态是否已显示

        public mainform()
        {
            InitializeComponent();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果

            CommunicationClass.ServiceStatusEvent += CommunicationClass_ServiceStatusEvent;
            sf.Show();
        }

        private void CommunicationClass_ServiceStatusEvent(string message)
        {
            string[] services = message.Split(new char[] { ';' });
            for (int i = 0; i < services.Length; i++)
            {
                string[] str = services[i].Split(new char[] { '_' });
                string result = "正在运行";
                if (str[1] == "False")
                    result = "已停止";

                switch (str[0])
                {
                    case "OMServer":
                        sf.ShowResult("运维服务" + result + "!");
                        break;
                    case "BCServer":
                        sf.ShowResult("业务协同服务" + result + "!");
                        break;
                    case "DCServer":
                        sf.ShowResult("数据中心服务" + result + "!");
                        break;
                    case "BMMSServer":
                        sf.ShowResult("基础模块管理服务" + result + "!");
                        break;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //注册事件               
            MouseWheel += new MouseEventHandler(Form1_MouseWheel);

            contentForm = new ContentForm1();
            contentForm.TopLevel = false;
            panel3.Controls.Add(contentForm);
            contentForm.Show();


        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            //获取改变量 ms
            int ms = e.NewValue - e.OldValue;

            contentForm.Top = contentForm.Top - ms;
        }

        //panel3鼠标滚动事件
        private void Form1_MouseWheel(object sender, MouseEventArgs e)
        {
            //获取光标位置             
            Point mousePoint = new Point(e.X, e.Y);
            //换算成相对本窗体的位置              
            mousePoint.Offset(this.Location.X, this.Location.Y);
            //判断是否在panel内              
            if (panel3.RectangleToScreen(panel3.DisplayRectangle).Contains(mousePoint))
            {                   //滚动     
                panel3.AutoScrollPosition = new Point(0, panel3.VerticalScroll.Value - e.Delta);
            }
        }
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int ShowScrollBar(IntPtr hWnd, int bar, int show);
        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Control _Control = (Control)sender;
            ShowScrollBar(_Control.Handle, 0, 0);
        }


        private void button_close_Click(object sender, EventArgs e)
        {
            DialogResult isCloseForm = MessageBox.Show("请确认是否退出?", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (isCloseForm == DialogResult.OK)
            {
                foreach (Process pro in contentForm.processList)
                {
                    try
                    {
                        pro.Kill();
                    }
                    catch { }
                }
                Process.GetCurrentProcess().Kill();
                AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
                Environment.Exit(0);
            }
        }

        int x, y;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            sf.Show();
        }

        private void button_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


    }
}
