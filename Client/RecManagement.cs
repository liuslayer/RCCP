using RecDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Client
{
    public partial class RecManagement : Form
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
        public RecManagement()
        {
            InitializeComponent();
        }

        private void RecManagement_Load(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果

            //显示录像信息
            foreach(string key in RecDataClass.recInfo.Keys)
            {
                ListViewItem item = new ListViewItem();
                item.Tag = key;
                item.SubItems.Add(RecDataClass.recInfo[key].Name);
                item.SubItems.Add(RecDataClass.recInfo[key].DT.ToString("yyyy-MM-dd HH:mm:ss"));
                item.SubItems.Add(RecDataClass.recInfo[key].RecType);
                if (RecDataClass.recInfo[key].RecType == "报警录像")
                {
                    item.ForeColor = Color.Red;
                }
                listView1.Items.Add(item);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void htn_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void RecManagement_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void StopRecBtn_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem item in listView1.CheckedItems)
            {
                //关闭录像
                string IPChannel = item.Tag.ToString();
                string RecType = item.SubItems[3].Text;
                switch (RecType)
                {
                    case "手动录像":
                        ManualRec.StopRec(item.Tag.ToString());
                        break;
                    case "自动录像":
                        AutoRec.StopRec(item.Tag.ToString());
                        break;
                    case "报警录像":
                        
                        break;
                }
                //移除录像信息
                listView1.Items.Remove(item);
               
            }
        }
    }
}
