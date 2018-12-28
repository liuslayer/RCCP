using PreviewDemo;
using System;
using System.Collections.Generic;

namespace AlarmService
{
    public class Rec_SDK
    {
        //正在录像的自动录像信息
        public static Dictionary<string, RecInfo> recInfo=new Dictionary<string, RecInfo>();
        public static string path = @"d:\";

        //设备预览返回值—[string:IP+","+Channel+"_2"]
        public static Dictionary<string, int> RealHandleList = new Dictionary<string, int>();
        /// <summary>
        /// 开启录像
        /// </summary>
        /// <param name="IP"></param>
        /// <param name="Channel"></param>
        /// <returns></returns>
        public static int Auto_Rec(string IP, int Channel)
        {
            string errorInfo = "";
            CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
            //lpPreviewInfo.hPlayWnd = handle;//预览窗口
            lpPreviewInfo.lChannel = Channel;//预te览的设备通道
            lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
            lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
            lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
            lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数

            CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
            IntPtr pUser = new IntPtr();//用户数据

            if (!MediaData.Device_UserID_Alarm.ContainsKey(IP)) return -1;
            int m_lUserID = MediaData.Device_UserID_Alarm[IP].UserID;
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
                sVideoFileName = IP + "_" + Channel + dt.ToString("yyyyMMddHHmmss") + "自动.mp4";
                //预览成功
                //强制I帧 Make a I frame
                int lChannel = Channel; //通道号 Channel number
                CHCNetSDK.NET_DVR_MakeKeyFrame(m_lUserID, lChannel);

                //开始录像 Start recording
                if (CHCNetSDK.NET_DVR_SaveRealData(m_lRealHandle, path + sVideoFileName))
                {
                    RealHandleList.Add(IP + "," + Channel , m_lRealHandle);
                    RecInfo info = new RecInfo(sVideoFileName, dt, "自动录像");
                    recInfo.Add(IP + "," + Channel, info);

                    //写入数据库
                }
                else
                {
                    return -1;
                }
            }
            return m_lRealHandle;
        }
        public static int StopRec(string IPChannel)
        {
            if (!RealHandleList.ContainsKey(IPChannel)) return -1;
            int m_lRealHandle = RealHandleList[IPChannel];
            DateTime dt = DateTime.Now;
            if (CHCNetSDK.NET_DVR_StopSaveRealData(m_lRealHandle))
            {
                //停止预览 Stop live view 
                CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                //从预览列表中移除
                RealHandleList.Remove(IPChannel);
                //将录像结束信息写入数据库
                return 1;
            }
            return -1;
        }
        public static void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
    }

    public class RecInfo
    {
        public string Name;//名称
        public DateTime DT;//开始时间
        public string RecType;//录像模式

        public RecInfo() { }
        public RecInfo(string name, DateTime dt, string recType)
        {
            Name = name;
            DT = dt;
            RecType = recType;
        }
    }
}
