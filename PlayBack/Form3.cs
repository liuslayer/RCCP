using ClassLibrary1;
using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayBack
{
    public partial class Form3 : Form
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

        int lPort = -1;//播放录像标识
        int lRet = -1;//返回值
        List<string> paths = new List<string>();//录像文件
        List<int> lPorts = new List<int>();//录像标识
        string szSID = "ch1";//视频标识
        string VideoName = "设备1";//视频名称
        CMSSdk.callbackCAMFile call;//接收录像文件信息委托
        int RecodingTime=300;//每个录像文件录制总时间（暂定为5分钟）

        public Form3()
        {
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(LoginMediaServer));
            th.IsBackground = true;
            th.Start();
        }
        public Form3(string SID,string name)
        {
            InitializeComponent();
            szSID = SID;
            VideoName = name;
            label3.Text = VideoName;
        }
        public Form3(string str)
        {
            InitializeComponent();
        }
        private void LoginMediaServer()
        {
            //单独启动该窗体时需要初始化、登录媒体服务器
            int i = CMSSdk.VM_CMS_Init();
            if (i < 0)
            {
                MessageBox.Show("媒体管理器初始化失败！");
                return;
            }
            CMSSdk.LPCMS_USER_LOGIN_INFO LoginInfo = new CMSSdk.LPCMS_USER_LOGIN_INFO();
            LoginInfo.szIP = "192.0.0.66";
            LoginInfo.uPort = 8000;
            LoginInfo.szUser = "system";
            LoginInfo.szPassword = "system";
            lRet = CMSSdk.VM_CMS_Login(ref LoginInfo, 0);
            if (lRet < 0)
            {
                MessageBox.Show("媒体管理器登录失败！");
                return;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
                                                  //显示设备列表
            InitData();
            label1.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            userControl11.SendMessage += PlayRecVideo;
        }

        private void InitData()
        {
            if (Class1.IsDone)
            {
                for (int i = 0; i < Class1.cameraList.Count; i++)
                {
                    TreeNode node = new TreeNode(Class1.cameraList[i].VideoName);
                    node.Tag = Class1.cameraList[i].Stream_MainID;
                    treeView1.Nodes.Add(node);
                }
            }
        }
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //查询
        private void button3_Click(object sender, EventArgs e)
        {
            //通过时间查询录像文件、
            call = CallbackCAMFile;
            string startTime = monthCalendar1.SelectionStart.ToString("yyyyMMdd") + "000000";
            string endTime = monthCalendar1.SelectionStart.ToString("yyyyMMdd") + "235959";
            int i = CMSSdk.VM_CMS_FindFileTime(0, szSID, startTime, endTime, call, 0);

        }
        //接收录像文件信息回调函数
        private void CallbackCAMFile(int lHandle, ref CMSSdk.LPCMS_CAM_FILE_INFO lpCMS_CAM_FILE_INFO, UInt32 userdata)
        {
            ShowPath(lpCMS_CAM_FILE_INFO);
        }
        //显示录像文件
        public void ShowPath(object obj)
        {
            CMSSdk.LPCMS_CAM_FILE_INFO lpCMS_CAM_FILE_INFO = (CMSSdk.LPCMS_CAM_FILE_INFO)obj;
            string FileName = lpCMS_CAM_FILE_INFO.szFileName;
            string FilePath = lpCMS_CAM_FILE_INFO.szFilePath;
            //截取时间、生成块、放到时间轴上去
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            lPort = Convert.ToInt32(ts.TotalSeconds);
            
            string time = FileName.Split('_')[1];
            int pastSecond = int.Parse(time.Substring(8, 2)) * 3600 + int.Parse(time.Substring(10, 2)) * 60 + int.Parse(time.Substring(12, 2));

            userControl11.AddTimeBlock(RecodingTime, pastSecond);
            paths.Add(FilePath);
            lPorts.Add(lPort);
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = FileName;
            dataGridView1.Rows[index].Cells[1].Value = FilePath;
            dataGridView1.Rows[index].Cells[2].Value = lPort;

        }
        
        //供时间轴调用
        public void PlayRecVideo(int index)
        {
            if (lPort != -1)
                lRet = VM_Player_Vlc.VMK_Player_Close(lPort);
            lPort = lPorts[index];
            lRet = VM_Player_Vlc.VMK_Player_Open(lPort, paths[index]);
            lRet = VM_Player_Vlc.VMK_Player_SetHwnd(lPort, pictureBox1.Handle);
            lRet = VM_Player_Vlc.VMK_Player_Play(lPort);
            
            if (lRet < 0)
            {
                MessageBox.Show("播放录像失败！");
            }

        }
        //播放时间轴滑动指针
        private void timer1_Tick(object sender, EventArgs e)
        {
            //userControl11.pictureBox1.Location
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            szSID = treeView1.SelectedNode.Tag.ToString();
            label3.Text = treeView1.SelectedNode.Text;
        }
        //快放
        private void button5_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Fast(lPort);
        }
        //正常
        private void button7_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_ReSpeed(lPort);
        }
        //慢放
        private void button6_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Slow(lPort);
        }

        //恢复
        private void button4_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Pause(lPort, false);
        }
        //暂停
        private void button8_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Pause(lPort, true);
        }
        //停止
        private void button9_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Stop(lPort);
        }
        //播放
        private void button10_Click(object sender, EventArgs e)
        {
            if (lPort != -1)
                lRet = VM_Player_Vlc.VMK_Player_Close(lPort);
            if (dataGridView1.Rows.Count == 0 || dataGridView1.SelectedRows.Count == 0) return;
            string path = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            lPort = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            lRet = VM_Player_Vlc.VMK_Player_Open(lPort, path);
            lRet = VM_Player_Vlc.VMK_Player_SetHwnd(lPort, pictureBox1.Handle);
            lRet = VM_Player_Vlc.VMK_Player_Play(lPort);
            if (lRet < 0)
            {
                MessageBox.Show("播放录像失败！");
            }
        }
    }
}
