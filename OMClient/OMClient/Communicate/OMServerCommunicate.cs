using Newtonsoft.Json;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class OMServerCommunicate : CommunicateBase
    {
        private OMClientManager manager = new OMClientManager();

        public delegate void UpdateDeviceInfoEventHandler(DeviceInfo deviceInfo);
        public event UpdateDeviceInfoEventHandler UpdateDeviceInfo;//设备信息更新事件

        public delegate void UpdateCameraStatusEventHandler(List<CameraStatusList> cameraStatusList);
        public event UpdateCameraStatusEventHandler UpdateCameraStatus;//摄像头状态信息更新事件

        public delegate void UpdateUPSStatusEventHandler(List<UPSStatusList> UPSStatusList);
        public event UpdateUPSStatusEventHandler UpdateUPSStatus;//UPS状态信息更新事件

        public delegate void UpdateSolarEnergyStatusEventHandler(List<SolarEnergyStatusList> solarEnergyStatusList);
        public event UpdateSolarEnergyStatusEventHandler UpdateSolarEnergyStatus;//太阳能状态信息更新事件

        public event Action<Dictionary<Guid, int>> UpdatestationStatus;//监控站状态信息更新事件

        public OMServerCommunicate(string ip, int port, string localIP)
            : base(ip, port, localIP)
        {

        }

        protected override void ProcessProtocol(object arg)
        {
            string content = string.Empty;
            string protocol = arg as string;
            if (protocol.StartsWith(OMCommand.Connected.ToString()))
            {
                string sendMsg = OMCommand.GetDeviceInfo.ToString() + " " + "\r\n";
                base.SendMsgToServer(sendMsg);//发送获取设备信息命令
            }
            else if (protocol.StartsWith(OMCommand.DeviceInfo.ToString()))
            {
                content = protocol.Substring(OMCommand.DeviceInfo.ToString().Length).Trim();
                try
                {
                    DeviceInfo newDeviceInfo = JsonConvert.DeserializeObject<DeviceInfo>(content);
                    OMClientManager.deviceInfo = newDeviceInfo;
                    if (UpdateDeviceInfo != null)
                        UpdateDeviceInfo(newDeviceInfo);

                    string sendMsg = OMCommand.GetDeviceStatus.ToString() + " " + "\r\n";
                    base.SendMsgToServer(sendMsg);//发送获取设备状态命令
                }
                catch
                { }
            }
            else if (protocol.StartsWith(OMCommand.CameraStatusInfo.ToString()))
            {
                content = protocol.Substring(OMCommand.CameraStatusInfo.ToString().Length).Trim();
                try
                {
                    List<CameraStatusList> newCameraStatusList = JsonConvert.DeserializeObject<List<CameraStatusList>>(content);
                    //Common.cameraStatusList = cameraStatusList;
                    manager.UpdateCameraStatus(newCameraStatusList);
                    if (UpdateCameraStatus != null)
                        UpdateCameraStatus(newCameraStatusList);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(OMCommand.UPSStatusInfo.ToString()))
            {
                content = protocol.Substring(OMCommand.UPSStatusInfo.ToString().Length).Trim();
                try
                {
                    List<UPSStatusList> newUPSStatusList = JsonConvert.DeserializeObject<List<UPSStatusList>>(content);
                    //Common.UPSStatusList = UPSStatusList;
                    manager.UpdateUPSStatus(newUPSStatusList);
                    if (UpdateUPSStatus != null)
                        UpdateUPSStatus(newUPSStatusList);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(OMCommand.SolarEnergyStatusInfo.ToString()))
            {
                content = protocol.Substring(OMCommand.SolarEnergyStatusInfo.ToString().Length).Trim();
                try
                {
                    List<SolarEnergyStatusList> newSolarEnergyStatusList = JsonConvert.DeserializeObject<List<SolarEnergyStatusList>>(content);
                    //Common.solarEnergyStatusList = solarEnergyStatusList;
                    manager.UpdateSolarEnergyStatus(newSolarEnergyStatusList);
                    if (UpdateSolarEnergyStatus != null)
                        UpdateSolarEnergyStatus(newSolarEnergyStatusList);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(OMCommand.StationStatusInfo.ToString()))
            {
                content = protocol.Substring(OMCommand.StationStatusInfo.ToString().Length).Trim();
                try
                {
                    Dictionary<Guid, int> newStationStatusDic = JsonConvert.DeserializeObject<Dictionary<Guid,int>>(content);
                    //Common.solarEnergyStatusList = solarEnergyStatusList;
                    manager.UpdateStationStatus(newStationStatusDic);
                    if (UpdatestationStatus != null)
                        UpdatestationStatus(newStationStatusDic);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 断线后向界面发送通知
        /// </summary>
        protected override void OnDisconnect()
        {
            ClearDeviceStatus();
            if (UpdateDeviceInfo != null)
                UpdateDeviceInfo(null);
        }

        private void ClearDeviceStatus()
        {
            OMClientManager.deviceInfo = null;
            OMClientManager.cameraStatusList.Clear();
            OMClientManager.UPSStatusList.Clear();
            OMClientManager.solarEnergyStatusList.Clear();
            OMClientManager.stationStatusDic.Clear();
        }
    }
}
