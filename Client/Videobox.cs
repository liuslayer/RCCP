using PresetForm;
using RecDll;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class Videobox : UserControl
    {
        #region 视频框样式
        private Color borderColor;
        private int borderWidth;
        private  ButtonBorderStyle BorderLineStyle = ButtonBorderStyle.Solid;
        public Color BorderColor
        {
            get
            {
                return borderColor;
            }

            set
            {
                borderColor = value;
                Refresh();
            }
        }

        public int BorderWidth
        {
            get
            {
                return borderWidth;
            }

            set
            {
                borderWidth = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (BorderColor != null)
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle,
                    BorderColor, BorderWidth, BorderLineStyle);
        }
        #endregion

        #region 视频信息
        public string IP = string.Empty;
        public int nChannel = -1;
        public int m_lUserID =-1;
        public int m_lRealHandle = -1;
        public string DeviceID = string.Empty;
        public string VideoName = string.Empty;
        bool b_ShoutSwitch = false;//喊话是否开启
        bool b_Rec = false;//手动录像是否开启
        bool b_VideoEffect = false;//设置视频参数是否开启
        bool b_Control = false;//设备控制窗体是否开启
        //设置视频信息
        public void SetVideoInfo(string IP,int nChannel,int m_lUserID, int m_lRealHandle,string DeviceID,string VideoName)
        {
            this.IP = IP;
            this.nChannel = nChannel;
            this.m_lUserID = m_lUserID;
            this.m_lRealHandle = m_lRealHandle;
            this.DeviceID = DeviceID;
            this.VideoName = VideoName;
        }
        //清空视频信息
        public void ClearVideoInfo()
        {
            IP = string.Empty;
            nChannel = -1;
            m_lUserID = -1;
            m_lRealHandle = -1;
            DeviceID = string.Empty;
            VideoName = string.Empty;
        }
        #endregion

        #region 视频轮巡
        public Thread thread;//轮巡线程
        public WheelGuard.WheelGuardInfo info;//轮巡信息
        //视频轮巡
        public void WheelGuardThread()
        {
            if (info.DeviceIDList.Count == 0 || info.WheelTime.Count == 0) return;
            while (true)
            {
                for (int i = 0; i < info.DeviceIDList.Count; i++)
                {
                    RealPlay.RealPlayVideo.Open(info.DeviceIDList[i].ToString(), (int)Tag,ref IP,ref nChannel,ref m_lUserID, ref m_lRealHandle);
                    Thread.Sleep(info.WheelTime[i] * 1000);
                }
            }
        }
        #endregion

        #region 报警闪烁
        public System.Windows.Forms.Timer timer;
        public bool b_Red=false;
        //视频框闪烁样式
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!b_Red)
            {
                //BorderColor = Color.Red;
                pictureBox5.BackgroundImage = Image.FromFile(@".\images\Icon\报警2.png");
                b_Red = true;
            }
            else
            {
                BorderColor = Color.Gray;
                b_Red = false;
            }
        }
        public void StartAlarm()
        {
            pictureBox5.BackgroundImage = Image.FromFile(@".\images\Icon\报警2.png");
        }
        public void EndAlarm()
        {
            pictureBox5.BackgroundImage = Image.FromFile(@".\images\Icon\报警.png");
        }
        #endregion 

        #region 报警声音
        public System.Media.SoundPlayer player;//报警声音播放                                
        public  string path = Application.StartupPath + @"\alarm.wav";//报警声音路径
        #endregion
        
       
        public Videobox()
        {
            InitializeComponent();
            #region 双缓存
            DoubleBuffered = true;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
            #endregion

            #region 视频框鼠标事件转移
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseDoubleClick += PictureBox1_MouseDoubleClick; ;
            pictureBox1.MouseEnter += PictureBox1_MouseEnter; ;
            pictureBox1.MouseLeave += PictureBox1_MouseLeave; ;
            pictureBox1.MouseUp += PictureBox1_MouseUp; ;
            //pictureBox1.Location = new Point(2, 2);
            #endregion

            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;

            info = new WheelGuard.WheelGuardInfo();

            player = new System.Media.SoundPlayer(path);
        }
        

        #region 流媒体视频不接受鼠标事件处理
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            OnMouseUp(e);
        }

        private void PictureBox1_MouseLeave(object sender, EventArgs e)
        {
            OnMouseLeave(e);
        }

        private void PictureBox1_MouseEnter(object sender, EventArgs e)
        {
            OnMouseEnter(e);
        }

        private void PictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            OnMouseDown(e);
        }
        #endregion
       
        //手动录像
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if(b_Rec)
            {
                //关闭录像
                if(!ManualRec.StopRec(IP+","+nChannel+"_1"))
                {
                    MessageBox.Show("关闭录像失败！");
                    return;
                }
                else
                {
                    MessageBox.Show("录像关闭！");
                    pictureBox2.BackgroundImage = Image.FromFile(@".\images\Icon\录像.png");
                    b_Rec = false;
                }
            }
            else
            {
                //打开录像
                int i = ManualRec.Rec(IP, nChannel, DeviceID);
                if(i<0)
                {
                    MessageBox.Show("打开录像失败！");
                    return;
                }
                else
                {
                    MessageBox.Show("录像打开！");
                    pictureBox2.BackgroundImage = Image.FromFile(@".\images\Icon\录像2.png");
                    b_Rec = true;
                }
            }
        }

        public void ChangeRecIcon(bool rec)
        {
            b_Rec = rec;
            if(b_Rec)
                pictureBox2.BackgroundImage = Image.FromFile(@".\images\Icon\录像2.png");
            else
                pictureBox2.BackgroundImage = Image.FromFile(@".\images\Icon\录像.png");
        }
        //截图
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            CapturePic.Capture(IP, nChannel, m_lRealHandle, DeviceID);
           //if(!CapturePic.Capture(IP, nChannel, m_lRealHandle,DeviceID))
           // {
           //     MessageBox.Show("截图失败！");
           // }
           // else
           // {
           //     MessageBox.Show("截图成功！");
           // }
        }
        //喊话
        private void pictureBox4_Click(object sender, EventArgs e)
        {
             IntercomShoutData.IntercomShoutDataInit();//初始化
            if (b_ShoutSwitch == false)
            {
                bool temp_bool = IntercomShoutData.ShoutSwitch(1, IP, nChannel, m_lUserID);
                if (temp_bool)
                {
                    pictureBox4.BackgroundImage = Image.FromFile(@".\images\Icon\喊话1.png");
                    b_ShoutSwitch = true;
                }
            }
            else
            {
                bool temp_bool = IntercomShoutData.ShoutSwitch(0, IP, nChannel, m_lUserID);
                if (temp_bool)
                {
                    pictureBox4.BackgroundImage = Image.FromFile(@".\images\Icon\喊话.png");
                    b_ShoutSwitch = false;
                }
            }
        }
        //设备控制
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if(b_Control)
            {
                Form1.CloseTurntableControlForm();
                pictureBox6.BackgroundImage = Image.FromFile(@".\images\Icon\控制.png");
                b_Control = false;
            }
            else
            {
                Form1.ShowTurntableControlForm(this);
                pictureBox6.BackgroundImage = Image.FromFile(@".\images\Icon\控制2.png");
                b_Control = true;
            }
        }
    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                                panel1.ClientRectangle,
                                BorderColor,//7f9db9
                                2,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                2,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                2,
                                ButtonBorderStyle.Solid,
                                BorderColor,
                                0,
                                ButtonBorderStyle.Solid);
        }
        VideoEffectForm VEF;
        //设置视频参数—亮度、对比度、灰度等
        private void pictureBox7_Click(object sender, EventArgs e)
        {
            if(b_VideoEffect)
            {
                pictureBox7.BackgroundImage = Image.FromFile(@".\images\Icon\调整.png");
                b_VideoEffect = false;
            }
            else
            {
                VEF = new VideoEffectForm(m_lUserID, nChannel);
                VEF.Show();
                pictureBox7.BackgroundImage = Image.FromFile(@".\images\Icon\调整2.png");
                b_VideoEffect = true;
            }
        }

        private void pictureBox7_MouseEnter(object sender, EventArgs e)
        {
            PictureBox p = sender as PictureBox;
            ToolTip t = new ToolTip();
            t.ShowAlways = true;
            t.SetToolTip(p, p.Tag.ToString());
        }
    }
}
