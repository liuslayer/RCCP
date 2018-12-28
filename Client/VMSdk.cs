using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class VMSdk
    {
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct VM_CLIENT_CONFIG_VMSTREAMINGSER
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public String sDeviceAddress;//流媒体IP

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public String sSID;//视频SID
        }

        [Serializable]
        [FlagsAttribute]
        public enum VM_CLIENT_DEV_TYPE
        {
            VM_CLIENT_DEV_HIKVISION = 1,//海康威视

            VM_CLIENT_DEV_RTSP = 0x1000,
            VM_CLIENT_DEV_RTSP_HIKVISION = 0x1001,//海康威视 RTSP
            VM_CLIENT_DEV_RTSP_VMSTREAMINGSER = 0x1002,//VMS
        }
        /// <summary>
        /// 流媒体初始化
        /// </summary>
        /// <returns></returns>
        [DllImport("VMSdk.dll")]
        public static extern Int32 VM_CLIENT_Init();

        /// <summary>
        /// 关闭流媒体
        /// </summary>
        /// <returns></returns>
        [DllImport("VMSdk.dll")]
        public static extern Int32 VM_CLIENT_Cleanup();

        /// <summary>
        /// 视频预览
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lpConfig"></param>
        /// <param name="ulDevType"></param>
        /// <returns></returns>
        [DllImport("VMSdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CLIENT_RealPlay(Int32 hwnd, ref VM_CLIENT_CONFIG_VMSTREAMINGSER lpConfig, Int32 ulDevType);

        /// <summary>
        /// 关闭预览
        /// </summary>
        /// <param name="hwnd"></param>
        /// <returns></returns>
        [DllImport("VMSdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CLIENT_RealStop(int hwnd);

    }
}
