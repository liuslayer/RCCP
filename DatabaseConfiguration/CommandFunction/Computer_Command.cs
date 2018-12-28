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
    public class Computer_Command
    {
        public List<ComputerList> tmpComputerList;
        public ComputerList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<ComputerList> tmp_ComputerList;
            public Guid[] tmp_Guid;
        }

        public void _AddData(List<ComputerList> _Computer)
        {
            if (_Computer != null && _Computer.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_ComputerList = _Computer;
                string str = JsonConvert.SerializeObject(data);
                string message = "Computer_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<ComputerList> _QueryData()
        {
            List<ComputerList> tmpQueryData = new List<ComputerList>();
            DeviceData data = new DeviceData();
            string message = "Computer_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_ComputerList;
            return tmpQueryData;
        }
        public void _ReviseData(List<ComputerList> _Computer)
        {
            if (_Computer != null && _Computer.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_ComputerList = _Computer;
                string str = JsonConvert.SerializeObject(data);
                string message = "Computer_DataTableControl/Revise," + str + "\r\n";
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
                string message = "Computer_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "Computer_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
