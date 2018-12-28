using OMServer;
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
    public class GetDeviceStatus : CommandBase<OMSession, StringRequestInfo>
    {
        public override void ExecuteCommand(OMSession session, StringRequestInfo requestInfo)
        {
            session.manager.Query_CameraStatus_Info(jsonContent =>
            {
                if (string.IsNullOrEmpty(jsonContent))
                    return;
                string message = OMCommand.CameraStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
                session.TrySend(message);
            });

            session.manager.Query_UPSStatus_Info(jsonContent =>
            {
                if (string.IsNullOrEmpty(jsonContent))
                    return;
                string message = OMCommand.UPSStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
                session.TrySend(message);
            });

            session.manager.Query_SolarEnergyStatus_Info(jsonContent =>
            {
                if (string.IsNullOrEmpty(jsonContent))
                    return;
                string message = OMCommand.SolarEnergyStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
                session.TrySend(message);
            });

            session.manager.Query_StationStatus_Info(jsonContent =>
            {
                if (string.IsNullOrEmpty(jsonContent))
                    return;
                string message = OMCommand.StationStatusInfo.ToString() + " " + jsonContent + "\r\n";//命令行协议
                session.TrySend(message);
            });
        }
    }
}
