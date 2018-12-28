﻿using DatabaseConfiguration.DeviceEntitiy;
using DeviceBaseData;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseConfiguration.CommandFunction
{
    public class SolarEnergy_Command
    {
        public List<SolarEnergyList> tmpSolarEnergyList;
        public SolarEnergyList tmp_SolarEnergy;
        public class DeviceData
        {
            public List<SolarEnergyList> tmp_SolarEnergyList;
            public Guid[] tmp_Guid;
        }
        public void _AddData(List<SolarEnergyList> _SolarEnergy)
        {
            if (_SolarEnergy != null && _SolarEnergy.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_SolarEnergyList = _SolarEnergy;
                string str = JsonConvert.SerializeObject(data);
                string message = "SolarEnergy_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }
        public List<SolarEnergyList> _QueryData()
        {
            List<SolarEnergyList> tmpQueryData = new List<SolarEnergyList>();
            DeviceData data = new DeviceData();
            string message = "SolarEnergy_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_SolarEnergyList;
            return tmpQueryData;
        }
        public void _ReviseData(List<SolarEnergyList> _SolarEnergy)
        {
            if (_SolarEnergy != null && _SolarEnergy.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_SolarEnergyList = _SolarEnergy;
                string str = JsonConvert.SerializeObject(data);
                string message = "SolarEnergy_DataTableControl/Revise," + str + "\r\n";
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
                string message = "SolarEnergy_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "SolarEnergy_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
