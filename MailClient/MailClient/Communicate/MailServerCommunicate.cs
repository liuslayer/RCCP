using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailClient
{
    public class MailServerCommunicate : CommunicateBase
    {
        public delegate void MsgHintEventHandler(string msg);
        public event MsgHintEventHandler MsgHint;//消息提示事件

        public event Action<string> DownloadHint;//下载界面消息事件

        public delegate void InitProgressEventHandler(int maxValue);
        public event InitProgressEventHandler InitSendProgress;//初始化进度条事件
        //public event InitProgressEventHandler InitDownloadProgress;//初始化进度条事件

        public delegate void DisplayProgressEventHandler(int currentValue);
        public event DisplayProgressEventHandler DisplayProgress;//显示进度条事件
        //public event DisplayProgressEventHandler DisplayDownloadProgress;//显示进度条事件

        public delegate void DisConnectEventHandler();
        public event DisConnectEventHandler DisConnect;//断线事件

        public delegate void ConnectedEventHandler();
        public event ConnectedEventHandler Connected;//连接成功事件

        public delegate void MailUsersResponseEventHandler(List<MailUser> mailUserList);
        public event MailUsersResponseEventHandler MailUsersResponse;//获取文电联系人事件

        public delegate void UpdateMailUsersEventHandler(MailUser mailUser);
        public event UpdateMailUsersEventHandler UpdateMailUsers;//更新文电联系人事件

        public delegate void MailRecordsResponseEventHandler(MailTableAssemble mailTableAssemble);
        public event MailRecordsResponseEventHandler MailRecordsResponse;//获取文电记录事件

        public MailServerCommunicate(string remoteIP, int remotePort, string localIP)
            : base(remoteIP, remotePort, localIP)
        {

        }

        protected override void ProcessProtocol(object arg)
        {
            string content = string.Empty;
            string protocol = arg as string;
            if (protocol.StartsWith(MailServerCommand.MailUsersResponse.ToString()))
            {
                content = protocol.Substring(MailServerCommand.MailUsersResponse.ToString().Length).Trim();
                try
                {
                    List<MailUser> mailUserList = JsonConvert.DeserializeObject<List<MailUser>>(content);
                    if (MailUsersResponse != null)
                        MailUsersResponse(mailUserList);

                    string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "send", "1", "10");
                    SendMsgToServer(sendMsg);
                    sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "receive", "1", "10");
                    SendMsgToServer(sendMsg);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(MailServerCommand.MailRecordsResponse.ToString()))
            {
                content = protocol.Substring(MailServerCommand.MailRecordsResponse.ToString().Length).Trim();
                try
                {
                    var JResult = JObject.Parse(content);
                    bool result = (bool)JResult["Result"];
                    string message = JResult["Message"].ToString();
                    MsgHint(message);
                    if (result == false)
                    {
                        return;
                    }
                    MailTableAssemble mailTableAssemble = JResult["MailTableAssemble"].ToObject<MailTableAssemble>();
                    if (MailRecordsResponse != null)
                        MailRecordsResponse(mailTableAssemble);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(MailServerCommand.MailSendResponse.ToString()))
            {
                content = protocol.Substring(MailServerCommand.MailSendResponse.ToString().Length).Trim();
                try
                {
                    var JResult = JObject.Parse(content);
                    string message = JResult["Message"].ToString();
                    MsgHint(message);
                    string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "send", "1", "10");
                    SendMsgToServer(sendMsg);
                }
                catch
                { }
            }
            else if (protocol.StartsWith(MailServerCommand.DownloadMailFileResponse.ToString()))
            {
                content = protocol.Substring(MailServerCommand.DownloadMailFileResponse.ToString().Length).Trim();
                try
                {
                    var JResult = JObject.Parse(content);
                    bool result = (bool)JResult["Result"];
                    if (result == false)
                    {
                        listener.Stop();
                        string message = JResult["Message"].ToString();
                        DownloadHint(message);
                        return;
                    }
                }
                catch
                { }
            }
            else if (protocol.StartsWith(MailServerCommand.NewMail.ToString()))
            {
                //获取接收文电记录
                string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "receive", "1", "10");
                SendMsgToServer(sendMsg);
            }
            else if (protocol.StartsWith(MailServerCommand.UpdateMailUsers.ToString()))
            {
                content = protocol.Substring(MailServerCommand.UpdateMailUsers.ToString().Length).Trim();
                try
                {
                    MailUser mailUser = JsonConvert.DeserializeObject<MailUser>(content);
                    if (UpdateMailUsers != null)
                        UpdateMailUsers(mailUser);
                }
                catch
                { }
            }
        }

        /// <summary>
        /// 发送文电
        /// </summary>
        /// <param name="mailTable"></param>
        /// <param name="filePath"></param>
        public bool SendMail(MailTable mailTable, string filePath)
        {
            string sendMsg = string.Empty;
            if (base.streamToServer == null)
                return false;
            if (string.IsNullOrEmpty(mailTable.MailFileName) || string.IsNullOrEmpty(filePath))
            {
                sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailSendResquest.ToString(), JsonConvert.SerializeObject(mailTable));
                SendMsgToServer(sendMsg);
            }
            else
            {
                TcpListener listener = new TcpListener(IPAddress.Parse(base.localIP), 0);
                listener.Start();
                IPEndPoint endPoint = listener.LocalEndpoint as IPEndPoint;
                mailTable.MailFileListenPort = endPoint.Port;

                sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailSendResquest.ToString(), JsonConvert.SerializeObject(mailTable));
                SendMsgToServer(sendMsg);

                TcpClient localClient = listener.AcceptTcpClient();
                NetworkStream streamToServer = localClient.GetStream();
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                InitSendProgress((int)fs.Length);

                byte[] fileBuffer = new byte[1024 * 1024];
                int bytesRead;
                int totalBytes = 0;
                try
                {
                    do
                    {
                        //Thread.Sleep(100);
                        bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length);
                        streamToServer.Write(fileBuffer, 0, bytesRead);
                        totalBytes += bytesRead;

                        DisplayProgress(totalBytes);
                    } while (bytesRead > 0);
                    //Console.WriteLine("Total {0} bytes Sent,Done!", totalBytes);
                    return true;
                }
                catch (Exception ex)
                {
                    if (MsgHint != null)
                        MsgHint(ex.Message);
                    //Console.WriteLine(ex.Message);
                    return false;
                }
                finally
                {
                    fs.Dispose();
                    streamToServer.Dispose();
                    localClient.Close();
                    listener.Stop();
                }
            }

            Thread.Sleep(1000);
            //获取发送文电记录
            sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "send", "1", "10");
            SendMsgToServer(sendMsg);
            return true;
        }

        TcpListener listener;
        /// <summary>
        /// 下载文电附件
        /// </summary>
        /// <param name="mailTable"></param>
        /// <param name="fileFullName"></param>
        public void DownloadMailFile(MailTable mailTable, string fileFullName, bool isOpen, Action<int> initDownloadProgress, Action<int> displayDownloadProgress, Action downloadEnd)
        {
            listener = new TcpListener(IPAddress.Parse(base.localIP), 0);//建立用于文件传输的临时通道
            listener.Start();
            IPEndPoint endPoint = listener.LocalEndpoint as IPEndPoint;

            string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.DownloadMailFileRequest.ToString(), mailTable.SenderIP, mailTable.MailFileStorageName, base.localIP, endPoint.Port.ToString());
            SendMsgToServer(sendMsg);

            Task.Run(() =>
            {
                FileStream fs;
                TcpClient localClient;
                try
                {
                    localClient = listener.AcceptTcpClient();
                }
                catch
                {
                    return;
                }
                NetworkStream stream = localClient.GetStream();
                //获取文件长度，前4字节
                byte[] byte_fileLen = new byte[4];
                int count = stream.Read(byte_fileLen, 0, byte_fileLen.Length);
                int fileLen = BitConverter.ToInt32(byte_fileLen, 0);
                initDownloadProgress(fileLen);

                fs = new FileStream(fileFullName, FileMode.OpenOrCreate, FileAccess.Write);
                byte[] streamBuffer = new byte[1024 * 1024];
                int bytesRead;
                int totalBytes = 0;
                try
                {
                    do
                    {
                        //Thread.Sleep(100);
                        bytesRead = stream.Read(streamBuffer, 0, streamBuffer.Length);
                        fs.Write(streamBuffer, 0, bytesRead);
                        totalBytes += bytesRead;
                        displayDownloadProgress(totalBytes);
                    } while (bytesRead > 0);
                    //Console.WriteLine("Total {0} bytes Sent,Done!", totalBytes);
                }
                catch (Exception ex)
                {
                    if (MsgHint != null)
                        DownloadHint(ex.Message);
                    //Console.WriteLine(ex.Message);
                }
                finally
                {
                    fs.Dispose();
                    stream.Dispose();
                    localClient.Close();
                    listener.Stop();
                    if (isOpen)
                    {
                        Process p = new Process();
                        p.StartInfo = new ProcessStartInfo(fileFullName);
                        p.Start();
                        //File.Open(fileFullName, FileMode.Open);
                    }
                    DownloadHint("下载完成");
                }
            }).ContinueWith(task =>
            {
                Thread.Sleep(500);//界面进度条有延迟，推迟显示提示 
                downloadEnd();
            }
                );
        }

        protected override void OnConnected()
        {
            if (Connected != null)
                Connected();
        }

        /// <summary>
        /// 断线后向界面发送通知
        /// </summary>
        protected override void OnDisconnect()
        {
            if (DisConnect != null)
                DisConnect();
        }

        public enum MailServerCommand
        {
            /// <summary>
            /// 登录请求
            /// </summary>
            MailUserLoginRequest = 1,
            /// <summary>
            /// 获取用户应答
            /// </summary>
            MailUsersResponse,
            /// <summary>
            /// 更新用户
            /// </summary>
            UpdateMailUsers,
            /// <summary>
            /// 获取邮件记录请求
            /// </summary>
            MailRecordsRequest,
            /// <summary>
            /// 获取邮件记录应答
            /// </summary>
            MailRecordsResponse,
            /// <summary>
            /// 发送邮件请求
            /// </summary>
            MailSendResquest,
            /// <summary>
            /// 发送邮件应答
            /// </summary>
            MailSendResponse,
            /// <summary>
            /// 新邮件通知
            /// </summary>
            NewMail,
            /// <summary>
            /// 下载附件请求
            /// </summary>
            DownloadMailFileRequest,
            /// <summary>
            /// 下载附件应答
            /// </summary>
            DownloadMailFileResponse,
            /// <summary>
            /// 更新邮件状态请求
            /// </summary>
            UpdateMailStatusRequest,
            /// <summary>
            /// 更新邮件状态应答
            /// </summary>
            UpdateMailStatusResponse
        }
    }
}
