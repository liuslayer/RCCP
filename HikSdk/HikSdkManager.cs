using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HikSdk
{
    /// <summary>
    /// 海康SDK封装类
    /// </summary>
    public class HikSdkManager
    {
        private static HikSdkManager _hikSdkManager;
        private Dictionary<string, UserID_m_lAlarmHandle> Device_UserID_Alarm = new Dictionary<string, UserID_m_lAlarmHandle>();//设备登录返回值—[string:IP]
        private static volatile object _lock = new object();

        public struct UserID_m_lAlarmHandle
        {
            public readonly int UserID;
            public int m_lAlarmHandle;
            public readonly CHCNetSDK.NET_DVR_DEVICEINFO_V30 deviceInfo;

            public UserID_m_lAlarmHandle(int UserID, int m_lAlarmHandle, CHCNetSDK.NET_DVR_DEVICEINFO_V30 deviceInfo)
            {
                this.UserID = UserID;
                this.m_lAlarmHandle = m_lAlarmHandle;
                this.deviceInfo = deviceInfo;
            }
        }

        private HikSdkManager()
        {
            Init();//海康初始化
            Login();//设备登录
        }

        /// <summary>
        /// 创建海康SDK管理器单例
        /// </summary>
        /// <returns></returns>
        public static HikSdkManager CreateInstance()
        {
            if (_hikSdkManager == null)
            {
                lock (_lock)
                {
                    if (_hikSdkManager == null)
                    {
                        _hikSdkManager = new HikSdkManager();
                    }
                }
            }
            return _hikSdkManager;
        }

        /// <summary>
        /// 返回海康userID键值对
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, UserID_m_lAlarmHandle> GetUserIDDic()
        {
            Login();//尝试登录尚未登录成功的设备
            return Device_UserID_Alarm;
        }

        private void Init()
        {
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (!m_bInitSDK)
            {
                throw new Exception("海康设备初始化失败!");
            }
        }

        List<Guid> noLoginStreamMediaList = null;//尚未登录成功的流媒体设备
        private void Login()
        {
            //登录设备
            StreamMediaListRepository repo = new StreamMediaListRepository();
            List<StreamMediaList> streamMediaList = repo.GetList();
            if (noLoginStreamMediaList == null)
            {
                noLoginStreamMediaList = streamMediaList.Select(_ => _.DeviceID).ToList();
            }
            streamMediaList.FindAll(f=> noLoginStreamMediaList.Contains(f.DeviceID)).ForEach(_ =>
            {
                CHCNetSDK.NET_DVR_DEVICEINFO_V30 deviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(_.VideoIP, _.Port, _.UserName, _.PassWord, ref deviceInfo);
                if (m_lUserID >= 0)
                {
                    //登录成功
                    UserID_m_lAlarmHandle temp_UserID_m_lAlarmHandle = new UserID_m_lAlarmHandle(m_lUserID, -1, deviceInfo);
                    if (!Device_UserID_Alarm.Keys.Contains(_.VideoIP))
                    {
                        Device_UserID_Alarm.Add(_.VideoIP, temp_UserID_m_lAlarmHandle);
                    }
                    noLoginStreamMediaList.Remove(_.DeviceID);
                }
            });
        }
    }
}
