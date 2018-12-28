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
    public class Radar_Command
    {
        public List<RadarList> tmpCameraList;
        public RadarList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<RadarList> tmp_RadarList;
            public Guid[] tmp_Guid;
        }

        public void _AddData(List<RadarList> _Camera)
        {
            if (_Camera != null && _Camera.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_RadarList = _Camera;
                string str = JsonConvert.SerializeObject(data);
                string message = "Radar_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<RadarList> _QueryData()
        {
            List<RadarList> tmpQueryData = new List<RadarList>();
            DeviceData data = new DeviceData();
            string message = "Radar_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_RadarList;
            return tmpQueryData;
        }
        public void _ReviseData(List<RadarList> _Radar)
        {
            if (_Radar != null && _Radar.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_RadarList = _Radar;
                string str = JsonConvert.SerializeObject(data);
                string message = "Radar_DataTableControl/Revise," + str + "\r\n";
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
                string message = "Radar_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "Radar_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
