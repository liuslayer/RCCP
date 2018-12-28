using PreviewDemo;
using System;
using System.Runtime.InteropServices;

namespace AlarmService
{
    public class TimeSet
    {
        public static class TimingSet
        {
            private static uint iLastErr = 0;
            private static string strErr;
            public static bool TimeSetBySuperior(string Year,string Month, string Day,string Hour,string Minute, string Second, string IP)
            {
                CHCNetSDK.NET_DVR_TIME m_struTimeCfg = new CHCNetSDK.NET_DVR_TIME();
                try
                {
                    m_struTimeCfg.dwYear = Convert.ToUInt16(Year);
                    m_struTimeCfg.dwMonth = Convert.ToUInt16(Month);
                    m_struTimeCfg.dwDay = Convert.ToUInt16(Day);
                    m_struTimeCfg.dwHour = Convert.ToUInt16(Hour);
                    m_struTimeCfg.dwMinute = Convert.ToUInt16(Minute);
                    m_struTimeCfg.dwSecond = Convert.ToUInt16(Second);
                    int m_UserID = -1;
                    if (MediaData.Device_UserID_Alarm.ContainsKey(IP))
                    {
                        m_UserID = MediaData.Device_UserID_Alarm[IP].UserID;
                    }
                    bool temp=TimimgSetByParam(m_struTimeCfg, m_UserID);
                    return temp;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            /// <summary>
            /// 设备手动校时
            /// </summary>
            /// <param name="m_struTimeCfg">时间结构体</param>
            /// <param name="m_lUserID">设备登录成功后返回的ID</param>
            /// <returns></returns>
            public static bool TimimgSetByParam(CHCNetSDK.NET_DVR_TIME m_struTimeCfg, Int32 m_lUserID)
            {
                Int32 nSize = Marshal.SizeOf(m_struTimeCfg);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    strErr = "NET_DVR_SET_TIMECFG failed, error code= " + iLastErr;
                    //设置时间失败，输出错误号 Failed to set the time of device and output the error code
                    Console.WriteLine(strErr);
                    return false;
                }
                else
                {
                    Console.WriteLine("校时成功！");
                    return true;
                }

                Marshal.FreeHGlobal(ptrTimeCfg);
            }
            /// <summary>
            /// 设备自动校时
            /// </summary>
            /// <param name="m_lUserID">设备登录成功后返回的ID</param>
            /// <returns></returns>
            public static bool TimingSetByAuto(Int32 m_lUserID)
            {
                CHCNetSDK.NET_DVR_TIME m_struTimeCfg = new CHCNetSDK.NET_DVR_TIME();
                m_struTimeCfg.dwYear = (uint)DateTime.Now.Year;
                m_struTimeCfg.dwMonth = (uint)DateTime.Now.Month;
                m_struTimeCfg.dwDay = (uint)DateTime.Now.Day;
                m_struTimeCfg.dwHour = (uint)DateTime.Now.Hour;
                m_struTimeCfg.dwMinute = (uint)DateTime.Now.Minute;
                m_struTimeCfg.dwSecond = (uint)DateTime.Now.Second;
                Int32 nSize = Marshal.SizeOf(m_struTimeCfg);
                IntPtr ptrTimeCfg = Marshal.AllocHGlobal(nSize);
                Marshal.StructureToPtr(m_struTimeCfg, ptrTimeCfg, false);

                if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_TIMECFG, -1, ptrTimeCfg, (UInt32)nSize))
                {
                    iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                    strErr = "NET_DVR_SET_TIMECFG failed, error code= " + iLastErr;
                    //设置时间失败，输出错误号 Failed to set the time of device and output the error code
                    Console.WriteLine(strErr);
                    return false;
                }
                else
                {
                    Console.WriteLine("校时成功！");
                    return true;
                }

                Marshal.FreeHGlobal(ptrTimeCfg);
            }
        }
    }
}
