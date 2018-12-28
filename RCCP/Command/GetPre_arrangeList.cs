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
    public class GetPre_arrangeList : CommandBase<AppSession, StringRequestInfo>
    {
        public class pre_arrangeList
        {
            public List<Pre_arrangeList> Pre_arrangeList;
            public Guid[] tmp_Guid;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            pre_arrangeList data = new pre_arrangeList();
            List<Pre_arrangeList> pre_arrangeListList = null;
            switch (requestInfo[0])
            {
                case "Add"://添加
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<pre_arrangeList>(str);
                        Pre_DataManagement.AddData(data.Pre_arrangeList);
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        data = JsonConvert.DeserializeObject<pre_arrangeList>(str);
                        Pre_DataManagement.DelData(data.tmp_Guid);
                    }
                    break;
                case "AllDel"://全删
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<pre_arrangeList>(str);
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        data = JsonConvert.DeserializeObject<pre_arrangeList>(str);
                        Pre_DataManagement.UpData(data.Pre_arrangeList);
                    }
                    break;
                case "Query"://查询
                    {
                        pre_arrangeListList = Pre_DataManagement.GetAllData();
                        data.Pre_arrangeList = pre_arrangeListList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
                case "TimeQuery"://根据时间查询
                    {
                        string sql = requestInfo.Body.Substring(10);
                        pre_arrangeListList = Pre_DataManagement.GetListWithCondition(sql);
                        data.Pre_arrangeList = pre_arrangeListList;
                        string strJsonData = JsonConvert.SerializeObject(data);
                        session.Send(strJsonData);
                    }
                    break;
            }
        }
    }
}
