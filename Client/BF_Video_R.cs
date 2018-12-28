using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace XW_HK_SDK
{
    public class BF_Video_R
    {
        /// <summary>
        /// 手动录像_初始化
        /// </summary>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_R_Init();

        /// <summary>
        /// 手动录像_查询该路视频是否在录像
        /// </summary>
        /// <param name="pDVRIP">DVR_IP</param>
        /// <param name="nChannel">DVR通道号</param>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_GetRecB(string pDVRIP, Int32 nChannel);

        /// <summary>
        /// 手动录像开始
        /// </summary>
        /// <param name="pDVRIP">DVR_IP</param>
        /// <param name="nChannel">DVR通道号</param>
        /// <param name="pChannelName">DVR通道名称</param>
        /// <param name="pName">名字</param>
        /// <param name="nType">录像类型</param>
        /// <param name="nRecMode">默认填：1</param>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_Rec(string pDVRIP, Int32 nChannel, string pChannelName, string pName, Int32 nType, Int32 nRecMode);

        /// <summary>
        /// 手动录像_停止
        /// </summary>
        /// <param name="pDVRIP">DVR_IP</param>
        /// <param name="nChannel">DVR通道号</param>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_StopRec(string pDVRIP, Int32 nChannel);

        /// <summary>
        /// 录像的信息
        /// </summary>
        /// <param name="pDVRIP">DVR IP</param>
        /// <param name="nChannel">DVR通道号</param>
        /// <param name="pFileName">录像名称</param>
        /// <param name="pFilePath">录像路径</param>
        /// <param name="tm">录像开始时间</param>
        /// <param name="lType">录像类型2标识手动录像开始，3表示自动自动开始，4表示报警录像开始，5表示手动录像停止，6标识自动录像停止，7表示报警录像停止</param>
        /// <param name="userdata">用户对象</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void fRecvForRInfoCallBack(string pDVRIP,Int32 nChannel,string pFileName,string pFilePath, string tm, Int32 lType, UInt32 userdata);

        /// <summary>
        /// 注册手动录像状态及其信息返回
        /// </summary>
        /// <param name="cbRecvForRInfoCallBack"></param>
        /// <param name="userdata"></param>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_SetRecvRState(fRecvForRInfoCallBack cbRecvForRInfoCallBack, UInt32 userdata = 0);
       
        /// <summary>
        /// 设置录像文件的描述信息
        /// </summary>
        /// <param name="pDVRIP">DVR IP</param>
        /// <param name="nChannel">DVR通道号</param>
        /// <param name="tm">录像开始时间</param>
        /// <param name="pEventName">录像事件名称</param>
        /// <param name="pDescription">录像事件描述</param>
        /// <returns></returns>
        [DllImport("rv.dll")]
        public static extern Int32 XW_Video_SetRecvRDesc(string pDVRIP, Int32 nChannel, string tm, string pEventName, string pDescription);
    }
}
