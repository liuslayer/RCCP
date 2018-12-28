using Newtonsoft.Json;
using OMServer.Model;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.IO.Ports;
using RCCP.Common;
using LogServer;
using System.Diagnostics;
using HikSdk;
using System.Runtime.InteropServices;

namespace OMServer
{
    public class OMServerManager
    {
        public bool isLoaddeviceInfo = false;
        private DeviceInfo deviceInfo;
        private List<CameraStatusList> cameraStatusList = new List<CameraStatusList>();
        private List<UPSStatusList> UPSStatusList = new List<UPSStatusList>();
        private List<SolarEnergyStatusList> solarEnergyStatusList = new List<SolarEnergyStatusList>();
        private Dictionary<Guid, int> stationStatusDic = new Dictionary<Guid, int>();
        private SerialCOMManager serialCOMManager;
        private HikSdkManager hikSdkManager;

        private Dictionary<uint, string> bitStreamDic = new Dictionary<uint, string>();


        //public delegate void SendDeviceInfoEventHandler(string jsonContent);
        //public event SendDeviceInfoEventHandler OnSendDeviceInfo;
        //public delegate void SendcameraStatusEventHandler(string jsonContent);
        //public event SendcameraStatusEventHandler SendCameraStatus;
        //public delegate void SendUPSStatusEventHandler(string jsonContent);
        //public event SendUPSStatusEventHandler SendUPSStatus;
        //public delegate void SendSolarEnergyStatusEventHandler(string jsonContent);
        //public event SendSolarEnergyStatusEventHandler SendSolarEnergyStatus;

        public OMServerManager()
        {
            serialCOMManager = SerialCOMManager.CreateInstance();
            serialCOMManager.ProcessUPSSerialData += ProcessUPSSerialData;
            serialCOMManager.ProcessSolarEnergySerialData += ProcessSolarEnergySerialData;

            hikSdkManager = HikSdkManager.CreateInstance();

            InitData();
        }

        private void InitData()
        {
            //视频码率 0 - 保留 1 - 16K 2 - 32K 3 - 48k 4 - 64K 5 - 80K 6 - 96K 7 - 128K 8 - 160k 9 - 192K 10 - 224K 11 - 256K 12 - 320K
            // 13-384K 14-448K 15-512K 16-640K 17-768K 18-896K 19-1024K 20-1280K 21-1536K 22-1792K 23-2048K
            bitStreamDic.Add(0, "0");
            bitStreamDic.Add(1, "16");
            bitStreamDic.Add(2, "32");
            bitStreamDic.Add(3, "48");
            bitStreamDic.Add(4, "64");
            bitStreamDic.Add(5, "80");
            bitStreamDic.Add(6, "96");
            bitStreamDic.Add(7, "128");
            bitStreamDic.Add(8, "160");
            bitStreamDic.Add(9, "192");
            bitStreamDic.Add(10, "224");
            bitStreamDic.Add(11, "256");
            bitStreamDic.Add(12, "320");
            bitStreamDic.Add(13, "384");
            bitStreamDic.Add(14, "448");
            bitStreamDic.Add(15, "512");
            bitStreamDic.Add(16, "640");
            bitStreamDic.Add(17, "768");
            bitStreamDic.Add(18, "896");
            bitStreamDic.Add(19, "1024");
            bitStreamDic.Add(20, "1280");
            bitStreamDic.Add(21, "1536");
            bitStreamDic.Add(22, "1792");
            bitStreamDic.Add(23, "2048");
            bitStreamDic.Add(24, "3072");
            bitStreamDic.Add(25, "4096");
            bitStreamDic.Add(26, "8192");
            bitStreamDic.Add(27, "16384");
        }

        /// <summary>
        /// 查询静态信息
        /// </summary>
        public void LoadDeviceInfo()
        {
            try
            {
                //TODO:初始化静态信息
                deviceInfo = DeviceInfo.GetInstance();
                deviceInfo.TurnTableList = new TurnTableListRepository().GetList();
                deviceInfo.StreamMediaList = new StreamMediaListRepository().GetList();
                deviceInfo.CameraList = new CameraListRepository().GetList();
                deviceInfo.StationList = new StationListRepository().GetList();
                deviceInfo.SolarEnergyList = new SolarEnergyListRepository().GetList();
                deviceInfo.UPSList = new UPSListRepository().GetList();
                deviceInfo.DeviceTypeList = new DeviceTypeListRepository().GetList();
            }
            catch (Exception ex)
            {
                deviceInfo = null;
                isLoaddeviceInfo = false;
                throw ex;
            }
            isLoaddeviceInfo = true;
        }

        public string SerializeDeviceInfo()
        {
            return JsonConvert.SerializeObject(deviceInfo);
        }

        public string GetDeviceInfoJson()
        {
            int countdown = 3;
            while (!isLoaddeviceInfo)
            {
                if (countdown-- == 0 || isLoaddeviceInfo)
                    break;
                Thread.Sleep(1000);
            }

            if (!isLoaddeviceInfo)
                return null;
            else
                return JsonConvert.SerializeObject(deviceInfo);
        }

        public void Query_StationStatus_Info(Action<string> sendStationStatus)
        {
            StationList station = deviceInfo.StationList.Find(_ => _.PStationID == null);
            if (station == null)
                return;
            stationStatusDic.Clear();
            stationStatusDic.Add(station.StationID, 3);
            string jsonContent = JsonConvert.SerializeObject(stationStatusDic);
            sendStationStatus(jsonContent);
        }

        public void Query_CameraStatus_Info(Action<string> sendCameraStatus)
        {
            //Stopwatch sp = new Stopwatch();
            //sp.Start();
            if (!isLoaddeviceInfo)
                return;
            StationList station = deviceInfo.StationList.Find(_ => _.PStationID == null);
            if (station == null)
                return;
            cameraStatusList.Clear();

            //LogServerManager.AddRunLog(OperationType.System, "查询本级摄像机状态");
            Dictionary<string, HikSdkManager.UserID_m_lAlarmHandle> userIDDic = hikSdkManager.GetUserIDDic();
            List<Task> taskList = new List<Task>();
            foreach (var streamMedia in deviceInfo.StreamMediaList.Where(_ => _.StationID == station.StationID))
            {
                taskList.Add(Task.Run(() =>
                {
                    bool isGetDVRConfig = false;
                    bool isGetDVRWorkstate = false;
                    if (!userIDDic.ContainsKey(streamMedia.VideoIP))//设备未登陆成功
                    {
                        foreach (var camera in deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMedia.DeviceID))
                        {
                            CameraStatusList newCameraStatus = new CameraStatusList();
                            newCameraStatus.DeviceID = camera.DeviceID;
                            newCameraStatus.Name = camera.VideoName;
                            newCameraStatus.IsOnline = false;
                            newCameraStatus.Time = DateTime.Now;
                            cameraStatusList.Add(newCameraStatus);
                        }
                        //continue;
                    }
                    else
                    {
                        HikSdkManager.UserID_m_lAlarmHandle userInfo = userIDDic[streamMedia.VideoIP];
                        uint dwDChanTotalNum = (uint)userInfo.deviceInfo.byIPChanNum + 256 * (uint)userInfo.deviceInfo.byHighDChanNum;
                        #region 旧的设备状态需求
                        //uint dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40);
                        //IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSize);
                        //Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);
                        //uint dwReturn = 0;
                        //int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取
                        //if (!CHCNetSDK.NET_DVR_GetDVRConfig(userInfo.UserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSize, ref dwReturn))
                        //{
                        //    uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        //    string errContent = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                        //    //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                        //    LogServerManager.AddErrLog(ErrLogType.InterfaceErr, null, this.GetType().ToString(), "Query_CameraStatus_Info", errContent);
                        //}
                        //else
                        //{
                        //    m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));
                        //    uint dwAChanTotalNum = (uint)userInfo.deviceInfo.byChanNum;
                        //    uint dwDChanTotalNum = (uint)userInfo.deviceInfo.byIPChanNum + 256 * (uint)userInfo.deviceInfo.byHighDChanNum;
                        //    if (dwDChanTotalNum > 0)
                        //    {
                        //        byte byStreamType = 0;
                        //        foreach (var camera in deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMedia.DeviceID))
                        //        {
                        //            int videoChannel = camera.VideoChannel - 33;//实际通道号
                        //            byStreamType = m_struIpParaCfgV40.struStreamMode[videoChannel].byGetStreamType;
                        //            dwSize = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[videoChannel].uGetStream);
                        //            CameraStatusList newCameraStatus = new CameraStatusList();
                        //            switch (byStreamType)
                        //            {
                        //                //目前NVR仅支持直接从设备取流 NVR supports only the mode: get stream from device directly
                        //                case 0:
                        //                    IntPtr ptrChanInfo = Marshal.AllocHGlobal((Int32)dwSize);
                        //                    Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[videoChannel].uGetStream, ptrChanInfo, false);
                        //                    m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));

                        //                    dwSize = (uint)Marshal.SizeOf(m_struCompressionCfgV30);
                        //                    IntPtr ptrCompressionCfgV30 = Marshal.AllocHGlobal((Int32)dwSize);
                        //                    Marshal.StructureToPtr(m_struCompressionCfgV30, ptrCompressionCfgV30, false);
                        //                    CHCNetSDK.NET_DVR_COMPRESSION_INFO_V30 m_struCompressionInfoV30 = new CHCNetSDK.NET_DVR_COMPRESSION_INFO_V30();
                        //                    if (!CHCNetSDK.NET_DVR_GetDVRConfig(userInfo.UserID, CHCNetSDK.NET_DVR_GET_COMPRESSCFG_V30, camera.VideoChannel, ptrCompressionCfgV30, dwSize, ref dwReturn))
                        //                    {
                        //                        uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                        //                        string errContent = "NET_DVR_GET_COMPRESSCFG_V30 failed, error code= " + iLastErr;
                        //                        //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                        //                        LogServerManager.AddErrLog(ErrLogType.InterfaceErr, null, this.GetType().ToString(), "Query_CameraStatus_Info", errContent);
                        //                    }
                        //                    else
                        //                    {
                        //                        m_struCompressionCfgV30 = (CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30)Marshal.PtrToStructure(ptrCompressionCfgV30, typeof(CHCNetSDK.NET_DVR_COMPRESSIONCFG_V30));
                        //                        m_struCompressionInfoV30 = m_struCompressionCfgV30.struNormHighRecordPara;
                        //                    }
                        //                    newCameraStatus.DeviceID = camera.DeviceID;
                        //                    newCameraStatus.Name = camera.VideoName;
                        //                    //newCameraStatus.IsOnline = BitConverter.ToBoolean(new byte[] { m_struChanInfo.byEnable }, 0);
                        //                    //newCameraStatus.NetStatus = newCameraStatus.IsOnline;
                        //                    //newCameraStatus.ImgStatus = newCameraStatus.IsOnline ? 2 : 0;
                        //                    //newCameraStatus.ImgQuality = m_struCompressionInfoV30.byPicQuality;
                        //                    //newCameraStatus.BitStream = bitStreamDic[m_struCompressionInfoV30.dwVideoBitrate];
                        //                    newCameraStatus.Time = DateTime.Now;
                        //                    cameraStatusList.Add(newCameraStatus);

                        //                    Marshal.FreeHGlobal(ptrChanInfo);
                        //                    break;
                        //                case 6:
                        //                    IntPtr ptrChanInfoV40 = Marshal.AllocHGlobal((Int32)dwSize);
                        //                    Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[videoChannel].uGetStream, ptrChanInfoV40, false);
                        //                    m_struChanInfoV40 = (CHCNetSDK.NET_DVR_IPCHANINFO_V40)Marshal.PtrToStructure(ptrChanInfoV40, typeof(CHCNetSDK.NET_DVR_IPCHANINFO_V40));

                        //                    Marshal.FreeHGlobal(ptrChanInfoV40);
                        //                    break;
                        //                default:
                        //                    break;
                        //            }
                        //        }
                        //    }
                        //    else
                        //    {
                        //        foreach (var camera in deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMedia.DeviceID))
                        //        {
                        //            CameraStatusList newCameraStatus = new CameraStatusList();
                        //            newCameraStatus.DeviceID = camera.DeviceID;
                        //            newCameraStatus.Name = camera.VideoName;
                        //            //newCameraStatus.IsOnline = true;
                        //            //newCameraStatus.NetStatus = newCameraStatus.IsOnline;
                        //            //newCameraStatus.ImgStatus = 0;
                        //            //newCameraStatus.ImgQuality = 0;
                        //            newCameraStatus.Time = DateTime.Now;
                        //            cameraStatusList.Add(newCameraStatus);
                        //        }
                        //    }
                        //}
                        #endregion

                        CHCNetSDK.NET_DVR_IPPARACFG_V40 m_struIpParaCfgV40 = new CHCNetSDK.NET_DVR_IPPARACFG_V40();
                        uint dwSizeIpParaCfgV40 = (uint)Marshal.SizeOf(m_struIpParaCfgV40);
                        IntPtr ptrIpParaCfgV40 = Marshal.AllocHGlobal((Int32)dwSizeIpParaCfgV40);
                        Marshal.StructureToPtr(m_struIpParaCfgV40, ptrIpParaCfgV40, false);
                        uint dwReturn = 0;
                        int iGroupNo = 0;  //该Demo仅获取第一组64个通道，如果设备IP通道大于64路，需要按组号0~i多次调用NET_DVR_GET_IPPARACFG_V40获取

                        if (dwDChanTotalNum > 0)//数字通道
                        {
                            if (!CHCNetSDK.NET_DVR_GetDVRConfig(userInfo.UserID, CHCNetSDK.NET_DVR_GET_IPPARACFG_V40, iGroupNo, ptrIpParaCfgV40, dwSizeIpParaCfgV40, ref dwReturn))
                            {
                                uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                                string errContent = "NET_DVR_GET_IPPARACFG_V40 failed, error code= " + iLastErr;
                                //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                                LogServerManager.AddErrLog(ErrLogType.InterfaceErr, null, this.GetType().ToString(), "Query_CameraStatus_Info", errContent);
                                isGetDVRConfig = false;
                            }
                            else
                            {
                                m_struIpParaCfgV40 = (CHCNetSDK.NET_DVR_IPPARACFG_V40)Marshal.PtrToStructure(ptrIpParaCfgV40, typeof(CHCNetSDK.NET_DVR_IPPARACFG_V40));
                                Marshal.FreeHGlobal(ptrIpParaCfgV40);
                                isGetDVRConfig = true;
                            }
                        }

                        CHCNetSDK.NET_DVR_WORKSTATE_V30 struDvrWorkstate = new CHCNetSDK.NET_DVR_WORKSTATE_V30();
                        uint dwSizeDvrWorkstate = (uint)Marshal.SizeOf(struDvrWorkstate);
                        IntPtr ptrDvrWorkstate = Marshal.AllocHGlobal((int)dwSizeDvrWorkstate);
                        Marshal.StructureToPtr(struDvrWorkstate, ptrDvrWorkstate, false);
                        if (!CHCNetSDK.NET_DVR_GetDVRWorkState_V30(userInfo.UserID, ptrDvrWorkstate))
                        {
                            uint iLastErr = CHCNetSDK.NET_DVR_GetLastError();
                            string errContent = "NET_DVR_GetDVRWorkState_V30 failed, error code= " + iLastErr;
                            //获取IP资源配置信息失败，输出错误号 Failed to get configuration of IP channels and output the error code
                            LogServerManager.AddErrLog(ErrLogType.InterfaceErr, null, this.GetType().ToString(), "Query_CameraStatus_Info", errContent);
                            isGetDVRWorkstate = false;
                        }
                        else
                        {
                            struDvrWorkstate = (CHCNetSDK.NET_DVR_WORKSTATE_V30)Marshal.PtrToStructure(ptrDvrWorkstate, typeof(CHCNetSDK.NET_DVR_WORKSTATE_V30));
                            Marshal.FreeHGlobal(ptrDvrWorkstate);
                            isGetDVRWorkstate = true;
                        }

                        foreach (var camera in deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMedia.DeviceID))
                        {
                            int channelNum = camera.VideoChannel - 1;
                            CameraStatusList newCameraStatus = new CameraStatusList();
                            newCameraStatus.DeviceID = camera.DeviceID;
                            newCameraStatus.Name = camera.VideoName;
                            if (dwDChanTotalNum > 0 && isGetDVRConfig)//有数字通道且获取到了配置信息
                            {
                                int videoChannel = camera.VideoChannel - 33;//实际通道号
                                byte byStreamType = m_struIpParaCfgV40.struStreamMode[videoChannel].byGetStreamType;
                                uint dwSizeStream = (uint)Marshal.SizeOf(m_struIpParaCfgV40.struStreamMode[videoChannel].uGetStream);
                                IntPtr ptrChanInfo = Marshal.AllocHGlobal((int)dwSizeStream);
                                Marshal.StructureToPtr(m_struIpParaCfgV40.struStreamMode[videoChannel].uGetStream, ptrChanInfo, false);
                                CHCNetSDK.NET_DVR_IPCHANINFO m_struChanInfo = (CHCNetSDK.NET_DVR_IPCHANINFO)Marshal.PtrToStructure(ptrChanInfo, typeof(CHCNetSDK.NET_DVR_IPCHANINFO));
                                newCameraStatus.IsOnline = BitConverter.ToBoolean(new byte[] { m_struChanInfo.byEnable }, 0);
                                Marshal.FreeHGlobal(ptrChanInfo);
                            }
                            else if (dwDChanTotalNum > 0 && !isGetDVRConfig)//有数字通道但未获取到了配置信息
                            {
                                newCameraStatus.IsOnline = false;
                            }
                            else//模拟通道默认都在线
                            {
                                newCameraStatus.IsOnline = true;
                            }
                            if (isGetDVRWorkstate)
                            {
                                newCameraStatus.RecordStatus = struDvrWorkstate.struChanStatic[channelNum].byRecordStatic + 1;
                                newCameraStatus.SignalStatus = struDvrWorkstate.struChanStatic[channelNum].bySignalStatic + 1;
                                newCameraStatus.HardwareStatus = struDvrWorkstate.struChanStatic[channelNum].byHardwareStatic + 1;
                                newCameraStatus.BitRate = (int)struDvrWorkstate.struChanStatic[channelNum].dwBitRate;
                            }
                            newCameraStatus.Time = DateTime.Now;
                            cameraStatusList.Add(newCameraStatus);
                        }
                    }
                }));
            }

            Task.WaitAll(taskList.ToArray());
            string jsonContent = JsonConvert.SerializeObject(cameraStatusList);
            sendCameraStatus(jsonContent);

            //sp.Stop();
            //Console.WriteLine(sp.Elapsed);
        }

        #region 旧的设备状态获取（已废弃）
        ///// <summary>
        ///// 获取摄像机状态信息（已废弃）
        ///// </summary>
        //public void Query_CameraStatus_Info(Action<string> sendCameraStatus)
        //{
        //    if (!isLoaddeviceInfo)
        //        return;
        //    StationList station = deviceInfo.StationList.Find(_ => _.PStationID == null);
        //    if (station == null)
        //        return;
        //    cameraStatusList.Clear();
        //    Dictionary<Guid, Task<PingReply>> taskDic = new Dictionary<Guid, Task<PingReply>>();
        //    byte[] buffer = new byte[300];

        //    foreach (var streamMedia in deviceInfo.StreamMediaList.Where(_=>_.StationID== station.StationID))
        //    {
        //        Thread.Sleep(5);
        //        Ping ping = new Ping();
        //        Array.Clear(buffer, 0, buffer.Length);
        //        taskDic[streamMedia.DeviceID] = ping.SendPingAsync(streamMedia.VideoIP, 5000, buffer);
        //    }
        //    //PingReply[] results = await Task.WhenAll<PingReply>(taskDic.Values);
        //    Task.WhenAll<PingReply>(taskDic.Values).ContinueWith(task =>
        //        {
        //            foreach (var streamMediaDeviceID in taskDic.Keys)
        //            {
        //                List<CameraList> cameraList = deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMediaDeviceID);
        //                foreach (var camera in cameraList)
        //                {
        //                    CameraStatusList newCameraStatus = new CameraStatusList();
        //                    newCameraStatus.DeviceID = camera.DeviceID;
        //                    newCameraStatus.Name = camera.VideoName;
        //                    newCameraStatus.NetStatus = taskDic[streamMediaDeviceID].Result.Status == IPStatus.Success ? true : false;
        //                    newCameraStatus.IsOnline = newCameraStatus.NetStatus;
        //                    newCameraStatus.Time = DateTime.Now;
        //                    newCameraStatus.ImgStatus = newCameraStatus.IsOnline ? 2 : 0;
        //                    newCameraStatus.ImgQuality = newCameraStatus.IsOnline ? 1 : 0;
        //                    cameraStatusList.Add(newCameraStatus);
        //                }
        //            }

        //            //CameraStatusListRepository repo = new CameraStatusListRepository();
        //            //Task.Run(() =>
        //            //{
        //            //    try
        //            //    {
        //            //        foreach (var cameraStatus in cameraStatusList)
        //            //        {
        //            //            repo.Insert(cameraStatus);
        //            //        }
        //            //    }
        //            //    catch
        //            //    {

        //            //    }

        //            //});


        //            //if (SendCameraStatus != null)
        //            //{
        //            //    string jsonContent = JsonConvert.SerializeObject(cameraStatusList);
        //            //    Delegate[] delArray = SendCameraStatus.GetInvocationList();
        //            //    foreach (var del in delArray)
        //            //    {
        //            //        SendcameraStatusEventHandler method = (SendcameraStatusEventHandler)del;
        //            //        method.BeginInvoke(jsonContent, null, null);
        //            //    }
        //            //}
        //            string jsonContent = JsonConvert.SerializeObject(cameraStatusList);
        //            sendCameraStatus(jsonContent);
        //        });
        //}

        //private Task<PingReply> PingAsync(string IP)
        //{
        //    Ping ping = new Ping();
        //    byte[] buffer = new byte[300];
        //    return ping.SendPingAsync(IP, 5000, buffer);
        //}

        ///// <summary>
        ///// 查询状态信息（已废弃）
        ///// </summary>
        //public void Query_CameraStatus_Info()
        //{
        //    cameraStatusList.Clear();
        //    MutipleThreadResetEvent mre = new MutipleThreadResetEvent(deviceInfo.StreamMediaList.Count);
        //    foreach (var streamMedia in deviceInfo.StreamMediaList)
        //    {
        //        Thread.Sleep(5);
        //        PingAsync(streamMedia, mre);
        //    }
        //    mre.WaitAll();
        //    CameraStatusListRepository repo = new CameraStatusListRepository();
        //    Task.Factory.StartNew(() =>
        //        {
        //            foreach (var cameraStatus in cameraStatusList)
        //            {
        //                repo.Insert(cameraStatus);
        //            }
        //        });

        //    if (SendCameraStatus != null)
        //    {
        //        string jsonContent = JsonConvert.SerializeObject(cameraStatusList);
        //        Delegate[] delArray = SendCameraStatus.GetInvocationList();
        //        foreach (var del in delArray)
        //        {
        //            SendcameraStatusEventHandler method = (SendcameraStatusEventHandler)del;
        //            method.BeginInvoke(jsonContent, null, null);
        //        }
        //    }
        //}

        //private async void PingAsync(StreamMediaList streamMedia, MutipleThreadResetEvent mre)
        //{
        //    Ping ping = new Ping();
        //    byte[] buffer = new byte[300];
        //    PingReply pingReply = await ping.SendPingAsync(streamMedia.VideoIP, 5000, buffer);
        //    IPStatus status = pingReply.Status;

        //    List<CameraList> cameraList = deviceInfo.CameraList.FindAll(_ => _.StreamMedia_DeviceID == streamMedia.DeviceID);
        //    foreach (var camera in cameraList)
        //    {
        //        CameraStatusList cameraStatus = new CameraStatusList();
        //        cameraStatus.DeviceID = camera.DeviceID;
        //        cameraStatus.Name = camera.VideoName;
        //        cameraStatus.NetStatus = status == IPStatus.Success ? true : false;
        //        cameraStatus.IsOnline = cameraStatus.NetStatus;
        //        cameraStatus.Time = DateTime.Now.ToString();
        //        cameraStatusList.Add(cameraStatus);
        //    }
        //    mre.SetOne();
        //}
        #endregion

        private MutipleThreadResetEvent upsmre;
        /// <summary>
        /// 获取UPS状态信息
        /// </summary>
        /// <param name="sendUPSStatus"></param>
        public void Query_UPSStatus_Info(Action<string> sendUPSStatus)
        {
            if (deviceInfo == null)
                return;
            StationList station = deviceInfo.StationList.Find(_ => _.PStationID == null);
            if (station == null)
                return;
            UPSStatusList.Clear();

            LogServerManager.AddRunLog(OperationType.System, "查询本级UPS状态");
            //Dictionary<Guid, SerialPort> SerialPortDic = serialCOMManager.GetSerialPortDic();
            List<UPSList> UPSList = deviceInfo.UPSList.FindAll(_ => _.CommunicationID.HasValue && _.CommunicationType == 1 && _.StationID == station.StationID);
            int mreCount = UPSList.Count;
            MutipleThreadResetEvent tempMre = new MutipleThreadResetEvent(mreCount);
            upsmre = tempMre;
            foreach (var item in UPSList)
            {
                string falseMsg = string.Empty;
                Guid SerialComID = item.CommunicationID.Value;
                //if (!SerialPortDic.Keys.Contains(SerialComID))
                //    continue;
                //SerialPort sp = SerialPortDic[SerialComID];
                //try
                //{
                //    if (!sp.IsOpen)
                //    {
                //        sp.ReadBufferSize = 4096;//输入缓冲区大小
                //        sp.WriteBufferSize = 2048;//输出缓冲区大小
                //        sp.ReceivedBytesThreshold = 42;//081完整数据长度为42，所以设置阈值为42
                //        sp.DataReceived += SerialPort_UPS_DataReceived;
                //        sp.Open();

                //        byte[] buffer = Encoding.Default.GetBytes("Q1\r\n");
                //        sp.Write(buffer, 0, buffer.Length);
                //    }
                //}
                //catch
                //{
                //    sp.Close();
                //}
                byte[] buffer = Encoding.Default.GetBytes("Q1\r\n");
                serialCOMManager.WriteSerialCOM(SerialComID, buffer, out falseMsg);
            }

            upsmre.WaitAll(2000);
            #region 测试数据
            //UPSStatusList UPSStatus = new UPSStatusList();
            //UPSStatus.ID = 1;
            //UPSStatus.DeviceID = deviceInfo.UPSList.Find(_ => _.StationID == station.StationID).DeviceID;
            //UPSStatus.Name = deviceInfo.UPSList.Find(_ => _.StationID == station.StationID).Name;
            //UPSStatus.InVoltage = "220";
            //UPSStatus.LVoltage = "220";
            //UPSStatus.OutVoltage = "220";
            //UPSStatus.OutputLoad = "80";
            //UPSStatus.Freq = "9600";
            //UPSStatus.CellVoltage = "220";
            //UPSStatus.Temperature = "30";
            //UPSStatus.Alarm = "00000000";
            //UPSStatus.Time = DateTime.Now.ToString();
            //UPSStatusList.Add(UPSStatus);
            #endregion
            string jsonContent = JsonConvert.SerializeObject(UPSStatusList);
            sendUPSStatus(jsonContent);
            upsmre.Dispose();
            upsmre = null;
        }

        private void ProcessUPSSerialData(byte[] receiveData, Guid serialPortID)
        {
            UPSList UPSList = deviceInfo.UPSList.Find(_ => _.CommunicationID == serialPortID);
            if (UPSList == null)
                return;
            string upsData = Encoding.ASCII.GetString(receiveData);
            ProtocolHandlerBase protocol = new ProtocolHandlerBase();
            string[] protocolArray = protocol.GetProtocol(upsData);
            foreach (var oneProtocl in protocolArray)
            {
                if (!oneProtocl.StartsWith("("))
                    continue;
                string[] oneProtoclArray = oneProtocl.Substring(1).Split(' ');
                if (oneProtoclArray.Length != 8)
                    continue;
                UPSStatusList UPSStatus = new UPSStatusList();
                UPSStatus.DeviceID = UPSList.DeviceID;
                UPSStatus.Name = UPSList.Name;
                UPSStatus.InVoltage = oneProtoclArray[0];
                UPSStatus.LVoltage = oneProtoclArray[1];
                UPSStatus.OutVoltage = oneProtoclArray[2];
                UPSStatus.OutputLoad = oneProtoclArray[3];
                UPSStatus.Freq = oneProtoclArray[4];
                UPSStatus.CellVoltage = oneProtoclArray[5];
                UPSStatus.Temperature = oneProtoclArray[6];
                UPSStatus.Alarm = oneProtoclArray[7];
                UPSStatus.Time = DateTime.Now;
                UPSStatusList.Add(UPSStatus);
            }
            if (upsmre != null)
            {
                upsmre.SetOne();
            }
        }

        //private void SerialPort_UPS_DataReceived(object sender, SerialDataReceivedEventArgs e)
        //{
        //    SerialPort serialPort = sender as SerialPort;
        //    int length = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
        //    byte[] buf = new byte[length];//声明一个临时数组存储当前来的串口数据  
        //    serialPort.Read(buf, 0, length);//读取缓冲数据
        //    Process_UPS(buf);
        //    upsmre.SetOne();
        //}

        //private void Process_UPS(byte[] buf)
        //{
        //    //TODO:解析协议，生成UPSStatusList
        //    UPSStatusList UPSStatus = new UPSStatusList();
        //    UPSStatusList.Add(UPSStatus);
        //}

        private MutipleThreadResetEvent solarEnergymre;
        /// <summary>
        /// 获取太阳能状态信息
        /// </summary>
        /// <param name="sendSolarEnergyStatus"></param>
        public void Query_SolarEnergyStatus_Info(Action<string> sendSolarEnergyStatus)
        {
            if (deviceInfo == null)
                return;
            StationList station = deviceInfo.StationList.Find(_ => _.PStationID == null);
            if (station == null)
                return;
            solarEnergyStatusList.Clear();

            LogServerManager.AddRunLog(OperationType.System, "查询本级太阳能状态");
            List<SolarEnergyList> solarEnergyList = deviceInfo.SolarEnergyList.FindAll(_ => _.CommunicationID.HasValue && _.CommunicationType == 1 && _.StationID == station.StationID);
            int mreCount = solarEnergyList.Count;
            MutipleThreadResetEvent tempMre = new MutipleThreadResetEvent(mreCount);
            solarEnergymre = tempMre;
            foreach (var item in solarEnergyList)
            {
                Guid SerialComID = item.CommunicationID.Value;
                //TODO:太阳能获取命令;
            }

            solarEnergymre.WaitAll(2000);
            #region 测试数据
            SolarEnergyStatusList solarEnergyStatus = new SolarEnergyStatusList();
            solarEnergyStatus.ID = 1;
            solarEnergyStatus.DeviceID = deviceInfo.SolarEnergyList.Find(_ => _.StationID == station.StationID).DeviceID;
            solarEnergyStatus.Name = deviceInfo.SolarEnergyList.Find(_ => _.StationID == station.StationID).Name;
            solarEnergyStatus.Alarm = 1;
            solarEnergyStatus.Humi = "30";
            solarEnergyStatus.Resistance = "220";
            solarEnergyStatus.SolarCurrent = "10";
            solarEnergyStatus.Time = DateTime.Now;
            solarEnergyStatus.Temp = "30";
            solarEnergyStatus.Voltage="220";
            solarEnergyStatusList.Add(solarEnergyStatus);
            #endregion

            string jsonContent = JsonConvert.SerializeObject(solarEnergyStatusList);
            sendSolarEnergyStatus(jsonContent);
            solarEnergymre.Dispose();
        }

        private void ProcessSolarEnergySerialData(byte[] receiveData, Guid serialPortID)
        {
            throw new NotImplementedException();
        }
    }

    public enum OMCommand
    {
        Connected = 1,
        GetDeviceInfo,
        GetDeviceStatus,
        DeviceInfo,
        CameraStatusInfo,
        UPSStatusInfo,
        SolarEnergyStatusInfo,
        StationStatusInfo
    }
}
