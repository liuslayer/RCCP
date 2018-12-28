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
    public class SerialCOM_Command
    {
        public List<SerialCOMList> tmpSerialCOMList;
        public SerialCOMList tmp_SerialCOM;
        public class DeviceData
        {
            public List<SerialCOMList> tmp_SerialCOMList;
            public Guid[] tmp_Guid;
        }
        public void _AddData(List<SerialCOMList> _SerialCOM)
        {
            if (_SerialCOM != null && _SerialCOM.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_SerialCOMList = _SerialCOM;
                string str = JsonConvert.SerializeObject(data);
                string message = "SerialCOM_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        public List<SerialCOMList> _QueryData()
        {
            List<SerialCOMList> tmpQueryData = new List<SerialCOMList>();
            DeviceData data = new DeviceData();
            string message = "SerialCOM_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_SerialCOMList;
            return tmpQueryData;
        }
        public void _ReviseData(List<SerialCOMList> _SerialCOM)
        {
            if (_SerialCOM != null && _SerialCOM.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_SerialCOMList = _SerialCOM;
                string str = JsonConvert.SerializeObject(data);
                string message = "SerialCOM_DataTableControl/Revise," + str + "\r\n";
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
                string message = "SerialCOM_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "SerialCOM_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
