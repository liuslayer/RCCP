using Client.Entities;
using Client.Entities.BCEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DeviceBaseData
{
    public class CommunicationClass
    {
        public delegate void AlarmDelegate(object obj);
        public static event AlarmDelegate AlarmEvent;//报警事件

        public delegate void ServiceStatusDelegate(string message);
        public static event ServiceStatusDelegate ServiceStatusEvent;//服务状态事件

        public static TcpClient tcp1;//业务协同服务
        public static NetworkStream stream1;//业务协同服务

        public static TcpClient tcp2;//数据中心服务
        public static NetworkStream stream2;//数据中心服务

        public static TcpClient tcp3;//基础模块服务
        public static NetworkStream stream3;//基础模块服务

        
        

        /// <summary>
        /// 通信初始化
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            tcp1 = new TcpClient();
           
            tcp2 = new TcpClient();

            tcp3 = new TcpClient();
            try
            {
                string ServerIP =System.Configuration.ConfigurationManager.AppSettings["ServerIP"];
                int BCServerPort=int.Parse(System.Configuration.ConfigurationManager.AppSettings["BCServer"]);
                int DCServerPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["DCServer"]);
                int BMMSServerPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["BMMSServer"]);

                tcp1.Connect(ServerIP, BCServerPort);//应该从配置文件读取服务器ip
                stream1 = tcp1.GetStream();
                tcp2.Connect(ServerIP, DCServerPort);
                stream2 = tcp2.GetStream();
                tcp3.Connect(ServerIP, BMMSServerPort);
                stream3 = tcp3.GetStream();
                if (tcp1.Connected)
                {
                    Console.WriteLine("业务协同服务连接成功！");
                    Thread th = new Thread(new ThreadStart(ReveiveData1));
                    th.IsBackground = true;
                    th.Start();
                }
                if (tcp2.Connected)
                {
                    Console.WriteLine("数据中心服务连接成功！");
                    Thread th = new Thread(new ThreadStart(ReveiveData2));
                    th.IsBackground = true;
                    th.Start();
                }
               if(tcp3.Connected)
                {
                    Console.WriteLine("基础模块管理连接成功！");
                    Thread th = new Thread(new ThreadStart(ReveiveData3));
                    th.IsBackground = true;
                    th.Start();
                }
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
           
        }

        /// <summary>
        /// 接收业务协同服务返回信息
        /// </summary>
        private static void ReveiveData1()
        {
            if (!tcp1.Connected) return;
            stream1 = tcp1.GetStream();
            byte[] data ;
            string receiveData;
            while (true)
            {
                try
                {
                    data = new Byte[1024 * 100];
                    Int32 bytes = stream1.Read(data, 0, data.Length);
                    receiveData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
                    //转换成ReceiveDataType，判断数据源的服务类型
                    ReceiveDataType d = JsonConvert.DeserializeObject<ReceiveDataType>(receiveData);

                    switch(d.SType)
                    {
                        case ServerType.DeviceRealTimeData:
                            
                            break;
                        case ServerType.Alarm:
                            AlarmEvent(d.DataPackage);
                            break;
                        case ServerType.Intercom:

                            break;
                    }
                    Console.WriteLine(receiveData);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //服务器重连
                    Init();
                }
            }
        }
        

        /// <summary>
        /// 接收数据中心服务返回信息
        /// </summary>
        private static void ReveiveData2()
        {
            //if (!tcp2.Connected) return;
            //stream2 = tcp2.GetStream();
            //Byte[] data = new Byte[256];
            //string receiveData;
            //while (true)
            //{
            //    Int32 bytes = stream2.Read(data, 0, data.Length);
            //    receiveData = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
            //    Console.WriteLine(receiveData);
            //}
        }

        private static void ReveiveData3()
        {
            if (!tcp3.Connected) return;
            stream3 = tcp3.GetStream();
            byte[] data = new byte[256];
            string receiveData="";
            while (true)
            {
                try
                {
                    int bytes = stream3.Read(data, 0, data.Length);
                    receiveData = Encoding.UTF8.GetString(data, 0, bytes);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    //服务器重连
                    Init();
                }
                if (receiveData == "") continue;
                //string message = "";
                //string[] str2 = Regex.Split(receiveData, "\r\n");
                //string[] str = receiveData.Split(new char[] { '_' });
                //try
                //{
                    //if (str[1] != "False")
                    //{
                    //    switch (str[0])
                    //    {
                    //        case "OMServer":
                    //            message = "运维服务已停止！";
                    //            break;
                    //        case "LogServer":
                    //            message = "日志服务已停止！";
                    //            break;
                    //        case "BCServer":
                    //            message = "业务协同服务已停止！";
                    //            break;
                    //        case "DCServer":
                    //            message = "数据中心服务已停止！";
                    //            break;
                    //        case "MailServer":
                    //            message = "文电服务已停止！";
                    //            break;
                    //        case "BMMSServer":
                    //            message = "基础模块管理服务已停止！";
                    //            break;
                    //    }
                        Console.WriteLine(receiveData);
                        ServiceStatusEvent?.Invoke(receiveData);
                //    }
                //}
                //catch { }
            }
        }
        private static void ShowForm()
        {
            

        }
    }
}
