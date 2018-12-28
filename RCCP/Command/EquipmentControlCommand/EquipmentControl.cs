using EquipmentControlServer;
using Newtonsoft.Json;
using RCCP.Repository.Entities.DynamicEntity;
using RCCP.Session;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.EquipmentControlCommand
{
    public class EquipmentControl : CommandBase<AppSession, StringRequestInfo>//AppSession, StringRequestInfo  ||BCSession, StringRequestInfo
    {
        public class DeviceData
        {
            public ControlData tmpControlData;
            public TurntablePresetData tmpTurntablePresetData;
            public SectorScanData tmpSectorScanData;
            public Guid? tmp_Guid;
            public List<TurntablePresetData> tmpListTurntablePreset;
            public List<DynamicDataOfUps3onedata> tmpGetUpsData;
            public TurntableStateData tmpTurntableStateData;

        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)//AppSession session, StringRequestInfo requestInfo||BCSession session, StringRequestInfo requestInfo
        {
            DeviceData data = new DeviceData();
            switch (requestInfo[0])
            {
                case "HD":
                    {
                        string str = requestInfo.Body.Substring(3);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.HDControlInterface(data.tmpControlData);
                    }
                    break;
                case "CCD":
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.CCDControlInterface(data.tmpControlData);
                    }
                    break;
                case "IR":
                    {
                        string str = requestInfo.Body.Substring(3);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.IRControlInterface(data.tmpControlData);
                    }
                    break;
                case "TurntableState":
                    {
                        string str = requestInfo.Body.Substring(15);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DeviceData data1 = new DeviceData();
                        data1.tmpTurntableStateData = ControlInterface.GetTurntableStateData(data.tmp_Guid);
                        string strJsonData = JsonConvert.SerializeObject(data1);
                        session.Send(strJsonData);
                    }
                    break;
                case "SuperiorGetStateData"://上级获取转台信息（临时使用）不作为永久使用。
                    {
                        string str = requestInfo.Body.Substring(21);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        string strTurntableState;
                        strTurntableState = ControlInterface.SuperiorGetTurntableStateData(data.tmp_Guid);
                        string strJsonData = JsonConvert.SerializeObject(strTurntableState);
                        session.Send(strJsonData);
                    }
                    break;
                case "PresetAdd":
                    {
                        string str = requestInfo.Body.Substring(10);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.PresetAddInterface(data.tmpTurntablePresetData);
                    }
                   break;
                case "PresetGet":
                    {
                        string str = requestInfo.Body.Substring(10);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DeviceData data1 = new DeviceData();
                        data1.tmpListTurntablePreset = ControlInterface.PresetGetInterface(data.tmp_Guid);
                        string strJsonData = JsonConvert.SerializeObject(data1);
                        session.Send(strJsonData);
                    }
                    break;
                case "PresetDel":
                    {
                        string str = requestInfo.Body.Substring(10);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.PresetDelInterface(data.tmpTurntablePresetData);
                    }
                    break;
                case "PresetSet":
                    {
                        string str = requestInfo.Body.Substring(10);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.PresetSetInterface(data.tmpTurntablePresetData);
                    }
                    break;
                case "PresetUpdate":
                    {
                        string str = requestInfo.Body.Substring(13);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.PresetUpdateInterface(data.tmpTurntablePresetData);
                    }
                    break;
                case "SectorScanOpen":
                    {
                        string str = requestInfo.Body.Substring(15);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.SectorScanOpen(data.tmpSectorScanData);
                    }
                    break;
                case "SectorScanOff":
                    {
                        string str = requestInfo.Body.Substring(14);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ControlInterface.SectorScanOff(data.tmpSectorScanData);
                    }
                    break;
                case "UPSGet":
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DeviceData data1 = new DeviceData();
                        data1.tmpGetUpsData = ControlInterface.UpsGet();
                        string strJsonData = JsonConvert.SerializeObject(data1);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
