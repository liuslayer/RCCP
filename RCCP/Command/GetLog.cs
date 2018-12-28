using Newtonsoft.Json;
using RCCP.Common;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using RCCP.Session;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class GetAlarmLog : CommandBase<LogSession, StringRequestInfo>
    {
        public override void ExecuteCommand(LogSession session, StringRequestInfo requestInfo)
        {
            try
            {
                string[] contents = requestInfo.Body.Split(',');
                int pageNumber = 0;
                int.TryParse(contents[0], out pageNumber);
                int rowsPerPage = 0;
                int.TryParse(contents[1], out rowsPerPage);
                AlarmLogRepository repo = new AlarmLogRepository();
                List<AlarmLog> alarmLogList = repo.GetListPaged(pageNumber, rowsPerPage, null, "OperationTime desc");
                session.TrySend("GetAlarmLog " + JsonConvert.SerializeObject(alarmLogList) + "\r\n");
            }
            catch (Exception ex)
            {
                LogOperation.AddErrLog(LogOperation.ErrLogType.InnerErr, ex);
            }
        }
    }
}
