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
    public class PersonnelInformation_Command
    {
        public List<PersonnelInformationList> tmpPersonnelInformationList;
        public PersonnelInformationList tmp_DeviceTyp;
        public class DeviceData
        {
            public List<PersonnelInformationList> tmp_PersonnelInformationList;
            public Guid[] tmp_Guid;
        }

        public void _AddData(List<PersonnelInformationList> _PersonnelInformation)
        {
            if (_PersonnelInformation != null && _PersonnelInformation.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_PersonnelInformationList = _PersonnelInformation;
                string str = JsonConvert.SerializeObject(data);
                string message = "PersonnelInformation_DataTableControl/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public List<PersonnelInformationList> _QueryData()
        {
            List<PersonnelInformationList> tmpQueryData = new List<PersonnelInformationList>();
            DeviceData data = new DeviceData();
            string message = "PersonnelInformation_DataTableControl/Query" + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);

            string responseData = String.Empty;
            b = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(b, 0, b.Length);
            responseData += Encoding.UTF8.GetString(b, 0, (int)bytes);
            DeviceData deviceData = new DeviceData();
            deviceData = JsonConvert.DeserializeObject<DeviceData>(responseData);
            tmpQueryData = deviceData.tmp_PersonnelInformationList;
            return tmpQueryData;
        }
        public void _ReviseData(List<PersonnelInformationList> _PersonnelInformation)
        {
            if (_PersonnelInformation != null && _PersonnelInformation.Count > 0)
            {
                DeviceData data = new DeviceData();
                data.tmp_PersonnelInformationList = _PersonnelInformation;
                string str = JsonConvert.SerializeObject(data);
                string message = "PersonnelInformation_DataTableControl/Revise," + str + "\r\n";
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
                string message = "PersonnelInformation_DataTableControl/Del," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
        }

        public void _AllDelData()
        {
            string message = "PersonnelInformation_DataTableControl/AllDel," + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
    }
}
