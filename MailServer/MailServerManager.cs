using LogServer;
using RCCP.Common;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using static LogServer.LogServerManager;

namespace MailServer
{
    public class MailServerManager
    {
        private static List<string> OnlineUserList = new List<string>();
        private static string mailDirectory = ConfigurationManager.AppSettings["MailPath"];
        private MailUserRepository mailUserRepository = new MailUserRepository();
        private MailTableRepository mailTableRepository = new MailTableRepository();

        public List<MailUser> GetMailUsers()
        {
            try
            {
                List<MailUser> mailUserList = mailUserRepository.GetList();
                mailUserList.ForEach(_ =>
                {
                    _.IsOnline = OnlineUserList.Contains(_.UserIP) ? true : false;
                });
                return mailUserList;
            }
            catch
            {
                return null;
            }
        }

        public MailUser GetMailUsersByIP(string userIP)
        {
            try
            {
                List<MailUser> mailUserList = mailUserRepository.GetListWithCondition(new { UserIP = userIP });
                mailUserList.ForEach(_ =>
                {
                    _.IsOnline = OnlineUserList.Contains(_.UserIP) ? true : false;
                });
                if (mailUserList.Count < 0)
                    return null;
                return mailUserList[0];
            }
            catch
            {
                return null;
            }
        }

        public void AddMailUser(MailUser mailUser)
        {
            try
            {
                mailUserRepository.Insert(mailUser);
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.DBErr, ex);
            }
        }

        public void UpdateMailUser(MailUser mailUser)
        {
            try
            {
                mailUserRepository.Update(mailUser);
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.DBErr, ex);
            }
        }

        public int GetMailCount(string userIP, string mailType)
        {
            try
            {
                if (mailType == "send")
                {
                    return mailTableRepository.RecordCount(" where SenderIP=" + "'" + userIP + "'");
                }
                else
                {
                    return mailTableRepository.RecordCount(" where ReceiverIP=" + "'" + userIP + "'");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userIP"></param>
        /// <param name="mailType">0发送 1接收</param>
        /// <returns></returns>
        public List<MailTable> GetMailRecordsByPage(int pageNumber,int rowsPerPage,string userIP, string mailType)
        {
            try
            {
                if (mailType == "send")
                {
                    return mailTableRepository.GetListPaged(pageNumber, rowsPerPage, " where SenderIP=" + "'" + userIP + "'", "SendTime desc");
                }
                else
                {
                    return mailTableRepository.GetListPaged(pageNumber, rowsPerPage, " where ReceiverIP=" + "'" + userIP + "'", "SendTime desc");
                }
            }
            catch
            {
                throw;
            }
        }

        private void SaveMailFile(MailTable mailTable)
        {
            IPAddress ip = IPAddress.Parse(mailTable.SenderIP);
            IPEndPoint endPoint = new IPEndPoint(ip, mailTable.MailFileListenPort);
            TcpClient localClient;
            try
            {
                localClient = new TcpClient();
                localClient.Connect(endPoint);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            NetworkStream streamToClient = localClient.GetStream();
            string ReceiverDirectory = Path.Combine(mailDirectory, mailTable.SenderIP);
            string filePath = Path.Combine(ReceiverDirectory, mailTable.MailFileStorageName);
            DirectoryInfo di = Directory.CreateDirectory(ReceiverDirectory);
            byte[] fileBuffer = new byte[1024];
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);
            int bytesRead;
            byte[] streamBuffer = new byte[1024 * 1024];
            try
            {
                do
                {
                    bytesRead = streamToClient.Read(streamBuffer, 0, streamBuffer.Length);
                    fs.Write(streamBuffer, 0, bytesRead);
                } while (bytesRead > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                streamToClient.Dispose();
                fs.Dispose();
                localClient.Close();
            }
        }

        /// <summary>
        /// 将邮件信息存储到服务器上
        /// </summary>
        /// <param name="mailTable"></param>
        public void SaveMail(MailTable mailTable)
        {
            try
            {
                if (!string.IsNullOrEmpty(mailTable.MailFileName))
                {
                    SaveMailFile(mailTable);
                }

                if (mailTable.ReceiverDic.Count == 1)
                {
                    MailTableRepository mailTableRepository = new MailTableRepository();
                    mailTableRepository.Insert(mailTable);
                }
                else if (mailTable.ReceiverDic.Count > 1)//群发，拆分成多条保存
                {
                    foreach (var item in mailTable.ReceiverDic)
                    {
                        MailTable newMailTable = new MailTable();
                        newMailTable.ReceiverIP = item.Key;
                        newMailTable.Receiver = item.Value;
                        newMailTable.SenderIP = mailTable.SenderIP;
                        newMailTable.Sender = mailTable.Sender;
                        newMailTable.SendTime = mailTable.SendTime;
                        newMailTable.MailTitle = mailTable.MailTitle;
                        newMailTable.MailContent = mailTable.MailContent;
                        newMailTable.MailFileName = mailTable.MailFileName;
                        newMailTable.MailFileStorageName = mailTable.MailFileStorageName;
                        MailTableRepository mailTableRepository = new MailTableRepository();
                        mailTableRepository.Insert(newMailTable);
                    }
                }
            }
            catch (Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.InnerErr, ex);
                throw ex;
            }
        }

        public bool IsFileExist(string SenderIP, string mailFileStorageName)
        {
            string SenderDirectory = Path.Combine(mailDirectory, SenderIP);
            string filePath = Path.Combine(SenderDirectory, mailFileStorageName);
            return File.Exists(filePath);
        }
        /// <summary>
        /// 发送附件给客户端
        /// </summary>
        /// <param name="senderIP"></param>
        /// <param name="mailFileStorageName"></param>
        /// <param name="fileConncectPort"></param>
        public void SendMailFile(string senderIP, string mailFileStorageName, string fileConncectIP, int fileConncectPort)
        {
            IPAddress ipAddress = IPAddress.Parse(fileConncectIP);
            IPEndPoint endPoint = new IPEndPoint(ipAddress, fileConncectPort);
            TcpClient localClient;
            try
            {
                localClient = new TcpClient();
                localClient.Connect(endPoint);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            NetworkStream streamToClient = localClient.GetStream();
            string ReceiverDirectory = Path.Combine(mailDirectory, senderIP);
            string filePath = Path.Combine(ReceiverDirectory, mailFileStorageName);
            //获取文件长度，前4字节
            FileInfo fi = new FileInfo(filePath);
            long fileLen = fi.Length;
            byte[] byte_fileLen = BitConverter.GetBytes(fileLen);
            streamToClient.Write(byte_fileLen, 0, 4);

            FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);//FileShare.Read支持多线程访问同一文件
            byte[] fileBuffer = new byte[1024 * 1024];
            int bytesRead;
            try
            {
                do
                {
                    //Thread.Sleep(100);
                    bytesRead = fs.Read(fileBuffer, 0, fileBuffer.Length);
                    streamToClient.Write(fileBuffer, 0, bytesRead);

                } while (bytesRead > 0);
                //Console.WriteLine("Total {0} bytes Sent,Done!", totalBytes);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                fs.Dispose();
                streamToClient.Dispose();
                localClient.Close();
            }
        }

        public void UpdateMailStatus(Guid mailID)
        {
            try
            {
                MailTable mailTable = mailTableRepository.GetEntityById(mailID);
                mailTable.IsRead = true;
                mailTableRepository.Update(mailTable);
            }
            catch(Exception ex)
            {
                LogServerManager.AddErrLog(ErrLogType.InnerErr, ex);
                throw;
            }
        }

        public void AddOnlineUser(string ip)
        {
            OnlineUserList.Add(ip);
        }

        public void RemoveOfflineUser(string ip)
        {
            OnlineUserList.Remove(ip);
        }

        public string GetMailFileStorageName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                return string.Empty;
            string fileNameWithoutEx = Path.GetFileNameWithoutExtension(fileName);
            string fileEx = Path.GetExtension(fileName);
            return string.Format(fileNameWithoutEx + "_" + DateTime.Now.Ticks + fileEx);
        }
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
