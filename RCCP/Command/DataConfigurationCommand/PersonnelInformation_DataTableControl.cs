using EquipmentManagementService;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;

namespace RCCP.Command.DataConfigurationCommand
{
    public class PersonnelInformation_DataTableControl : CommandBase<AppSession, StringRequestInfo>
    {

        public class DeviceData
        {
            public List<PersonnelInformationList> tmp_PersonnelInformationList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            DeviceData data = new DeviceData();
            List<PersonnelInformationList> personnelinformationList = new List<PersonnelInformationList>();
            switch (requestInfo[0])
            {
                case "Add"://添加 
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        PersonnelInformation_DataManagement.AddData(data.tmp_PersonnelInformationList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        PersonnelInformation_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        PersonnelInformation_DataManagement.DelAllData();
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        PersonnelInformation_DataManagement.UpData(data.tmp_PersonnelInformationList);
                    }
                    break;
                case "Query"://查询
                    {
                        personnelinformationList = PersonnelInformation_DataManagement.GetAllData();
                        data.tmp_PersonnelInformationList = personnelinformationList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
