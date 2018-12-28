using LogServer;
using LogServer.Model;
using Newtonsoft.Json;
using RCCP.Repository.Concrete;
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
                AlarmLogAssemble alarmLogAssemble = new AlarmLogAssemble();
                alarmLogAssemble.PageNumber = pageNumber;
                alarmLogAssemble.rowsPerPage = rowsPerPage;
                alarmLogAssemble.LogCount = repo.RecordCount();
                alarmLogAssemble.PageCount = (int)Math.Ceiling((double)alarmLogAssemble.LogCount / rowsPerPage);
                alarmLogAssemble.AlarmLogList = repo.GetListPaged(pageNumber, rowsPerPage, null, "AlarmTime desc");

                session.TrySend(LogServerCommand.GetAlarmLogResult.ToString() + " " + JsonConvert.SerializeObject(alarmLogAssemble) + "\r\n");
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.InnerErr, ex);
            }
        }
    }
}
