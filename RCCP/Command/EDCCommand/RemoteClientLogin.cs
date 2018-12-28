using RCCP.Common;
using RCCP.Server;
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
    /// <summary>
    /// 远程终端登录——综合信息管理发布信息使用
    /// </summary>
    public class RemoteClientLogin : CommandBase<EDCSession, StringRequestInfo>
    {
        public override void ExecuteCommand(EDCSession session, StringRequestInfo requestInfo)
        {
            session.ClientIdentity = requestInfo.Body;
        }
    }
}
