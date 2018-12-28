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
    public class GetRunLog : CommandBase<LogSession, StringRequestInfo>
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
                RunLogRepository repo = new RunLogRepository();
                RunLogAssemble runLogAssemble = new RunLogAssemble();
                runLogAssemble.PageNumber = pageNumber;
                runLogAssemble.rowsPerPage = rowsPerPage;
                runLogAssemble.LogCount = repo.RecordCount();
                runLogAssemble.PageCount = (int)Math.Ceiling((double)runLogAssemble.LogCount / rowsPerPage);
                runLogAssemble.RunLogList = repo.GetListPaged(pageNumber, rowsPerPage, null, "OperationTime desc");

                session.TrySend(LogServerCommand.GetRunLogResult.ToString() + " " + JsonConvert.SerializeObject(runLogAssemble) + "\r\n");
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.InnerErr, ex);
            }
        }
    }
}
