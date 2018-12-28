using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using DeviceBaseData;
using Client.Entities.AlarmEntity;
using PreviewDemo;
using AccessOperation;
using TurntableControlInterface;

namespace PresetForm
{
    public partial class Cms_AlarmSetting : Form
    {
        /// <summary>
        /// 生成报警器时添加预置位
        /// </summary>
        /// <param name="CameraDeviceID"></param>
        //---------------------预置位事件--------------------------------------
        public delegate void AlarmPresetSetupDelegate(string CameraDeviceID, string AlarmName);
        public event AlarmPresetSetupDelegate AddAlarmPreset;//添加预置位
        public event AlarmPresetSetupDelegate deleteAlarmPreset;//删除预置位
        //---------------------------------------------------------------------
        Alarm_Command.ArmAndDisarmList_Command Alarm_Command;
        DeviceBaseData.AlarmComand.VideoAlarmComand.VideoAlarmList_Command tempAlarm_Command;
        List<ArmAndDisarmList> tmpArmAndDisarmList=new List<ArmAndDisarmList>();
        List<VideoAlarmList> tmpVideoAlarmList = new List<VideoAlarmList>();
        ArmAndDisarmList temp_ArmAndDisarmList;//储存设备报警器的信息
        VideoAlarmList temp_VideoAlarmList;//储存设备临时报警的信息
        Dictionary<Guid, string> temp_AlarmID = new Dictionary<Guid, string>();
        private List<Guid> AlarmDeviceID;
        private string ip;//接收视频框传过来的ip
        private int ChannelNum;//接收视频框传过来的通道号
        private Guid cameraDeviceID;//摄像机ID
        private List<string> t = new List<string>();//储存划线的点，使用string形式便于储存
        private List<Point> t1 = new List<Point>();//重绘划线的点，使用point形式便于划线
        private List<Point> t2 = new List<Point>();//截图用
        private List<Point> t4 = new List<Point>();//录像透明截图
        private string AlarmLine;
        private string temp_alarmline;//临时报警模式的线
        private string video_alarmline;//视频报警器模式的线
        private int lineType = 0;
        private int AlarmType = 1;//报警类型
        private int AlarmSensitive = 1;//报警敏感度
        private string AlarmName;//报警名称
        private bool T_AlarmDeviceID = false;//报警器中是否已包含DeviceID
        private string temp_AlarmName;//临时报警名称
        //private string PictureboxSize;//视频框尺寸
        //private string ScreenResolution;//视频分辨率
        private Guid AlarmRecPictureID;//报警器照片ID
        private Point MyPoint1, MyPoint2;
        private Point MyPoint3;
        private bool operationResult = false;
        private bool isAlarmOrNot = false;
        private string errorinfo = "";

        private Point m_nVideoSize;
        private Point m_nPictureSize;

        public Point NVideoSize
        {
            get { return m_nVideoSize; }
            set { m_nVideoSize = value; }
        }

        private Point pStartPoint;

        public Point PStartPoint
        {
            get { return pStartPoint; }
            set { pStartPoint = value; }
        }

        private Point pEndPoint;

        public Point PEndPoint
        {
            get { return pEndPoint; }
            set { pEndPoint = value; }
        }

        public Point NPictureSize
        {
            get
            {
                return m_nPictureSize;
            }

            set
            {
                m_nPictureSize = value;
            }
        }

        Form1 f1 = null;
        private Point p;
        int m_lUserID;//登录设备返回ID
        int m_lMotionPlayHandle;//预览返回ID
        public Cms_AlarmSetting(string pDVRIP, int nChannel,int m_lUserID, Guid cameraDeviceID)
        {
            bool temp = CHCNetSDK.NET_DVR_Init();
            string IPAddress = "192.168.1.150"; //设备IP地址或者域名
            int PortNumber = 8000;//设备服务端口号
            string UserName = "admin";//设备登录用户名
            string Password = "admin12345";//设备登录密码

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
            AlarmSetSDK.m_struDeviceInfo = DeviceInfo;
            //测试用初始化数据
            //初始化通信类
            bool result1 = CommunicationClass.Init();
            Class1 temp_class = new Class1();
            temp_class.Init();
            Alarm_Command = new Alarm_Command.ArmAndDisarmList_Command();
            tempAlarm_Command = new DeviceBaseData.AlarmComand.VideoAlarmComand.VideoAlarmList_Command();
            this.ip = pDVRIP;
            this.ChannelNum = nChannel;
            this.cameraDeviceID = cameraDeviceID;
            this.m_lUserID = m_lUserID;
            InitializeComponent();
            p = PointToScreen(pictureBox1.Location);
            AlarmDeviceID = new List<Guid>();
            comboBox1.Text = "移动全屏报警";
            comboBox2.Text = "1";
            AlarmType = 1;
            AlarmSensitive = 1;
            button5.Enabled = true;
            button2.Enabled = false;
            if (comboBox3.Items.Count > 0)
            {
                comboBox3.SelectedIndex = 0;
            }
            //----------------------------预览视频----------------------------------------------
            //BF_Video_SDK.XW_DVR_SingleRealPlayEx(ip, ChannelNum, pictureBox1.Handle);
            //----------------------------------------------------------------------------------
            tmpArmAndDisarmList = Alarm_Command.ArmAndDisarmList_QueryData();
            tmpVideoAlarmList = tempAlarm_Command.VideoAlarmList_QueryData();
            //判断是否已设置过临时报警
            if (tmpVideoAlarmList.Count != 0)
            {
                for (int i = 0; i < tmpVideoAlarmList.Count; i++)
                {
                    if (tmpVideoAlarmList[i].DeviceID == cameraDeviceID)//判断该视频是否设置了报警划线
                    {
                        isAlarmOrNot = true;
                        temp_VideoAlarmList = tmpVideoAlarmList[i];
                        //AlarmName = videoAlarmList[i].AlarmName;
                        temp_AlarmName = tmpVideoAlarmList[i].AlarmName;
                        temp_alarmline = tmpVideoAlarmList[i].AlarmPointSelect;
                        break;
                    }
                }
            }
            //判断之前是否已设置过报警器
            for (int j = 0; j < tmpArmAndDisarmList.Count; j++)
            {
                try
                {
                    if (tmpArmAndDisarmList[j].DeviceID == cameraDeviceID)
                    {
                        temp_ArmAndDisarmList = tmpArmAndDisarmList[j];
                    }
                    temp_AlarmID.Add(tmpArmAndDisarmList[j].AlarmDeviceID, tmpArmAndDisarmList[j].AlarmName);
                    AlarmDeviceID.Add(tmpArmAndDisarmList[j].AlarmDeviceID);
                }
                catch { }
            }
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            lpPreviewInfo.hPlayWnd = pictureBox1.Handle;//预览窗口
            lpPreviewInfo.lChannel = ChannelNum;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            //打开预览 Start live view 
            m_lMotionPlayHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
        }
        public void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f1.Hide();
            f1.Close();
            this.Close();
        }
        int x, y;
        private void rangingForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                x = e.X;
                y = e.Y;
            }

        }

        private void rangingForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + (e.X - x), this.Location.Y + (e.Y - y));
            }
        }
        /// <summary>
        /// “报警器设置”按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (AlarmType != 1 && AlarmLine == null)
            {
                MessageBox.Show("请设置划线！");
                button2.Enabled = true;
                return;
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("请设置报警器名称！");
                button2.Enabled = true;
                return;
            }
            else
            {

                if (T_AlarmDeviceID == true)
                {
                    MessageBox.Show("该设备已设置过报警器！请重新选择设备设置报警器");
                    button2.Enabled = true;
                    return;
                }
                //设置报警器
                ArmAndDisarmList Set_ArmAndDisarmList = new ArmAndDisarmList();
                Set_ArmAndDisarmList.AlarmDeviceID= Guid.NewGuid();
                Set_ArmAndDisarmList.DeviceID = cameraDeviceID;
                Set_ArmAndDisarmList.AlarmType = AlarmType;
                Set_ArmAndDisarmList.AlarmName = textBox1.Text;
                AlarmName = textBox1.Text;
                for (int i = 0; i < temp_AlarmID.Count; i++)
                {
                    if (temp_AlarmID.ElementAt(i).Value == AlarmName)
                    {
                        MessageBox.Show("报警器中已包含该名称，请重新命名！");
                        button2.Enabled = true;
                        return;
                    }
                }
                Set_ArmAndDisarmList.AlarmSensitive = AlarmSensitive;
                Set_ArmAndDisarmList.AlarmLine = AlarmLine;
                Set_ArmAndDisarmList.PictureboxSize = pictureBox1.Width.ToString() + "," + pictureBox1.Height.ToString();
                Set_ArmAndDisarmList.AlarmRecPictureID = Set_ArmAndDisarmList.AlarmDeviceID;
                AlarmRecPictureID = Set_ArmAndDisarmList.AlarmDeviceID;

                string PresetName = Set_ArmAndDisarmList.AlarmName + "_预置位";
                Set_ArmAndDisarmList.PresetName = PresetName;
                List<ArmAndDisarmList> Add_ArmAndDisarmList = new List<ArmAndDisarmList>();
                Add_ArmAndDisarmList.Add(Set_ArmAndDisarmList);
                try
                {
                    Alarm_Command.ArmAndDisarmList_AddData(Add_ArmAndDisarmList);
                    //带线截图
                    photo();
                    //播放器截图
                    //Transparent_layer();
                    //添加报警器预置位
                    ThirdPartyCallingInterface.PresetAddInterface(cameraDeviceID, PresetName);
                }
                catch (Exception ex)
                {
                    button2.Enabled = true;
                    MessageBox.Show("未能写入数据库！");
                    temp_ArmAndDisarmList = null;
                    return;
                }
                //if (operationResult == true)
                //{
                //    BaseDataClass.RunLog temp_RunLog = new BaseDataClass.RunLog();
                //    temp_RunLog.LogType = "报警器设置";
                //    temp_RunLog.IsAbnormal = "正常";
                //    temp_RunLog.Date = DateTime.Now.ToString("yyyy-MM-dd");
                //    temp_RunLog.Time = DateTime.Now.ToString("HH:mm:ss");
                //    temp_RunLog.Operation = "报警器设置" + alarmModel.AlarmName + "成功";
                //    DatabaseAccess.AddBaseList(temp_RunLog, ref errorinfo);
                
                MessageBox.Show("报警器'" + AlarmName + "'设置成功！");
                temp_AlarmID.Add(Set_ArmAndDisarmList.AlarmDeviceID, Set_ArmAndDisarmList.AlarmName);
                AlarmDeviceID.Add(Set_ArmAndDisarmList.AlarmDeviceID);
                button4.Enabled = true;
            }
            comboBox3_SelectedIndexChanged(sender, e);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (f1 != null)
            {
                f1.flag = 1;
                this.MyPoint1.X = e.X;
                this.MyPoint1.Y = e.Y;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (f1 != null)
            {
                if (f1.flag != 1)
                {
                    return;
                }
                //鼠标移动，每次变换时，MyPoint2都记录下鼠标的位置，以便进行鼠标移动画线  
                this.MyPoint2.X = e.X;
                this.MyPoint2.Y = e.Y;

                pEndPoint.X = MyPoint2.X * NVideoSize.X / pictureBox1.Width;
                pEndPoint.Y = MyPoint2.Y * NVideoSize.Y / pictureBox1.Height;

                int x1 = NVideoSize.X / 22;
                int y1 = NVideoSize.Y / 18;

                t.Add(MyPoint1.X.ToString() + "," + MyPoint1.Y.ToString());//储存划线的点

                //当画完一条线后（很短的，可以当做一个小点看待），将MyPoint1的坐标重置为此时鼠标的位置  
                MyPoint1.X = e.X;
                MyPoint1.Y = e.Y;

                f1.draw(MyPoint1);
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (f1 != null)
            {
                f1.flag = 2;
                f1.UD = 0;
            }
            AlarmLine = string.Join("#", t.ToArray());//将t这个list转成字符串的形式，中间间隔加上#
            temp_alarmline = AlarmLine;
            lineType = 1;
        }

        private void Cms_AlarmSetting_Move(object sender, EventArgs e)
        {
            if (f1 != null)
            {
                f1.Size = new Size(pictureBox1.Width, pictureBox1.Height);
                p = PointToScreen(pictureBox1.Location);
                f1.Location = p;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (f1 != null) { f1.Invalidate(); }
            t.Clear();
            t1.Clear();
            t2.Clear();
            t4.Clear();
            lineType = 0;
            temp_alarmline = null;
            AlarmLine = null;
        }

        //private void Transparent_layer()
        //{

        //    if (AlarmLine != null && AlarmLine != "")
        //    {
        //        #region 获取视频分辨率
        //        int screenResolution = AlarmOperation.BF_Video_SDK.XW_DVR_GetVideoSize(ip, ChannelNum);//获取分辨率
        //        int k = screenResolution;
        //        switch (k)
        //        {
        //            case 0:
        //                {
        //                    //DCIF = 528×384
        //                    m_nPictureSize.X = 528;
        //                    m_nPictureSize.Y = 384;
        //                    break;
        //                }
        //            case 1:
        //                {
        //                    //CIF = 352×288
        //                    m_nPictureSize.X = 352;
        //                    m_nPictureSize.Y = 288;
        //                    break;
        //                }
        //            case 2:
        //                {
        //                    //QCIF = 176×144
        //                    m_nPictureSize.X = 176;
        //                    m_nPictureSize.Y = 144;
        //                    break;
        //                }
        //            case 3:
        //                {
        //                    //4CIF = 704×576
        //                    m_nPictureSize.X = 704;
        //                    m_nPictureSize.Y = 576;
        //                    break;
        //                }
        //            case 4:
        //                {
        //                    //2CIF = 704×288
        //                    m_nPictureSize.X = 704;
        //                    m_nPictureSize.Y = 288;
        //                    break;
        //                }
        //            case 6:
        //                {
        //                    //QVGA = 320*240
        //                    m_nPictureSize.X = 320;
        //                    m_nPictureSize.Y = 240;
        //                    break;
        //                }
        //            case 7:
        //                {
        //                    //7-QQVGA(160*120)
        //                    m_nPictureSize.X = 160;
        //                    m_nPictureSize.Y = 120;
        //                    break;
        //                }
        //            case 12:
        //                {
        //                    //12-384*288
        //                    m_nPictureSize.X = 384;
        //                    m_nPictureSize.Y = 288;
        //                    break;
        //                }
        //            case 13:
        //                {
        //                    //13-576*576
        //                    m_nPictureSize.X = 576;
        //                    m_nPictureSize.Y = 576;
        //                    break;
        //                }
        //            case 16:
        //                {
        //                    //VGA = 640×480 
        //                    m_nPictureSize.X = 640;
        //                    m_nPictureSize.Y = 480;
        //                    break;
        //                }
        //            case 17:
        //                {
        //                    //UXGA = 1600×1200
        //                    m_nPictureSize.X = 1600;
        //                    m_nPictureSize.Y = 1200;
        //                    break;
        //                }
        //            case 18:
        //                {
        //                    //SVGA = 800×600
        //                    m_nPictureSize.X = 800;
        //                    m_nPictureSize.Y = 600;
        //                    break;
        //                }
        //            case 19:
        //                {
        //                    //HD720p = 1280×720
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 720;
        //                    break;
        //                }
        //            case 20:
        //                {
        //                    //20-XVGA(1280*960)
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 960;
        //                    break;
        //                }
        //            case 22:
        //                {
        //                    //22-1360*1024
        //                    m_nPictureSize.X = 1360;
        //                    m_nPictureSize.Y = 1024;
        //                    break;
        //                }
        //            case 23:
        //                {
        //                    //23-1536*1536
        //                    m_nPictureSize.X = 1536;
        //                    m_nPictureSize.Y = 1536;
        //                    break;
        //                }
        //            case 24:
        //                {
        //                    //24-1920*1920
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1920;
        //                    break;
        //                }
        //            case 27:
        //                {
        //                    //27-1920*1080p
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1080;
        //                    break;
        //                }
        //            case 28:
        //                {
        //                    //28-2560*1920
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 1920;
        //                    break;
        //                }
        //            case 29:
        //                {
        //                    //29-1600*304
        //                    m_nPictureSize.X = 1600;
        //                    m_nPictureSize.Y = 304;
        //                    break;
        //                }
        //            case 30:
        //                {
        //                    //30-2048*1536
        //                    m_nPictureSize.X = 2048;
        //                    m_nPictureSize.Y = 1536;
        //                    break;
        //                }
        //            case 31:
        //                {
        //                    //31-2448*2048
        //                    m_nPictureSize.X = 2448;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 32:
        //                {
        //                    //32-2448*1200
        //                    m_nPictureSize.X = 2448;
        //                    m_nPictureSize.Y = 1200;
        //                    break;
        //                }
        //            case 33:
        //                {
        //                    //33-2448*800
        //                    m_nPictureSize.X = 2448;
        //                    m_nPictureSize.Y = 800;
        //                    break;
        //                }
        //            case 34:
        //                {
        //                    //34-XGA(1024*768)
        //                    m_nPictureSize.X = 1024;
        //                    m_nPictureSize.Y = 768;
        //                    break;
        //                }
        //            case 35:
        //                {
        //                    //35-SXGA(1280*1024)
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 1024;
        //                    break;
        //                }
        //            case 36:
        //                {
        //                    //36-WD1(960*576/960*480)
        //                    m_nPictureSize.X = 960;
        //                    m_nPictureSize.Y = 576;
        //                    break;
        //                }
        //            case 37:
        //                {
        //                    //37-1080i(1920*1080)
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1080;
        //                    break;
        //                }
        //            case 38:
        //                {
        //                    //38-WXGA(1440*900)
        //                    m_nPictureSize.X = 1440;
        //                    m_nPictureSize.Y = 900;
        //                    break;
        //                }
        //            case 39:
        //                {
        //                    //39-HD_F(1920*1080/1280*720)
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1080;
        //                    break;
        //                }
        //            case 40:
        //                {
        //                    //40-HD_H(1920*540/1280*360)
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 540;
        //                    break;
        //                }
        //            case 41:
        //                {
        //                    //41-HD_Q(960*540/630*360)
        //                    m_nPictureSize.X = 960;
        //                    m_nPictureSize.Y = 540;
        //                    break;
        //                }
        //            case 42:
        //                {
        //                    //42-2336*1744
        //                    m_nPictureSize.X = 2336;
        //                    m_nPictureSize.Y = 1744;
        //                    break;
        //                }
        //            case 43:
        //                {
        //                    //43-1920*1456
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1456;
        //                    break;
        //                }
        //            case 44:
        //                {
        //                    //44-2592*2048
        //                    m_nPictureSize.X = 2592;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 45:
        //                {
        //                    //45-3296*2472
        //                    m_nPictureSize.X = 3296;
        //                    m_nPictureSize.Y = 2472;
        //                    break;
        //                }
        //            case 46:
        //                {
        //                    //46-1376*768
        //                    m_nPictureSize.X = 1376;
        //                    m_nPictureSize.Y = 768;
        //                    break;
        //                }
        //            case 47:
        //                {
        //                    //47-1366*768
        //                    m_nPictureSize.X = 1366;
        //                    m_nPictureSize.Y = 768;
        //                    break;
        //                }
        //            case 48:
        //                {
        //                    //48-1360*768
        //                    m_nPictureSize.X = 1360;
        //                    m_nPictureSize.Y = 768;
        //                    break;
        //                }
        //            case 49:
        //                {
        //                    //49-WSXGA+ 1680*1050
        //                    m_nPictureSize.X = 1680;
        //                    m_nPictureSize.Y = 1050;
        //                    break;
        //                }
        //            case 50:
        //                {
        //                    //50-720*720
        //                    m_nPictureSize.X = 720;
        //                    m_nPictureSize.Y = 720;
        //                    break;
        //                }
        //            case 51:
        //                {
        //                    //51-1280*1280
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 1280;
        //                    break;
        //                }
        //            case 52:
        //                {
        //                    //52-2048*768
        //                    m_nPictureSize.X = 2048;
        //                    m_nPictureSize.Y = 768;
        //                    break;
        //                }
        //            case 53:
        //                {
        //                    //53-2048*2048
        //                    m_nPictureSize.X = 2048;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 54:
        //                {
        //                    //54-2560*2048
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 55:
        //                {
        //                    //55-3072*2048
        //                    m_nPictureSize.X = 3072;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 56:
        //                {
        //                    //56-2304*1296
        //                    m_nPictureSize.X = 2304;
        //                    m_nPictureSize.Y = 1296;
        //                    break;
        //                }
        //            case 57:
        //                {
        //                    //57-WXGA(1280*800)
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 800;
        //                    break;
        //                }
        //            case 58:
        //                {
        //                    //58-1600*600
        //                    m_nPictureSize.X = 1600;
        //                    m_nPictureSize.Y = 600;
        //                    break;
        //                }
        //            case 59:
        //                {
        //                    //59-1600*900
        //                    m_nPictureSize.X = 1600;
        //                    m_nPictureSize.Y = 900;
        //                    break;
        //                }
        //            case 60:
        //                {
        //                    //60-2752*2208
        //                    m_nPictureSize.X = 2752;
        //                    m_nPictureSize.Y = 2208;
        //                    break;
        //                }
        //            case 61:
        //                {
        //                    //61-384*288
        //                    m_nPictureSize.X = 384;
        //                    m_nPictureSize.Y = 288;
        //                    break;
        //                }
        //            case 62:
        //                {
        //                    //62-4000*3000
        //                    m_nPictureSize.X = 4000;
        //                    m_nPictureSize.Y = 3000;
        //                    break;
        //                }
        //            case 63:
        //                {
        //                    //63-4096*2160
        //                    m_nPictureSize.X = 4096;
        //                    m_nPictureSize.Y = 2160;
        //                    break;
        //                }
        //            case 64:
        //                {
        //                    //64-3840*2160
        //                    m_nPictureSize.X = 3840;
        //                    m_nPictureSize.Y = 2160;
        //                    break;
        //                }
        //            case 65:
        //                {
        //                    //65-4000*2250
        //                    m_nPictureSize.X = 4000;
        //                    m_nPictureSize.Y = 2250;
        //                    break;
        //                }
        //            case 66:
        //                {
        //                    //66-3072*1728
        //                    m_nPictureSize.X = 3072;
        //                    m_nPictureSize.Y = 1728;
        //                    break;
        //                }
        //            case 67:
        //                {
        //                    //67-2592*1944
        //                    m_nPictureSize.X = 2592;
        //                    m_nPictureSize.Y = 1944;
        //                    break;
        //                }
        //            case 68:
        //                {
        //                    //68-2464*1520
        //                    m_nPictureSize.X = 2464;
        //                    m_nPictureSize.Y = 1520;
        //                    break;
        //                }
        //            case 69:
        //                {
        //                    //69-1280*1920
        //                    m_nPictureSize.X = 1280;
        //                    m_nPictureSize.Y = 1920;
        //                    break;
        //                }
        //            case 70:
        //                {
        //                    //70-2560*1440
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 1440;
        //                    break;
        //                }
        //            case 71:
        //                {
        //                    //71-1024*1024
        //                    m_nPictureSize.X = 1024;
        //                    m_nPictureSize.Y = 1024;
        //                    break;
        //                }
        //            case 72:
        //                {
        //                    //72-160*128
        //                    m_nPictureSize.X = 160;
        //                    m_nPictureSize.Y = 128;
        //                    break;
        //                }
        //            case 73:
        //                {
        //                    //73-324*240
        //                    m_nPictureSize.X = 324;
        //                    m_nPictureSize.Y = 240;
        //                    break;
        //                }
        //            case 74:
        //                {
        //                    //74-324*256
        //                    m_nPictureSize.X = 324;
        //                    m_nPictureSize.Y = 256;
        //                    break;
        //                }
        //            case 75:
        //                {
        //                    //75-336*256
        //                    m_nPictureSize.X = 336;
        //                    m_nPictureSize.Y = 256;
        //                    break;
        //                }
        //            case 76:
        //                {
        //                    //76-640*512
        //                    m_nPictureSize.X = 640;
        //                    m_nPictureSize.Y = 512;
        //                    break;
        //                }
        //            case 77:
        //                {
        //                    //77-2720*2048
        //                    m_nPictureSize.X = 2720;
        //                    m_nPictureSize.Y = 2048;
        //                    break;
        //                }
        //            case 78:
        //                {
        //                    //78-384*256
        //                    m_nPictureSize.X = 384;
        //                    m_nPictureSize.Y = 256;
        //                    break;
        //                }
        //            case 79:
        //                {
        //                    //79-384*216
        //                    m_nPictureSize.X = 384;
        //                    m_nPictureSize.Y = 216;
        //                    break;
        //                }
        //            case 80:
        //                {
        //                    //80-320*256
        //                    m_nPictureSize.X = 320;
        //                    m_nPictureSize.Y = 256;
        //                    break;
        //                }
        //            case 81:
        //                {
        //                    //81-320*180
        //                    m_nPictureSize.X = 320;
        //                    m_nPictureSize.Y = 180;
        //                    break;
        //                }
        //            case 82:
        //                {
        //                    //82-320*192
        //                    m_nPictureSize.X = 320;
        //                    m_nPictureSize.Y = 192;
        //                    break;
        //                }
        //            case 83:
        //                {
        //                    //83-512*384
        //                    m_nPictureSize.X = 512;
        //                    m_nPictureSize.Y = 384;
        //                    break;
        //                }
        //            case 84:
        //                {
        //                    //84-325*256
        //                    m_nPictureSize.X = 325;
        //                    m_nPictureSize.Y = 256;
        //                    break;
        //                }
        //            case 85:
        //                {
        //                    //85-256*192
        //                    m_nPictureSize.X = 256;
        //                    m_nPictureSize.Y = 192;
        //                    break;
        //                }
        //            case 86:
        //                {
        //                    //86- 640*360
        //                    m_nPictureSize.X = 640;
        //                    m_nPictureSize.Y = 360;
        //                    break;
        //                }
        //            case 87:
        //                {
        //                    //87-1776x1340
        //                    m_nPictureSize.X = 1776;
        //                    m_nPictureSize.Y = 1340;
        //                    break;
        //                }
        //            case 88:
        //                {
        //                    //88-1936x1092
        //                    m_nPictureSize.X = 1936;
        //                    m_nPictureSize.Y = 1092;
        //                    break;
        //                }
        //            case 89:
        //                {
        //                    //89-2080x784
        //                    m_nPictureSize.X = 2080;
        //                    m_nPictureSize.Y = 784;
        //                    break;
        //                }
        //            case 90:
        //                {
        //                    //90-2144x604
        //                    m_nPictureSize.X = 2144;
        //                    m_nPictureSize.Y = 604;
        //                    break;
        //                }
        //            case 91:
        //                {
        //                    //91-1920*1200
        //                    m_nPictureSize.X = 1920;
        //                    m_nPictureSize.Y = 1200;
        //                    break;
        //                }
        //            case 92:
        //                {
        //                    //92-4064*3040
        //                    m_nPictureSize.X = 4064;
        //                    m_nPictureSize.Y = 3040;
        //                    break;
        //                }
        //            case 93:
        //                {
        //                    //93-3040*3040
        //                    m_nPictureSize.X = 3040;
        //                    m_nPictureSize.Y = 3040;
        //                    break;
        //                }
        //            case 94:
        //                {
        //                    //94-3072*2304
        //                    m_nPictureSize.X = 3072;
        //                    m_nPictureSize.Y = 2304;
        //                    break;
        //                }
        //            case 95:
        //                {
        //                    //95-3072*1152
        //                    m_nPictureSize.X = 3072;
        //                    m_nPictureSize.Y = 1152;
        //                    break;
        //                }
        //            case 96:
        //                {
        //                    //96-2560*2560
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 2560;
        //                    break;
        //                }
        //            case 97:
        //                {
        //                    //97-2688*1536
        //                    m_nPictureSize.X = 2688;
        //                    m_nPictureSize.Y = 1536;
        //                    break;
        //                }
        //            case 98:
        //                {
        //                    //98-2688*1520
        //                    m_nPictureSize.X = 2688;
        //                    m_nPictureSize.Y = 1520;
        //                    break;
        //                }
        //            case 99:
        //                {
        //                    //99-3072*3072
        //                    m_nPictureSize.X = 3072;
        //                    m_nPictureSize.Y = 3072;
        //                    break;
        //                }
        //            case 100:
        //                {
        //                    //100-3392*2008
        //                    m_nPictureSize.X = 3392;
        //                    m_nPictureSize.Y = 2008;
        //                    break;
        //                }
        //            case 101:
        //                {
        //                    //101-4000*3080
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 2560;
        //                    break;
        //                }
        //            case 102:
        //                {
        //                    //102-960*720
        //                    m_nPictureSize.X = 960;
        //                    m_nPictureSize.Y = 720;
        //                    break;
        //                }
        //            case 103:
        //                {
        //                    //103-1024*1536
        //                    m_nPictureSize.X = 1024;
        //                    m_nPictureSize.Y = 1536;
        //                    break;
        //                }
        //            case 104:
        //                {
        //                    //104-704*1056
        //                    m_nPictureSize.X = 704;
        //                    m_nPictureSize.Y = 1056;
        //                    break;
        //                }
        //            case 105:
        //                {
        //                    //105-352*528
        //                    m_nPictureSize.X = 352;
        //                    m_nPictureSize.Y = 528;
        //                    break;
        //                }
        //            case 106:
        //                {
        //                    //106-2048*1530
        //                    m_nPictureSize.X = 2048;
        //                    m_nPictureSize.Y = 1530;
        //                    break;
        //                }
        //            case 107:
        //                {
        //                    //107-2560*1600
        //                    m_nPictureSize.X = 2560;
        //                    m_nPictureSize.Y = 1600;
        //                    break;
        //                }
        //            case 108:
        //                {
        //                    //108-2800*2100
        //                    m_nPictureSize.X = 2800;
        //                    m_nPictureSize.Y = 2100;
        //                    break;
        //                }
        //            case 109:
        //                {
        //                    //109-4088*4088
        //                    m_nPictureSize.X = 4088;
        //                    m_nPictureSize.Y = 4088;
        //                    break;
        //                }
        //            case 110:
        //                {
        //                    //110-4000*3072
        //                    m_nPictureSize.X = 4000;
        //                    m_nPictureSize.Y = 3072;
        //                    break;
        //                }
        //            case 111:
        //                {
        //                    //111-960*1080(1080p Lite)
        //                    m_nPictureSize.X = 960;
        //                    m_nPictureSize.Y = 1080;
        //                    break;
        //                }
        //            case 112:
        //                {
        //                    //112-640*720(half 720p)
        //                    m_nPictureSize.X = 640;
        //                    m_nPictureSize.Y = 720;
        //                    break;
        //                }
        //        }
        //        #endregion
        //        //创建图象，保存将来截取的图象
        //        Bitmap Trans_image = new Bitmap(m_nPictureSize.X, m_nPictureSize.Y);
        //        Graphics imgGraphics = Graphics.FromImage(Trans_image);
        //        string Filename = AlarmName;
        //        string path = AvailablePath.GetUsedPath("报警截图");
        //        Graphics g = Graphics.FromImage(Trans_image);
        //        int proportion_x = m_nPictureSize.X / pictureBox1.Width;
        //        int proportion_y = m_nPictureSize.Y / pictureBox1.Height;
        //        string[] str = AlarmLine.Split('#');//将pointStr以#为标志分隔开，储存在str[]中
        //        Pen Mypen = new Pen(Color.Red, 2);
        //        for (int i = 0; i < str.Length; i++)
        //        {
        //            string[] str1 = str[i].Split(',');
        //            MyPoint1.X = int.Parse(str1[0]) * proportion_x;
        //            MyPoint1.Y = int.Parse(str1[1]) * proportion_y;
        //            t4.Add(MyPoint1);
        //        }//重绘时解析字符串
        //        for (int i = 0; i < t4.Count; i++)
        //        {
        //            if (i == t4.Count - 1)
        //            {
        //                break;
        //            }
        //            if (Math.Abs(t4[i].X - t4[i + 1].X) < 50 && Math.Abs(t4[i].Y - t4[i + 1].Y) < 50)
        //            {
        //                MyPoint3 = t4[i + 1];
        //                g.DrawLine(Mypen, t4[i], MyPoint3);
        //                continue;
        //            }
        //        }
        //        Trans_image.Save(@path + AlarmName + ".png");
        //    }
        //}
        private Point p1 = new Point(0, 0);
        private void photo()
        {
            //创建图象，保存将来截取的图象
            Bitmap image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            Graphics imgGraphics = Graphics.FromImage(image);
            //设置截屏区域
            imgGraphics.CopyFromScreen(p, p1, new Size(pictureBox1.Width, pictureBox1.Height));
            //保存
            string Filename = AlarmName;
            //获取存放路径
            string path = Path.GetDirectoryName(Application.ExecutablePath)+"\\报警器照片\\"; 
            //新创建一个用于存放报警录像的文件夹
            if (!Directory.Exists(path))
            {
                // Create the directory it does not exist.
                Directory.CreateDirectory(path);
            }
            if (AlarmLine != null && AlarmLine != "")
            {
                Graphics g = Graphics.FromImage(image);
                string[] str = AlarmLine.Split('#');//将pointStr以#为标志分隔开，储存在str[]中
                Pen Mypen = new Pen(Color.Red, 2);
                for (int i = 0; i < str.Length; i++)
                {
                    string[] str1 = str[i].Split(',');
                    MyPoint1.X = int.Parse(str1[0]);
                    MyPoint1.Y = int.Parse(str1[1]);
                    t2.Add(MyPoint1);
                }//重绘时解析字符串
                for (int i = 0; i < t2.Count; i++)
                {
                    if (i == t2.Count - 1)
                    {
                        break;
                    }
                    if (Math.Abs(t2[i].X - t2[i + 1].X) < 10 && Math.Abs(t2[i].Y - t2[i + 1].Y) < 10)
                    {
                        MyPoint3 = t2[i + 1];
                        g.DrawLine(Mypen, t2[i], MyPoint3);
                        continue;
                    }
                }

            }
            image.Save(@path + AlarmName + ".jpg");
        }
        private void button4_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;//将"删除"按钮置灰
            f1.Refresh();//刷新控件
            pictureBox2.Visible = false;
            t.Clear();
            t1.Clear();
            t2.Clear();
            t4.Clear();
            lineType = 0;
            temp_alarmline = null;
            video_alarmline = null;
            AlarmLine = null;//清空划线
            pictureBox2.Visible = false;
            textBox1.ReadOnly = false;
            textBox1.Text = "";
            if (comboBox3.Text == "临时报警器生成")//切换到临时报警器生成模式
            {
                if (isAlarmOrNot == true)
                //取消报警
                {
                    Guid del_guid = temp_VideoAlarmList.DeviceID;
                    Guid[] _GuisList = new Guid[1];
                    _GuisList[0] = del_guid;
                    temp_VideoAlarmList = null;
                    //-----------------临时报警取消日志----------------------
                    //-------------------------------------------------------
                    temp_AlarmName = "";//清空临时报警名称
                    //-----------------取消临时报警设置----------------------
                    AlarmSetSDK.Alarm_Close(ip,ChannelNum,m_lUserID);
                    //-------------------------------------------------------
                    //AlarmOperation.SetAlarm.XW_DVR_StopSingleRealPlayEx(ip);
                    tempAlarm_Command.VideoAlarmList_DelData(_GuisList);
                    for (int i = tmpVideoAlarmList.Count - 1; i >= 0; i--)
                    {
                        if (tmpVideoAlarmList[i].DeviceID == del_guid)
                            tmpVideoAlarmList.Remove(tmpVideoAlarmList[i]);
                    }
                    isAlarmOrNot = false;
                    button5.Enabled = true;
                }
                else
                {
                    MessageBox.Show("该视频并未设置临时报警器！");
                }
            }
            else
            {
                //先取消报警
                string errorinfo = "";
                bool result;
                try
                {
                    #region 预警监控软件版 删除报警器流程
                    //查找到报警器以及所有的阶段设置信息

                    //1、删除罗骅的报警联动字典，并取消报警

                    //2、通过主界面删除报警器对应的预置位   并关闭布放小绿点

                    //3、删除报警快照

                    //4、删除联动、处置、未处置所有的设置信息

                    //5、删除时间段设置

                    //6、删除报警器
                    #endregion
                    //-----------------取消报警器设置报警--------------------

                    //-------------------------------------------------------
                    MessageBox.Show("请在报警预案中执行该操作！");
                    tmpArmAndDisarmList = null;
                    //button5.Enabled = true;
                    //刷新表格
                }
                catch { }
                finally
                {
                }
            }
            comboBox3_SelectedIndexChanged(sender, e);
        }

        public void line(string s)
        {
            //tips:在使用之前请判断pointStr是否为空
            //tips:在使用之前请判断pointStr是否为空
            if (s != "" || s != null)
            {
                string[] str = s.Split('#');//将pointStr以#为标志分隔开，储存在str[]中
                t1.Clear();
                for (int i = 0; i < str.Length; i++)
                {
                    try
                    {
                        string[] str1 = str[i].Split(',');
                        MyPoint1.X = int.Parse(str1[0]);
                        MyPoint1.Y = int.Parse(str1[1]);
                        t1.Add(MyPoint1);
                    }
                    catch { }
                }//重绘时解析字符串
                f1.flag = 1;
                for (int i = 0; i < t1.Count; i++)
                {
                    if (i == t1.Count - 1)
                    {
                        break;
                    }
                    if (Math.Abs(t1[i].X - t1[i + 1].X) > 10 && Math.Abs(t1[i].Y - t1[i + 1].Y) > 10)
                    {
                        f1.MyPoint1 = t1[i + 1];
                        continue;
                    }
                    f1.draw(t1[i]);
                }
                f1.flag = 2;
                f1.UD = 0;
            }
        }


        private void Cms_AlarmSetting_Shown(object sender, EventArgs e)
        {
            f1 = new Form1(this, pictureBox1.Width, pictureBox1.Height, p);

            f1.Show();
            f1.ShowInTaskbar = false;
            f1.Size = new Size(pictureBox1.Width, pictureBox1.Height);
            f1.Location = p;
            f1.Owner = this;
            comboBox3_SelectedIndexChanged(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            if (comboBox3.Text == "临时报警器生成")//切换到临时报警器生成模式
            {
                if (AlarmType != 1 && (AlarmLine == null || AlarmLine == ""))
                {
                    MessageBox.Show("请设置划线！");
                    button5.Enabled = true;
                    return;
                }
                if (textBox1.Text == "" || textBox1.Text == null)
                {
                    MessageBox.Show("请设置临时报警器名称！");
                    button5.Enabled = true;
                    return;
                }
                if (isAlarmOrNot == true)
                {
                    MessageBox.Show("该视频已设置报警！请取消后再设置");
                    button5.Enabled = true;
                    return;
                }
                VideoAlarmList temp_VideoAlarmList_Set = new VideoAlarmList();
                AlarmName = textBox1.Text;
                temp_AlarmName = textBox1.Text;
                temp_VideoAlarmList_Set.DeviceID = cameraDeviceID;
                temp_VideoAlarmList_Set.AlarmName = textBox1.Text;
                temp_VideoAlarmList_Set.AlarmType = AlarmType;
                temp_VideoAlarmList_Set.AlarmPointSelect = AlarmLine;
                temp_VideoAlarmList_Set.IP = ip + "," + ChannelNum ;
                temp_VideoAlarmList_Set.Description = comboBox2.Text;//表示报警灵敏度
                try
                {
                    List<VideoAlarmList> _VideoAlarmList = new List<VideoAlarmList>();
                    _VideoAlarmList.Add(temp_VideoAlarmList_Set);
                    tempAlarm_Command.VideoAlarmList_AddData(_VideoAlarmList);
                }
                catch
                { }

                //------------------------设置临时报警---------------------------
                AlarmSetSDK.AlarmSet(ip, ChannelNum, m_lUserID, AlarmType, int.Parse(temp_VideoAlarmList_Set.Description), temp_VideoAlarmList_Set.AlarmName, temp_VideoAlarmList_Set.AlarmPointSelect, pictureBox1.Size.Width, pictureBox1.Size.Height);
                //---------------------------------------------------------------
                if (true)
                {
                    MessageBox.Show("临时报警" + comboBox1.Text + "设置成功！");
                    lineType = 1;
                    temp_alarmline = AlarmLine;
                    //写入日志
                    temp_VideoAlarmList = temp_VideoAlarmList_Set;
                    isAlarmOrNot = true;
                    button4.Enabled = true;
                    comboBox3_SelectedIndexChanged(sender, e);
                }
                else
                {
                    MessageBox.Show("临时报警" + comboBox1.Text + "设置失败！该视频已设置报警");
                    //写入日志
                    isAlarmOrNot = false;
                    button4.Enabled = false;
                }
            }
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "移动全屏报警":
                    AlarmType = 1;
                    break;
                case "移动局部报警":
                    AlarmType = 2;
                    break;
                case "移动过线报警":
                    AlarmType = 3;
                    break;
            }
        }

        private void comboBox2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch (comboBox2.Text)
            {
                case "1":
                    AlarmSensitive = 1;
                    break;
                case "2":
                    AlarmSensitive = 2;
                    break;
                case "3":
                    AlarmSensitive = 3;
                    break;
                case "4":
                    AlarmSensitive = 4;
                    break;
                case "5":
                    AlarmSensitive = 5;
                    break;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            //if (f1 != null)
            //{ f1.Refresh(); }
            if (lineType == 0)
            {
                return;
            }
            else if (lineType == 1)
            {
                if (comboBox3.Text == "临时报警器生成")
                {
                    line(temp_alarmline);
                }
                else { line(video_alarmline); }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (f1 != null)
            {
                Graphics g = f1.CreateGraphics();
                g.Clear(f1.BackColor);
            }
            #region 临时报警器模式
            if (comboBox3.Text == "临时报警器生成")//切换到临时报警器生成模式
            {
                button5.Enabled = true;
                button2.Enabled = false;


                if (temp_VideoAlarmList != null)//若已有设置过的临时报警器
                {
                    textBox1.Text = temp_VideoAlarmList.AlarmName;
                    textBox1.ReadOnly = true;
                    comboBox1.SelectedIndex = int.Parse(temp_VideoAlarmList.AlarmType.ToString())-1;
                    if (temp_VideoAlarmList.AlarmType != 1)
                    {
                        pictureBox2.Visible = false;
                        temp_alarmline = temp_VideoAlarmList.AlarmPointSelect;
                        lineType = 1;
                        line(temp_alarmline);
                    }
                    else
                    {
                        pictureBox2.Visible = true;//为全屏报警
                        lineType = 0;
                    }
                    comboBox2.SelectedIndex = int.Parse(temp_VideoAlarmList.Description)-1;
                    button5.Enabled = false;
                    button4.Enabled = true;
                }
                else
                {
                    pictureBox2.Visible = false;
                    temp_alarmline = "";
                    textBox1.ReadOnly = false;
                    textBox1.Text = "";
                    button5.Enabled = true;
                    button4.Enabled = false;
                }
            }
            #endregion
            else if (comboBox3.Text == "视频报警器生成")//切换到视频报警器生成模式
            {
                button5.Enabled = false;
                pictureBox2.Visible = false;
                video_alarmline = "";
                textBox1.ReadOnly = false;
                textBox1.Text = "";
                button2.Enabled = true;
                button4.Enabled = false;
            }
        }
    }
}
