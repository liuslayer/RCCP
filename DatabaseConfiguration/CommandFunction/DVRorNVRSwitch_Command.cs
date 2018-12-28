using DatabaseConfiguration.DeviceEntitiy;
using DeviceBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConfiguration.CommandFunction
{
    public class DVRorNVRSwitch_Command
    {
        public List<DVRorNVR_SwitchList> tmpDVRorNVRSwitchList;
        public DVRorNVR_SwitchList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<DVRorNVR_SwitchList> tmp_DVRorNVRSwitchList;
            public Guid[] tmp_Guid;
        }
        public void DeviceType_AddData(List<DVRorNVR_SwitchList> _DVRorNVRSwitch)
        {
            if (_DVRorNVRSwitch != null && _DVRorNVRSwitch.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_DVRorNVRSwitchList = _DVRorNVRSwitch;
                string str = JsonConvert.SerializeObject(data);
                string message = "DVRorNVRSwitch_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<DVRorNVR_SwitchList> DeviceType_QueryData()
        {
            List<DVRorNVR_SwitchList> tmpQueryData = new List<DVRorNVR_SwitchList>();
            DeviceData data = new DeviceData();
            string message = "DVRorNVRSwitch_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_DVRorNVRSwitchList;
            return tmpQueryData;
        }
        public void DeviceType_ReviseData(List<DVRorNVR_SwitchList> _DVRorNVRSwitch)
        {
            if (_DVRorNVRSwitch != null && _DVRorNVRSwitch.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_DVRorNVRSwitchList = _DVRorNVRSwitch;
                string str = JsonConvert.SerializeObject(data);
                string message = "DVRorNVRSwitch_DataTableControl/Revise," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        public void DeviceType_DelData(Guid[] _GuisList)
        {
            if (_GuisList != null && _GuisList.Length > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = _GuisList;
                string str = JsonConvert.SerializeObject(data);
                string message = "DVRorNVRSwitch_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void DeviceType_AllDelData()
        {
            string message = "DVRorNVRSwitch_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
