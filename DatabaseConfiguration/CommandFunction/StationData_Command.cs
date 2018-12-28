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
    public class StationData_Command
    {//Add_Modify_Station
        public class DeviceData
        {
            public List<StationList> tmp_StationList;
            public Guid[] tmp_Guid;
        }

        public void Station_AddData(List<StationList> _StationList)
        {
            if (_StationList != null && _StationList.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_StationList = _StationList;
                string str = JsonConvert.SerializeObject(data);
                string message = "Station_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<StationList> Station_QueryData()
        {
            List<StationList> tmpQueryData = new List<StationList>();
            DeviceData data = new DeviceData();
            string message = "Station_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);

            tmpQueryData = deviceData.tmp_StationList;
            return tmpQueryData;
        }

        public void Station_ReviseData(List<StationList> _StationList)
        {
            if (_StationList != null && _StationList.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_StationList = _StationList;
                string str = JsonConvert.SerializeObject(data);
                string message = "Station_DataTableControl/Revise," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);

            }
        }

        public void Station_DelData(Guid[] _GuisList)
        {
            if (_GuisList != null && _GuisList.Length > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_Guid = _GuisList;
                string str = JsonConvert.SerializeObject(data);
                string message = "Station_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
    }
}
