using AlarmService;
using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using TurntableControlInterface;
using static ExternalDataCentreService.ControlCommandData;

namespace ExternalDataCentreService
{
    public class CommunicationClass
    {
        //Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
       
        //建立socket服务器监听上级发送的命令
        Socket sSocket1;
        Socket serverSocket1;
        Socket sSocket2;
        Socket serverSocket2;

        //建立socket客户端发送上级中心报警信息等
        //Socket clientSocket1;

        //业务协同服务
        public static TcpClient tcp1;
        public static NetworkStream stream1;
        //数据服务
        public static TcpClient tcp2;
        public static NetworkStream stream2;

        int tmpSpeed;
        Guid tmpGuid;
        int VideoType = 1;
        static SectorScanData tmpSectorScanData = new SectorScanData();

        //接收数据包事件
        public delegate void ReceiveDataPackageDelegate(string message);
        public event ReceiveDataPackageDelegate ReceiveDataPackageEvent;

        public void Start()
        {
            #region 建立socket服务器监听上级发送的命令
            string host = ConfigurationManager.AppSettings["ListenIP"];
            int port1 = int.Parse(ConfigurationManager.AppSettings["ListenPort1"]);
            int port2 = int.Parse(ConfigurationManager.AppSettings["ListenPort2"]);
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe1 = new IPEndPoint(ip, port1);
            sSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket1.Bind(ipe1);
            sSocket1.Listen(0);
            IPEndPoint ipe2 = new IPEndPoint(ip, port2);
            sSocket2 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket2.Bind(ipe2);
            sSocket2.Listen(0);

            Thread th1 = new Thread(new ThreadStart(ReveiceData1));
            th1.IsBackground = true;
            th1.Start();
            Thread th2 = new Thread(new ThreadStart(ReveiceData2));
            th2.IsBackground = true;
            th2.Start();
            #endregion

            #region 与业务协同服务建立连接，接收业务协同返回的消息
            tcp1 = new TcpClient();
            string BCServer_IP = ConfigurationManager.AppSettings["BCServer_IP"];
            int BCServer_Port1 = int.Parse(ConfigurationManager.AppSettings["BCServer_Port"]);
            try
            {
                tcp1.Connect(BCServer_IP, BCServer_Port1);
                stream1 = tcp1.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine("外部数据中心连接业务协同服务失败。错误信息:"+ex.ToString());
            }
            Thread th3 = new Thread(new ThreadStart(ReveiveData3));
            th3.IsBackground = true;
            th3.Start();
            #endregion
            #region 与数据中心服务建立连接，接收数据中心返回的消息
            tcp2 = new TcpClient();
            string DCServer_IP = ConfigurationManager.AppSettings["DCServer_IP"];
            int DCServer_Port = int.Parse(ConfigurationManager.AppSettings["DCServer_Port"]);
            try
            {
                tcp2.Connect(DCServer_IP, DCServer_Port);
                stream2 = tcp2.GetStream();
            }
            catch (Exception ex)
            {
                Console.WriteLine("外部数据中心连接数据中心服务失败。错误信息:" + ex.ToString());
            }
            Thread th4 = new Thread(new ThreadStart(ReveiveData4));
            th4.IsBackground = true;
            th4.Start();
            #endregion

            #region 连接上级中心,向上级发送消息
            //IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_IP"]);
            //int BCSimulateSoftware_Port = int.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_Port"]);
            //IPEndPoint ipe3 = new IPEndPoint(ipAddress, BCSimulateSoftware_Port);
            //Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //try
            //{ clientSocket1.Connect(ipe3); }
            //catch { }
            #endregion
        }
        //接收数据中心返回的消息（设备实时信息）
        private void ReveiveData4()
        {
            if (!tcp2.Connected) return;
            stream2 = tcp2.GetStream();
            byte[] data;
            while (true)
            {
                try
                {
                    data = new byte[1024];
                    int bytes = stream2.Read(data, 0, data.Length);
                    string receiveData = Encoding.UTF8.GetString(data).Replace("\r\n", "");
                    data = Encoding.UTF8.GetBytes(receiveData);
                    //显示
                    ReceiveDataPackageEvent(receiveData);

                    IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_IP"]);
                    int BCSimulateSoftware_Port = int.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_Port"]);
                    IPEndPoint ipe3 = new IPEndPoint(ipAddress, BCSimulateSoftware_Port);
                    Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    clientSocket1.Connect(ipe3);
                    clientSocket1.Send(data);
                }
                catch { }
            }
        }

        //接收业务协同返回的消息（报警信息）
        private void ReveiveData3()
        {
            if (!tcp1.Connected) return;
            stream1 = tcp1.GetStream();
            byte[] data;
            string receiveData;
            while (true)
            {
                try
                {
                    data = new byte[1024 * 100];
                    int bytes = stream1.Read(data, 0, data.Length);
                    receiveData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
                    //转换成ReceiveDataType，判断数据源的服务类型
                    ReceiveDataType d = JsonConvert.DeserializeObject<ReceiveDataType>(receiveData);
                    switch (d.SType)
                    {
                        //实时信息
                        case ServerType.DeviceRealTimeData:

                            break;
                            //报警信息
                        case ServerType.Alarm:

                            string sendStr = "10/"+ JsonConvert.SerializeObject(d.DataPackage.alarmmessage);
                            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
                            IPAddress ipAddress = IPAddress.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_IP"]);
                            int BCSimulateSoftware_Port = int.Parse(ConfigurationManager.AppSettings["BCSimulateSoftware_Port"]);
                            IPEndPoint ipe3 = new IPEndPoint(ipAddress, BCSimulateSoftware_Port);
                            Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                            clientSocket1.Connect(ipe3);
                            clientSocket1.Send(sendBytes);
                            break;
                        case ServerType.Intercom:

                            break;
                    }

                    Console.WriteLine(receiveData);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private void ReveiceData1()
        {
            while (true)
            {
                try
                {
                    serverSocket1 = sSocket1.Accept();
                    string recStr = "";
                    byte[] recByte = new byte[4096];
                    int bytes = serverSocket1.Receive(recByte, recByte.Length, 0);
                    recStr += Encoding.UTF8.GetString(recByte, 0, bytes);

                    //显示
                    ReceiveDataPackageEvent(recStr);

                    string[] str1 = recStr.Split('/');
                    if (str1.Length != 2) return;
                    string[] str2 = str1[1].Split(',');

                    //各种数据解析
                    int i_Action = -1;
                    string message = "";
                    byte[] b;
                    if (int.Parse(str2[0]) >= 1 && int.Parse(str2[0]) < 9)
                    {
                        switch (str2[0])
                        {
                            //八方位、聚焦、视场
                            case "1":
                                tmpGuid = new Guid(str2[1]);
                                tmpSpeed = int.Parse(str2[4]);
                                switch (str2[3])
                                {
                                    case "0":
                                        i_Action = (int)HDCommand.DirectionStop;
                                        break;
                                    //左上
                                    case "1":
                                        //转发
                                        i_Action = (int)HDCommand.LeftUp;
                                        break;
                                    //上
                                    case "2":
                                        //转发
                                        i_Action = (int)HDCommand.Up;
                                        break;
                                    //右上
                                    case "3":
                                        //转发
                                        i_Action = (int)HDCommand.RightDown;
                                        break;
                                    //左
                                    case "4":
                                        //转发
                                        i_Action = (int)HDCommand.Left;
                                        break;
                                    //初始位
                                    case "5":
                                        //转发
                                        i_Action = (int)HDCommand.InitialPoint;
                                        break;
                                    //右
                                    case "6":
                                        //转发
                                        i_Action = (int)HDCommand.Right;
                                        break;
                                    //左下
                                    case "7":
                                        //转发
                                        i_Action = (int)HDCommand.LeftUp;
                                        break;
                                    //下
                                    case "8":
                                        //转发
                                        i_Action = (int)HDCommand.Down;
                                        break;
                                    //右下
                                    case "9":
                                        //转发
                                        i_Action = (int)HDCommand.RightDown;
                                        break;
                                    //视场-
                                    case "10":
                                        i_Action = (int)CCDCommand.CCD_TurnShort;
                                        //转发
                                        break;
                                    //视场- 停 
                                    case "11":
                                        i_Action = (int)CCDCommand.CCD_TurnShortStop;
                                        break;
                                    //视场+
                                    case "12":
                                        //转发
                                        i_Action = (int)CCDCommand.CCD_TurnLong;
                                        break;
                                    //视场+ 停 
                                    case "13":
                                        i_Action = (int)CCDCommand.CCD_TurnLongStop;
                                        break;
                                    //焦距-
                                    case "14":
                                        //转发
                                        i_Action = (int)CCDCommand.CCD_FocusShort;
                                        break;
                                    //焦距- 停
                                    case "15":
                                        i_Action = (int)CCDCommand.CCD_FocusShortStop;
                                        break;
                                    //焦距+
                                    case "16":
                                        //转发
                                        i_Action = (int)CCDCommand.CCD_FocusLong;
                                        break;
                                    //焦距+ 停
                                    case "17":
                                        i_Action = (int)CCDCommand.CCD_FocusLongStop;
                                        break;
                                }
                                if (Convert.ToInt32(str2[2]) >= 0 && Convert.ToInt32(str2[2]) < 10)
                                {
                                    InterfaceControl.HDControl(tmpGuid, i_Action, tmpSpeed, 0, null);
                                }
                                else if (Convert.ToInt32(str2[2]) > 10)
                                {
                                    VideoType = int.Parse(str2[1]);
                                    if (VideoType == 1)
                                    {
                                        InterfaceControl.CCDControl(tmpGuid, i_Action, tmpSpeed, 0, null);
                                    }
                                    else
                                    {
                                        InterfaceControl.IRControl(tmpGuid, i_Action, 0, 0, null);
                                    }
                                }
                                Control_Command.GetStateData(tmpGuid);
                                break;
                            //扇扫开
                            case "4":
                                tmpGuid = new Guid(str2[1]);
                                int i_HorizontalSt = Convert.ToInt32(str2[2]);
                                int i_HorizontalEnd = Convert.ToInt32(str2[3]);
                                int i_Hspeed = Convert.ToInt32(str2[4]);
                                int i_VerticalSt = Convert.ToInt32(str2[5]);
                                int i_VerticalEnd = Convert.ToInt32(str2[6]);
                                int i_Vspeed = Convert.ToInt32(str2[7]);
                                //0,1,     2         3          4         5        6          7
                                //4,设ID,水平起点、水平终点、水平速度、俯仰起点、俯仰终点、俯仰速度
                                InterfaceControl.SectorScanOpen(tmpGuid, i_HorizontalSt, i_HorizontalEnd, i_Hspeed, i_VerticalSt, i_VerticalEnd, i_Vspeed);
                                break;
                            //扇扫关
                            case "5":
                                tmpGuid = new Guid(str2[1]);
                                InterfaceControl.SectorScanOff(tmpGuid);
                                break;
                            //预置位调用
                            case "6":
                                TurntablePresetData tmpPresetData = new TurntablePresetData();
                                tmpPresetData.VideoGuid = new Guid(str2[1]);
                                tmpPresetData.PresetName = str2[2];
                                //0   1    2
                                //6,设ID,预置位1
                                InterfaceControl.SetPreset(tmpPresetData);
                                break;
                            //预置位轮巡开
                            case "7":
                                break;
                            //预置位轮巡关
                            case "8":
                                break;

                        }
                    }
                    else if (int.Parse(str2[0]) >= 9 && int.Parse(str2[0]) < 12)
                    {
                        switch (str2[0])
                        {
                            //设备授时
                            case "9":
                                message = "TimeSet/" + str2[1] + "\r\n";
                                break;
                            //报警设置
                            case "10":
                                message = "Alertor/" + str2[1] + "\r\n";
                                break;
                            //叠加字符
                            case "11":
                                message = "StringSet/" + str2[1] + "\r\n";
                                break;
                        }
                        b = Encoding.UTF8.GetBytes(message);
                        if (!tcp1.Connected)
                        {
                            tcp1 = new TcpClient();
                            string BCServer_IP = ConfigurationManager.AppSettings["BCServer_IP"];
                            int BCServer_Port1 = int.Parse(ConfigurationManager.AppSettings["BCServer_Port"]);
                            try
                            {
                                tcp1.Connect(BCServer_IP, BCServer_Port1);
                                stream1 = tcp1.GetStream();
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("外部数据中心连接业务协同服务失败。错误信息:" + ex.ToString());
                            }
                        }
                        stream1.Write(b, 0, b.Length);
                    }
                    else if (int.Parse(str2[0]) >= 12)
                    {
                        switch (str2[0])
                        {
                            //流媒体列表
                            case "12":
                                List<CameraList> cameraList;
                                CameraListRepository camera = new CameraListRepository();
                                cameraList = camera.GetList();
                                string str = JsonConvert.SerializeObject(cameraList);
                                serverSocket1.Send(Encoding.UTF8.GetBytes(str));
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("外部数据中心发送数据失败。错误信息：" + ex.ToString());
                }

            }
        }
        private void ReveiceData2()
        {
            try
            {
                while (true)
                {
                    serverSocket2 = sSocket2.Accept();
                    string recStr = "";
                    byte[] recByte = new byte[4096];
                    int bytes = serverSocket2.Receive(recByte, recByte.Length, 0);
                    recStr += Encoding.UTF8.GetString(recByte, 0, bytes);
                    //各种数据解析
                    try
                    {
                        switch (recStr)
                        {
                            //字符叠加
                            case "14":
                                //转发
                                //stream1.Write(recByte, 0, recByte.Length);
                                //显示
                                ReceiveDataPackageEvent(recStr);
                                break;
                            //上
                            case "2":
                                //转发
                                //stream1.Write(recByte, 0, recByte.Length);
                                //显示
                                ReceiveDataPackageEvent(recStr);
                                break;
                            case "3":

                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("外部数据中心发送数据失败。错误信息：" + ex.ToString());
                    }

                }

            }
            catch (Exception ex) { Console.WriteLine("外部数据中心接收数据失败。错误信息：" + ex.ToString()); }
        }
    }
}
