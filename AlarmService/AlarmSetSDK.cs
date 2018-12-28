using AlarmService;
using PreviewDemo;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;

namespace AccessOperation
{
    public static class AlarmSetSDK
    {
        private static Point m_nVideoSize;
        public static Point MyPoint1;
        private static List<Point> t1 = new List<Point>();//重绘划线的点，使用point形式便于划线
        private static int[] Alarm_area = new int[22 * 18];
        private static int x, y;
        private static Point NVideoSize
        {
            get { return m_nVideoSize; }
            set { m_nVideoSize = value; }
        }
        private static Point pEndPoint;
        private static Point PEndPoint
        {
            get { return pEndPoint; }
            set { pEndPoint = value; }
        }

        public static CHCNetSDK.NET_DVR_PICCFG_V40 m_struPicCfgV40 = new CHCNetSDK.NET_DVR_PICCFG_V40();
        public static CHCNetSDK.NET_DVR_MOTION_V40 m_struMotionV40 = new CHCNetSDK.NET_DVR_MOTION_V40();
        //public static CHCNetSDK.NET_DVR_PICCFG m_struMotion = new CHCNetSDK.NET_DVR_PICCFG();
        public static CHCNetSDK.NET_DVR_DEVICEINFO_V30 m_struDeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();
        public static CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30 m_comPressionCFG = new CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30();
        public static CHCNetSDK.NET_DVR_SHOWSTRING_V30 m_struShowStrCfg;//设置字符叠加
        //public static CHCNetSDK.NET_DVR_COMPRESSION_INFO_V30 m_comPressionCFG_INFO = new CHCNetSDK.NET_DVR_COMPRESSION_INFO_V30();
        /// <summary>
        /// 设置划线报警
        /// </summary>
        /// <param name="pDVRIP">设备IP地址</param>
        /// <param name="nChannel">设备通道号</param>
        /// <param name="m_lUserID">登录设备后返回ID</param>
        /// <param name="nAlarmType">报警类型 1,移动全屏报警 2,移动局部报警 3,移动过线报警</param>
        /// <param name="nSensitive">灵敏度:1-5 1,最低 5,最高</param>
        /// <param name="pChannelName">报警名称</param>
        /// <param name="PointStr">报警划线</param>
        /// <param name="SizeX">picturebox的x</param>
        /// <param name="SizeY">picturebox的y</param>
        /// <returns></returns>
        public static int AlarmSet(string pDVRIP, Int32 nChannel,Int32 m_lUserID, Int32 nAlarmType, Int32 nSensitive, string pChannelName, string PointStr, Int32 SizeX, Int32 SizeY)
        {
            //-------------------获取分辨率---------------------------
            UInt32 dwReturn_CFG = 0;
            Int32 nSize_CFG = Marshal.SizeOf(m_comPressionCFG);
            IntPtr comPressionCFG = Marshal.AllocHGlobal(nSize_CFG);
            Marshal.StructureToPtr(m_comPressionCFG, comPressionCFG, false);
            bool CFG = CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_COMPRESSCFG_V30, nChannel, comPressionCFG, (UInt32)nSize_CFG, ref dwReturn_CFG);
            //------------------ 获取通道图象结构(V40扩展)------------
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPicCfgV40);
            IntPtr ptrPicCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPicCfgV40, ptrPicCfg, false);
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_PICCFG_V40, nChannel, ptrPicCfg, (UInt32)nSize, ref dwReturn))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_GET_PICCFG_V40 failed, error code= " + iLastErr;
                return int.Parse(iLastErr.ToString());
                //获取图像参数失败，输出错误号 Failed to get image parameters and output the error code
                //MessageBox.Show(strErr);
            }
            else
            {
                m_struPicCfgV40 = (CHCNetSDK.NET_DVR_PICCFG_V40)Marshal.PtrToStructure(ptrPicCfg, typeof(CHCNetSDK.NET_DVR_PICCFG_V40));
                m_struMotionV40 = m_struPicCfgV40.struMotion;
            }
                /*移动侦测灵敏度, 0 - 5,越高越灵敏,0xff关闭*/
            m_struMotionV40.struMotionMode.struMotionSingleArea.byMotionSensitive = (byte)nSensitive;
            SetAlarmHandleWnd();
            SetAlarmTimeWnd();
            //SetRecordChanWnd();
            //if (checkBoxEnableMotion.Checked)
            //{
            //处理移动侦测
                m_struMotionV40.byEnableHandleMotion = 1;
            //}
            //else
            //{
            //    m_struMotionV40.byEnableHandleMotion = 0;
            //}
            #region
            //设置移动侦测区域 
            int Alarm_result = 0;
            string[] str = null;
            //int screenResolution = AlarmOperation.BF_Video_SDK.XW_DVR_GetVideoSize(pDVRIP, nChannel);//获取分辨率
            //MessageBox.Show(screenResolution.ToString());
            int k = 27;//全部统一默认1080P
            switch (k)
            {
                case 0:
                    {
                        //DCIF = 528×384
                        m_nVideoSize.X = 528;
                        m_nVideoSize.Y = 384;
                        break;
                    }
                case 1:
                    {
                        //CIF = 352×288
                        m_nVideoSize.X = 352;
                        m_nVideoSize.Y = 288;
                        break;
                    }
                case 2:
                    {
                        //QCIF = 176×144
                        m_nVideoSize.X = 176;
                        m_nVideoSize.Y = 144;
                        break;
                    }
                case 3:
                    {
                        //4CIF = 704×576
                        m_nVideoSize.X = 704;
                        m_nVideoSize.Y = 576;
                        break;
                    }
                case 4:
                    {
                        //2CIF = 704×288
                        m_nVideoSize.X = 704;
                        m_nVideoSize.Y = 288;
                        break;
                    }
                case 6:
                    {
                        //QVGA = 320*240
                        m_nVideoSize.X = 320;
                        m_nVideoSize.Y = 240;
                        break;
                    }
                case 7:
                    {
                        //7-QQVGA(160*120)
                        m_nVideoSize.X = 160;
                        m_nVideoSize.Y = 120;
                        break;
                    }
                case 12:
                    {
                        //12-384*288
                        m_nVideoSize.X = 384;
                        m_nVideoSize.Y = 288;
                        break;
                    }
                case 13:
                    {
                        //13-576*576
                        m_nVideoSize.X = 576;
                        m_nVideoSize.Y = 576;
                        break;
                    }
                case 16:
                    {
                        //VGA = 640×480 
                        m_nVideoSize.X = 640;
                        m_nVideoSize.Y = 480;
                        break;
                    }
                case 17:
                    {
                        //UXGA = 1600×1200
                        m_nVideoSize.X = 1600;
                        m_nVideoSize.Y = 1200;
                        break;
                    }
                case 18:
                    {
                        //SVGA = 800×600
                        m_nVideoSize.X = 800;
                        m_nVideoSize.Y = 600;
                        break;
                    }
                case 19:
                    {
                        //HD720p = 1280×720
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 720;
                        break;
                    }
                case 20:
                    {
                        //20-XVGA(1280*960)
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 960;
                        break;
                    }
                case 22:
                    {
                        //22-1360*1024
                        m_nVideoSize.X = 1360;
                        m_nVideoSize.Y = 1024;
                        break;
                    }
                case 23:
                    {
                        //23-1536*1536
                        m_nVideoSize.X = 1536;
                        m_nVideoSize.Y = 1536;
                        break;
                    }
                case 24:
                    {
                        //24-1920*1920
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1920;
                        break;
                    }
                case 27:
                    {
                        //27-1920*1080p
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1080;
                        break;
                    }
                case 28:
                    {
                        //28-2560*1920
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 1920;
                        break;
                    }
                case 29:
                    {
                        //29-1600*304
                        m_nVideoSize.X = 1600;
                        m_nVideoSize.Y = 304;
                        break;
                    }
                case 30:
                    {
                        //30-2048*1536
                        m_nVideoSize.X = 2048;
                        m_nVideoSize.Y = 1536;
                        break;
                    }
                case 31:
                    {
                        //31-2448*2048
                        m_nVideoSize.X = 2448;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 32:
                    {
                        //32-2448*1200
                        m_nVideoSize.X = 2448;
                        m_nVideoSize.Y = 1200;
                        break;
                    }
                case 33:
                    {
                        //33-2448*800
                        m_nVideoSize.X = 2448;
                        m_nVideoSize.Y = 800;
                        break;
                    }
                case 34:
                    {
                        //34-XGA(1024*768)
                        m_nVideoSize.X = 1024;
                        m_nVideoSize.Y = 768;
                        break;
                    }
                case 35:
                    {
                        //35-SXGA(1280*1024)
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 1024;
                        break;
                    }
                case 36:
                    {
                        //36-WD1(960*576/960*480)
                        m_nVideoSize.X = 960;
                        m_nVideoSize.Y = 576;
                        break;
                    }
                case 37:
                    {
                        //37-1080i(1920*1080)
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1080;
                        break;
                    }
                case 38:
                    {
                        //38-WXGA(1440*900)
                        m_nVideoSize.X = 1440;
                        m_nVideoSize.Y = 900;
                        break;
                    }
                case 39:
                    {
                        //39-HD_F(1920*1080/1280*720)
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1080;
                        break;
                    }
                case 40:
                    {
                        //40-HD_H(1920*540/1280*360)
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 540;
                        break;
                    }
                case 41:
                    {
                        //41-HD_Q(960*540/630*360)
                        m_nVideoSize.X = 960;
                        m_nVideoSize.Y = 540;
                        break;
                    }
                case 42:
                    {
                        //42-2336*1744
                        m_nVideoSize.X = 2336;
                        m_nVideoSize.Y = 1744;
                        break;
                    }
                case 43:
                    {
                        //43-1920*1456
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1456;
                        break;
                    }
                case 44:
                    {
                        //44-2592*2048
                        m_nVideoSize.X = 2592;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 45:
                    {
                        //45-3296*2472
                        m_nVideoSize.X = 3296;
                        m_nVideoSize.Y = 2472;
                        break;
                    }
                case 46:
                    {
                        //46-1376*768
                        m_nVideoSize.X = 1376;
                        m_nVideoSize.Y = 768;
                        break;
                    }
                case 47:
                    {
                        //47-1366*768
                        m_nVideoSize.X = 1366;
                        m_nVideoSize.Y = 768;
                        break;
                    }
                case 48:
                    {
                        //48-1360*768
                        m_nVideoSize.X = 1360;
                        m_nVideoSize.Y = 768;
                        break;
                    }
                case 49:
                    {
                        //49-WSXGA+ 1680*1050
                        m_nVideoSize.X = 1680;
                        m_nVideoSize.Y = 1050;
                        break;
                    }
                case 50:
                    {
                        //50-720*720
                        m_nVideoSize.X = 720;
                        m_nVideoSize.Y = 720;
                        break;
                    }
                case 51:
                    {
                        //51-1280*1280
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 1280;
                        break;
                    }
                case 52:
                    {
                        //52-2048*768
                        m_nVideoSize.X = 2048;
                        m_nVideoSize.Y = 768;
                        break;
                    }
                case 53:
                    {
                        //53-2048*2048
                        m_nVideoSize.X = 2048;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 54:
                    {
                        //54-2560*2048
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 55:
                    {
                        //55-3072*2048
                        m_nVideoSize.X = 3072;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 56:
                    {
                        //56-2304*1296
                        m_nVideoSize.X = 2304;
                        m_nVideoSize.Y = 1296;
                        break;
                    }
                case 57:
                    {
                        //57-WXGA(1280*800)
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 800;
                        break;
                    }
                case 58:
                    {
                        //58-1600*600
                        m_nVideoSize.X = 1600;
                        m_nVideoSize.Y = 600;
                        break;
                    }
                case 59:
                    {
                        //59-1600*900
                        m_nVideoSize.X = 1600;
                        m_nVideoSize.Y = 900;
                        break;
                    }
                case 60:
                    {
                        //60-2752*2208
                        m_nVideoSize.X = 2752;
                        m_nVideoSize.Y = 2208;
                        break;
                    }
                case 61:
                    {
                        //61-384*288
                        m_nVideoSize.X = 384;
                        m_nVideoSize.Y = 288;
                        break;
                    }
                case 62:
                    {
                        //62-4000*3000
                        m_nVideoSize.X = 4000;
                        m_nVideoSize.Y = 3000;
                        break;
                    }
                case 63:
                    {
                        //63-4096*2160
                        m_nVideoSize.X = 4096;
                        m_nVideoSize.Y = 2160;
                        break;
                    }
                case 64:
                    {
                        //64-3840*2160
                        m_nVideoSize.X = 3840;
                        m_nVideoSize.Y = 2160;
                        break;
                    }
                case 65:
                    {
                        //65-4000*2250
                        m_nVideoSize.X = 4000;
                        m_nVideoSize.Y = 2250;
                        break;
                    }
                case 66:
                    {
                        //66-3072*1728
                        m_nVideoSize.X = 3072;
                        m_nVideoSize.Y = 1728;
                        break;
                    }
                case 67:
                    {
                        //67-2592*1944
                        m_nVideoSize.X = 2592;
                        m_nVideoSize.Y = 1944;
                        break;
                    }
                case 68:
                    {
                        //68-2464*1520
                        m_nVideoSize.X = 2464;
                        m_nVideoSize.Y = 1520;
                        break;
                    }
                case 69:
                    {
                        //69-1280*1920
                        m_nVideoSize.X = 1280;
                        m_nVideoSize.Y = 1920;
                        break;
                    }
                case 70:
                    {
                        //70-2560*1440
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 1440;
                        break;
                    }
                case 71:
                    {
                        //71-1024*1024
                        m_nVideoSize.X = 1024;
                        m_nVideoSize.Y = 1024;
                        break;
                    }
                case 72:
                    {
                        //72-160*128
                        m_nVideoSize.X = 160;
                        m_nVideoSize.Y = 128;
                        break;
                    }
                case 73:
                    {
                        //73-324*240
                        m_nVideoSize.X = 324;
                        m_nVideoSize.Y = 240;
                        break;
                    }
                case 74:
                    {
                        //74-324*256
                        m_nVideoSize.X = 324;
                        m_nVideoSize.Y = 256;
                        break;
                    }
                case 75:
                    {
                        //75-336*256
                        m_nVideoSize.X = 336;
                        m_nVideoSize.Y = 256;
                        break;
                    }
                case 76:
                    {
                        //76-640*512
                        m_nVideoSize.X = 640;
                        m_nVideoSize.Y = 512;
                        break;
                    }
                case 77:
                    {
                        //77-2720*2048
                        m_nVideoSize.X = 2720;
                        m_nVideoSize.Y = 2048;
                        break;
                    }
                case 78:
                    {
                        //78-384*256
                        m_nVideoSize.X = 384;
                        m_nVideoSize.Y = 256;
                        break;
                    }
                case 79:
                    {
                        //79-384*216
                        m_nVideoSize.X = 384;
                        m_nVideoSize.Y = 216;
                        break;
                    }
                case 80:
                    {
                        //80-320*256
                        m_nVideoSize.X = 320;
                        m_nVideoSize.Y = 256;
                        break;
                    }
                case 81:
                    {
                        //81-320*180
                        m_nVideoSize.X = 320;
                        m_nVideoSize.Y = 180;
                        break;
                    }
                case 82:
                    {
                        //82-320*192
                        m_nVideoSize.X = 320;
                        m_nVideoSize.Y = 192;
                        break;
                    }
                case 83:
                    {
                        //83-512*384
                        m_nVideoSize.X = 512;
                        m_nVideoSize.Y = 384;
                        break;
                    }
                case 84:
                    {
                        //84-325*256
                        m_nVideoSize.X = 325;
                        m_nVideoSize.Y = 256;
                        break;
                    }
                case 85:
                    {
                        //85-256*192
                        m_nVideoSize.X = 256;
                        m_nVideoSize.Y = 192;
                        break;
                    }
                case 86:
                    {
                        //86- 640*360
                        m_nVideoSize.X = 640;
                        m_nVideoSize.Y = 360;
                        break;
                    }
                case 87:
                    {
                        //87-1776x1340
                        m_nVideoSize.X = 1776;
                        m_nVideoSize.Y = 1340;
                        break;
                    }
                case 88:
                    {
                        //88-1936x1092
                        m_nVideoSize.X = 1936;
                        m_nVideoSize.Y = 1092;
                        break;
                    }
                case 89:
                    {
                        //89-2080x784
                        m_nVideoSize.X = 2080;
                        m_nVideoSize.Y = 784;
                        break;
                    }
                case 90:
                    {
                        //90-2144x604
                        m_nVideoSize.X = 2144;
                        m_nVideoSize.Y = 604;
                        break;
                    }
                case 91:
                    {
                        //91-1920*1200
                        m_nVideoSize.X = 1920;
                        m_nVideoSize.Y = 1200;
                        break;
                    }
                case 92:
                    {
                        //92-4064*3040
                        m_nVideoSize.X = 4064;
                        m_nVideoSize.Y = 3040;
                        break;
                    }
                case 93:
                    {
                        //93-3040*3040
                        m_nVideoSize.X = 3040;
                        m_nVideoSize.Y = 3040;
                        break;
                    }
                case 94:
                    {
                        //94-3072*2304
                        m_nVideoSize.X = 3072;
                        m_nVideoSize.Y = 2304;
                        break;
                    }
                case 95:
                    {
                        //95-3072*1152
                        m_nVideoSize.X = 3072;
                        m_nVideoSize.Y = 1152;
                        break;
                    }
                case 96:
                    {
                        //96-2560*2560
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 2560;
                        break;
                    }
                case 97:
                    {
                        //97-2688*1536
                        m_nVideoSize.X = 2688;
                        m_nVideoSize.Y = 1536;
                        break;
                    }
                case 98:
                    {
                        //98-2688*1520
                        m_nVideoSize.X = 2688;
                        m_nVideoSize.Y = 1520;
                        break;
                    }
                case 99:
                    {
                        //99-3072*3072
                        m_nVideoSize.X = 3072;
                        m_nVideoSize.Y = 3072;
                        break;
                    }
                case 100:
                    {
                        //100-3392*2008
                        m_nVideoSize.X = 3392;
                        m_nVideoSize.Y = 2008;
                        break;
                    }
                case 101:
                    {
                        //101-4000*3080
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 2560;
                        break;
                    }
                case 102:
                    {
                        //102-960*720
                        m_nVideoSize.X = 960;
                        m_nVideoSize.Y = 720;
                        break;
                    }
                case 103:
                    {
                        //103-1024*1536
                        m_nVideoSize.X = 1024;
                        m_nVideoSize.Y = 1536;
                        break;
                    }
                case 104:
                    {
                        //104-704*1056
                        m_nVideoSize.X = 704;
                        m_nVideoSize.Y = 1056;
                        break;
                    }
                case 105:
                    {
                        //105-352*528
                        m_nVideoSize.X = 352;
                        m_nVideoSize.Y = 528;
                        break;
                    }
                case 106:
                    {
                        //106-2048*1530
                        m_nVideoSize.X = 2048;
                        m_nVideoSize.Y = 1530;
                        break;
                    }
                case 107:
                    {
                        //107-2560*1600
                        m_nVideoSize.X = 2560;
                        m_nVideoSize.Y = 1600;
                        break;
                    }
                case 108:
                    {
                        //108-2800*2100
                        m_nVideoSize.X = 2800;
                        m_nVideoSize.Y = 2100;
                        break;
                    }
                case 109:
                    {
                        //109-4088*4088
                        m_nVideoSize.X = 4088;
                        m_nVideoSize.Y = 4088;
                        break;
                    }
                case 110:
                    {
                        //110-4000*3072
                        m_nVideoSize.X = 4000;
                        m_nVideoSize.Y = 3072;
                        break;
                    }
                case 111:
                    {
                        //111-960*1080(1080p Lite)
                        m_nVideoSize.X = 960;
                        m_nVideoSize.Y = 1080;
                        break;
                    }
                case 112:
                    {
                        //112-640*720(half 720p)
                        m_nVideoSize.X = 640;
                        m_nVideoSize.Y = 720;
                        break;
                    }
            }
            x = NVideoSize.X / 22;
            y = NVideoSize.Y / 18;
            if (NVideoSize.X == 0 || NVideoSize.Y == 0)
            {
                // MessageBox.Show("获取视频分辨率失败！");
                //return 0;
            }
            if (nAlarmType != 1 && PointStr != null)
            {
                //拿到PointStr先解析
                str = PointStr.Split('#');//将pointStr以#为标志分隔开，储存在str[]中

            }
            for (int i = 0; i < 396; i++)
            {
                Alarm_area[i] = 0;
            }
            switch (nAlarmType)
            {            
                case 1:
                    for (int i = 0; i < 396; i++)
                    {
                        Alarm_area[i] = 1;
                    }
                    //Alarm_result = AlarmOperation.BF_Video_SDK.XW_DVR_SetAlarmInfo(pDVRIP, nChannel, nAlarmType, nSensitive, pChannelName, Alarm_area);
                    break;//全屏
                case 2:
                    for (int i = 0; i < str.Length; i++)
                    {
                        string[] str1 = str[i].Split(',');
                        MyPoint1.X = int.Parse(str1[0]);
                        MyPoint1.Y = int.Parse(str1[1]);
                        //for (int j = 0; j < t1.Count; j++)
                        //{
                        try
                        {
                            pEndPoint.X = MyPoint1.X * NVideoSize.X / SizeX;
                            pEndPoint.Y = MyPoint1.Y * NVideoSize.Y / SizeY;
                            Alarm_area[pEndPoint.X / x + pEndPoint.Y / y * 22] = 1;
                        }
                        catch { }
                        //}
                        //t1.Add(MyPoint1);
                    }//重绘时解析字符串

                    for (int i = 0; i < 396; i++)
                    {
                        bool AlarmJudge1 = false, AlarmJudge2 = false, AlarmJudge3 = false, AlarmJudge4 = false;
                        for (int j = i; j < 396; j += 22)
                        {
                            if (Alarm_area[j] == 1)
                            {
                                AlarmJudge1 = true;
                            }
                        }
                        for (int j = i; j > 0; j -= 22)
                        {
                            if (Alarm_area[j] == 1)
                            {
                                AlarmJudge2 = true;
                            }
                        }
                        for (int j = i; j < i + 22 && j < 396; j++)
                        {
                            if (Alarm_area[j] == 1)
                            {
                                AlarmJudge3 = true;
                            }
                        }
                        for (int j = i; j > 0 && j > i - 22; j--)
                        {
                            if (Alarm_area[j] == 1)
                            {
                                AlarmJudge4 = true;
                            }
                        }
                        if (AlarmJudge1 == true && AlarmJudge2 == true && AlarmJudge3 == true && AlarmJudge4 == true)
                        {
                            Alarm_area[i] = 1;
                        }
                    }
                    //Alarm_result = AlarmOperation.BF_Video_SDK.XW_DVR_SetAlarmInfo(pDVRIP, nChannel, nAlarmType, nSensitive, pChannelName, Alarm_area);
                    break;//局部
                case 3:
                    //for (int i = 0; i < 396; i++)
                    //{
                    //    Alarm_area[i] = 0; 
                    //}
                    for (int i = 0; i < str.Length; i++)
                    {
                        string[] str1 = str[i].Split(',');
                        MyPoint1.X = int.Parse(str1[0]);
                        MyPoint1.Y = int.Parse(str1[1]);
                        //for (int j = 0; j < t1.Count; j++)
                        //{
                        try
                        {
                            pEndPoint.X = MyPoint1.X * NVideoSize.X / SizeX;
                            pEndPoint.Y = MyPoint1.Y * NVideoSize.Y / SizeY;
                            Alarm_area[pEndPoint.X / x + pEndPoint.Y / y * 22] = 1;
                        }
                        catch { }
                        //}
                        //t1.Add(MyPoint1);
                    }//重绘时解析字符串

                    try
                    {
                        //Alarm_result = AlarmOperation.BF_Video_SDK.XW_DVR_SetAlarmInfo(pDVRIP, nChannel, nAlarmType, nSensitive, pChannelName, Alarm_area);
                    }
                    catch { }

                    break;//过线
            }
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    m_struMotionV40.struMotionMode.struMotionSingleArea.byMotionScope[i * 96 + j] = (byte)Alarm_area[i*22+j];
                }
            }
            #endregion
            m_struPicCfgV40.struMotion = m_struMotionV40;
            Int32 nSize_Set = Marshal.SizeOf(m_struPicCfgV40);
            IntPtr ptrPicCfg_Set = Marshal.AllocHGlobal(nSize_Set);
            Marshal.StructureToPtr(m_struPicCfgV40, ptrPicCfg_Set, false);
            if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_PICCFG_V40, nChannel, ptrPicCfg_Set, (UInt32)nSize_Set))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_SET_PICCFG_V40 failed, error code= " + iLastErr;
                Marshal.FreeHGlobal(ptrPicCfg);
                return int.Parse(iLastErr.ToString());
                //设置图像参数失败，输出错误号 Failed to set image parameters and output the error code
                //MessageBox.Show(strErr);
            }
            else
            {
                return 1;
                //MessageBox.Show("设置图像参数成功！");
            }
            //CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_SHOWSTRING_V30, m_lChannel, ptrShowStrCfg, (UInt32)nSize);
            //if (checkBoxDisplay.Checked)
            //{
            //    m_struMotionV40.byEnableDisplay = 1;
            //}
            /*启用移动侦测高亮显示，0-否，1-是*/
            //m_struPicCfgV40.struMotion = m_struMotionV40;

            //MessageBox.Show("保存参数成功!");
        }
        /// <summary>
        /// 取消报警设置
        /// </summary>
        /// <param name="pDVRIP">设备IP地址</param>
        /// <param name="nChannel">设备通道号</param>
        /// <param name="m_lUserID">登录设备后返回ID</param>
        public static int Alarm_Close(string pDVRIP, Int32 nChannel, Int32 m_lUserID)
        {
            //-------------------获取分辨率---------------------------
            UInt32 dwReturn_CFG = 0;
            Int32 nSize_CFG = Marshal.SizeOf(m_comPressionCFG);
            IntPtr comPressionCFG = Marshal.AllocHGlobal(nSize_CFG);
            Marshal.StructureToPtr(m_comPressionCFG, comPressionCFG, false);
            bool CFG = CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_COMPRESSCFG_V30, nChannel, comPressionCFG, (UInt32)nSize_CFG, ref dwReturn_CFG);
            //------------------ 获取通道图象结构(V40扩展)------------
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struPicCfgV40);
            IntPtr ptrPicCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struPicCfgV40, ptrPicCfg, false);
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_GET_PICCFG_V40, nChannel, ptrPicCfg, (UInt32)nSize, ref dwReturn))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_GET_PICCFG_V40 failed, error code= " + iLastErr;
                return -1;
                //获取图像参数失败，输出错误号 Failed to get image parameters and output the error code
                //MessageBox.Show(strErr);
            }
            else
            {
                m_struPicCfgV40 = (CHCNetSDK.NET_DVR_PICCFG_V40)Marshal.PtrToStructure(ptrPicCfg, typeof(CHCNetSDK.NET_DVR_PICCFG_V40));
                m_struMotionV40 = m_struPicCfgV40.struMotion;
            }
            /*移动侦测灵敏度, 0 - 5,越高越灵敏,0xff关闭*/
            m_struMotionV40.struMotionMode.struMotionSingleArea.byMotionSensitive = 0;
            SetAlarmHandleWnd();
            SetAlarmTimeWnd();
            m_struMotionV40.byEnableHandleMotion = 0;
            //设置移动侦测区域 
            for (int i = 0; i < 18; i++)
            {
                for (int j = 0; j < 22; j++)
                {
                    m_struMotionV40.struMotionMode.struMotionSingleArea.byMotionScope[i * 96 + j] =0;
                }
            }
            m_struPicCfgV40.struMotion = m_struMotionV40;
            Int32 nSize_Set = Marshal.SizeOf(m_struPicCfgV40);
            IntPtr ptrPicCfg_Set = Marshal.AllocHGlobal(nSize_Set);
            Marshal.StructureToPtr(m_struPicCfgV40, ptrPicCfg_Set, false);
            if (!CHCNetSDK.NET_DVR_SetDVRConfig(m_lUserID, CHCNetSDK.NET_DVR_SET_PICCFG_V40, nChannel, ptrPicCfg_Set, (UInt32)nSize_Set))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_SET_PICCFG_V40 failed, error code= " + iLastErr;
                Marshal.FreeHGlobal(ptrPicCfg_Set);
                return int.Parse(iLastErr.ToString());
                //设置图像参数失败，输出错误号 Failed to set image parameters and output the error code
                //MessageBox.Show(strErr);
            }
            else
            {
                Marshal.FreeHGlobal(ptrPicCfg_Set);
                return 1;
                //MessageBox.Show("设置图像参数成功！");
            }
        }
        /// <summary>
        /// 设置报警处理方式
        /// </summary>
        private static void SetAlarmHandleWnd()
        {
            //设置报警处理方式

            //m_struMotionV40.dwHandleType = 0;
            //电视墙上警告
            //if (checkBoxShowAlarm.Checked)
            //{
            //    m_struMotionV40.dwHandleType |= (0x01 << 0);
            //}
            //声音报警
            //if (checkBoxAudioAlarm.Checked)
            //{
            //    m_struMotionV40.dwHandleType |= (0x01 << 1);
            //}
            //上传中心
            //if (checkBoxReportAlarm.Checked)
            //{
                m_struMotionV40.dwHandleType |= (0x01 << 2);
            //}
            //触发报警输出
            //if (checkBoxTriggerAlarm.Checked)
            //{
            //    m_struMotionV40.dwHandleType |= (0x01 << 3);
            //}
            //抓图并上传email
            //if (checkBoxEmailAlarm.Checked)
            //{
            //    m_struMotionV40.dwHandleType |= (0x01 << 4);
            //}
            //抓图并上传FTP
            //if (checkBoxFTPAlarm.Checked)
            //{
            //    m_struMotionV40.dwHandleType |= (0x01 << 9);
            //}

            int dwRelAlarmOutChanNum = 0;
            //触发报警输出具体赋值
            //for (int i = 0; i < treeViewAlarmOut.Nodes.Count; i++)
            //{
            //    if (treeViewAlarmOut.Nodes[i].Checked)
            //    {
            //        m_struMotionV40.dwRelAlarmOut[dwRelAlarmOutChanNum++] = (uint)i;
            //    }
            //}
            m_struMotionV40.dwRelAlarmOut[dwRelAlarmOutChanNum] = 0xffffffff;

        }
        /// <summary>
        /// 设置布防时间
        /// </summary>
        private static void SetAlarmTimeWnd()
        {
            //设置布防时间
            int nDayIndex = 0;
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 0].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 0].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 0].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 0].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 1].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 1].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 1].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 1].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 2].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 2].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 2].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 2].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 3].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 3].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 3].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 3].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 4].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 4].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 4].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 4].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 5].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 5].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 5].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 5].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 6].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 6].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 6].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 6].byStopMin = byte.Parse("0");

            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 7].byStartHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 7].byStartMin = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 7].byStopHour = byte.Parse("0");
            m_struMotionV40.struAlarmTime[nDayIndex * CHCNetSDK.MAX_TIMESEGMENT_V30 + 7].byStopMin = byte.Parse("0");
        }
        public static int StringSet(string IP, int m_lChannel, string wShowString, string TopLeftX, string TopLeftY)
        {
            StringGet(IP,m_lChannel);
            m_struShowStrCfg.struStringInfo[0].wShowString = 1;
            m_struShowStrCfg.struStringInfo[0].sString = wShowString;
            m_struShowStrCfg.struStringInfo[0].wStringSize = (ushort)(wShowString.Length*2);
            m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftX = UInt16.Parse(TopLeftX);
            m_struShowStrCfg.struStringInfo[0].wShowStringTopLeftY = UInt16.Parse(TopLeftY);
            int mUserID = -1;
            if (MediaData.Device_UserID_Alarm.ContainsKey(IP))
            {
                mUserID = MediaData.Device_UserID_Alarm[IP].UserID;
            }

            Int32 nSize = Marshal.SizeOf(m_struShowStrCfg);
            IntPtr ptrShowStrCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struShowStrCfg, ptrShowStrCfg, false);

            if (!CHCNetSDK.NET_DVR_SetDVRConfig(mUserID, CHCNetSDK.NET_DVR_SET_SHOWSTRING_V30, m_lChannel, ptrShowStrCfg, (UInt32)nSize))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_GET_SHOWSTRING_V30 failed, error code= " + iLastErr;
                //设置字符叠加参数失败，输出错误号 Failed to get overlay parameters and output the error code
                return int.Parse(iLastErr.ToString());
            }
            else
            {
                Console.WriteLine("设置图像参数成功！字符串:"+ wShowString);
            }

            Marshal.FreeHGlobal(ptrShowStrCfg);
            return 0;
        }
        public static int StringGet(string IP, int m_lChannel)
        {
            UInt32 dwReturn = 0;
            Int32 nSize = Marshal.SizeOf(m_struShowStrCfg);
            IntPtr ptrShowStrCfg = Marshal.AllocHGlobal(nSize);
            Marshal.StructureToPtr(m_struShowStrCfg, ptrShowStrCfg, false);
            int mUserID = -1;
            if (MediaData.Device_UserID_Alarm.ContainsKey(IP))
            {
                mUserID = MediaData.Device_UserID_Alarm[IP].UserID;
            }
            if (!CHCNetSDK.NET_DVR_GetDVRConfig(mUserID, CHCNetSDK.NET_DVR_GET_SHOWSTRING_V30, m_lChannel, ptrShowStrCfg, (UInt32)nSize, ref dwReturn))
            {
                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                string strErr = "NET_DVR_GET_SHOWSTRING_V30 failed, error code= " + iLastErr;
                //获取字符叠加参数失败，输出错误号 Failed to get overlay parameters and output the error code
                return int.Parse(iLastErr.ToString());
            }
            else
            {
                m_struShowStrCfg = (CHCNetSDK.NET_DVR_SHOWSTRING_V30)Marshal.PtrToStructure(ptrShowStrCfg, typeof(CHCNetSDK.NET_DVR_SHOWSTRING_V30));
                return 1;
            }
            Marshal.FreeHGlobal(ptrShowStrCfg);
        }
    }
}
