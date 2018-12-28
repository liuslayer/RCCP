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
    public class DeviceType_Command
    {
        public List<DeviceTypeList> tmpDeviceTypeList;
        public DeviceTypeList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<DeviceTypeList> tmp_DeviceTypeList;
            public Guid[] tmp_Guid;
        }

        public void _AddData(List<DeviceTypeList> _DeviceType)
        {
            if (_DeviceType != null && _DeviceType.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_DeviceTypeList = _DeviceType;
                string str = JsonConvert.SerializeObject(data);
                string message = "DeviceType_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<DeviceTypeList> _QueryData()
        {
            List<DeviceTypeList> tmpQueryData = new List<DeviceTypeList>();
            DeviceData data = new DeviceData();
            string message = "DeviceType_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 10000];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_DeviceTypeList;
            return tmpQueryData;
        }
        public void _ReviseData(List<DeviceTypeList> _DeviceType)
        {
            if (_DeviceType != null && _DeviceType.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_DeviceTypeList = _DeviceType;
                string str = JsonConvert.SerializeObject(data);
                string message = "DeviceType_DataTableControl/Revise," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        public void _DelData(Guid[] _GuisList)
        {
            if (_GuisList != null && _GuisList.Length > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = _GuisList;
                string str = JsonConvert.SerializeObject(data);
                string message = "DeviceType_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "DeviceType_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
