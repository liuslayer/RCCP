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
    public class GetErrLog : CommandBase<LogSession, StringRequestInfo>
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
                ErrLogRepository repo = new ErrLogRepository();
                ErrLogAssemble errLogAssemble = new ErrLogAssemble();
                errLogAssemble.PageNumber = pageNumber;
                errLogAssemble.rowsPerPage = rowsPerPage;
                errLogAssemble.LogCount = repo.RecordCount();
                errLogAssemble.PageCount = (int)Math.Ceiling((double)errLogAssemble.LogCount / rowsPerPage);
                errLogAssemble.ErrLogList = repo.GetListPaged(pageNumber, rowsPerPage, null, "ErrTime desc");

                session.TrySend(LogServerCommand.GetErrLogResult.ToString() + " " + JsonConvert.SerializeObject(errLogAssemble) + "\r\n");
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.InnerErr, ex);
            }
        }
    }
}
