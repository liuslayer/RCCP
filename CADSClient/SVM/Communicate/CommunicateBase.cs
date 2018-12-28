using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SVM
{
    public class CommunicateBase
    {
        public string remoteIP = string.Empty;
        public int remotePort;
        public string localIP = string.Empty;
        public int localPort;
        private object lockObj_IsConnectSuccess = new object();
        private TcpClient tcpClient;
        protected NetworkStream streamToServer;
        private byte[] buffer;
        private const int BufferSize = 655360;

        private ProtocolHandlerBase _protocolHandler = new ProtocolHandlerBase();
        protected virtual ProtocolHandlerBase ProtocolHandler
        {
            get
            {
                return _protocolHandler;
            }
            set
            {
                _protocolHandler = value;
            }
        }

        public CommunicateBase(string remoteIP, int remotePort, string localIP)
            : this(remoteIP, remotePort, localIP, 0)
        {
        }

        public CommunicateBase(string remoteIP, int remotePort,string localIP,int localPort)
        {
            this.remoteIP = remoteIP;
            this.remotePort = remotePort;
            this.localIP = localIP;
            this.localPort = localPort;
        }
        public void SocketCreateConnect()
        {
            try
            {
                IPEndPoint ep = new IPEndPoint(IPAddress.Parse(localIP), localPort);
                tcpClient = new TcpClient(ep);
                tcpClient.BeginConnect(remoteIP, remotePort, ConnectedCallback, tcpClient);
            }
            catch
            {
            
            }
        }

        /// 异步连接回调函数  
        ///   
        /// 
        private void ConnectedCallback(IAsyncResult iar)
        {
            #region <remarks>
            /// 1、置位IsconnectSuccess  
            #endregion </remarks>

            lock (lockObj_IsConnectSuccess)
            {
                TcpClient tcpClient = (TcpClient)iar.AsyncState;
                try
                {
                    tcpClient.EndConnect(iar);
                    streamToServer = tcpClient.GetStream();
                    OnConnected();
                    //IsconnectSuccess = true;
                    ReceiveMsgFronServer();
                }
                catch
                {
                    //IsconnectSuccess = false;
                    Thread.Sleep(10000);
                    tcpClient.BeginConnect(remoteIP, remotePort, ConnectedCallback, tcpClient);
                }
            }
        }

        protected virtual void OnConnected()
        {
        }

        public virtual void SendMsgToServer(string sendMsg)
        {
            if (streamToServer == null)
                return;
            byte[] buffer = Encoding.UTF8.GetBytes(sendMsg);
            try
            {
                streamToServer.Write(buffer, 0, buffer.Length);
            }
            catch
            {

            }
        }

        private void ReceiveMsgFronServer()
        {
            buffer = new byte[BufferSize];
            while (true)
            {
                try
                {
                    if (!tcpClient.Client.Connected)
                    {
                        if (!IsSocketConnected())
                        {
                            Reconnect();
                            return;
                        }
                    }

                    //streamToServer = tcpClient.GetStream();
                    int count = streamToServer.Read(buffer, 0, BufferSize);
                    if (count == 0)
                    {
                        Reconnect();
                        return;
                    }
                    string protocolStr = Encoding.UTF8.GetString(buffer, 0, count);
                    Array.Clear(buffer, 0, buffer.Length);
                    string[] protocolArray = ProtocolHandler.GetProtocol(protocolStr);
                    foreach (var item in protocolArray)
                    {
                        Task.Factory.StartNew(ProcessProtocol, item);
                    }
                }
                catch
                {
                    //if (streamToServer != null)
                    //{
                    //    streamToServer.Close();
                    //}
                    //tcpClient.Close();
                    //break;
                    continue;
                }
            }
        }

        /// <summary>
        /// 处理协议
        /// </summary>
        /// <param name="arg"></param>
        protected virtual void ProcessProtocol(object arg)
        { 
        }

        /// 当socket.connected为false时，进一步确定下当前连接状态  
        ///   
        ///   
        private bool IsSocketConnected()
        {
            #region remarks
            /******************************************************************************************** 
             * 当Socket.Conneted为false时， 如果您需要确定连接的当前状态，请进行非阻塞、零字节的 Send 调用。 
             * 如果该调用成功返回或引发 WAEWOULDBLOCK 错误代码 (10035)，则该套接字仍然处于连接状态；  
             * 否则，该套接字不再处于连接状态。 
             * Depending on http://msdn.microsoft.com/zh-cn/library/system.net.sockets.socket.connected.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-2 
            ********************************************************************************************/
            #endregion

            #region 过程
            // This is how you can determine whether a socket is still connected.  
            bool connectState = true;
            bool blockingState = tcpClient.Client.Blocking;
            try
            {
                byte[] tmp = new byte[1];

                tcpClient.Client.Blocking = false;
                tcpClient.Client.Send(tmp, 0, 0);
                //Console.WriteLine("Connected!");  
                connectState = true; //若Send错误会跳去执行catch体，而不会执行其try体里其之后的代码  
            }
            catch (SocketException e)
            {
                // 10035 == WSAEWOULDBLOCK  
                if (e.NativeErrorCode.Equals(10035))
                {
                    //Console.WriteLine("Still Connected, but the Send would block");  
                    connectState = true;
                }

                else
                {
                    //Console.WriteLine("Disconnected: error code {0}!", e.NativeErrorCode);  
                    connectState = false;
                }
            }
            finally
            {
                tcpClient.Client.Blocking = blockingState;
            }

            //Console.WriteLine("Connected: {0}", client.Connected);  
            return connectState;
            #endregion
        }

        /// 断线重连函数  
        ///   
        ///   
        private void Reconnect()
        {
            OnDisconnect();
            //tcpClient.Client.Shutdown(SocketShutdown.Both);
            tcpClient.Close();
            streamToServer.Close();
            tcpClient = null;
            streamToServer = null;

            //创建socket  
            SocketCreateConnect();
        }

        /// <summary>
        /// 断线后向界面发送通知
        /// </summary>
        protected virtual void OnDisconnect()
        {
        }
    }
}
