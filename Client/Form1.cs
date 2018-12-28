using ClassLibrary1;
using Client.Entities;
using Client.Entities.AlarmEntity;
using Client.Properties;
using DeviceBaseData;
using DeviceRTStatus;
using InformationManagementDLL;
using PlayBack;
using PresetForm;
using RecDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SystemSetupDLL;
using TurntableControlInterface;
using static Client.Entities.ControlCommandData;

namespace Client
{
    public partial class Form1 : Form
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

        #region 全局变量
        public static int BoxCount=36;          //分屏最大数
        public static Videobox[] videoboxs;     //视频框
        public static Panel[] panels;           //闪烁视频框
        public static List<int> flash_tag;      //需要闪烁的视频框下标
        public static int selectedIndex = 0;    //选中的视频框下标
        int CurrentNum = 9;
        /*****----视频相关信息----*****/
        public int lHandle=-1;//媒体管理器登录返回值，用于打开视频
        public static string[] DeviceIDs;       //存储打开的视频设备ID
        public static int[] hwnd;               //存储打开的流媒体句柄
        public static string[] SID;             //存储已经打开的视频sSID
        string[] IPNchannel;                    //存储已经打开的视频IP和通道号
        public static bool[] IsAlarm;           //记录是否报警
        public static string[] AlarmDeviceID;   //记录报警器ID
        public static string[] AlarmFingerprintID;//记录报警器报警后生成的唯一标识
        public static int[] AlarmType;          //报警方式
        public static Dictionary<string,bool> MotorSwitch;       //电机开关（数组长度为CameraList长度）
        public static Dictionary<string, bool> CCDSwitch;         //白光开关（数组长度为CameraList长度）
        public static Dictionary<string, bool> IRSwitch;          //红外开关（数组长度为CameraList长度）
        /*****----视频相关信息----*****/
        public static PresetDataManage[] PDM;   //记录报警联动信息
        public Thread StatusThread;             //实时状态线程
        public static List<string> Device_IP;   //设备IP
        public static List<int> Device_Status ; //设备实时状态
        Thread[] WheelGuardThreads;             //视频轮巡线程
        #endregion

        #region 窗体加载
        public Form1()
        {
            #region 全局变量初始化
            InitializeComponent();
            videoboxs = new Videobox[BoxCount];
            panels = new Panel[BoxCount];
            flash_tag = new List<int>();
            hwnd = new int[BoxCount];
            SID = new string[BoxCount];
            IPNchannel = new string[BoxCount];
            IsAlarm = new bool[BoxCount];
            WheelGuardThreads = new Thread[BoxCount];
            DeviceIDs = new string[BoxCount];
            AlarmDeviceID = new string[BoxCount];
            AlarmFingerprintID = new string[BoxCount];
            AlarmType = new int[BoxCount];
            //初始化电机、白光、红外开关数组
            MotorSwitch = new Dictionary<string, bool>();
            CCDSwitch = new Dictionary<string, bool>();
            IRSwitch = new Dictionary<string, bool>();
            PDM = new PresetDataManage[BoxCount];
            StatusThread = new Thread(new ThreadStart(FlashStatus));//设备实时信息线程
            StatusThread.IsBackground = true;
            Device_IP = new List<string>();
            Device_Status = new List<int>();
            Size = new Size(Screen.PrimaryScreen.Bounds.Width,Screen.PrimaryScreen.Bounds.Height);
            Location = new Point(0, 0);
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
            #endregion

            #region 双缓存
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲 
            #endregion

            #region 状态显示窗体
            Program.statusForm = new StatusForm();
            Program.statusForm.Show();
            #endregion
        }
        #region 设备状态刷新
        private void FlashStatus()
        {
            try
            {
                while (true)
                {
                    for (int i = 0; i < Device_IP.Count; i++)
                    {
                        for (int j = 0; j < NetPing.IP.Count; j++)
                        {
                            if (NetPing.IP[j] == Device_IP[i] && Device_Status[i] != NetPing.status[j])
                            {
                                bool result = false;
                                Action action = delegate () { result = ChangeDeviceStatusIcon(Device_IP[i], NetPing.status[j]); };
                                Invoke(action);
                                if (result)
                                {
                                    Device_Status[i] = NetPing.status[j];
                                }
                                break;
                            }
                        }
                    }
                    Thread.Sleep(5000);
                }
            }
            catch { }
        }

        private bool ChangeDeviceStatusIcon(string IP,int status)
        {
            //查找节点
            foreach (TreeNode node in treeView1.Nodes)
            {
                foreach (TreeNode item in node.Nodes)
                {
                    if (item.Tag == null) continue;
                    if (item.Tag.ToString() == IP)
                    {
                        foreach (TreeNode subNode in item.Nodes)
                        {
                            if (subNode.ImageIndex == -1) continue;
                            switch (status)
                            {
                                //设备重新在线
                                case 1:
                                    subNode.ImageIndex += 3;
                                    //需重新登录设备
                                    ManualRec.AddLogIn(subNode.Tag.ToString());
                                    break;
                                case 0:
                                    subNode.ImageIndex -= 3;
                                    break;
                            }
                        }
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion
        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i=0;i< BoxCount; i++)
            {
                Videobox videobox = new Videobox();
                videobox.BorderWidth = 2;
                videobox.BorderColor = Color.Transparent;
                videobox.ContextMenuStrip = contextMenuStrip1;
                videobox.MouseDown += Videobox_MouseDown;
                videobox.Tag = i;
                videoboxs[i] = videobox;

                hwnd[i] = -1;

                panels[i] = new Panel();
                panels[i].BackColor = Color.Transparent;
                
            }
            Thread th = new Thread(new ThreadStart(Init));
            th.IsBackground = true;
            th.Start();
            SetVideoBox(4, panel1);
            
        }

        #region 视频框事件
        private void Videobox_MouseDown(object sender, MouseEventArgs e)
        {
            Videobox v = sender as Videobox;
            if(selectedIndex!=(int)v.Tag)
            {
                videoboxs[selectedIndex].BorderColor = Color.Transparent;
                selectedIndex = (int)v.Tag;
            }
            videoboxs[selectedIndex].BorderColor = Color.Green;
           
            //左下角显示视频名称
            label7.Text = "当前选中视频为："+v.VideoName;

            //判断视频框是否正在报警器报警，如果是则启用"显示联动视频"
            if (e.Button == MouseButtons.Right && IsAlarm[selectedIndex] && AlarmDeviceID[selectedIndex] != "")
            {
                contextMenuStrip1.Items["ShowLinkageVideo"].Enabled = true;
            }
            else
            {
                contextMenuStrip1.Items["ShowLinkageVideo"].Enabled = false;
            }

            if (IsAlarm[selectedIndex] && AlarmDeviceID[selectedIndex] == null)
            {
                v.player.Stop();//取消报警声音
                flash_tag.Remove(selectedIndex);//取消视频框闪烁
                panels[selectedIndex].BackColor = Color.Transparent;
                videoboxs[selectedIndex].EndAlarm();
            }
        }
        #endregion
        //打开“设备控制”窗体
       static  TurntableControlForm TCF = new TurntableControlForm();
        public static void ShowTurntableControlForm(Control control)
        {
            if (DeviceIDs[selectedIndex] == null) return;
            TurntableControlForm.VideoDeviceGuid = new Guid(DeviceIDs[selectedIndex]);
            TurntableControlForm.UserGuid =new Guid();
            TCF.TurntableDeviceDataInit();
            CameraList camera = Class1.cameraList.Find(_ => _.DeviceID.Equals(TurntableControlForm.VideoDeviceGuid));
            if (camera == null) return;
            TurntableControlForm.VideoType =int.Parse(camera.VideoType);
            TCF.StartPosition = FormStartPosition.Manual;
            Point p = LocationOnClient(control);
            if(p.X+ control.Width + TCF.Width>Screen.PrimaryScreen.WorkingArea.Width)
            {
                p.X -= TCF.Width;
            }
            else
            {
                p.X += control.Width;
            }
            TCF.Location = new Point(p.X, p.Y);
            TCF.Show();
        }
        //关闭“设备控制”窗体
        public static void CloseTurntableControlForm()
        {
            if (TCF != null)
            {
                TCF.Hide();
            }
        }

        //计算视频框的位置，显示透明窗体
        private static Point LocationOnClient(Control c)
        {
            Point retval = new Point(0, 0);
            for (; c.Parent != null; c = c.Parent)
            {
                retval.Offset(c.Location);
            }
            return retval;
        }
        #endregion

        #region 最大化、最小化窗体操作

        // 关闭窗体
        private void button1_Click(object sender, EventArgs e)
        {
            //transForm.Close();
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
            ManualRec.Logout();
            AutoRec.Logout();
            AlarmRec.Logout();
            CapturePic.Logout();
            //try
            //{
            //    VMSdk.VM_CLIENT_Cleanup();
            //}
            //catch { //并不能处理会报错的异常，假如流媒体服务器初始化不成功
            //}
        }
        
        // 最小化窗体
        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            //transForm.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
        }
        
        #endregion
        

        #region 分屏
        // 一分屏
        private void button6_Click(object sender, EventArgs e)
        {
            if(selectedIndex!=-1)
            {
                //splitContainer3.Panel2.Controls.Clear();
                //splitContainer3.Panel2.Controls.Add(videoboxs[selectedIndex]);
                //int width = splitContainer3.Panel2.Width;
                //int height = splitContainer3.Panel2.Height;
                //videoboxs[selectedIndex].Size = new Size(width, height);
                //videoboxs[selectedIndex].Location = new Point(0,0);
                //transForm.FullScreen(selectedIndex, splitContainer3.Panel2.Size, LocationOnClient(splitContainer3.Panel2));
                CurrentNum = 1;
            }
            else
            {
                SetVideoBox(1, panel1);
            }
        }

        // 四分屏
        private void button7_Click(object sender, EventArgs e)
        {
            SetVideoBox(4, panel1);
        }
        // 九分屏
        private void button8_Click(object sender, EventArgs e)
        {
            SetVideoBox(9, panel1);
        }
        // 16分屏
        private void button9_Click(object sender, EventArgs e)
        {
            SetVideoBox(16,panel1);
        }
        
        /// <summary>
        /// 设置视频框
        /// </summary>
        /// <param name="Num">要设置的视频框数</param>
        private void SetVideoBox(int Num,Control control)
        {
            try
            {
                double num = Math.Sqrt(Num);
                control.Controls.Clear();
                int width = (int)((control.Width - (num + 1) * 3) / num);
                int height = (int)((control.Height - (num + 1) * 3) / num);
                int x = 1;
                int y = 1;
                int tag = 0;
                for (int i = 0; i < num; i++)
                {
                    for (int j = 0; j < num; j++)
                    {
                        control.Controls.Add(panels[tag]);
                        panels[tag].Size = new Size(width, height);
                        panels[tag].Location = new Point(x * (j ) + j * width, y * (i ) + i * height);
                        panels[tag].Controls.Add(videoboxs[tag]);

                        videoboxs[tag].Size = new Size(width-4, height-4);
                        videoboxs[tag].Location = new Point(2, 2);
                        tag++;
                    }
                }
                CurrentNum = Num;
            }
            catch { }
        }
        #endregion


        //开启视频框闪烁
        private void button12_Click(object sender, EventArgs e)
        {
            videoboxs[selectedIndex].timer.Start();
        }

        

        #region 右键菜单
        private void 关闭预览ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (System.Configuration.ConfigurationManager.AppSettings["MediaStream"] == "1")
            {
                if (CMSSdk.VM_CMS_StopPlay(hwnd[selectedIndex]) == -1)
                {
                    MessageBox.Show("关闭失败！");
                    return;
                }
                DeviceIDs[selectedIndex] = null;
                hwnd[selectedIndex] = -1;
                SID[selectedIndex] = null;
                videoboxs[selectedIndex].Refresh();
                videoboxs[selectedIndex].ClearVideoInfo();
            }
            else
            {
                if (!PreviewDemo.CHCNetSDK.NET_DVR_StopRealPlay(hwnd[selectedIndex]))
                {
                    MessageBox.Show("关闭失败！");
                }
                else
                {
                    DeviceIDs[selectedIndex] = null;
                    hwnd[selectedIndex] = -1;
                    videoboxs[selectedIndex].Refresh();
                    videoboxs[selectedIndex].ClearVideoInfo();
                }
            }
            
        }
        private void 打开录像ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i;
            switch (sender.ToString())
            {
                case "打开录像":
                    i = ManualRec.Rec(videoboxs[selectedIndex].IP, videoboxs[selectedIndex].nChannel, DeviceIDs[selectedIndex]);
                    if (i != -1)
                    {
                        MessageBox.Show("打开录像成功！");
                        contextMenuStrip1.Items[1].Text = "关闭录像";
                        videoboxs[selectedIndex].ChangeRecIcon(true);
                    }
                    else
                        MessageBox.Show("打开录像失败！");

                    break;

                case "关闭录像":
                    if (ManualRec.StopRec(videoboxs[selectedIndex].IP+","+videoboxs[selectedIndex].nChannel+"_1"))
                    {
                        MessageBox.Show("关闭录像成功！");
                        contextMenuStrip1.Items[1].Text = "打开录像";
                        videoboxs[selectedIndex].ChangeRecIcon(false);
                    }

                    else
                        MessageBox.Show("关闭录像失败！");
                    break;
            }
        }

        private void 视频轮巡ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenWheelGuard swg = new ScreenWheelGuard(videoboxs[selectedIndex]);
           
            swg.Show();

        }
        
        #endregion



        #region 快捷键

        /// <summary>
        /// 录像管理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            //需要一个录像管理类
            RecManagement recManagement = new RecManagement();
            recManagement.Show();
            recManagement.Owner = this;
        }

        #endregion

        #region 显示设备列表
        public void Init()
        {
            while (true)
            {
                if (Class1.IsDone)
                {
                    ShowDeivceList();
                    break;
                }
            }

        }

        public delegate void ShowDeivceListDelegate();
        public void ShowDeivceList()
        {
            if(treeView1.InvokeRequired)
            {
                ShowDeivceListDelegate d = ShowDeivceList;
                treeView1.Invoke(d);
            }
            else
            {
                //添加根站节点
                for (int rootIndex = 0; rootIndex < Class1.stationList.Count; rootIndex++)
                {
                    //if(Class1.stationList[rootIndex].PStationID==null)
                    //{
                        TreeNode root = new TreeNode(Class1.stationList[rootIndex].Name);
                        root.Tag = Class1.stationList[rootIndex].StationID;
                        treeView1.Nodes.Add(root);
                       
                        //for (int nextIndex = 0; nextIndex < Class1.stationList.Count; nextIndex++)
                        //{
                        //    if (Class1.stationList[nextIndex].PStationID != null
                        //        && Class1.stationList[nextIndex].PStationID == Class1.stationList[rootIndex].StationID)
                        //    {
                        //        TreeNode next = new TreeNode(Class1.stationList[nextIndex].Name);
                        //        next.Tag = Class1.stationList[nextIndex].StationID;
                        //        root.Nodes.Add(next);

                                //1、添加流媒体根节点，记录deviceID
                                for (int i = 0; i < Class1.streamMediaList.Count; i++)
                                {
                                    if (Class1.streamMediaList[i].Stationid == Class1.stationList[rootIndex].StationID)
                                    {
                                        TreeNode nNext = new TreeNode();
                                        nNext.Text = Class1.streamMediaList[i].Name;
                                        nNext.Tag = Class1.streamMediaList[i].VideoIP;
                                        Device_IP.Add(Class1.streamMediaList[i].VideoIP);
                                        Device_Status.Add(0);
                                        root.Nodes.Add(nNext);
                                        //2、添加摄像机节点
                                        for (int j = 0; j < Class1.cameraList.Count; j++)
                                        {
                                            if (Class1.cameraList[j].StreamMedia_DeviceID == Class1.streamMediaList[i].DeviceID)
                                            {
                                                TreeNode tn = new TreeNode();
                                                tn.Text = Class1.cameraList[j].VideoName;
                                                tn.Tag = Class1.cameraList[j].DeviceID;
                                                string VideoType = Class1.cameraList[j].VideoType;
                                                if (VideoType == "101")
                                                {
                                                    tn.ImageIndex = 0;
                                                }
                                                else if (VideoType == "102")
                                                {
                                                    tn.ImageIndex = 1;
                                                }
                                                else if (VideoType == "103")
                                                {
                                                    tn.ImageIndex = 2;
                                                }
                                                nNext.Nodes.Add(tn);
                                                //初始化电机、白光、红外开关数组
                                                MotorSwitch.Add(Class1.cameraList[j].DeviceID.ToString(), false);
                                                CCDSwitch.Add(Class1.cameraList[j].DeviceID.ToString(), false);
                                                IRSwitch.Add(Class1.cameraList[j].DeviceID.ToString(), false);
                                            }
                                        }
                                    }

                                }
                            }
                    //    }
                    //}
                //}
                treeView1.ExpandAll();
                StatusThread.Start();
            }
        }
        #endregion

        private void button19_Click(object sender, EventArgs e)
        {
            AlarmForm a1 = new AlarmForm();
            a1.Show();
        }
        
        // 双击列表，预览视频
        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //获取设备ID
            TreeNode node = e.Node;
            if (node.Tag == null||node.Level==0||node.Level==1) return;
            string IP="";
            int nChannel = -1;
            int m_lUserID = -1;
            int m_lRealHandle = -1;
            int i = RealPlay.RealPlayVideo.Open(node.Tag.ToString(),selectedIndex,ref IP,ref nChannel,ref m_lUserID,ref m_lRealHandle);
            if(i>=0)
            {
                videoboxs[selectedIndex].SetVideoInfo(IP,nChannel,m_lUserID, m_lRealHandle, node.Tag.ToString(),node.Text);
                label7.Text = "当前选中视频为：" + node.Text;
            }
            else
            {
                MessageBox.Show("预览失败！");
            }
        }

        //单击列表，弹出右键菜单
        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            treeView1.SelectedNode = node;
            if (e.Button == MouseButtons.Right && node.Level == 2)
            {
                treeView1.ContextMenuStrip = contextMenuStrip2;
                //电机开关
                if (MotorSwitch.ContainsKey(node.Tag.ToString()))
                {
                    if(MotorSwitch[node.Tag.ToString()])
                        contextMenuStrip2.Items["MotorItem"].Text = "关闭电机";
                    else
                        contextMenuStrip2.Items["MotorItem"].Text = "打开电机";
                }
                //白光开关
                if (CCDSwitch.ContainsKey(node.Tag.ToString()))
                {
                    if (CCDSwitch[node.Tag.ToString()])
                        contextMenuStrip2.Items["CCDItem"].Text = "关闭白光";
                    else
                        contextMenuStrip2.Items["CCDItem"].Text = "打开白光";
                }
                //红外开关
                if (IRSwitch.ContainsKey(node.Tag.ToString()))
                {
                    if (IRSwitch[node.Tag.ToString()])
                        contextMenuStrip2.Items["IRItem"].Text = "关闭红外";
                    else
                        contextMenuStrip2.Items["IRItem"].Text = "打开红外";
                }
            }
            if (node.Level == 0)
            {
                treeView1.ContextMenuStrip = null;
                if (node.IsExpanded)
                    node.Collapse();
                else
                    node.Expand();
            }
        }
        //下拉列表切换分屏
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetVideoBox(int.Parse(comboBox1.Text), panel1);
        }
        //下拉列表切换分屏鼠标按下
        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && e.KeyChar != '.' && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        //下拉列表切换分屏鼠标弹起
        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                SetVideoBox(int.Parse(comboBox1.Text), panel1);
            }
        }
        #region 关于报警
        // 显示报警信息
        public void ShowAlarmInfo(AlarmMessage info)
        {
            int rowIndex = dataGridView1.Rows.Add();
            dataGridView1.Rows[rowIndex].Tag = info.DeviceID;
            dataGridView1.Rows[rowIndex].Cells[0].Value = info.AlarmAreaName;
            switch (info.AlarmType)
            {
                case 0:
                    dataGridView1.Rows[rowIndex].Cells[1].Value = "临时报警";
                    break;
                case 1:
                    dataGridView1.Rows[rowIndex].Cells[1].Value = "报警器报警";
                    break;
            }
            dataGridView1.Rows[rowIndex].Cells[2].Value = info.DT_Alarm.ToString("yyyy-MM-dd HH:mm:ss");
            switch (info.AlarmStage)
            {
                case 1:
                    dataGridView1.Rows[rowIndex].Cells[3].Value = "触发";
                    break;
                case 2:
                    dataGridView1.Rows[rowIndex].Cells[3].Value = "处置";
                    break;
                case 3:
                    dataGridView1.Rows[rowIndex].Cells[3].Value = "未处置";
                    break;
                case 4:
                    dataGridView1.Rows[rowIndex].Cells[3].Value = "结束";
                    break;
            }
            dataGridView1.Rows[rowIndex].Cells[4].Value = "坐标：X:" + info.AlarmPosition_X + ",Y:" + info.AlarmPosition_Y;
            dataGridView1.Rows[rowIndex].Cells[5].Value = "查看";
        }

        public void ThreadShow(AlarmMessage info)
        {
            Action act = delegate () { ShowAlarmInfo(info); };
            dataGridView1.Invoke(act);
        }

        //报警信息边框样式
        private void dataGridView1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawRectangle(Pens.DimGray, new Rectangle(0, 0, dataGridView1.Width - 1, dataGridView1.Height - 1));
        }
        // 右键菜单查看联动视频，打开联动视频窗口
        private void ShowLinkageVideo_Click(object sender, EventArgs e)
        {
            LinkageVideoForm LVF = new LinkageVideoForm(DeviceIDs[selectedIndex]);
            LVF.Show();
        }
        // 查看详细报警信息,打开联动视频窗口
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name== "DetailMes" && e.RowIndex != -1)
            {
                string DeviceID = dataGridView1.Rows[e.RowIndex].Tag.ToString();
                LinkageVideoForm LVF = new LinkageVideoForm(DeviceID);
                LVF.Show();
            }
        }
        // 报警处置
        private void DisposeAlarm_Click(object sender, EventArgs e)
        {
            videoboxs[selectedIndex].player.Stop();//结束报警声音
            videoboxs[selectedIndex].timer.Stop();//结束报警闪烁
           
            //给服务器发送报警处置消息
            string message = "DisposeAlarm/"+AlarmFingerprintID[selectedIndex]+","+ AlarmType[selectedIndex]+"\r\n";
            Byte[] data = Encoding.ASCII.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);
            string responseData = String.Empty;
        }

        //清理视频框报警信息
        public static void ClearAlarmInfo(int BoxTab)
        {
            AlarmDeviceID[BoxTab] = null;
            AlarmFingerprintID[BoxTab] = null;
            AlarmType[BoxTab] = -1;
            IsAlarm[BoxTab] = false;
            videoboxs[BoxTab].EndAlarm();
            flash_tag.Remove(BoxTab);
            panels[BoxTab].BackColor = Color.Transparent;
        }

        #endregion
        //设备搜索
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            string strValue = textBox1.Text;
            if (strValue == "") return;
            TreeNode tnRet = null;
            foreach (TreeNode node in treeView1.Nodes)
            {
                tnRet= FindNode(node, strValue);
                if (tnRet != null)
                {
                    treeView1.SelectedNode = tnRet;
                    treeView1.Focus();
                    break;
                }
            }
        }
        //递归查找节点
        private TreeNode FindNode(TreeNode tnParent,string strValue)
        {
            if (tnParent == null) return null;
            if (tnParent.Text == strValue) return tnParent;
            TreeNode tnRet = null;
            foreach (TreeNode tn in tnParent.Nodes)
            {
                tnRet = FindNode(tn, strValue);
                if (tnRet != null) break;
            }
            return tnRet;
        } 
        //快捷键panel边框样式
        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics,
                panel6.ClientRectangle,
                Color.FromArgb(28, 31, 34), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(28, 31, 34), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(28, 31, 34), 1, ButtonBorderStyle.Solid,
                Color.FromArgb(28, 31, 34), 1, ButtonBorderStyle.Solid);
        }
        //时间显示
        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            label8.Text =string.Format("{0:F}", dt);
        }
        //设备列表样式重写
        private void treeView1_DrawNode(object sender, DrawTreeNodeEventArgs e)
        {
            TreeNode tn = e.Node as TreeNode;
            if (tn == null)
            {
                return;
            }

            //设置Image绘制Rectangle
            Point pt = new Point(tn.Bounds.X + 5, tn.Bounds.Y+5);
            Rectangle rt = new Rectangle(pt, new Size(8,5));

            if ((e.State & TreeNodeStates.Selected) != 0)
            {
                //绘制TreeNode选择后的背景框
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(90, Color.FromArgb(205, 226, 252))), 2, tn.Bounds.Y, Width - 7, tn.Bounds.Height - 1);

                //绘制TreeNode选择后的边框线条
                e.Graphics.DrawRectangle(new Pen(Color.FromArgb(7,8,9), 1), 1, tn.Bounds.Y, Width - 6, tn.Bounds.Height - 1);
            }

            //绘制节点图片
            if (tn.Nodes.Count != 0)
            {
                rt.Y += 4;
                if (tn.IsExpanded == true)
                {
                    e.Graphics.DrawImage(Resources.NodeExpandedImage, rt);
                }
                else
                {
                    e.Graphics.DrawImage(Resources.NodeCollapseImage, rt);
                }
                rt.Y -= 4;
            }
            

            //绘制节点自身图片                
            if (e.Node.ImageIndex != -1 && imageList1 != null)
            {
                rt.X += 15;
                rt.Width += 6;
                rt.Height += 12;
                try
                {
                    e.Graphics.DrawImage(imageList1.Images[e.Node.ImageIndex], rt);
                }
                catch { }
            }

            //绘制节点的文本
            rt.X += 18;
            rt.Y += 1;
            rt.Width = Width - rt.X;
            rt.Height = 20;
            e.Graphics.DrawString(e.Node.Text, new Font("微软雅黑", 9, FontStyle.Regular), Brushes.White, rt);
        }
        //窗体拖动事件
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        //服务状态
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Program.statusForm.Show();
        }
        

        private void timer2_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < flash_tag.Count; i++)
            {
                if (panels[flash_tag[i]].BackColor == Color.Transparent)
                {
                    panels[flash_tag[i]].BackColor = Color.Red;
                }
                else
                {
                    panels[flash_tag[i]].BackColor = Color.Transparent;
                }
            }
        }
        //电机开关
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string DeviceID = treeView1.SelectedNode.Tag.ToString();
            switch (item.Text)
            {
                case "打开电机":
                    InterfaceControl.HDControl(new Guid(DeviceID), (int)HDCommand.MotorOpen, 0, 0, null);
                    if (MotorSwitch.ContainsKey(DeviceID))
                        MotorSwitch[DeviceID] = true;
                    break;
                case "关闭电机":
                    InterfaceControl.HDControl(new Guid(DeviceID), (int)HDCommand.MotorOff, 0, 0, null);
                    if (MotorSwitch.ContainsKey(DeviceID))
                        MotorSwitch[DeviceID] = false;
                    break;
            }
        }
        //白光开关
        private void CCDItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string DeviceID = treeView1.SelectedNode.Tag.ToString();
            switch (item.Text)
            {
                case "打开白光":
                    InterfaceControl.CCDControl(new Guid(DeviceID), (int)CCDCommand.CCD_Open, 0, 0, null);
                    if (CCDSwitch.ContainsKey(DeviceID))
                        CCDSwitch[DeviceID] = true;
                    break;
                case "关闭白光":
                    InterfaceControl.CCDControl(new Guid(DeviceID), (int)CCDCommand.CCD_Off, 0, 0, null);
                    if (CCDSwitch.ContainsKey(DeviceID))
                        CCDSwitch[DeviceID] = false;
                    break;
            }
        }
        //红外开关
        private void IRItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            string DeviceID = treeView1.SelectedNode.Tag.ToString();
            switch (item.Text)
            {
                case "打开红外":
                    InterfaceControl.IRControl(new Guid(DeviceID), (int)IRCommand.IR_Open, 0, 0, null);
                    if (IRSwitch.ContainsKey(DeviceID))
                        IRSwitch[DeviceID] = true;
                    break;
                case "关闭红外":
                    InterfaceControl.IRControl(new Guid(DeviceID), (int)IRCommand.IR_Off, 0, 0, null);
                    if (IRSwitch.ContainsKey(DeviceID))
                        IRSwitch[DeviceID] = false;
                    break;
            }
        }

        private void SetAlarm_Click(object sender, EventArgs e)
        {
            Cms_AlarmSetting CA = new Cms_AlarmSetting(videoboxs[selectedIndex].IP,videoboxs[selectedIndex].nChannel,videoboxs[selectedIndex].m_lUserID,new Guid(videoboxs[selectedIndex].DeviceID));
            CA.Show();
        }

        private void button6_MouseEnter(object sender, EventArgs e)
        {
            System.Windows.Forms.Button b = sender as System.Windows.Forms.Button;
            System.Windows.Forms.ToolTip p = new System.Windows.Forms.ToolTip();
            p.ShowAlways = true;
            p.SetToolTip(b, b.Tag.ToString());
        }
        Form3 form3;
        //回放
        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Red;
            button3.BackColor = Color.Transparent;
            if (form3 == null)
            {
                form3 = new Form3("回放");
                form3.Size = panel4.Size;
                form3.Location = panel4.Location;
                form3.TopLevel = false;
                panel4.Visible = false;
                Controls.Add(form3);
                form3.Show();
            }
            else
            {
                form3.Visible = true;
                panel4.Visible = false;
            }
        }
        //预览
        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Red;
            button4.BackColor = Color.Transparent;
            if(form3!=null)
            {
                form3.Visible = false;
                panel4.Visible = true;
            }
        }
    }
}
