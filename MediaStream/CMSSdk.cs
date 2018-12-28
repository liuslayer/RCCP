using System;
using System.Runtime.InteropServices;
using System.Text;
namespace ClassLibrary1
{
    public class CMSSdk
    {
        //登录媒体管理服务器
        public struct LPCMS_USER_LOGIN_INFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szIP;
            public int uPort;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szUser;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szPassword;
        }
        public struct LPCMS_USERO
        {
            public string szUserName;
            public string szPasseord;
        }
        //流媒体服务器信息
        public struct LPCMS_VMSR
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szSid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szIP;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szPort;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szState;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szMaxChannel;
        }
        //摄像机信息
        public struct LPCMS_CAM
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szSid;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szIP;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szPort;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 500)]
            public string szRTSP;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szMark;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
            public string szState;
        }
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct LPCMS_CAM_FILE_INFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string szFileName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string szFilePath;
        }
        //用户名信息返回
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void callbackUserName(int lhandle, string buf, int lbufSize, Int32 userdata);

        //VMS VMR 信息返回
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void callbackVMSR(int lHandle, LPCMS_VMSR lpCMS_VMSR, Int32 userdate);

        //CAM 信息返回
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void callbackCAM(int lHandle, LPCMS_CAM lpCMS_CAM, Int32 userdata);

        //录像信息返回
        [UnmanagedFunctionPointer(CallingConvention.Cdecl,CharSet=CharSet.Ansi)]
        public delegate void callbackCAMFile(int lHandle,ref LPCMS_CAM_FILE_INFO lpCMS_CAM_FILE_INFO, UInt32 userdata);

        //日志信息返回
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        public delegate void callbackLogFile(int lHandle, string szBug, int lSize, Int32 userdata);

        //海康威视
        [StructLayout(LayoutKind.Sequential,CharSet=CharSet.Ansi)]
        public struct LPCMS_CONFIG_HIKVISION
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 129)]
            public string sDeviceAddress;
            public UInt32 ulPort;//8000-网络端口，554-流媒体端口
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string sUserName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string sPassword;
            public Int32 lChannel;
            public UInt32 ulStreamType;//0-主码流，1-子码流，2-码流3，3-虚拟码流，以此类推 
            public UInt32 ulLinkMode;//连接方式：0- TCP方式，1- UDP方式，2- 多播方式，3- RTP方式，4-RTP/RTSP，5-RTP/HTTP
            public UInt32 ulVideoEncType;//编码类型：0-264，1-mpeg4

        }
        public struct MyAddress
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1024)]
            public string szRtspOutput;
        }

        [Serializable]
        [FlagsAttribute]
        public enum emCMS_CAM_TYPE
        {
            CMS_CAM_HIKVISION = 1,//海康威视

            CMS_CAM_RTSP = 0x1000,
            CMS_CAM_RTSP_HIKVISION = 0x1001,//海康威视 RTSP
            CMS_CAM_RTSP_VMSTREAMINGSER = 0x1002,//VMS
        }

        public enum emLoadLevelingType
        {
            LOADLEVELING_BASICS = 1,//基础
            LOADLEVELING_AVERAGE = 2,//平均
        }
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_Init();
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_Cleanup(); //退出初始化
        [DllImport("CMSSdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_Login(ref LPCMS_USER_LOGIN_INFO lpCMS_USER_LOGIN_INFO, UInt32 dwRet);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_Logout(int lhandle);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_GetUserName(int lhandle, callbackUserName cbUserName, Int32 userdata);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_AddUser(int lhandle, LPCMS_USERO lpCMS_USERO, int dwRet);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_DelUser(int lhandle, LPCMS_USERO lpCMS_USERO, int dwRet);

        [DllImport("CMSSdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_GetVMS(int lhandle, callbackVMSR cbVMSR, Int32 userdata);
        [DllImport("CMSSdk.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_AddVMS(int lhandle, ref LPCMS_VMSR lpCMS_VMSR, UInt32 dwRet);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_DelVMS(int lhandle, LPCMS_VMSR lpCMS_VMSR, int dwRet);

        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_GetVMR(int lhandle, callbackVMSR cbVMSR, Int32 userdata);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_AddVMR(int lhandle, LPCMS_VMSR lpCMS_VMSR, int dwRet);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_DelVMR(int lhandle, LPCMS_VMSR lpCMS_VMSR, int dwRet);


        [DllImport("CMSSdk.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_CAMToRTSP(ref LPCMS_CONFIG_HIKVISION lpBuf, emCMS_CAM_TYPE emType,ref MyAddress szRtspOutput);//先声明szRtspOutput变量，返回地址
        //VM_CMS_SDK_API long VM_CMS_CAMToRTSP(LPVOID lpBuf, emCMS_CAM_TYPE emType, char* szRtspOutput);


        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_GetCAM(int lhandle, callbackCAM cbCAM, Int32 userdata);
        [DllImport("CMSSdk.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_AddCAM(int lhandle, ref LPCMS_CAM lpCMS_CAM, UInt32 dwRet);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_DelCAM(int lhandle, LPCMS_CAM lpCMS_CAM, UInt32 dwRet);

        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_GetLog(int lhandle, callbackLogFile cbLog, Int32 userdata);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_ReadLog(int lhandle, callbackLogFile cbLog, string szLogName, Int32 serdata);

        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_SetLoadLeveling(int lhandle, emLoadLevelingType emLV);
        [DllImport("CMSSdk.dll")]
        public static extern Int32 VM_CMS_GetLoadLeveling(int lhandle);

        //
        //返回值说明
        //>=0  -- 正常, 返回标识符
        //-1   -- 未登陆
        //-2   -- 连接服务端实时数据异常
        //-3   -- 其他异常
        //-4   -- 视频预览异常
        [DllImport("CMSSdk.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_RealPlay(int lhandle, IntPtr hwnd, string szSID);

        //lhandle -- VM_CMS_RealPlay 有效返回至
        [DllImport("CMSSdk.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
        public static extern Int32 VM_CMS_StopPlay(int lhandle);

        //通过时间查询录像文件
        //返回值说明
        //>=0  -- 正常, 返回标识符
        //-1   -- 未登陆
        //-2   -- 连接服务端实时数据异常
        //-3   -- 其他异常
        //-4   -- 查找录像文件异常
        [DllImport("CMSSdk.dll",CallingConvention=CallingConvention.Cdecl,CharSet=CharSet.Ansi)]
        public static extern Int32 VM_CMS_FindFileTime(Int32 lhandle, string szSID, string szStartDateTime, string szEndDateTime, callbackCAMFile cbCAMFile, UInt32 userdata);

    }
}