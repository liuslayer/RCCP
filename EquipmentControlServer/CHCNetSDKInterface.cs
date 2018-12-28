using PreviewDemo;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class CHCNetSDKInterface
    {
        public static List<CameraList> cameraList;//摄像机设备信息
        public static List<StreamMediaList> streamMediaList;//流媒体设备信息
        public static CameraListRepository CameraList = new CameraListRepository();//摄像机设备信息SQL
        public static StreamMediaListRepository StreamMediaList = new StreamMediaListRepository();//流媒体设备信息SQL
        public static Dictionary<string, int> Device_UserID = new Dictionary<string, int>();
        public static void HK_EquipmentInit()
        {
            DataInit();//数据初始化
            Init();//海康初始化
            LogInit();
        }

        public static void DataInit()
        {
            cameraList = CameraList.GetList();
            streamMediaList = StreamMediaList.GetList();
        }

        public static bool Init()
        {
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                Console.WriteLine("NET_DVR_Init error!");
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void LogInit()
        {
            for (int i = 0; i < streamMediaList.Count; i++)
            {
                string IPAddress = streamMediaList[i].VideoIP; //设备IP地址或者域名
                int PortNumber = streamMediaList[i].Port;//设备服务端口号
                string UserName = streamMediaList[i].UserName;//设备登录用户名
                string Password = streamMediaList[i].PassWord;//设备登录密码
                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
                if (m_lUserID < 0)
                {

                }
                else
                {
                    if(!Device_UserID.Keys.Contains(IPAddress))
                        Device_UserID.Add(IPAddress, m_lUserID);
                }
            }
        }


        public static void SetTurntable(ControlData tmp_ControlData)
        {
            //Device_UserID[]
            switch (tmp_ControlData.iAction)
            {
                case (int)HDCommand.Up:
                    //CHCNetSDK.NET_DVR_PTZControlWithSpeed_Other();
                    break;
                case (int)HDCommand.Down:
                    break;
                case (int)HDCommand.Left:
                    break;
                case (int)HDCommand.Right:
                    break;
                case (int)HDCommand.LeftUp:
                    break;
                case (int)HDCommand.LeftDown:
                    break;
                case (int)HDCommand.RightUp:
                    break;
                case (int)HDCommand.RightDown:
                    break;
                case (int)HDCommand.DirectionStop:
                    break;
            }
            
        }

    }
}
