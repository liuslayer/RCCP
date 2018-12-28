using ClassLibrary1;
using DeviceBaseData;
using PreviewDemo;
using System;
using System.Windows;

namespace Client.RealPlay
{
    public class RealPlayVideo
    {
        public delegate int ControlDelegate(string strDeviceID, int index, ref string IP, ref int nChannel, ref int m_lUserID, ref int m_lRealHandle);
        /// <summary>
        /// 视频预览
        /// </summary>
        /// <param name="strDeviceID"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static int Open(string strDeviceID,int index,ref string IP,ref int nChannel,ref int m_lUserID,ref int m_lRealHandle)
        {
            if (Form1.videoboxs[index].InvokeRequired)
            {
                ControlDelegate d = Open;
                Form1.videoboxs[index].Invoke(d, strDeviceID,index ,IP,nChannel,m_lUserID,m_lRealHandle);
            }
            else
            {
                Guid DeviceID = new Guid(strDeviceID);
                Entities.CameraList device = Class1.cameraList.Find(
                    delegate (Entities.CameraList camera)
                    {
                        return camera.DeviceID.Equals(DeviceID);
                    }
                    );
                if (device == null) return -1;
                Entities.StreamMediaList streamMedia = Class1.streamMediaList.Find(
                    delegate (Entities.StreamMediaList sm)
                    {
                        return sm.DeviceID.Equals(device.StreamMedia_DeviceID);

                    });
                if (streamMedia == null) return -1;
                IP = streamMedia.VideoIP;
                nChannel = device.VideoChannel;
                string mediaMedia=System.Configuration.ConfigurationManager.AppSettings["MediaStream"];
               if(mediaMedia=="1")
                {
                    #region 流媒体预览
                    Entities.StreamServerList server = Class1.streamServerList.Find(
                        delegate (Entities.StreamServerList ss)
                        {
                            return ss.DeviceID.Equals(streamMedia.StreamServerID);
                        }
                        );
                    if (server == null) return -1;
                    //视频预览
                    VMSdk.VM_CLIENT_CONFIG_VMSTREAMINGSER config = new VMSdk.VM_CLIENT_CONFIG_VMSTREAMINGSER();
                    config.sSID = device.Stream_MainID.ToString();
                    config.sDeviceAddress = server.StreamServerIP;
                    if(SearchRealPlayVideo(config.sSID,index))
                    {
                        //流媒体预览视频
                        //Form1.hwnd[index] = VMSdk.VM_CLIENT_RealPlay(Form1.videoboxs[index].pictureBox1.Handle.ToInt32(), ref config, (int)VMSdk.VM_CLIENT_DEV_TYPE.VM_CLIENT_DEV_RTSP_VMSTREAMINGSER);

                        Form1.hwnd[index] = CMSSdk.VM_CMS_RealPlay(0, Form1.videoboxs[index].pictureBox1.Handle, config.sSID);
                        //存储视频信息
                        Form1.SID[index] = config.sSID;
                    }
                    #endregion
                }
               else
                {
                    if (SearchRealPlayVideo2(strDeviceID, index))
                    {
                        
                        CHCNetSDK.NET_DVR_PREVIEWINFO lpPreviewInfo = new CHCNetSDK.NET_DVR_PREVIEWINFO();
                        lpPreviewInfo.hPlayWnd = Form1.videoboxs[index].pictureBox1.Handle;//预览窗口
                        lpPreviewInfo.lChannel = device.VideoChannel;//预te览的设备通道
                        lpPreviewInfo.dwStreamType = 0;//码流类型：0-主码流，1-子码流，2-码流3，3-码流4，以此类推
                        lpPreviewInfo.dwLinkMode = 0;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RSTP/HTTP 
                        lpPreviewInfo.bBlocked = true; //0- 非阻塞取流，1- 阻塞取流
                        lpPreviewInfo.dwDisplayBufNum = 15; //播放库播放缓冲区最大缓冲帧数
                        CHCNetSDK.REALDATACALLBACK RealData = new CHCNetSDK.REALDATACALLBACK(RealDataCallBack);//预览实时流回调函数
                        IntPtr pUser = new IntPtr();//用户数据
                        if (streamMedia.VideoIP == null) return -1;
                        if (!RecDll.ManualRec.userIDList.ContainsKey(streamMedia.VideoIP)) return -1;
                        int UserID = RecDll.ManualRec.userIDList[streamMedia.VideoIP];
                        m_lUserID = UserID;
                        Form1.hwnd[index] = CHCNetSDK.NET_DVR_RealPlay_V40(m_lUserID, ref lpPreviewInfo, null/*RealData*/, pUser);
                        m_lRealHandle = Form1.hwnd[index];
                        if (Form1.hwnd[index] == -1)
                        {
                            uint temp = CHCNetSDK.NET_DVR_GetLastError();
                            MessageBox.Show("视频预览失败！");
                        }
                        else
                        {
                            //Form1.SID[index] = config.sSID;
                            Form1.DeviceIDs[index] = strDeviceID;
                            Form1.videoboxs[index].SetVideoInfo(IP, nChannel, m_lUserID, m_lRealHandle, strDeviceID, device.VideoName);
                        }
                    }
                }
            }
             return Form1.hwnd[index];
        }
        public static void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }

        /// <summary>
        /// 搜索视频是否已经打开(流媒体)
        /// </summary>
        /// <param name="sSID">流媒体服务器视频标识</param>
        private static bool SearchRealPlayVideo(string sSID,int index)
        {
            bool result = true;
            for (int i = 0; i < Form1.BoxCount; i++)
            {
                //1、如果视频已经打开，并且不在选中的视频框中，则关闭视频
                if (Form1.SID[i] == sSID && i != index)
                {
                    VMSdk.VM_CLIENT_RealStop(Form1.hwnd[i]);
                    Form1.videoboxs[i].Refresh();
                    Form1.videoboxs[i].ClearVideoInfo();
                    Form1.SID[i] = null;
                    Form1.hwnd[i] = -1;
                    result = true;
                    continue;
                }
                //2、如果视频以及打开，并且在选中的视频框中，则不做任何操作
                if (Form1.SID[i] == sSID && i == index)
                {
                    result = false;
                    continue;
                }
                //3、如果当前选中的视频已有其他视频，则先关闭其他视频，再打开
                if (Form1.SID[i] != null && Form1.SID[i] != sSID&&i== index)
                {
                    VMSdk.VM_CLIENT_RealStop(Form1.hwnd[i]);
                    Form1.videoboxs[i].Refresh();
                    Form1.videoboxs[i].ClearVideoInfo();
                    Form1.SID[i] = null;
                    Form1.hwnd[i] = -1;
                    result = true;
                    continue;
                }
            }
            //如果视频还未打开，则直接在选中的视频框中打开
            return result;
        }
        /// <summary>
        /// 搜索视频是否已经打开
        /// </summary>
        /// <param name="deviceID">视频标识</param>
        private static bool SearchRealPlayVideo2(string deviceID, int index)
        {
            bool result = true;
            for (int i = 0; i < Form1.BoxCount; i++)
            {
                //1、如果视频已经打开，并且不在选中的视频框中，则关闭视频
                if (Form1.DeviceIDs[i] == deviceID && i != index)
                {
                    if (!Form1.IsAlarm[i])
                    {
                        CHCNetSDK.NET_DVR_StopRealPlay(Form1.hwnd[i]);
                        Form1.videoboxs[i].Refresh();
                        Form1.videoboxs[i].ClearVideoInfo();
                        Form1.DeviceIDs[i] = null;
                        result = true;
                    }
                    else
                    {
                        result = false;
                        MessageBox.Show("该视频正在报警！");
                    }
                    break;
                }
                //2、如果视频以及打开，并且在选中的视频框中，则不做任何操作
                if (Form1.DeviceIDs[i] == deviceID && i == index)
                {
                    result = false;
                    break;
                }
                //3、如果当前选中的视频已有其他视频，则先关闭其他视频，再打开
                if (Form1.DeviceIDs[i] != null && Form1.DeviceIDs[i] != deviceID && i == index)
                {
                    CHCNetSDK.NET_DVR_StopRealPlay(Form1.hwnd[i]);
                    Form1.videoboxs[i].Refresh();
                    Form1.videoboxs[i].ClearVideoInfo();
                    Form1.DeviceIDs[i] = null;
                    result = true;
                    break;
                }
            }
            //如果视频还未打开，则直接在选中的视频框中打开
            return result;
        }
        /// <summary>
        /// 打开报警视频
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns></returns>
        public static int OpenAlarm(string strDeviceID,object AlarmFingerprintID)
        {
            //查找视频是否已经打开
            Guid DeviceID;
            if (!Guid.TryParse(strDeviceID, out DeviceID)) return -1;
            Entities.CameraList device = Class1.cameraList.Find(
                delegate (Entities.CameraList camera)
                {
                    return camera.DeviceID.Equals(DeviceID);
                }
                );
            if (device == null) return -1;

            //1、如果视频已经打开，则直接闪烁
            for (int i = 0; i < Form1.BoxCount; i++)
            {
                if(Form1.DeviceIDs[i]== strDeviceID)
                {
                    Form1.flash_tag.Add(i);
                    Form1.IsAlarm[i] = true;
                    Form1.videoboxs[i].StartAlarm();
                    Form1.videoboxs[i].player.PlayLooping();
                    return i;
                }
            }
            //2、视频未打开，搜索空视频框显示视频并闪烁
            for(int i=0;i< Form1.BoxCount; i++)
            {
                if(Form1.DeviceIDs[i]==null)
                {
                    string IP = "";
                    int nChannel = -1;
                    int m_lUserID=-1;
                    int m_lRealHandle = -1;
                    Open(strDeviceID, i,ref IP,ref nChannel,ref m_lUserID, ref m_lRealHandle);
                    Action action = delegate () { Form1.videoboxs[i].StartAlarm(); };
                    Form1.videoboxs[i].Invoke(action);
                    Form1.IsAlarm[i] = true;
                    Form1.videoboxs[i].player.PlayLooping();
                    Form1.flash_tag.Add(i);
                    return i;
                }
            }
            return -1;
        }
    }
}
