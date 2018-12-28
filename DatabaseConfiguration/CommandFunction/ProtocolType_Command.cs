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
    public class ProtocolType_Command
    {
        public List<ProtocolTypeList> tmpProtocolTypeList;
        public ProtocolTypeList tmp_ProtocolType;
        public class DeviceData
        {
            public List<ProtocolTypeList> tmp_ProtocolTypeList;
            public Guid[] tmp_Guid;
        }
        public void _AddData(List<ProtocolTypeList> _ProtocolType)
        {
            if (_ProtocolType != null && _ProtocolType.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_ProtocolTypeList = _ProtocolType;
                string str = JsonConvert.SerializeObject(data);
                string message = "ProtocolType_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<ProtocolTypeList> _QueryData()
        {
            List<ProtocolTypeList> tmpQueryData = new List<ProtocolTypeList>();
            DeviceData data = new DeviceData();
            string message = "ProtocolType_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_ProtocolTypeList;
            return tmpQueryData;
        }
        public void _ReviseData(List<ProtocolTypeList> _ProtocolType)
        {
            if (_ProtocolType != null && _ProtocolType.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_ProtocolTypeList = _ProtocolType;
                string str = JsonConvert.SerializeObject(data);
                string message = "ProtocolType_DataTableControl/Revise," + str + "\r\n";
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
                string message = "ProtocolType_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "ProtocolType_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
