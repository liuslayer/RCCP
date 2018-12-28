using Client.Entities;
using Client.Entities.ControlEntity;
using DeviceBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurntableControlInterface
{
    public class Control_Command
    {
        public class DeviceData
        {
            public ControlData tmpControlData;
            public TurntablePresetData tmpTurntablePresetData;
            public SectorScanData tmpSectorScanData;
            public Guid? tmp_Guid;
            public List<TurntablePresetData> tmpListTurntablePreset;
            public List<DynamicDataOfUps3onedata> tmpGetUpsData;
        }
        //转台控制
        public static void HDControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid != null)
            {
              DeviceData data = new DeviceData();
              data.tmpControlData = tmpControlData;
              string str = JsonConvert.SerializeObject(data);
              string message = "EquipmentControl/HD," + str + "\r\n";
              byte[] b = Encoding.UTF8.GetBytes(message);
              CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //白光控制
        public static void CCDControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmpControlData = tmpControlData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/CCD," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //红外控制
        public static void IRControl(ControlData tmpControlData)
        {
            if (tmpControlData.VideoGuid!= null)
            {
                DeviceData data = new DeviceData();
                data.tmpControlData = tmpControlData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/IR," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public static void ResetIRProtect()
        {
            DeviceData data = new DeviceData();
            //data.tmpControlData = tmpControlData;
            //string str = JsonConvert.SerializeObject(data);
            string message = "EquipmentControl/ResetIRProtect," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
        //添加预置位
        public static TurntablePresetData PresetAddControl(TurntablePresetData tmpAddPreset)
        {
            TurntablePresetData tmp_AddPreset = new TurntablePresetData();
            if(tmpAddPreset.PresetName !=null && tmpAddPreset.VideoGuid !=null)
            {
                DeviceData data = new DeviceData();
                data.tmpTurntablePresetData = tmpAddPreset;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetAdd," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
            return tmp_AddPreset;
        }
        public static List<DynamicDataOfUps3onedata> UpsDataGetControl()
        {
            List<DynamicDataOfUps3onedata> tmpUpsDataGet = new List<DynamicDataOfUps3onedata>();
            //DeviceData data = new DeviceData();
            //data.tmp_Guid = VideoDeviceGuid.Value;
            //string str = JsonConvert.SerializeObject(data);
            //string message = "EquipmentControl/PresetGet," + str + "\r\n";
            string message = "EquipmentControl/UPSGet," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 1000];
            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpUpsDataGet = deviceData.tmpGetUpsData;

            return tmpUpsDataGet;
        }
        //获取所有预置位
        public static List<TurntablePresetData> PresetGetControl(Guid? VideoDeviceGuid)
        {
            List<TurntablePresetData> tmp_PresetList = new List<TurntablePresetData>();
            tmp_PresetList = null;
            if (VideoDeviceGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = VideoDeviceGuid.Value;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetGet," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

                string responseData = String.Empty;
                b = new Byte[1024 * 1000];
                Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
                responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
                DeviceData deviceData = new DeviceData();
                deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
                tmp_PresetList = deviceData.tmpListTurntablePreset;
            }
            return tmp_PresetList;
        }
        //删除某个预置位
        public static void PresetDelControl(TurntablePresetData tmpPresetData)
        {
            if (tmpPresetData != null)
            {
                DeviceData data = new DeviceData();
                data.tmpTurntablePresetData = tmpPresetData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetDel," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //调用预置位
        public static void PresetSetControl(TurntablePresetData tmpPresetData)
        {
            if (tmpPresetData != null)
            {
                DeviceData data = new DeviceData();
                data.tmpTurntablePresetData = tmpPresetData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetSet," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        public static void PresetUpdateControl(TurntablePresetData tmpPresetData)
        {
            if(tmpPresetData != null)
            {
                DeviceData data = new DeviceData();
                data.tmpTurntablePresetData = tmpPresetData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/PresetUpdate," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        //开启扇扫
        public static void SectorScanOpenControl(SectorScanData tmpSectorScanData)
        {
            if (tmpSectorScanData.VideoGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmpSectorScanData = tmpSectorScanData;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/SectorScanOpen," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

            }
        }
        //关闭扇扫
        public static void SectorScanOffControl(Guid? tmpGuid)
        {
            if(tmpGuid != null)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = tmpGuid;
                string str = JsonConvert.SerializeObject(data);
                string message = "EquipmentControl/SectorScanOff," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
    }
}
