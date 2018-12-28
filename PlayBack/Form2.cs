using System;
using System.Windows.Forms;
using ClassLibrary1;
using System.Threading;

namespace PlayBack
{
    public partial class Form2 : Form
    {
        int lPort=-1;//播放录像标识
        int lRet = -1;//返回值
        string szSID = "ch2";//视频标识
        CMSSdk.callbackCAMFile call;//接收录像文件信息委托
        public Form2()
        {
            InitializeComponent();
           
            Thread th = new Thread(new ThreadStart(LoginMediaServer));
            th.IsBackground = true;
            th.Start();
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

        public Form2(string SID)
        {
            InitializeComponent();
            szSID = SID;
        }
        ////接收录像文件信息回调函数
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
            int lPort = Convert.ToInt32(ts.TotalSeconds);

            #region 无法通过VMK_Player_SetHwnd获取文件总时间
            //lRet = VM_Player_Vlc.VMK_Player_Open(lPort, FilePath);
            //PictureBox p = new PictureBox();
            //lRet = VM_Player_Vlc.VMK_Player_SetHwnd(lPort, p.Handle);
            //lRet = VM_Player_Vlc.VMK_Player_Play(lPort);
            //int RecodingTime = VM_Player_Vlc.VMK_Player_GetTime(lPort);
            //lRet = VM_Player_Vlc.VMK_Player_Stop(lPort);
            //lRet = VM_Player_Vlc.VMK_Player_Close(lPort);
            //int seconds = 18000;
            //string time = FileName.Split('_')[1];
            //int pastSecond = int.Parse(time.Substring(8, 2)) * 3600 + int.Parse(time.Substring(10, 2)) * 60 + int.Parse(time.Substring(12, 2));
            #endregion

            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = FileName;
            dataGridView1.Rows[index].Cells[1].Value = FilePath;
            dataGridView1.Rows[index].Cells[2].Value = lPort;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }

        //播放
        private void button1_Click(object sender, EventArgs e)
        {
            //if(lPort!=-1)
            //lRet = VM_Player_Vlc.VMK_Player_Close(lPort);
            lPort = 1;
            string path = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            lPort = (int)dataGridView1.SelectedRows[0].Cells[2].Value;
            lRet = VM_Player_Vlc.VMK_Player_Open(lPort, path);
            lRet = VM_Player_Vlc.VMK_Player_SetHwnd(lPort, pictureBox1.Handle);
            lRet = VM_Player_Vlc.VMK_Player_Play(lPort);

            int RecodingTime = VM_Player_Vlc.VMK_Player_GetPlayedTime(lPort);
            //trackBar1.Value = 0;
            trackBar1.Maximum = RecodingTime * 1000;
            if (lRet < 0)
            {
                MessageBox.Show("播放录像失败！");
            }
        }
        //暂停
        private void button2_Click(object sender, EventArgs e)
        {
             lRet = VM_Player_Vlc.VMK_Player_Pause(lPort,true);
        }
        //停止
        private void button3_Click(object sender, EventArgs e)
        {
             lRet = VM_Player_Vlc.VMK_Player_Stop(lPort);
        }
        //恢复
        private void button4_Click(object sender, EventArgs e)
        {
             lRet = VM_Player_Vlc.VMK_Player_Pause(lPort, false);
        }
        //快放
        private void button5_Click(object sender, EventArgs e)
        {
             lRet = VM_Player_Vlc.VMK_Player_Fast(lPort);
        }
        //慢放
        private void button6_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_Slow(lPort);
        }
        //恢复播放速度
        private void button7_Click(object sender, EventArgs e)
        {
            lRet = VM_Player_Vlc.VMK_Player_ReSpeed(lPort);
        }
        //查询录像文件
        private void button8_Click(object sender, EventArgs e)
        {
            //通过时间查询录像文件、
            call = CallbackCAMFile;
            string startTime = dateTimePicker1.Value.ToString("yyyyMMdd") + dateTimePicker2.Value.ToString("HHmmss");
            string endTime= dateTimePicker3.Value.ToString("yyyyMMdd") + dateTimePicker4.Value.ToString("HHmmss");
            int i = CMSSdk.VM_CMS_FindFileTime(0, szSID, startTime, endTime, call, 0);

        }
        int count;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(trackBar1.Value!= trackBar1.Maximum)
            {
                trackBar1.Value++;
                count++;
            }
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            int Hours = trackBar1.Value / 3600;
            int Minutes = (trackBar1.Value - Hours * 3600) / 60;
            int seconds = (trackBar1.Value - Hours * 3600) % 60;
            string str = Hours + ":" + Minutes + ":" + seconds;
            //DateTime dt = DateTime.ParseExact(str, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
            label5.Text =str;
            if(count==5)
            {
                //获取视频当前时间
                int CurrentTime = VM_Player_Vlc.VMK_Player_GetPlayedTime(lPort);
                //设置滑动条时间
                trackBar1.Value=seconds;
                count = 0;
            }
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button1_Click(null, null);

        }

        private void trackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            //trackBar1.Value = Convert.ToInt32((e.X) * Convert.ToDouble(trackBar1.Maximum) / (trackBar1.Width));
            ////回放时间定位
            //lRet = VM_Player_Vlc.VMK_Player_SetPlayedTime(lPort, trackBar1.Value);
        }
    }
}
