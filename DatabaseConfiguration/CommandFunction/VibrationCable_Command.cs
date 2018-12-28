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
    public class VibrationCable_Command
    {
        public List<VibrationCableList> tmpVibrationCableList;
        public VibrationCableList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<VibrationCableList> tmp_VibrationCableList;
            public Guid[] tmp_Guid;
        }

        public void _AddData(List<VibrationCableList> _VibrationCable)
        {
            if (_VibrationCable != null && _VibrationCable.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_VibrationCableList = _VibrationCable;
                string str = JsonConvert.SerializeObject(data);
                string message = "VibrationCable_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<VibrationCableList> _QueryData()
        {
            List<VibrationCableList> tmpQueryData = new List<VibrationCableList>();
            DeviceData data = new DeviceData();
            string message = "VibrationCable_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_VibrationCableList;
            return tmpQueryData;
        }
        public void _ReviseData(List<VibrationCableList> _VibrationCable)
        {
            if (_VibrationCable != null && _VibrationCable.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_VibrationCableList = _VibrationCable;
                string str = JsonConvert.SerializeObject(data);
                string message = "VibrationCable_DataTableControl/Revise," + str + "\r\n";
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
                string message = "VibrationCable_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "VibrationCable_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
