using EquipmentManagementService;
using Newtonsoft.Json;
using RCCP.Repository.Entities;
using RCCP.Session;
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
    public class UPS_DataTableControl : CommandBase<AppSession, StringRequestInfo>
    {//
        public class DeviceData
        {
            public List<UPSList> tmp_UpsList;
            public Guid[] tmp_Guid;
        }
        public UPSList tmp_UpsList1;
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            DeviceData data = new DeviceData();
            List<UPSList> upsList = null;
            switch (requestInfo[0])
            {
                case "Add"://添加
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        UPS_DataManagement.AddData(data.tmp_UpsList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        UPS_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        //UPS_DataManagement.DelData();
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        UPS_DataManagement.UpData(data.tmp_UpsList);
                    }
                    break;
                case "Query"://查询
                    {
                        upsList = UPS_DataManagement.GetAllData();
                        data.tmp_UpsList = upsList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }    
        }
    }
}
