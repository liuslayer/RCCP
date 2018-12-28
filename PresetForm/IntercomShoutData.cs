using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static PreviewDemo.CHCNetSDK;

namespace PresetForm
{
    public class IntercomShoutData
    {
        public struct IntercomShoutMapped
        {
            public string VideoIP;
            public int VideoChannel;
            public string ShoutIP;
            public int ShoutChannel;
            public string IntercomIP;
            public int IntercomChannel;
        }
        public static Dictionary<string, IntercomShoutMapped> Dic_IntercomShoutMapped = new Dictionary<string, IntercomShoutMapped>();
        public static string IP_Channel;
        private static VOICEDATACALLBACK VoiceCB;
        private static int m_lUserID;
        private static int lVoiceComHandle;//NET_DVR_StartVoiceCom或NET_DVR_StartVoiceCom_V30、NET_DVR_StartVoiceCom_MR或NET_DVR_StartVoiceCom_MR_V30的返回值 
        public static void IntercomShoutDataInit()
        {
            string SQL = "Select * From IntercomShoutList";
            DataTable dt = new DataTable();
            string path = "xwxayj_Local.mdb";
            dt = AccessDBHelper.dataTable(SQL, path);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string temp_IP_Channel = dt.Rows[i]["VideoIP"].ToString() + "," + dt.Rows[i]["VideoChannel"].ToString();
                if (!Dic_IntercomShoutMapped.ContainsKey(temp_IP_Channel))
                {
                    IntercomShoutMapped temp_IntercomShoutMapped = new IntercomShoutMapped();
                    temp_IntercomShoutMapped.VideoIP = dt.Rows[i]["VideoIP"].ToString();
                    temp_IntercomShoutMapped.VideoChannel = int.Parse(dt.Rows[i]["VideoChannel"].ToString());
                    temp_IntercomShoutMapped.ShoutIP = dt.Rows[i]["ShoutIP"].ToString();
                    temp_IntercomShoutMapped.ShoutChannel = int.Parse(dt.Rows[i]["ShoutChannel"].ToString());
                    temp_IntercomShoutMapped.IntercomIP = dt.Rows[i]["IntercomIP"].ToString();
                    temp_IntercomShoutMapped.IntercomChannel = int.Parse(dt.Rows[i]["IntercomChannel"].ToString());
                    Dic_IntercomShoutMapped.Add(temp_IP_Channel, temp_IntercomShoutMapped);
                }
            }
            VoiceCB = new VOICEDATACALLBACK(RVoiceCallBack);
        }
        public static void RVoiceCallBack(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, uint dwUser)
        {

        }
        /// <summary>
        /// 喊话开关
        /// </summary>
        /// <param name="SwitchParam">开关参数：0-关闭，1-打开</param>
        /// <param name="IP"></param>
        /// <param name="Nchannel"></param>
        public static bool ShoutSwitch(int SwitchParam, string IP, int Nchannel, int m_lUserID)
        {
            //配置数据库中包含该喊话配置信息
            if (Dic_IntercomShoutMapped!=null&&Dic_IntercomShoutMapped.ContainsKey(IP))
            {
                //命令参数为打开
                if (SwitchParam == 1)
                {
                    //打开相应喊话通道
                    lVoiceComHandle = NET_DVR_StartVoiceCom(m_lUserID, VoiceCB, 0);
                    if (lVoiceComHandle >= 0)
                    {
                        Console.WriteLine("打开喊话成功");
                        return true;
                    }
                    else
                    {
                        uint Error = NET_DVR_GetLastError();
                        return false;
                    }
                }
                //命令参数为关闭
                else
                {
                    //关闭相应喊话通道
                    bool temp_bool = NET_DVR_StopVoiceCom(lVoiceComHandle);
                    if (temp_bool == true)
                    {
                        Console.WriteLine("关闭喊话成功");
                    }
                    else
                    {
                        uint Error = NET_DVR_GetLastError();
                    }
                    //关闭相应喊话通道
                    return temp_bool;
                }
            }
            else//配置数据库中未包含相关喊话配置信息，则直接使用传入的IP和通道号进行喊话
            {
                if (SwitchParam == 1)
                {
                    //打开相应喊话通道
                    lVoiceComHandle = NET_DVR_StartVoiceCom(m_lUserID, VoiceCB, 0);
                    if (lVoiceComHandle >= 0)
                    {
                        Console.WriteLine("打开喊话成功");
                        return true;
                    }
                    else
                    {
                        uint Error = NET_DVR_GetLastError();
                        return false;
                    }
                }
                //命令参数为关闭
                else
                {
                    bool temp_bool = NET_DVR_StopVoiceCom(lVoiceComHandle);
                    if (temp_bool == true)
                    {
                        Console.WriteLine("关闭喊话成功");
                    }
                    else
                    {
                        uint Error = NET_DVR_GetLastError();
                    }
                    //关闭相应喊话通道
                    return temp_bool;
                }
            }
        }
    }
}
