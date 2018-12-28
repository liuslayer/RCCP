using ClassLibrary1;
using Client;
using Client.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BCSimulateSoftware
{
    public partial class Form2 : Form
    {
        #region 发送数据
        //Socket clientSocket1;
        //Socket clientSocket2;
        #endregion

        #region 接收数据
        Socket sSocket;
        Socket serverSocket;
        #endregion
        int returningValue1;
        private int lHandle;
        CMSSdk.callbackCAMFile call;//接收录像文件信息委托
        int lPort = -1;//播放录像标识
        string szSID = "ch1";//视频标识
        public Form2()
        {
            InitializeComponent();
            #region 连接外部数据中心 
            //IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
            //int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
            //int ExternalDataCentreService_Port2 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port2"]);

            //IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
            //clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //clientSocket1.Connect(ipe1);
            //IPEndPoint ipe2 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port2);
            //clientSocket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //clientSocket2.Connect(ipe2);
            #endregion

            #region 建立socket服务器监听外部数据中心返回值
            int ListenPort = int.Parse(ConfigurationManager.AppSettings["ListenPort"]);
            IPAddress ListenIP = IPAddress.Parse(ConfigurationManager.AppSettings["ListenIP"]);
            IPEndPoint ipe = new IPEndPoint(ListenIP, ListenPort);
            sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket.Bind(ipe);
            sSocket.Listen(0);
            Thread th = new Thread(new ThreadStart(ReveiceData));
            th.IsBackground = true;
            th.Start();
            #endregion
            //初始化流媒体
            //returningValue1 = VMSdk.VM_CLIENT_Init();
            returningValue1 = CMSSdk.VM_CMS_Init();
            CMSSdk.LPCMS_USER_LOGIN_INFO LoginInfo = new CMSSdk.LPCMS_USER_LOGIN_INFO();
            LoginInfo.szIP = ConfigurationManager.AppSettings["MediaStream_IP"];
            LoginInfo.uPort = int.Parse(ConfigurationManager.AppSettings["MediaStream_Port"]);
            LoginInfo.szUser = ConfigurationManager.AppSettings["MediaStream_User"];
            LoginInfo.szPassword = ConfigurationManager.AppSettings["MediaStream_Password"];
            lHandle = CMSSdk.VM_CMS_Login(ref LoginInfo, 0);
            if (lHandle < 0)
            {
                MessageBox.Show("媒体管理服务器登录失败!");
            }
            else
            {
                MessageBox.Show("媒体管理服务器登录成功！");
            }
        }

        private void ReveiceData()
        {
            try
            {
                while (true)
                {
                    serverSocket = sSocket.Accept();
                    string recStr = "";
                    byte[] recByte = new byte[4096];
                    int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                    recStr += Encoding.UTF8.GetString(recByte, 0, bytes);
                    //解析数据
                    string[] str = recStr.Split('/');
                    if (str.Length != 2) return;
                    switch(str[0])
                    {
                        //报警信息
                        case "10":
                            ShowAlarmMessage(str[1]);
                            break;
                    }
                }
            }
            catch (Exception ex)
            { Console.WriteLine("业务协同模拟软件2接收数据失败。错误信息："+ex.ToString()); }

        }

        private void ShowAlarmMessage(string message)
        {
            Action action = delegate () { listBox1.Items.Add(message); };
            Invoke(action);
        }


        //获取流媒体视频地址
        private void button2_Click(object sender, EventArgs e)
        {
            string sendStr = "xxxx/12";
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);
                string recStr = "";
                byte[] recByte = new byte[1024*100];
                Action action = delegate ()
                  {
                      clientSocket1.Receive(recByte, recByte.Length, 0);
                      recStr = Encoding.UTF8.GetString(recByte);
                     List<CameraList> cameraList = JsonConvert.DeserializeObject<List<CameraList>>(recStr);
                      listBox2.DataSource = cameraList;
                      listBox2.DisplayMember = "VideoName";
                      listBox2.ValueMember = "Stream_MainID";
                  };
                Invoke(action);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }

        } //发送视频调阅命令
        private void button1_Click(object sender, EventArgs e)
        {
            //直接使用流媒体库播放视频
            string sid = listBox2.SelectedValue.ToString();
            returningValue1 = CMSSdk.VM_CMS_RealPlay(lHandle, pictureBox1.Handle, "ch1");
            if (returningValue1 < 0)
                MessageBox.Show("预览失败！");
            
        }
        //查询录像信息
        private void button3_Click(object sender, EventArgs e)
        {
            //通过时间查询录像文件、
            call = CallbackCAMFile;
            szSID= listBox2.SelectedValue.ToString();
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
            
            int index = dataGridView1.Rows.Add();
            dataGridView1.Rows[index].Cells[0].Value = FileName;
            dataGridView1.Rows[index].Cells[1].Value = FilePath;
            //dataGridView1.Rows[index].Cells[2].Value = lPort;

        }
        //录像播放
        private void button4_Click(object sender, EventArgs e)
        {

        }
        
        //设置报警
        private void button17_Click(object sender, EventArgs e)
        {
            string sendStr = "xxxx/10,"+textBox3.Text+"_"+textBox4.Text+"_1_5_上级临时报警器_1";
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }
        //授时
        private void button18_Click(object sender, EventArgs e)
        {
            string IP = textBox2.Text;
            string sendStr = "xxxx/9,"+DateTime.Now.Year+"_"
                + DateTime.Now.Month + "_" + DateTime.Now.Day 
                + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute 
                + "_" + DateTime.Now.Second + "_"+IP;
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }
    }
}
