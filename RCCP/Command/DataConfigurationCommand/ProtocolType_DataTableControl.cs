﻿using EquipmentManagementService;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command.DataConfigurationCommand
{
    public class ProtocolType_DataTableControl : CommandBase<AppSession, StringRequestInfo>
    {
        public class DeviceData
        {
            public List<ProtocolTypeList> tmp_ProtocolTypeList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            DeviceData data = new DeviceData();
            List<ProtocolTypeList> protoclTypeList = new List<ProtocolTypeList>();
            switch (requestInfo[0])
            {
                case "Add"://添加 
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ProtocolType_DataManagement.AddData(data.tmp_ProtocolTypeList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ProtocolType_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        ProtocolType_DataManagement.DelAllData();
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        ProtocolType_DataManagement.UpData(data.tmp_ProtocolTypeList);
                    }
                    break;
                case "Query"://查询
                    {
                        protoclTypeList = ProtocolType_DataManagement.GetAllData();
                        data.tmp_ProtocolTypeList = protoclTypeList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}