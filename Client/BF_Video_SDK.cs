using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace XW_HK_SDK
{
     public class BF_Video_SDK
     {
         // HK_SDK初始化函数
         /// <summary>
         /// HK_SDK初始化函数
         /// </summary>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_Init();

         // 预览视频
         /// <summary>
         /// 预览视频
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="hwnd">显示视频的控件句柄</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_RealPlay(string pDVRIP, Int32 nChannel, IntPtr hwnd);

         // 停止预览视频
         /// <summary>
         /// 停止预览视频
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopRealPlay(string pDVRIP, Int32 nChannel);

         // 获取视频分辨率
         /// <summary>
         /// 获取视频分辨率
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_GetVideoSize(string pDVRIP, Int32 nChannel);
         //
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_RecControl(string pDVRIP, Int32 nChannel, string pRealPlayName, bool bRec);
         //
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_GetRec(string pDVRIP, Int32 nChannel);

         // 视频抓图
         /// <summary>
         /// 视频抓图
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="pPicPath">图片存放路径</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_CapturePicture(string pDVRIP, Int32 nChannel, string pPicPath);
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopRealPlayData(Int32 nDevicePort);
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_RealPlayImage(string pDVRIP, Int32 nChannel, bool bRealPlay = true);

         // 启动画线报警
         /// <summary>
         /// 启动画线报警
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="hwnd">显示视频的控件句柄</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SingleRealPlayEx(string pDVRIP, Int32 nChannel, IntPtr hwnd);

         // 取消报警
         /// <summary>
         /// 取消报警
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopSingleRealPlayEx(string pDVRIP);

         // 设置视频报警线--整个线的数据
         /// <summary>
         /// 设置视频报警线--整个线的数据
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="nAlarmType">报警类型 1,移动全屏报警 2,移动局部报警 3,移动过线报警 </param>
         /// <param name="nSensitive">灵敏度:1-5 1,最低 5,最高</param>
         /// <param name="pChannelName">报警名称</param>
         /// <param name="pRect">报警线</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetAlarmInfo(string pDVRIP, Int32 nChannel, Int32 nAlarmType, Int32 nSensitive, string pChannelName,Int32[] pRect);

         // 设置视频报警线--线的起点与终点设置
         /// <summary>
         /// 设置视频报警线--线的起点与终点设置
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="nAlarmType">报警类型 1,移动全屏报警 2,移动局部报警 3,移动过线报警</param>
         /// <param name="pStartPoint">起点</param>
         /// <param name="pEndPoint">终点</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_DrawAlarmRect(string pDVRIP, Int32 nChannel, Int32 nAlarmType, Point pStartPoint, Point pEndPoint);

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayRecFile(string pRecFilePath, IntPtr hwnd);

         // 清除划线报警
         /// <summary>
         /// 清除划线报警
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="pChannelName">报警名称</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_DelAlarmInfo(string pDVRIP, Int32 nChannel, string pChannelName);

         // 开启哨所对讲
         /// <summary>
         /// 开启哨所对讲
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="hwnd">显示视频的控件句柄</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_Talk_ShaoSuo(string pDVRIP, Int32 nChannel, IntPtr hwnd);

         // 关闭哨所对讲
         /// <summary>
         /// 关闭哨所对讲
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopTalk_ShaoSuo(string pDVRIP);


         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_Talk_SendPCToShaoSuo(string pDVRIP, string pSendBuf, int nBufLength);

         // 录像检索时间
         /// <summary>
         /// 录像检索时间
         /// </summary>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayRecAllTime();

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayRecNowTime();

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetPlayRecNowTime(Int32 nNowTime);

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetPlayRecPause(bool bPlay);

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetPlayRecStop();

         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayRecCapturePicture(string pPicturePath);

         // 设置DVR时间   C++ CTime 在C#对应 DateTime ？
         /// <summary>
         /// 设置DVR时间
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nTime">时间</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_CurTimes(string pDVRIP, long nTime);

         //HK网络球控制
         /// <summary>
         /// 
         /// </summary>
         /// <param name="pDVRIP"></param>
         /// <param name="nChannel"></param>
         /// <param name="nPTZCommand"></param>
         /// <param name="nSpeed"></param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_ControlWithSpeed(string pDVRIP, Int32 nChannel, Int32 nPTZCommand, Int32 nSpeed);

         /// <summary>
         /// 
         /// </summary>
         /// <param name="pDVRIP"></param>
         /// <param name="nChannel"></param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_ControlWithSpeed_Stop(string pDVRIP, Int32 nChannel);

         /// <summary>
         /// 
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="lPTZPresetCmd"></param>
         /// <param name="lPresetIndex"></param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PTZPreset(string pDVRIP, Int32 nChannel, Int32 lPTZPresetCmd, Int32 lPresetIndex);

         // DVR/NVR报警输出控制
         /// <summary>
         /// DVR/NVR报警输出控制
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="lAlarmOutPort">设备报警输出口序号从0开始，6701设备一般为0；</param>
         /// <param name="lAlarmOutStatic">0为关 1为开</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetAlarmOut(string pDVRIP, Int32 lAlarmOutPort, Int32 lAlarmOutStatic);

         // 白天夜晚模式切换
         /// <summary>
         /// 白天夜晚模式切换
         /// </summary>
         /// <param name="pDVRIP">HK设备IP</param>
         /// <param name="nChannel">HK设备通道号</param>
         /// <param name="lDayNightFilterType">日夜切换：0-白天（彩色），1-夜晚（黑白），2-自动，3-定时，4-报警输入触发</param>
         /// <returns></returns>
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_SetDayNightFilter(string pDVRIP, Int32 nChannel, Int32 lDayNightFilterType);

         //调取NVR和DVR里面的录像视频
         // [StructLayoutAttribute(LayoutKind.Sequential)] public struct student
         public struct XW_DVR_TIME
         {
             public UInt32 dwYear;
             public UInt32 dwMonth;
             public UInt32 dwDay;
             public UInt32 dwHour;
             public UInt32 dwMinute;
             public UInt32 dwSecond;
         };
        // [DllImport("VideoDll.dll")] 
         //  typedef void (*fRecvFileNameCallBack)(char* pDVRIP,LONG nChannel, char* pFileName, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, DWORD userdata);
         [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
         public delegate void RECORDLIST(string pDVRIP,Int32 nChannel, string pFileName, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, UInt32 userdata);
         //获取录像文件名称
         [DllImport("VideoDll.dll")]
         //XW_DVR_FindFileName(char* pDVRIP,LONG nChannel, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, fRecvFileNameCallBack pRecvFileNameCallBack=NULL,DWORD userdata=0);
         public static extern Int32 XW_DVR_FindFileName(string pDVRIP, Int32 nChannel, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, RECORDLIST pRecvFileNameCallBack, UInt32 userdata = 0);

        //通过名称播放录像文件
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayBackByName(string pDVRIP, string pRecvFileName, IntPtr hwnd);

        //通过时间播放
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_PlayBackByTime(string pDVRIP, Int32 nChannel, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, IntPtr hwnd);

         //停止播放录像文件
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopPlayBack(string pDVRIP);

         //播放控制 dwControlCode:1为开始 3为暂停 4继续
         //[DllImport("VideoDll.dll")]
         //public static extern Int32 XW_DVR_PlayBackControl(string pDVRIP, UInt32 dwControlCode, long lpInBuffer, UInt32 dwInLen, long lpOutBuffer, UInt32* lpOutLen);
         //public static extern Int32 XW_DVR_PlayBackControl(string pDVRIP, UInt32 dwControlCode, LPVOID lpInBuffer, UInt32 dwInLen, LPVOID lpOutBuffer, UInt32* lpOutLen);

         //录像文件下载
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_GetFileByName(string pDVRIP, string pRecvFileName, string pSaveRecvFilePath);

         //时间段录像文件下载
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_GetFileByTime(string pDVRIP, Int32 nChannel, XW_DVR_TIME struStartTime, XW_DVR_TIME struStopTime, string pSaveRecvFilePath);

         //停止下载
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_StopGetFile(string pDVRIP);

         //获取下载进度 0～100表示下载的进度；100表示下载结束；正常范围0-100
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_NET_DVR_GetDownloadPos(string pDVRIP);

         //获取错误代码
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_NET_DVR_GetLastError();

         //-----------------------------------------获取 96xxNVR的通道状态---------------------------------
        //获取96xxNVR的通道状态
        // [DllImport("VideoDll.dll")]
        // public static extern Int32 XW_DVR_DigitalChannelState(string pDVRIP,long nChannel);
        ////获取96xxNVR的所有通道状态
        // [DllImport("VideoDll.dll")]
        // public static extern Int32 XW_DVR_DigitalChannelStateEx(string pDVRIP, Byte[] pChannelState, LPDWORD dwReturnLen);
        //-----------------------------------------获取 96xxNVR的通道状态----------------------------------
         /// <summary>
         /// 设备状态
         /// </summary>
         /// <param name="pDVRIP">设备IP</param>
         /// <param name="nChannel">设备类型 </param>
         /// <param name="nChannelState">设备状态--DVR、6701</param>
         /// <param name="pAllChannelState">设备状态--NVR 各个通道状态</param>
         /// <param name="dwReturnLen"></param>
         /// <param name="userdata"></param>
         [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
         public delegate void fDigitalChannelStateCallback(string pDVRIP, Int32 nChannel, Int32 nChannelState, Byte[] pAllChannelState, UInt32 dwReturnLen, UInt32 userdata);
        //注册状态回调函数，用于XW_DVR_Init之前使用 dwWaitTime 单位ms 默认参数为20秒
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_MSGState(UInt32 dwWaitTime, fDigitalChannelStateCallback pDigitalChannelStateCallback, UInt32 userdata = 0);

         //2016年3月16日
         [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
         public delegate void fAlarmInfoCallBack(string pInfo, Int32 lBufSize, UInt32 userdata);
         [DllImport("VideoDll.dll")]
         public static extern Int32 XW_DVR_AlarmInfoCB(fAlarmInfoCallBack cbAlarmInfoCallBack, UInt32 userdata = 0);

     }
}
