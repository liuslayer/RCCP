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
    public class GetVideoAlarmList : CommandBase<AppSession, StringRequestInfo>
    {

        public class videoAlarmData
        {
            public List<VideoAlarmList> videoAlarmList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            videoAlarmData data = new videoAlarmData();
            List<VideoAlarmList> videoAlarmDataList = null;
            switch (requestInfo[0])
            {
                case "Add"://添加
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<videoAlarmData>(str);
                        Video_DataManagement.AddData(data.videoAlarmList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<videoAlarmData>(str);
                        Video_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<videoAlarmData>(str);
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<videoAlarmData>(str);
                        Video_DataManagement.UpData(data.videoAlarmList);
                    }


                    break;
                case "Query"://查询
                    {
                        videoAlarmDataList = Video_DataManagement.GetAllData();
                        data.videoAlarmList = videoAlarmDataList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
