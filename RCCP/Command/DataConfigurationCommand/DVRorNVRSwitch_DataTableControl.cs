using EquipmentManagementService;
using Newtonsoft.Json;
using RCCP.Repository.Entities.StaticEntity;
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
    public class DVRorNVRSwitch_DataTableControl : CommandBase<AppSession, StringRequestInfo>
    {
        public class DeviceData
        {
            public List<DVRorNVR_SwitchList> tmp_DVRorNVRSwitchList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            DeviceData data = new DeviceData();
            List<DVRorNVR_SwitchList> DvrOrNvr_SwitchList = new List<DVRorNVR_SwitchList>();
            switch (requestInfo[0])
            {
                case "Add"://添加 
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DVRorNVRSwitch_DataManagement.AddData(data.tmp_DVRorNVRSwitchList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DVRorNVRSwitch_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        DVRorNVRSwitch_DataManagement.DelAllData();
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<DeviceData>(str);
                        DVRorNVRSwitch_DataManagement.UpData(data.tmp_DVRorNVRSwitchList);
                    }
                    break;
                case "Query"://查询
                    {
                        DvrOrNvr_SwitchList = DVRorNVRSwitch_DataManagement.GetAllData();
                        data.tmp_DVRorNVRSwitchList = DvrOrNvr_SwitchList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
