using Newtonsoft.Json;
using RCCP.Command.Alarm;
using RCCP.Repository.Entities;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class GetArmAndDisarmList : CommandBase<AppSession, StringRequestInfo>
    {
        public class armAndDisarmData
        {
            public List<ArmAndDisarmList> armAndDisarmList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            armAndDisarmData data = new armAndDisarmData();
            List<ArmAndDisarmList> armAndDisarmDataList = null;
            switch (requestInfo[0])
            {
                case "Add"://添加
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<armAndDisarmData>(str);
                        Alarm_DataManagement.AddData(data.armAndDisarmList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<armAndDisarmData>(str);
                        Alarm_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<armAndDisarmData>(str);
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<armAndDisarmData>(str);
                        Alarm_DataManagement.UpData(data.armAndDisarmList);
                    }


                    break;
                case "Query"://查询
                    {
                        armAndDisarmDataList = Alarm_DataManagement.GetAllData();
                        data.armAndDisarmList = armAndDisarmDataList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
