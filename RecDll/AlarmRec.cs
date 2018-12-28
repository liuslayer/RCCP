using DeviceBaseData;
using PreviewDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecDll
{
    public class AlarmRec
    {
        //设备登录返回值—[string:IP]
        public static Dictionary<string, int> userIDList = new Dictionary<string, int>();

        //设备预览返回值—[string:IP+","+Channel+"_3"]
        public static Dictionary<string, int> RealHandleList = new Dictionary<string, int>();

        //录像文件存储路径
        public static string path = @"d:\";

        /// <summary>
        /// 设备登录
        /// </summary>
        public static void LogIn()
        {
            //登录设备
            for (int i = 0; i < Class1.streamMediaList.Count; i++)
            {
                string IPAddress = Class1.streamMediaList[i].VideoIP; //设备IP地址或者域名
                int PortNumber = Class1.streamMediaList[i].Port;//设备服务端口号
                string UserName = Class1.streamMediaList[i].UserName;//设备登录用户名
                string Password = Class1.streamMediaList[i].PassWord;//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
                if (m_lUserID < 0)
                {

                }
                else
                {
                    //登录成功
                    Console.WriteLine("Login Success!");
                    if (!userIDList.Keys.Contains(IPAddress))
                        userIDList.Add(IPAddress, m_lUserID);
                }
            }
        }

        /// <summary>
        /// 设备登出
        /// </summary>
        public static void Logout()
        {
            foreach (int m_lUserID in userIDList.Values)
            {
                //注销登录 Logout the device
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
            }
        }
        /// <summary>
        /// 开启录像
        /// </summary>
        /// <param name="strDeviceID"></param>
        /// <returns></returns>
        public static int Rec(string strDeviceID)
        {
            Guid DeviceID = new Guid(strDeviceID);
            Client.Entities.CameraList device = Class1.cameraList.Find(
                delegate (Client.Entities.CameraList camera)
                {
                    return camera.DeviceID.Equals(DeviceID);
                }
                );
            if (device == null) return -1;

            Client.Entities.StreamMediaList streamMedia = Class1.streamMediaList.Find(
                   delegate (Client.Entities.StreamMediaList sm)
                   {
                       return sm.DeviceID.Equals(device.StreamMedia_DeviceID);

                   });
            if (streamMedia == null) return -1;
            string IP = streamMedia.VideoIP;
            int Channel = device.VideoChannel;
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //lpPreviewInfo.hPlayWnd = handle;//预览窗口
            lpPreviewInfo.lChannel = Channel;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            if (!userIDList.ContainsKey(IP)) return -1;
            int m_lUserID = userIDList[IP];
            //打开预览 Start live view 
            int m_lRealHandle = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
            if (m_lRealHandle < 0)
            {

            }
            else
            {
                //录像保存路径和文件名 the path and file name to save
                string sVideoFileName;
                DateTime dt = DateTime.Now;
                sVideoFileName = IP + "_" + Channel +dt.ToString("yyyyMMddHHmmss") + "报警.mp4";
                //预览成功
                //强制I帧 Make a I frame
                int lChannel = Channel; //通道号 Channel number
                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel);

                //开始录像 Start recording
                if (CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle, path + sVideoFileName))
                {
                    RealHandleList.Add(IP + "," + Channel+"_3", m_lRealHandle);
                    RecInfo info = new RecInfo(sVideoFileName, dt, "报警录像");
                    RecDataClass.recInfo.Add(IP + "," + Channel + "_3", info);

                    //写入数据库
                    RecFileList recFileList = new RecFileList();
                    recFileList.CameraID = strDeviceID;
                    recFileList.RecName = sVideoFileName;
                    recFileList.RecRecFile = path + sVideoFileName;
                    recFileList.RecStartDate = dt.ToString("yyyy-MM-dd");
                    recFileList.RecStartTime = dt.ToString("HH:mm:ss");
                    recFileList.RecType = "3";
                    RecFileClass.AddStartTime(recFileList);
                }
                else
                {
                    return -1;
                }
            }
            return m_lRealHandle;
        }

        public static void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }

        /// <summary>
        /// 停止录像
        /// </summary>
        public static bool StopRec(object strDeviceID)
        {
            Guid DeviceID = (Guid)strDeviceID;
            Client.Entities.CameraList device = Class1.cameraList.Find(
                delegate (Client.Entities.CameraList camera)
                {
                    return camera.DeviceID.Equals(DeviceID);
                }
                );
            if (device == null) return false;

            Client.Entities.StreamMediaList streamMedia = Class1.streamMediaList.Find(
                   delegate (Client.Entities.StreamMediaList sm)
                   {
                       return sm.DeviceID.Equals(device.StreamMedia_DeviceID);

                   });
            if (streamMedia == null) return false;
            string IPChannel = streamMedia.VideoIP + "," + device.VideoChannel + "_3";
            if (!RealHandleList.ContainsKey(IPChannel)) return false;
            int m_lRealHandle = RealHandleList[IPChannel];
            DateTime dt = DateTime.Now;
            if (CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle))
            {
                //停止预览 Stop live view 
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                //从预览列表中移除
                RealHandleList.Remove(IPChannel);
                //将录像结束信息写入数据库
                RecFileClass.AddEndTime(RecDataClass.recInfo[IPChannel].Name, dt.ToString("yyyy-MM-dd"), dt.ToString("HH:mm:ss"));
                //移除RecInfo存储信息
                RecDataClass.recInfo.Remove(IPChannel);
                return true;
            }
            return false;
        }
    }
}
