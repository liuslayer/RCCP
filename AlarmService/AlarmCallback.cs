using EquipmentControlServer;
using Newtonsoft.Json;
using PreviewDemo;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;

namespace AlarmService
{
    public class MediaData
    {
        public static List<CameraList> cameraList;//摄像机设备信息
        public static List<StreamMediaList> streamMediaList;//流媒体设备信息
        public static List<StreamServerList> streamServerList;//服务器流媒体设备信息
        public static List<ArmAndDisarmList> armAndDisarmList;//报警器数据信息
        public static List<LinkageData> linkageDataList;//报警联动数据信息
        public static List<TurnTableList> turnTableList;//转台数据信息
        public static List<Pre_arrangedPlanning> pre_arrangedPlanning;  
        public static CameraListRepository CameraList = new CameraListRepository();//摄像机设备信息SQL
        public static StreamMediaListRepository StreamMediaList = new StreamMediaListRepository();//流媒体设备信息SQL
        public static StreamServerListRepository StreamServerList = new StreamServerListRepository();//服务器流媒体设备信息SQL
        public static ArmAndDisArmListRepository ArmAndDisArmList = new ArmAndDisArmListRepository();//报警器数据信息SQL
        public static LinkageDataRepository LinkageData = new LinkageDataRepository();//报警联动数据信息SQL
        public static TurnTableListRepository TurnTable = new TurnTableListRepository();//转台数据SQL
        public static Pre_arrangedPlanningRepository Pre_arranged = new Pre_arrangedPlanningRepository();
        public static AlarmLogRepository AlarmLog = new AlarmLogRepository();
        public static Dictionary<string, UserID_m_lAlarmHandle> Device_UserID_Alarm = new Dictionary<string, UserID_m_lAlarmHandle>();//设备登录返回值—[string:IP]
        public struct UserID_m_lAlarmHandle
        {
            public int UserID;
            public int m_lAlarmHandle;
        }
        public static void DataInit()
        {
            //从数据库中获取各类表单
            cameraList = CameraList.GetList();
            streamMediaList = StreamMediaList.GetList();
            streamServerList = StreamServerList.GetList();
            armAndDisarmList = ArmAndDisArmList.GetList();
            linkageDataList = LinkageData.GetList();
            turnTableList = TurnTable.GetList();
            pre_arrangedPlanning = Pre_arranged.GetList();
            //    //登录设备
            //    for (int i = 0; i < streamMediaList.Count; i++)
            //    {
            //        string IPAddress = streamMediaList[i].VideoIP; //设备IP地址或者域名
            //        int PortNumber = streamMediaList[i].Port;//设备服务端口号
            //        string UserName = streamMediaList[i].UserName;//设备登录用户名
            //        string Password = streamMediaList[i].PassWord;//设备登录密码

            //        CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //        //登录设备 Login the device
            //        int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
            //        if (m_lUserID < 0)
            //        {
            //            Console.WriteLine("Login Faild!");
            //        }
            //        else
            //        {
            //            if (!Device_UserID.ContainsKey(IPAddress))
            //            {
            //                Device_UserID.Add(IPAddress, m_lUserID);
            //            }
            //            //登录成功
            //            Console.WriteLine("Login Success!");
            //            //if (!userIDList.Keys.Contains(IPAddress))
            //            //    userIDList.Add(IPAddress, m_lUserID);
            //        }
            //    }
            //}
        }
        /// <summary>
        /// SDK初始化
        /// </summary>
        /// <returns></returns>
        public static bool Init()
        {
            bool m_bInitSDK = CHCNetSDK.NET_DVR_Init();
            if (m_bInitSDK == false)
            {
                Console.WriteLine("NET_DVR_Init error!");
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void LogIn()
        {
            //登录设备
            for (int i = 0; i < streamMediaList.Count; i++)
            {
                string IPAddress = streamMediaList[i].VideoIP; //设备IP地址或者域名
                int PortNumber = streamMediaList[i].Port;//设备服务端口号
                string UserName =streamMediaList[i].UserName;//设备登录用户名
                string Password = streamMediaList[i].PassWord;//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
                if (m_lUserID < 0)
                {

                }
                else
                {
                    //登录成功
                    Console.WriteLine("Login Success!");
                    UserID_m_lAlarmHandle temp_UserID_m_lAlarmHandle = new UserID_m_lAlarmHandle();
                    temp_UserID_m_lAlarmHandle.UserID = m_lUserID;
                    temp_UserID_m_lAlarmHandle.m_lAlarmHandle = -1;
                    if (!Device_UserID_Alarm.Keys.Contains(IPAddress))
                        Device_UserID_Alarm.Add(IPAddress, temp_UserID_m_lAlarmHandle);
                }
            }
        }
        public class AlarmCallback
        {
            const int COUNTDOWN_INT = 20;//报警清理计数
            public static Dictionary<string, int> pInfoDic = new Dictionary<string, int>();//储存报警器计时字典
            public static Dictionary<string, AlarmMessageForAll> Dic_AlarmMessageForAll = new Dictionary<string, AlarmMessageForAll>();//储存当前报警器的信息(AlarmFingerprintID,报警结构体)
            public delegate void TempAlarmDelegate(string jsonStr);
            public static event TempAlarmDelegate tempAlarmEvent;
            static BF_Video_SDK.fAlarmInfoCallBack callBack;
            private static CHCNetSDK.MSGCallBack m_falarmData = null;
            public static List<ArmAndDisarmList> ArmAndDisArmList;
            static ArmAndDisArmListRepository ArmAndDisArm = new ArmAndDisArmListRepository();
            private static Int32 m_lUserID = -1;
            //private static Int32[] m_lAlarmHandle = new Int32[200];
            private static uint iLastErr = 0;//海康错误代码
            public static void stateCallBack()
            {
                //callBack = new BF_Video_SDK.fAlarmInfoCallBack(alarmCallBack);
                //BF_Video_SDK.XW_DVR_AlarmInfoCB(callBack, 0);
                MediaData.DataInit();
                ArmAndDisArmList = ArmAndDisArm.GetList();
            }
            #region 海康报警服务
            CHCNetSDK.NET_VCA_TRAVERSE_PLANE m_struTraversePlane = new CHCNetSDK.NET_VCA_TRAVERSE_PLANE();
            CHCNetSDK.NET_VCA_AREA m_struVcaArea = new CHCNetSDK.NET_VCA_AREA();
            CHCNetSDK.NET_VCA_INTRUSION m_struIntrusion = new CHCNetSDK.NET_VCA_INTRUSION();
            //CHCNetSDK.UNION_STATFRAME m_struStatFrame = new CHCNetSDK.UNION_STATFRAME();
            //CHCNetSDK.UNION_STATTIME m_struStatTime = new CHCNetSDK.UNION_STATTIME();
            public static void AlarmMessageCallback()
            {
                DataInit();//数据初始化
                Init();//海康初始化
                LogIn();//设备登录
                //设置报警回调函数
                Thread th = new Thread(AlarmCall_Start);
                th.IsBackground = true;
                th.Start();
            }
            public static void AlarmCall_Start()
            {
                m_falarmData = new CHCNetSDK.MSGCallBack(MsgCallback);
                bool temp_a = CHCNetSDK.NET_DVR_SetDVRMessageCallBack_V30(m_falarmData, IntPtr.Zero);
                GC.KeepAlive(m_falarmData);
                SetAlarm();
            }
            public static void MsgCallback(int lCommand, ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
            {
                //通过lCommand来判断接收到的报警信息类型，不同的lCommand对应不同的pAlarmInfo内容
                switch (lCommand)
                {
                    case CHCNetSDK.COMM_ALARM: //(DS-8000老设备)移动侦测、视频丢失、遮挡、IO信号量等报警信息
                                               //ProcessCommAlarm(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    case CHCNetSDK.COMM_ALARM_V30://移动侦测、视频丢失、遮挡、IO信号量等报警信息
                         ProcessCommAlarm_V30(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    case CHCNetSDK.COMM_ALARM_RULE://进出区域、入侵、徘徊、人员聚集等行为分析报警信息
                                                   //ProcessCommAlarm_RULE(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    case CHCNetSDK.COMM_UPLOAD_PLATE_RESULT://交通抓拍结果上传(老报警信息类型)
                                                            //ProcessCommAlarm_Plate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    case CHCNetSDK.COMM_ITS_PLATE_RESULT://交通抓拍结果上传(新报警信息类型)
                                                         //ProcessCommAlarm_ITSPlate(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    case CHCNetSDK.COMM_ALARM_PDC://客流量统计报警信息
                                                  // ProcessCommAlarm_PDC(ref pAlarmer, pAlarmInfo, dwBufLen, pUser);
                        break;
                    default:
                        break;
                }
            }
            public static void SetAlarm()
            {
                CHCNetSDK.NET_DVR_SETUPALARM_PARAM struAlarmParam = new CHCNetSDK.NET_DVR_SETUPALARM_PARAM();
                struAlarmParam.dwSize = (uint)Marshal.SizeOf(struAlarmParam);
                struAlarmParam.byLevel = 1; //0- 一级布防,1- 二级布防
                struAlarmParam.byAlarmInfoType = 1;//智能交通设备有效，新报警信息类型

                for (int i = 0; i < Device_UserID_Alarm.Count; i++)
                {
                    m_lUserID = Device_UserID_Alarm.ElementAt(i).Value.UserID;
                    UserID_m_lAlarmHandle temp_UserID_m_lAlarmHandle = new UserID_m_lAlarmHandle();
                    temp_UserID_m_lAlarmHandle.UserID = m_lUserID;
                    temp_UserID_m_lAlarmHandle.m_lAlarmHandle = CHCNetSDK.NET_DVR_SetupAlarmChan_V41(m_lUserID, ref struAlarmParam);
                    string temp_ip = Device_UserID_Alarm.ElementAt(i).Key;
                    if (temp_UserID_m_lAlarmHandle.m_lAlarmHandle < 0)
                    {
                        iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        Console.WriteLine("布防失败，错误号：" + iLastErr); //布防失败，输出错误号
                    }
                    else
                    {
                        Device_UserID_Alarm[temp_ip] = temp_UserID_m_lAlarmHandle;
                        Console.WriteLine("布防成功"+ Device_UserID_Alarm.ElementAt(i).Key);
                    }
                }
            }
            public void SetSTDConfig()
            {
                //CHCNetSDK.NET_DVR_SetSTDConfig();
            }
            private static void ProcessCommAlarm_V30(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
            {

                CHCNetSDK.NET_DVR_ALARMINFO_V30 struAlarmInfoV30 = new CHCNetSDK.NET_DVR_ALARMINFO_V30();

                struAlarmInfoV30 = (CHCNetSDK.NET_DVR_ALARMINFO_V30)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_DVR_ALARMINFO_V30));

                string strIP = pAlarmer.sDeviceIP;
                string stringAlarm = "";
                int i;

                switch (struAlarmInfoV30.dwAlarmType)
                {
                    case 0:
                        stringAlarm = "信号量报警，报警报警输入口：" + struAlarmInfoV30.dwAlarmInputNumber + "，触发录像通道：";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byAlarmRelateChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + "\\";
                            }
                        }
                        break;
                    case 1:
                        stringAlarm = "硬盘满，报警硬盘号：";
                        for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byDiskNumber[i] == 1)
                            {
                                stringAlarm += (i + 1) + " ";
                            }
                        }
                        break;
                    case 2:
                        stringAlarm = "信号丢失，报警通道：";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 3:
                        stringAlarm = "移动侦测，报警通道：";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                                string pInfo = strIP + "," + (i+1).ToString();
                                alarmCallBack(pInfo, pInfo.Length,0);
                            }
                        }
                        break;
                    case 4:
                        stringAlarm = "硬盘未格式化，报警硬盘号：";
                        for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byDiskNumber[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 5:
                        stringAlarm = "读写硬盘出错，报警硬盘号：";
                        for (i = 0; i < CHCNetSDK.MAX_DISKNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byDiskNumber[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 6:
                        stringAlarm = "遮挡报警，报警通道：";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 7:
                        stringAlarm = "制式不匹配，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 8:
                        stringAlarm = "非法访问";
                        break;
                    case 9:
                        stringAlarm = "视频信号异常，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 10:
                        stringAlarm = "录像/抓图异常，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 11:
                        stringAlarm = "智能场景变化，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 12:
                        stringAlarm = "阵列异常";
                        break;
                    case 13:
                        stringAlarm = "前端/录像分辨率不匹配，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    case 15:
                        stringAlarm = "智能侦测，报警通道";
                        for (i = 0; i < CHCNetSDK.MAX_CHANNUM_V30; i++)
                        {
                            if (struAlarmInfoV30.byChannel[i] == 1)
                            {
                                stringAlarm += (i + 1) + " \\ ";
                            }
                        }
                        break;
                    default:
                        stringAlarm = "其他未知报警信息";
                        break;
                }
            }
            private void ProcessCommAlarm_RULE(ref CHCNetSDK.NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser)
            {
                CHCNetSDK.NET_VCA_RULE_ALARM struRuleAlarmInfo = new CHCNetSDK.NET_VCA_RULE_ALARM();
                struRuleAlarmInfo = (CHCNetSDK.NET_VCA_RULE_ALARM)Marshal.PtrToStructure(pAlarmInfo, typeof(CHCNetSDK.NET_VCA_RULE_ALARM));

                //报警信息
                string stringAlarm = "";
                uint dwSize = (uint)Marshal.SizeOf(struRuleAlarmInfo.struRuleInfo.uEventParam);

                switch (struRuleAlarmInfo.struRuleInfo.wEventTypeEx)
                {
                    case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_TRAVERSE_PLANE:
                        IntPtr ptrTraverseInfo = Marshal.AllocHGlobal((Int32)dwSize);
                        Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrTraverseInfo, false);
                        m_struTraversePlane = (CHCNetSDK.NET_VCA_TRAVERSE_PLANE)Marshal.PtrToStructure(ptrTraverseInfo, typeof(CHCNetSDK.NET_VCA_TRAVERSE_PLANE));
                        stringAlarm = "穿越警戒面，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                        //警戒面边线起点坐标: (m_struTraversePlane.struPlaneBottom.struStart.fX, m_struTraversePlane.struPlaneBottom.struStart.fY)
                        //警戒面边线终点坐标: (m_struTraversePlane.struPlaneBottom.struEnd.fX, m_struTraversePlane.struPlaneBottom.struEnd.fY)
                        break;
                    case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_ENTER_AREA:
                        IntPtr ptrEnterInfo = Marshal.AllocHGlobal((Int32)dwSize);
                        Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrEnterInfo, false);
                        m_struVcaArea = (CHCNetSDK.NET_VCA_AREA)Marshal.PtrToStructure(ptrEnterInfo, typeof(CHCNetSDK.NET_VCA_AREA));
                        stringAlarm = "目标进入区域，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                        //m_struVcaArea.struRegion 多边形区域坐标
                        break;
                    case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_EXIT_AREA:
                        IntPtr ptrExitInfo = Marshal.AllocHGlobal((Int32)dwSize);
                        Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrExitInfo, false);
                        m_struVcaArea = (CHCNetSDK.NET_VCA_AREA)Marshal.PtrToStructure(ptrExitInfo, typeof(CHCNetSDK.NET_VCA_AREA));
                        stringAlarm = "目标离开区域，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                        //m_struVcaArea.struRegion 多边形区域坐标
                        break;
                    case (ushort)CHCNetSDK.VCA_RULE_EVENT_TYPE_EX.ENUM_VCA_EVENT_INTRUSION:
                        IntPtr ptrIntrusionInfo = Marshal.AllocHGlobal((Int32)dwSize);
                        Marshal.StructureToPtr(struRuleAlarmInfo.struRuleInfo.uEventParam, ptrIntrusionInfo, false);
                        m_struIntrusion = (CHCNetSDK.NET_VCA_INTRUSION)Marshal.PtrToStructure(ptrIntrusionInfo, typeof(CHCNetSDK.NET_VCA_INTRUSION));
                        stringAlarm = "周界入侵，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                        //m_struIntrusion.struRegion 多边形区域坐标
                        break;
                    default:
                        stringAlarm = "其他行为分析报警，目标ID：" + struRuleAlarmInfo.struTargetInfo.dwID;
                        break;
                }


                //报警图片保存
                if (struRuleAlarmInfo.dwPicDataLen > 0)
                {
                    FileStream fs = new FileStream("行为分析报警抓图.jpg", FileMode.Create);
                    int iLen = (int)struRuleAlarmInfo.dwPicDataLen;
                    byte[] by = new byte[iLen];
                    Marshal.Copy(struRuleAlarmInfo.pImage, by, 0, iLen);
                    fs.Write(by, 0, iLen);
                    fs.Close();
                }

                //报警时间：年月日时分秒
                string strTimeYear = ((struRuleAlarmInfo.dwAbsTime >> 26) + 2000).ToString();
                string strTimeMonth = ((struRuleAlarmInfo.dwAbsTime >> 22) & 15).ToString("d2");
                string strTimeDay = ((struRuleAlarmInfo.dwAbsTime >> 17) & 31).ToString("d2");
                string strTimeHour = ((struRuleAlarmInfo.dwAbsTime >> 12) & 31).ToString("d2");
                string strTimeMinute = ((struRuleAlarmInfo.dwAbsTime >> 6) & 63).ToString("d2");
                string strTimeSecond = ((struRuleAlarmInfo.dwAbsTime >> 0) & 63).ToString("d2");
                string strTime = strTimeYear + "-" + strTimeMonth + "-" + strTimeDay + " " + strTimeHour + ":" + strTimeMinute + ":" + strTimeSecond;

                //报警设备IP地址
                string strIP = struRuleAlarmInfo.struDevInfo.struDevIP.sIpV4;

                ////将报警信息添加进列表
                //if (InvokeRequired)
                //{
                //    object[] paras = new object[3];
                //    paras[0] = strTime;
                //    paras[1] = strIP;
                //    paras[2] = stringAlarm;
                //    listViewAlarmInfo.BeginInvoke(new UpdateListBoxCallback(UpdateClientList), paras);
                //}
                //else
                //{
                //    //创建该控件的主线程直接更新信息列表 
                //    UpdateClientList(strTime, strIP, stringAlarm);
                //}
            }
            #endregion
            /// <summary>
            /// 
            /// </summary>
            /// <param name="pInfo">回调函数信息</param>
            /// <param name="lBufSize">数据长度</param>
            /// <param name="userdata">报警类型：0-视频触发报警(当在数据库中无法查询到相关信息时，赋值为0，表示为临时报警);4-雷达;5-震动光缆;6-smartwall;7-微博墙</param>
            public static void alarmCallBack(string pInfo, Int32 lBufSize, UInt32 userdata)
            {
                //报警器字典开始计数
                if (pInfoDic.ContainsKey(pInfo))
                {
                    pInfoDic[pInfo] = COUNTDOWN_INT;
                    //---------------------测试用发送数据------------------------------
                    //SendToClient(Dic_AlarmMessageForAll.ElementAt(0).Value,1);
                    //-----------------------------------------------------------------
                    //Console.WriteLine("报警字典刷新时间:" + pInfo);
                    return;
                }
                else
                {
                    pInfoDic.Add(pInfo, COUNTDOWN_INT);
                    Console.WriteLine("报警字典添加信息:" + pInfo);
                }
                string temp_DeviceID = null;
                string temp_AlarmDeviceID = null;
                string temp_PlanDeviceID = null;
                switch (userdata)
                {
                    case 0://视频报警
                        {
                            //--------------------根据接受的报警信息查询相应的设备ID、报警ID--------------------------
                            string[] temp_pInfo = pInfo.Split(',');
                            string temp_ip = temp_pInfo[0];
                            string temp_channel = temp_pInfo[1];
                            ArmAndDisarmList temp_ArmAndDisarmList = new ArmAndDisarmList();
                            Pre_arrangedPlanning temp_Pre_arrangedPlanning = new Pre_arrangedPlanning();//预案数据查询
                            if (MediaData.streamMediaList!=null)
                            {
                                StreamMediaList temp_StreamMediaList = MediaData.streamMediaList.Find(_ => _.VideoIP == temp_ip);
                                if (temp_StreamMediaList != null)
                                {
                                    CameraList temp_CameraList = MediaData.cameraList.Find(_ => _.StreamMedia_DeviceID == temp_StreamMediaList.DeviceID && _.VideoChannel == int.Parse(temp_channel));
                                    //直连设备
                                    if (temp_CameraList != null)
                                    {
                                        temp_Pre_arrangedPlanning = pre_arrangedPlanning.Find(_=>_.DeviceID== temp_CameraList.DeviceID.ToString()&&_.Mark=="1");
                                        if (temp_Pre_arrangedPlanning!=null)
                                        {
                                            temp_PlanDeviceID = temp_Pre_arrangedPlanning.PlanDeviceID.ToString();
                                            temp_ArmAndDisarmList = MediaData.armAndDisarmList.Find(_ => _.DeviceID.ToString() == temp_Pre_arrangedPlanning.DeviceID.ToString());
                                            if (temp_ArmAndDisarmList != null)
                                            {
                                                temp_AlarmDeviceID = temp_ArmAndDisarmList.AlarmDeviceID.ToString();
                                            }
                                            //return;
                                        }
                                    }
                                }
                                else
                                {
                                    //流媒体设备
                                    StreamServerList temp_StreamServerList = MediaData.streamServerList.Find(_ => _.StreamServerIP.ToString() == temp_ip);
                                    if (temp_StreamServerList != null)
                                    {
                                        CameraList temp_CameraList = MediaData.cameraList.Find(_ => _.StreamMedia_DeviceID == temp_StreamMediaList.DeviceID && _.VideoChannel == int.Parse(temp_channel));
                                        //直连设备
                                        if (temp_CameraList != null)
                                        {
                                            temp_Pre_arrangedPlanning = pre_arrangedPlanning.Find(_ => _.DeviceID == temp_CameraList.DeviceID.ToString() && _.Mark == "1");
                                            if (temp_Pre_arrangedPlanning != null)
                                            {
                                                temp_PlanDeviceID = temp_Pre_arrangedPlanning.PlanDeviceID.ToString();
                                                temp_ArmAndDisarmList = MediaData.armAndDisarmList.Find(_ => _.AlarmDeviceID.ToString() == temp_Pre_arrangedPlanning.PlanDeviceID.ToString());
                                                if (temp_ArmAndDisarmList != null)
                                                {
                                                    temp_AlarmDeviceID = temp_ArmAndDisarmList.AlarmDeviceID.ToString();
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            
                            //--------------------根据接受的报警信息查询相应的设备ID、报警ID--------------------------
                            if (temp_ArmAndDisarmList!= null&& temp_Pre_arrangedPlanning!=null)//判断为视频报警器
                            {
                                if (temp_ArmAndDisarmList.DeviceID!=null)
                                {
                                    #region 新建报警信息，查询并赋值，往当前报警器字典中存储信息
                                    //---------------------通过报警的相关信息查询AlarmDeviceID的值--------------------------
                                    AlarmMessageForAll temp_AlarmMessageForAll = AssembleAlarm(temp_AlarmDeviceID, temp_PlanDeviceID, temp_ip,temp_channel);
                                    temp_AlarmMessageForAll.alarmmessage.AlarmString = pInfo;
                                    Dic_AlarmMessageForAll.Add(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID, temp_AlarmMessageForAll);
                                    //当前报警器报警信息添加
                                    Console.WriteLine("当前报警器报警信息添加:" + temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID);
                                    //测试用信息
                                    //AlarmFingerprintID = temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID;
                                    #endregion
                                    if (temp_AlarmMessageForAll != null)
                                    {
                                        Thread th = new Thread(AlarmClear);
                                        th.IsBackground = true;
                                        string AlarmClearMessage = pInfo + '|' + temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID.ToString();
                                        th.Start((object)AlarmClearMessage);
                                        //进入报警触发流程
                                        DoAlarmWithParamType(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID, ParamType.Trigger, userdata);
                                    }
                                }
                                else //进入临时报警触发流程
                                {
                                    AlarmMessageForAll temp_AlarmMessageForAll = AssembleAlarm(temp_AlarmDeviceID, temp_PlanDeviceID, temp_ip, temp_channel);
                                    temp_AlarmMessageForAll.alarmmessage.AlarmString = pInfo;
                                    temp_AlarmMessageForAll.alarmmessage.DeviceID = temp_DeviceID;
                                    Dic_AlarmMessageForAll.Add(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID, temp_AlarmMessageForAll);
                                    SendToClient(temp_AlarmMessageForAll, 1);
                                    string AlarmClearMessage = pInfo + '|' + temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID.ToString();
                                    Thread th = new Thread(temp_AlarmClear);
                                    th.IsBackground = true;
                                    th.Start((object)AlarmClearMessage);
                                }
                            }
                            else //进入临时报警触发流程
                            {
                                AlarmMessageForAll temp_AlarmMessageForAll = AssembleAlarm(temp_AlarmDeviceID, temp_PlanDeviceID, temp_ip, temp_channel);
                                temp_AlarmMessageForAll.alarmmessage.AlarmString = pInfo;
                                temp_AlarmMessageForAll.alarmmessage.DeviceID = temp_DeviceID;
                                bool temp = Dic_AlarmMessageForAll.ContainsKey(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID);
                                if (Dic_AlarmMessageForAll.ContainsKey(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID))
                                {
                                    temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID = Guid.NewGuid().ToString("N");
                                }
                                Dic_AlarmMessageForAll.Add(temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID, temp_AlarmMessageForAll);
                                SendToClient(temp_AlarmMessageForAll,1);
                                string AlarmClearMessage = pInfo + '|' + temp_AlarmMessageForAll.alarmmessage.AlarmFingerprintID.ToString();
                                Thread th = new Thread(temp_AlarmClear);
                                th.IsBackground = true;
                                th.Start((object)AlarmClearMessage);
                            }
                            break;
                        }
                    case 4://雷达报警器流程
                        {
                            Console.WriteLine("收到雷达报警信息:" + pInfo);
                            string[] temp_pInfo = pInfo.Split(',');//接受报警的IP地址以及对方发送的端口号
                            temp_AlarmDeviceID = temp_pInfo[0];
                            break;
                        }
                    case 5://震动光缆报警器流程
                        { break; }
                    case 6://Smartwall报警器流程
                        { break; }
                    case 7://微波墙报警器流程
                        { break; }
                }
            }
            private static void temp_AlarmClear(object o)
            {
                string AlarmClearMessage = o.ToString();
                string[] temp_AlarmClearMessage = AlarmClearMessage.Split('|');
                string pInfo_a = temp_AlarmClearMessage[0];
                string temp_AlarmFingerprintID = temp_AlarmClearMessage[1].ToString();
                while (true)
                {
                    pInfoDic[pInfo_a]--;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (pInfoDic[pInfo_a] == 0)
                        break;
                }
                Dic_AlarmMessageForAll[temp_AlarmFingerprintID].alarmmessage.AlarmStage = 4;
                SendToClient(Dic_AlarmMessageForAll[temp_AlarmFingerprintID],4);
                pInfoDic.Remove(pInfo_a);
                Dic_AlarmMessageForAll.Remove(temp_AlarmFingerprintID);
                Console.WriteLine("报警字典删除信息:临时报警" + pInfo_a);
            }
            /// <summary>
            /// 一定时间后清理报警器报警
            /// </summary>
            /// <param name="o"></param>
            private static void AlarmClear(object o)
            {
                string AlarmClearMessage = o.ToString();
                string[] temp_AlarmClearMessage = AlarmClearMessage.Split('|');
                string pInfo_a = temp_AlarmClearMessage[0];
                string temp_AlarmFingerprintID =temp_AlarmClearMessage[1].ToString();
                while (true)
                {
                    pInfoDic[pInfo_a]--;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    if (pInfoDic[pInfo_a] == 0)
                        break;
                }
                //执行联动结束流程
                DoAlarmWithParamType(temp_AlarmFingerprintID, ParamType.AlarmEnd, Convert.ToUInt32(Dic_AlarmMessageForAll[temp_AlarmFingerprintID].alarmmessage.AlarmType));
                pInfoDic.Remove(pInfo_a);
                Dic_AlarmMessageForAll.Remove(temp_AlarmFingerprintID);
                Console.WriteLine("报警字典删除信息:" + pInfo_a);
            }
            public static void DoAlarmWithParamType(string AlarmFingerprintID, ParamType paramType, UInt32 userdata)
            {
                if (!Dic_AlarmMessageForAll.ContainsKey(AlarmFingerprintID))
                    return;
                if (paramType == ParamType.Trigger)
                {
                    Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage =1;
                    //未处置线程计时启动
                    Thread untreatedTh = new Thread(DoUntreated);
                    untreatedTh.IsBackground = true;
                    untreatedTh.Start((object)AlarmFingerprintID);
                    /*----传入LinkageData，执行相应操作----*/
                    DoLinkageData(AlarmFingerprintID, Dic_AlarmMessageForAll[AlarmFingerprintID].Trigger_LinkageData);
                    /*----end----*/
                }
                else if (paramType == ParamType.Disposal)
                {
                    Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage = 2;
                    Thread disposalTh = new Thread(DoDisposal);
                    disposalTh.IsBackground = true;
                    disposalTh.Start((object)AlarmFingerprintID);
                }
                else if (paramType==ParamType.AlarmEnd)
                {
                    Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage = 4;
                    DoLinkageData(AlarmFingerprintID,new LinkageDataStruct());
                }
            }
            /// <summary>
            /// 等待进入报警未处置
            /// </summary>
            /// <param name="o"></param>
            private static void DoUntreated(object o)
            {
                string temp_AlarmFingerprintID = o.ToString();
                //Thread.Sleep(TimeSpan.FromSeconds(int.Parse(Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData.Mark)));
                if (!Dic_AlarmMessageForAll.ContainsKey(temp_AlarmFingerprintID))
                {
                    return;
                }
                int sleepTime=0;
                if (Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData.Mark!=null)
                {
                    sleepTime = int.Parse(Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData.Mark);
                }
                Thread.Sleep(TimeSpan.FromSeconds(sleepTime));
                if (Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData.LinkageID == null ||
                    Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Disposal_LinkageData.isAlarm == true)//如果已经处置，则不继续处理
                { return; }
                Console.WriteLine("执行报警未处置操作:" + temp_AlarmFingerprintID);
                //else
                //{
                //    //Thread.Sleep(TimeSpan.FromSeconds(int.Parse(Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData.Mark)));
                //    Thread.Sleep(TimeSpan.FromSeconds(10));
                //} 

                Dic_AlarmMessageForAll[temp_AlarmFingerprintID].alarmmessage.AlarmStage = 3;
                /*----根据传入LinkageData，执行相应操作----*/
                DoLinkageData(temp_AlarmFingerprintID, Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Untreated_LinkageData);
                /*----end----*/
            }
            /// <summary>
            /// 处置报警流程
            /// </summary>
            /// <param name="o"></param>
            public static void DoDisposal(object o)
            {
                string temp_AlarmFingerprintID = o.ToString();
                Console.WriteLine("执行报警处置操作:" + temp_AlarmFingerprintID);
                if (Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Disposal_LinkageData.LinkageID == null)
                { return; }
                else
                {
                    DoLinkageData(temp_AlarmFingerprintID, Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Disposal_LinkageData);
                    Dic_AlarmMessageForAll[temp_AlarmFingerprintID].Disposal_LinkageData.isAlarm = true;//表示已经成功执行报警处置流程
                    /*----根据传入LinkageData，执行相应操作----*/
                    /*----end----*/
                }
            }
            public static AlarmMessageForAll AssembleAlarm(string AlarmDeviceID,string PlanDeviceID, string IP ,string Channel)
            {
                if (AlarmDeviceID != null)
                {
                    string temp_AlarmDeviceID = AlarmDeviceID;
                    AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                    AlarmMessage temp_AlarmMessage = new AlarmMessage();
                    {
                        StreamMediaList temp_StreamMediaList = MediaData.streamMediaList.Find(_ => _.VideoIP == IP);
                        if (temp_StreamMediaList != null)
                        {
                            CameraList temp_CameraList = MediaData.cameraList.Find(_ => _.StreamMedia_DeviceID == temp_StreamMediaList.DeviceID && _.VideoChannel == int.Parse(Channel));
                            if (temp_CameraList != null)
                            {
                                TurnTableList temp_TurnTableList = MediaData.turnTableList.Find(_ => _.DeviceID == temp_CameraList.Turntable_PTZ_DeviceID);
                                if (temp_TurnTableList!=null)
                                {
                                    temp_AlarmMessage.AlarmPosition_X = float.Parse(temp_TurnTableList.Lon.ToString());
                                    temp_AlarmMessage.AlarmPosition_Y = float.Parse(temp_TurnTableList.Lat.ToString());
                                }
                            }
                        }
                        ArmAndDisarmList temp_ArmAndDisarmList = new ArmAndDisarmList();
                        //temp_ArmAndDisarmList = Array.Find<ArmAndDisarmList>(MediaData.armAndDisarmList.ToArray(), _ => _.AlarmDeviceID.ToString() == AlarmDeviceID);
                        temp_ArmAndDisarmList = MediaData.armAndDisarmList.Find(_ => _.AlarmDeviceID.ToString() == AlarmDeviceID);
                        if (temp_ArmAndDisarmList != null)
                        {
                            //根据AlarmDeviceID查询相关报警信息，并组装报警信息结构体
                            temp_AlarmMessage.AlarmFingerprintID = Guid.NewGuid().ToString("N");
                            temp_AlarmMessage.AlarmAreaName = temp_ArmAndDisarmList.AlarmName;
                            if (temp_ArmAndDisarmList.Description != null)
                            {
                                temp_AlarmMessage.AlarmDescription = int.Parse(temp_ArmAndDisarmList.Description);
                            }
                            temp_AlarmMessage.AlarmDeviceID = temp_ArmAndDisarmList.AlarmDeviceID.ToString();
                            temp_AlarmMessage.AlarmType = temp_ArmAndDisarmList.AlarmType;
                            temp_AlarmMessage.DeviceID = temp_ArmAndDisarmList.DeviceID.ToString();
                            temp_AlarmMessage.AlarmLevel = temp_ArmAndDisarmList.AlarmLevel;
                            temp_AlarmMessage.DT_Alarm = DateTime.Now;
                            temp_AlarmMessage.AlarmStage = 1;//表示报警开始
                        }
                        /*-----------------以下为测试数据---------------*/
                        //temp_AlarmMessage.AlarmAreaName = "测试报警防区";
                        //temp_AlarmMessage.AlarmDeviceID = "10001";
                        //temp_AlarmMessage.AlarmDistance = 1000;
                        //temp_AlarmMessage.AlarmLevel = 1;
                        //temp_AlarmMessage.DeviceID = "7001";
                        /*----end----*/
                    }
                    temp_AlarmMessageForAll.alarmmessage = temp_AlarmMessage;
                    LinkageDataStruct temp_Trigger_LinkageData = new LinkageDataStruct();//联动信息
                    {
                        LinkageData temp_TriggerLinkageData = new LinkageData();
                        temp_TriggerLinkageData = MediaData.linkageDataList.Find(_ => _.PlanDeviceID.ToString() == PlanDeviceID && _.LinakgeStage == 1);
                        //从数据库预案信息中查询该报警器相关联动信息，并赋值
                        if (temp_TriggerLinkageData != null)
                        {
                            temp_Trigger_LinkageData.LinkageID = temp_TriggerLinkageData.LinkageID.ToString();
                            temp_Trigger_LinkageData.Video_DeviceID = temp_TriggerLinkageData.VideoDeviceID;
                            temp_Trigger_LinkageData.LinkageStage = "1";
                            temp_Trigger_LinkageData.PTZ_DeviceID = temp_TriggerLinkageData.PTZDeviceID;
                            temp_Trigger_LinkageData.Preset = temp_TriggerLinkageData.Preset;
                            temp_Trigger_LinkageData.Switch_DeviceID = temp_TriggerLinkageData.SwitchDeviceID;
                            temp_Trigger_LinkageData.SwitchOperation = temp_TriggerLinkageData.SwitchOperation;
                            temp_Trigger_LinkageData.SwitchOperationTimeDelay = temp_TriggerLinkageData.Switchoperationtimedelay;
                            temp_Trigger_LinkageData.VideoRecording = temp_TriggerLinkageData.Videorecording;
                            temp_Trigger_LinkageData.AlarmSound = temp_TriggerLinkageData.Alarmsound;
                            temp_Trigger_LinkageData.AlarmSoundTimeDelay = temp_TriggerLinkageData.Alarmsoundtimedelay;
                            temp_Trigger_LinkageData.Reset = temp_TriggerLinkageData.Reset;
                            temp_Trigger_LinkageData.Mark = temp_TriggerLinkageData.Mark;
                            temp_Trigger_LinkageData.Description = temp_TriggerLinkageData.Description;
                        }
                        temp_Trigger_LinkageData.isAlarm = false;
                        /*-----------------以下为测试数据---------------*/
                        //temp_Trigger_LinkageData.LinkageID = "10001";
                        //temp_Trigger_LinkageData.isAlarm = false;
                        //temp_Trigger_LinkageData.LinkageStage = "1";
                        /*----end----*/
                    }
                    temp_AlarmMessageForAll.Trigger_LinkageData = temp_Trigger_LinkageData;
                    LinkageDataStruct temp_Disposal_LinkageData = new LinkageDataStruct();//处置信息
                    {
                        RCCP.Repository.Entities.LinkageData temp_DisposalLinkageData = new RCCP.Repository.Entities.LinkageData();
                        temp_DisposalLinkageData = MediaData.linkageDataList.Find(_ => _.PlanDeviceID.ToString() == PlanDeviceID && _.LinakgeStage == 2);
                        //从数据库预案信息中查询该报警器相关处置信息，并赋值
                        if (temp_DisposalLinkageData != null)
                        {
                            temp_Disposal_LinkageData.LinkageID = temp_DisposalLinkageData.LinkageID.ToString();
                            temp_Disposal_LinkageData.Video_DeviceID = temp_DisposalLinkageData.VideoDeviceID;
                            temp_Disposal_LinkageData.LinkageStage = "2";
                            temp_Disposal_LinkageData.PTZ_DeviceID = temp_DisposalLinkageData.PTZDeviceID;
                            temp_Disposal_LinkageData.Preset = temp_DisposalLinkageData.Preset;
                            temp_Disposal_LinkageData.Switch_DeviceID = temp_DisposalLinkageData.SwitchDeviceID;
                            temp_Disposal_LinkageData.SwitchOperation = temp_DisposalLinkageData.SwitchOperation;
                            temp_Disposal_LinkageData.SwitchOperationTimeDelay = temp_DisposalLinkageData.Switchoperationtimedelay;
                            temp_Disposal_LinkageData.VideoRecording = temp_DisposalLinkageData.Videorecording;
                            temp_Disposal_LinkageData.AlarmSound = temp_DisposalLinkageData.Alarmsound;
                            temp_Disposal_LinkageData.AlarmSoundTimeDelay = temp_DisposalLinkageData.Alarmsoundtimedelay;
                            temp_Disposal_LinkageData.Reset = temp_DisposalLinkageData.Reset;
                            temp_Disposal_LinkageData.Mark = temp_DisposalLinkageData.Mark;
                            temp_Disposal_LinkageData.Description = temp_DisposalLinkageData.Description;
                        }
                        temp_Trigger_LinkageData.isAlarm = false;
                        /*-----------------以下为测试数据---------------*/
                        /*----end----*/
                    }
                    temp_AlarmMessageForAll.Disposal_LinkageData = temp_Disposal_LinkageData;
                    LinkageDataStruct temp_Untreated_LinkageData = new LinkageDataStruct();//未处置信息
                    {
                        RCCP.Repository.Entities.LinkageData temp_UntreatedLinkageData = new RCCP.Repository.Entities.LinkageData();
                        temp_UntreatedLinkageData = MediaData.linkageDataList.Find(_ => _.PlanDeviceID.ToString() == PlanDeviceID && _.LinakgeStage == 3);
                        //从数据库预案信息中查询该报警器相关处置信息，并赋值
                        if (temp_UntreatedLinkageData != null)
                        {
                            temp_Untreated_LinkageData.LinkageID = temp_UntreatedLinkageData.LinkageID.ToString();
                            temp_Untreated_LinkageData.Video_DeviceID = temp_UntreatedLinkageData.VideoDeviceID;
                            temp_Untreated_LinkageData.LinkageStage = "3";
                            temp_Untreated_LinkageData.PTZ_DeviceID = temp_UntreatedLinkageData.PTZDeviceID;
                            temp_Untreated_LinkageData.Preset = temp_UntreatedLinkageData.Preset;
                            temp_Untreated_LinkageData.Switch_DeviceID = temp_UntreatedLinkageData.SwitchDeviceID;
                            temp_Untreated_LinkageData.SwitchOperation = temp_UntreatedLinkageData.SwitchOperation;
                            temp_Untreated_LinkageData.SwitchOperationTimeDelay = temp_UntreatedLinkageData.Switchoperationtimedelay;
                            temp_Untreated_LinkageData.VideoRecording = temp_UntreatedLinkageData.Videorecording;
                            temp_Untreated_LinkageData.AlarmSound = temp_UntreatedLinkageData.Alarmsound;
                            temp_Untreated_LinkageData.AlarmSoundTimeDelay = temp_UntreatedLinkageData.Alarmsoundtimedelay;
                            temp_Untreated_LinkageData.Reset = temp_UntreatedLinkageData.Reset;
                            temp_Untreated_LinkageData.Mark = temp_UntreatedLinkageData.Mark;
                            temp_Untreated_LinkageData.Description = temp_UntreatedLinkageData.Description;
                        }
                        temp_Untreated_LinkageData.isAlarm = false;
                        /*-----------------以下为测试数据---------------*/
                        /*----end----*/
                    }
                    temp_AlarmMessageForAll.Untreated_LinkageData = temp_Untreated_LinkageData;
                    return temp_AlarmMessageForAll;
                }
                else
                {
                    AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                    AlarmMessage temp_AlarmMessage = new AlarmMessage();
                    StreamMediaList temp_StreamMediaList = MediaData.streamMediaList.Find(_ => _.VideoIP == IP);
                    if (temp_StreamMediaList != null)
                    {
                        CameraList temp_CameraList = MediaData.cameraList.Find(_ => _.StreamMedia_DeviceID == temp_StreamMediaList.DeviceID && _.VideoChannel == int.Parse(Channel));
                        if (temp_CameraList != null)
                        {
                            TurnTableList temp_TurnTableList = MediaData.turnTableList.Find(_ => _.DeviceID == temp_CameraList.Turntable_PTZ_DeviceID);
                            if (temp_TurnTableList!=null)
                            {
                                temp_AlarmMessage.AlarmPosition_X = float.Parse(temp_TurnTableList.Lon.ToString());
                                temp_AlarmMessage.AlarmPosition_Y = float.Parse(temp_TurnTableList.Lat.ToString());
                            }
                        }
                    }
                    temp_AlarmMessage.AlarmFingerprintID = Guid.NewGuid().ToString("N");
                    temp_AlarmMessage.DT_Alarm = DateTime.Now;
                    temp_AlarmMessage.AlarmStage = 1;//表示报警开始
                    temp_AlarmMessageForAll.alarmmessage = temp_AlarmMessage;
                    return temp_AlarmMessageForAll;
                }
            }
            /// <summary>
            /// 根据传入LinkageData，执行相应操作
            /// </summary>
            /// <param name="LinkageData"></param>
            public static void DoLinkageData(string AlarmFingerprintID, LinkageDataStruct LinkageData)
            {
                //预置位
                if (Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage == 1)//报警开始
                {
                    string PresetName = Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmAreaName + "_预置位";
                    ControlInterface.PresetAlarmSetInterface(new Guid(Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.DeviceID), PresetName,null);
                    Console.WriteLine("调用预置位:"+ PresetName);
                }
                else
                {
                    if (LinkageData.Video_DeviceID!=null)
                    {
                        string[] PresetVideoIP = LinkageData.Video_DeviceID.Split(',');
                        string[] PresetName = LinkageData.Preset.Split(',');
                        for (int i = 0; i < PresetVideoIP.Length; i++)
                        {
                            ControlInterface.PresetAlarmSetInterface(new Guid(PresetVideoIP[i]), PresetName[i], null);
                            Console.WriteLine("调用预置位:" + PresetName[i]);
                        }
                    }
                }
                //调阅视频
                if (LinkageData.LinkageStage == null)
                {
                    Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage = 4;
                    SendToClient(Dic_AlarmMessageForAll[AlarmFingerprintID], 4);
                }
                else
                {
                    Dic_AlarmMessageForAll[AlarmFingerprintID].alarmmessage.AlarmStage = int.Parse(LinkageData.LinkageStage);
                    SendToClient(Dic_AlarmMessageForAll[AlarmFingerprintID], int.Parse(LinkageData.LinkageStage));
                }
                //开关量
            }
            public static void SendToClient(AlarmMessageForAll AssembleAlarm, int AlarmStage)
            {
                AlarmMessageToClient temp_AlarmMessageToClient = new AlarmMessageToClient();
                switch (AlarmStage)
                {
                    case 1:
                        temp_AlarmMessageToClient.alarmmessage = AssembleAlarm.alarmmessage;
                        temp_AlarmMessageToClient.alarmmessage.AlarmStage = 1;
                        temp_AlarmMessageToClient.Now_LinkageData = AssembleAlarm.Trigger_LinkageData;
                        break;
                    case 2:
                        temp_AlarmMessageToClient.alarmmessage = AssembleAlarm.alarmmessage;
                        temp_AlarmMessageToClient.alarmmessage.AlarmStage = 2;
                        temp_AlarmMessageToClient.Now_LinkageData = AssembleAlarm.Disposal_LinkageData;
                        break;
                    case 3:
                        temp_AlarmMessageToClient.alarmmessage = AssembleAlarm.alarmmessage;
                        temp_AlarmMessageToClient.alarmmessage.AlarmStage = 3;
                        temp_AlarmMessageToClient.Now_LinkageData = AssembleAlarm.Untreated_LinkageData;
                        break;
                    case 4:
                        temp_AlarmMessageToClient.alarmmessage = AssembleAlarm.alarmmessage;
                        LinkageDataStruct temp_LinkageDataStruct = new LinkageDataStruct();
                        temp_AlarmMessageToClient.alarmmessage.AlarmStage = 4;
                        temp_LinkageDataStruct.LinkageStage = "4";
                        temp_AlarmMessageToClient.Now_LinkageData = temp_LinkageDataStruct;
                        break;
                }
                try//添加报警日志
                {
                    AlarmLog temp_AlarmLog = new AlarmLog();
                    if (AssembleAlarm.alarmmessage.AlarmDeviceID!=null)
                    {
                        temp_AlarmLog.AlarmDeviceID = new Guid(AssembleAlarm.alarmmessage.AlarmDeviceID);
                    }
                    temp_AlarmLog.AlarmID = AssembleAlarm.alarmmessage.AlarmFingerprintID.ToString();
                    temp_AlarmLog.AlarmLevel = AssembleAlarm.alarmmessage.AlarmLevel;
                    temp_AlarmLog.AlarmName = AssembleAlarm.alarmmessage.AlarmAreaName;
                    temp_AlarmLog.AlarmStatus = AlarmStage;
                    temp_AlarmLog.AlarmTime = AssembleAlarm.alarmmessage.DT_Alarm;
                    if (AssembleAlarm.alarmmessage.AlarmType==1|| AssembleAlarm.alarmmessage.AlarmType==2|| AssembleAlarm.alarmmessage.AlarmType==3)
                    {
                        temp_AlarmLog.AlarmType = 1;
                    }
                    else
                    {
                        temp_AlarmLog.AlarmType = AssembleAlarm.alarmmessage.AlarmType;
                    }
                    temp_AlarmLog.Alt = 0;
                    temp_AlarmLog.DisposeTime = DateTime.Now.ToString();
                    temp_AlarmLog.Lat = AssembleAlarm.alarmmessage.AlarmPosition_X;
                    temp_AlarmLog.Lon = AssembleAlarm.alarmmessage.AlarmPosition_Y;
                    //操作人员赋值
                    AlarmLog.Insert(temp_AlarmLog);
                }
                catch
                {
                }
                try//转发报警信息
                {
                    //string String_temp_AlarmMessageToClient = temp_AlarmMessageToClient.ToString();
                    ReceiveDataType temp_ReceiveDataType = new ReceiveDataType();
                    temp_ReceiveDataType.SType = ServerType.Alarm;
                    temp_ReceiveDataType.DataPackage = temp_AlarmMessageToClient;
                    string d = JsonConvert.SerializeObject(temp_ReceiveDataType);
                    tempAlarmEvent(d);
                }
                catch
                { }
            }
            private static Thread AlarmSet_TH;
            private static Thread Rec_TH;
            private static Dictionary<string, Pre_arrangedPlanning> AlarmSet_Dictionary;//储存报警器结构的字典
            private static Dictionary<string, Pre_arrangedPlanning> AutoRec_Dictionary;//储存自动录像结构的字典
            private static string Alarm_startWeek;
            private static string Alarm_endWeek;
            private static string Alarm_startTime;
            private static string Alarm_endTime;
            private static string Rec_startWeek;
            private static string Rec_endWeek;
            private static string Rec_startTime;
            private static string Rec_endTime;
            private static string[] pictureBoxSize = new string[2];
            private static int SizeX;
            private static int SizeY;
            public static Dictionary<string, int> weekDic = new Dictionary<string, int>();
            public static void InitialWeek()
            {
                if (weekDic.Count > 0)
                    weekDic.Clear();
                weekDic.Add("Monday", 1);
                weekDic.Add("Tuesday", 2);
                weekDic.Add("Wednesday", 3);
                weekDic.Add("Thursday", 4);
                weekDic.Add("Friday", 5);
                weekDic.Add("Saturday", 6);
                weekDic.Add("Sunday", 7);
            }
            public static void AlarmSetAll()
            {
                AlarmSet_Dictionary = new Dictionary<string, Pre_arrangedPlanning>();
                for (int i = 0; i < pre_arrangedPlanning.Count; i++)
                {
                    if (pre_arrangedPlanning[i].PlanType == 1)
                    {
                        AlarmSet_Dictionary.Add(i.ToString(), pre_arrangedPlanning[i]);
                    }
                }
                //将数据库中数据往字典Alarm_Dictionary中添加
                InitialWeek();
                AlarmSet_TH = new Thread(Alarm_Set);
                AlarmSet_TH.Start();
                AlarmSet_TH.IsBackground = true;
            }
            public class AlarmFormation
            {
                public string pDVRIP;
                public Int32 nChannel;
                public Int32 nAlarmType;
                public Int32 nSensitive;
                public string pChannelName;
                public string PointStr;
                public string PictureBoxSize;
            }
            /// <summary>
            /// 通过设备ID获取IP和通道号
            /// </summary>
            /// <param name="deviceID"></param>
            /// <param name="IP"></param>
            /// <param name="channel"></param>
            public static void GetFormation(string deviceID, string AlarmDeviceID, out AlarmFormation AF)
            {
                AlarmFormation temp = new AlarmFormation();
                CameraList temp_CameraList = MediaData.cameraList.Find(_ => _.DeviceID.ToString() == deviceID );
                //查找出IP地址以及通道号
                if (temp_CameraList != null)
                {
                    temp.nChannel = temp_CameraList.VideoChannel;
                    StreamMediaList streamMedia = new StreamMediaList();
                    streamMedia = streamMediaList.Find(_ => _.DeviceID == temp_CameraList.StreamMedia_DeviceID);
                    temp.pDVRIP = streamMedia.VideoIP;
                }
                ArmAndDisarmList armAndDisarm = new ArmAndDisarmList();
                armAndDisarm = MediaData.armAndDisarmList.Find(_ => _.AlarmDeviceID.ToString() == AlarmDeviceID);
                if (armAndDisarm != null)
                {
                    temp.nSensitive = armAndDisarm.AlarmSensitive;
                    temp.pChannelName = armAndDisarm.AlarmName;
                    temp.nAlarmType =armAndDisarm.AlarmType;
                    temp.PointStr = armAndDisarm.AlarmLine;
                    temp.PictureBoxSize = armAndDisarm.PictureboxSize;
                }
                AF = temp;
            }
            public static void Alarm_Set()
            {
                while (true)
                {
                    for (int i = 0; i < AlarmSet_Dictionary.Count; i++)
                    {
                        if (AlarmSet_Dictionary.ElementAt(i).Value.TimeType == null)
                            return;
                        int TimeType = int.Parse(AlarmSet_Dictionary.ElementAt(i).Value.TimeType);
                        #region 判断属于哪种布放模式
                        switch (TimeType)
                        {
                            case 1://每周设置
                                {
                                    Alarm_startWeek = AlarmSet_Dictionary.ElementAt(i).Value.StartWeek;
                                    Alarm_endWeek = AlarmSet_Dictionary.ElementAt(i).Value.EndWeek;
                                    Alarm_startTime = AlarmSet_Dictionary.ElementAt(i).Value.StartTime;
                                    Alarm_endTime = AlarmSet_Dictionary.ElementAt(i).Value.EndTime;
                                    //判断该报警器当前布放状态
                                    bool a1 = (weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Alarm_startWeek] && DateTime.Now >= DateTime.Parse(Alarm_startTime) && weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Alarm_endWeek] && DateTime.Now <= DateTime.Parse(Alarm_endTime));//没跨天，时间在当天的设置时间段内
                                    bool a2 = (weekDic[DateTime.Now.DayOfWeek.ToString()] > weekDic[Alarm_startWeek] && weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Alarm_endWeek] && DateTime.Now <= DateTime.Parse(Alarm_endTime));//当天已经过了起始设置日，在设置日的最后一天，且时间没有到截止时间
                                    bool a3 = (weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Alarm_startWeek] && DateTime.Now >= DateTime.Parse(Alarm_startTime) && weekDic[DateTime.Now.DayOfWeek.ToString()] < weekDic[Alarm_endWeek]);//当天在起始设置日，但是和截止日不在同一天
                                    bool a4 = (weekDic[DateTime.Now.DayOfWeek.ToString()] > weekDic[Alarm_startWeek] && weekDic[DateTime.Now.DayOfWeek.ToString()] < weekDic[Alarm_endWeek]);//当天已经超过起始设置日，但是还没有到截止日
                                    if (a1 || a2 || a3 || a4)
                                    {
                                        if (AlarmSet_Dictionary.ElementAt(i).Value.Mark != "1")//在布防时间内，切该预案并未布防
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AlarmSet_Dictionary.ElementAt(i).Value.DeviceID, AlarmSet_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.PictureBoxSize != null)
                                            {
                                                pictureBoxSize = AF.PictureBoxSize.Split(',');
                                                SizeX = int.Parse(pictureBoxSize[0]);
                                                SizeY = int.Parse(pictureBoxSize[1]);
                                            }
                                            if (AF.pDVRIP==null)
                                            {
                                                return;
                                            }
                                            //给重阳发送预置位

                                            //-----------------
                                            Thread.Sleep(9000);
                                            //布防
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = AccessOperation.AlarmSetSDK.AlarmSet(AF.pDVRIP, AF.nChannel, mUserID, AF.nAlarmType, AF.nSensitive, AF.pChannelName, AF.PointStr, SizeX, SizeY);
                                            if (a_1 == 1)
                                            {
                                                AlarmSet_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动布放成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AlarmSet_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (AlarmSet_Dictionary.ElementAt(i).Value.Mark == "1")//布放时间外且预案仍然布放
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AlarmSet_Dictionary.ElementAt(i).Value.DeviceID, AlarmSet_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.PictureBoxSize != null)
                                            {
                                                pictureBoxSize = AF.PictureBoxSize.Split(',');
                                                SizeX = int.Parse(pictureBoxSize[0]);
                                                SizeY = int.Parse(pictureBoxSize[1]);
                                            }
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            //布防
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = AccessOperation.AlarmSetSDK.Alarm_Close(AF.pDVRIP, AF.nChannel, mUserID);
                                            if (a_1 == 1)
                                            {
                                                AlarmSet_Dictionary.ElementAt(i).Value.Mark = "0";
                                                Console.WriteLine(AF.pDVRIP + "自动撤防成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AlarmSet_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                }
                                break;

                            case 2://时间设置
                                {
                                    Alarm_startTime = AlarmSet_Dictionary.ElementAt(i).Value.StartTime;
                                    Alarm_endTime = AlarmSet_Dictionary.ElementAt(i).Value.EndTime;

                                    if (DateTime.Now >= DateTime.Parse(AlarmSet_Dictionary.ElementAt(i).Value.StartTime) && DateTime.Now <= DateTime.Parse(AlarmSet_Dictionary.ElementAt(i).Value.EndTime))
                                    {
                                        if (AlarmSet_Dictionary.ElementAt(i).Value.Mark != "1")
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AlarmSet_Dictionary.ElementAt(i).Value.DeviceID, AlarmSet_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.PictureBoxSize != null)
                                            {
                                                pictureBoxSize = AF.PictureBoxSize.Split(',');
                                                SizeX = int.Parse(pictureBoxSize[0]);
                                                SizeY = int.Parse(pictureBoxSize[1]);
                                            }
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            //给重阳发送预置位

                                            //-----------------
                                            Thread.Sleep(9000);
                                            //布防
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = AccessOperation.AlarmSetSDK.AlarmSet(AF.pDVRIP, AF.nChannel, mUserID, AF.nAlarmType, AF.nSensitive, AF.pChannelName, AF.PointStr, SizeX, SizeY);
                                            if (a_1 == 1)
                                            {
                                                AlarmSet_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动布放成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AlarmSet_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                        else//该时间段内撤防 
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AlarmSet_Dictionary.ElementAt(i).Value.DeviceID, AlarmSet_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.PictureBoxSize != null)
                                            {
                                                pictureBoxSize = AF.PictureBoxSize.Split(',');
                                                SizeX = int.Parse(pictureBoxSize[0]);
                                                SizeY = int.Parse(pictureBoxSize[1]);
                                            }
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            //布防
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = AccessOperation.AlarmSetSDK.Alarm_Close(AF.pDVRIP, AF.nChannel, mUserID);
                                            if (a_1 == 1)
                                            {
                                                AlarmSet_Dictionary.ElementAt(i).Value.Mark = "0";
                                                Console.WriteLine(AF.pDVRIP + "自动撤防成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AlarmSet_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 3://全时段报警设置
                                {
                                    try
                                    {
                                        if (AlarmSet_Dictionary.ElementAt(i).Value.Mark != "1")
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AlarmSet_Dictionary.ElementAt(i).Value.DeviceID, AlarmSet_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.PictureBoxSize != null)
                                            {
                                                pictureBoxSize = AF.PictureBoxSize.Split(',');
                                                SizeX = int.Parse(pictureBoxSize[0]);
                                                SizeY = int.Parse(pictureBoxSize[1]);
                                            }
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            //给重阳发送预置位

                                            //-----------------
                                            Thread.Sleep(9000);
                                            //布防
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = AccessOperation.AlarmSetSDK.AlarmSet(AF.pDVRIP, AF.nChannel, mUserID, AF.nAlarmType, AF.nSensitive, AF.pChannelName, AF.PointStr, SizeX, SizeY);
                                            if (a_1 == 1)
                                            {
                                                AlarmSet_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动布放成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AlarmSet_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                    catch { }
                                    break;
                                }
                        }
                        #endregion
                    }
                    Thread.Sleep(1000);
                }
            }
            /// <summary>
            /// 自动录像设置函数
            /// </summary>
            public static void RecSetAll()
            {
                AutoRec_Dictionary = new Dictionary<string, Pre_arrangedPlanning>();
                for (int i = 0; i < pre_arrangedPlanning.Count; i++)
                {
                    if (pre_arrangedPlanning[i].PlanType == 2)
                    {
                        pre_arrangedPlanning[i].Mark = "0";//默认所有设备均未录像
                        AutoRec_Dictionary.Add(i.ToString(), pre_arrangedPlanning[i]);
                    }
                }
                //将数据库中数据往字典AutoRec_Dictionary中添加
                InitialWeek();
                Rec_TH = new Thread(AutoRec_Set);
                Rec_TH.Start();
                Rec_TH.IsBackground = true;
            }

            public static void AutoRec_Set()
            {
                while (true)
                {
                    for (int i = 0; i < AutoRec_Dictionary.Count; i++)
                    {
                        if (AutoRec_Dictionary.ElementAt(i).Value.TimeType == null)
                            return;
                        int TimeType = int.Parse(AutoRec_Dictionary.ElementAt(i).Value.TimeType);
                        #region 判断属于哪种布放模式
                        switch (TimeType)
                        {
                            case 1://每周设置
                                {
                                    Rec_startWeek = AutoRec_Dictionary.ElementAt(i).Value.StartWeek;
                                    Rec_endWeek = AutoRec_Dictionary.ElementAt(i).Value.EndWeek;
                                    Rec_startTime = AutoRec_Dictionary.ElementAt(i).Value.StartTime;
                                    Rec_endTime = AutoRec_Dictionary.ElementAt(i).Value.EndTime;
                                    //判断该设备录像状态
                                    bool a1 = (weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Rec_startWeek] && DateTime.Now >= DateTime.Parse(Rec_startTime) && weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Rec_endWeek] && DateTime.Now <= DateTime.Parse(Rec_endTime));//没跨天，时间在当天的设置时间段内
                                    bool a2 = (weekDic[DateTime.Now.DayOfWeek.ToString()] > weekDic[Rec_startWeek] && weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Rec_endWeek] && DateTime.Now <= DateTime.Parse(Rec_endTime));//当天已经过了起始设置日，在设置日的最后一天，且时间没有到截止时间
                                    bool a3 = (weekDic[DateTime.Now.DayOfWeek.ToString()] == weekDic[Rec_startWeek] && DateTime.Now >= DateTime.Parse(Rec_startTime) && weekDic[DateTime.Now.DayOfWeek.ToString()] < weekDic[Rec_endWeek]);//当天在起始设置日，但是和截止日不在同一天
                                    bool a4 = (weekDic[DateTime.Now.DayOfWeek.ToString()] > weekDic[Rec_startWeek] && weekDic[DateTime.Now.DayOfWeek.ToString()] < weekDic[Rec_endWeek]);//当天已经超过起始设置日，但是还没有到截止日
                                    if (a1 || a2 || a3 || a4)
                                    {
                                        if (AutoRec_Dictionary.ElementAt(i).Value.Mark != "1")//在布防时间内，切该预案并未布防
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AutoRec_Dictionary.ElementAt(i).Value.DeviceID, AutoRec_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            //布防
                                            if (AF.pDVRIP==null)
                                            {
                                                return;
                                            }
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = Rec_SDK.Auto_Rec(AF.pDVRIP,AF.nChannel);
                                            if (a_1 != -1)
                                            {
                                                AutoRec_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动录像开始成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AutoRec_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (AutoRec_Dictionary.ElementAt(i).Value.Mark == "1")//布放时间外且预案仍然布放
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AutoRec_Dictionary.ElementAt(i).Value.DeviceID, AutoRec_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = Rec_SDK.StopRec(AF.pDVRIP);
                                            if (a_1 == 1)
                                            {
                                                AutoRec_Dictionary.ElementAt(i).Value.Mark = "0";
                                                Console.WriteLine(AF.pDVRIP + "自动录像停止成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AutoRec_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                }
                                break;

                            case 2://每天时间设置
                                {
                                    Rec_startTime = AutoRec_Dictionary.ElementAt(i).Value.StartTime;
                                    Rec_endTime = AutoRec_Dictionary.ElementAt(i).Value.EndTime;

                                    if (DateTime.Now >= DateTime.Parse(AutoRec_Dictionary.ElementAt(i).Value.StartTime) && DateTime.Now <= DateTime.Parse(AutoRec_Dictionary.ElementAt(i).Value.EndTime))
                                    {
                                        if (AutoRec_Dictionary.ElementAt(i).Value.Mark != "1")
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AutoRec_Dictionary.ElementAt(i).Value.DeviceID, AutoRec_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = Rec_SDK.Auto_Rec(AF.pDVRIP, AF.nChannel);
                                            if (a_1 != -1)
                                            {
                                                AutoRec_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动录像开始成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AutoRec_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                        else//该时间段内撤防 
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AutoRec_Dictionary.ElementAt(i).Value.DeviceID, AutoRec_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = Rec_SDK.StopRec(AF.pDVRIP);
                                            if (a_1 == 1)
                                            {
                                                AutoRec_Dictionary.ElementAt(i).Value.Mark = "0";
                                                Console.WriteLine(AF.pDVRIP + "自动录像停止成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AutoRec_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                    }
                                    break;
                                }
                            case 3://全时段报警设置
                                {
                                    try
                                    {
                                        if (AutoRec_Dictionary.ElementAt(i).Value.Mark != "1")
                                        {
                                            AlarmFormation AF = new AlarmFormation();
                                            GetFormation(AutoRec_Dictionary.ElementAt(i).Value.DeviceID, AutoRec_Dictionary.ElementAt(i).Value.PlanTypeID.ToString(), out AF);
                                            if (AF.pDVRIP == null)
                                            {
                                                return;
                                            }
                                            int mUserID = -1;
                                            if (Device_UserID_Alarm.ContainsKey(AF.pDVRIP))
                                            {
                                                mUserID = Device_UserID_Alarm[AF.pDVRIP].UserID;
                                            }
                                            int a_1 = Rec_SDK.Auto_Rec(AF.pDVRIP, AF.nChannel);
                                            if (a_1 != -1)
                                            {
                                                AutoRec_Dictionary.ElementAt(i).Value.Mark = "1";
                                                Console.WriteLine(AF.pDVRIP + "自动录像开始成功");
                                                //对数据库内预案的设置状态进行更改
                                                MediaData.Pre_arranged.Update(AutoRec_Dictionary.ElementAt(i).Value);
                                                MediaData.pre_arrangedPlanning = Pre_arranged.GetList();
                                                //--------------------------------
                                            }
                                        }
                                        else
                                        {

                                        }
                                    }
                                    catch { }
                                    break;
                                }
                        }
                        #endregion
                    }
                    Thread.Sleep(1000);
                }
            }
        }
    }
}
