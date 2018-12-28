using AccessOperation;
using System;

namespace AlarmService
{
    public class SetAlarm
    {
        /// <summary>
        /// 设置临时报警
        /// </summary>
        /// <param name="str"></param>
        public static void SetTempAlarm(string[] str)
        {
            try
            {
                int m_UserID = -1;
                if (MediaData.Device_UserID_Alarm.ContainsKey(str[0]))
                {
                    m_UserID = MediaData.Device_UserID_Alarm[str[0]].UserID;
                }
                AlarmSetSDK.AlarmSet(str[0],int.Parse(str[1]),m_UserID, int.Parse(str[2]), int.Parse(str[3]), str[4],null,0,0);
            }
            catch 
            {
            }
        }
        public void SetAlertorAlarm()
        {

        }
        public void AlarmReview(string ip,int nChannel,IntPtr Hwnd)
        {
            BF_Video_SDK.XW_DVR_RealPlay(ip, nChannel, Hwnd);
        }

    }
}
