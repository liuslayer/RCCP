using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace BasicModuleManagement
{
    public partial class Form1 : Form
    {
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        string path = @".\ServerList.xml";
        #region 服务器RCCP
        bool b_serverSwitch = false;//服务器开关
        Process pro;//服务器进程
        Socket sSocket;
        Socket serverSocket;
        public TcpClient tcp1;//服务器管理器
        public NetworkStream stream1;//服务器管理器
        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        #endregion
        public Form1()
        {
            InitializeComponent();
            ShowData();

            //建立socket服务器监听RCCP返回的服务状态
            int port = int.Parse(config.AppSettings.Settings["ListenPort"].Value);
            string host = config.AppSettings.Settings["ListenIP"].Value;
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                sSocket.Bind(ipe);
                sSocket.Listen(0);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //接收服务器返回的服务状态线程
            Thread th1 = new Thread(new ThreadStart(ReveiceData1));
            th1.IsBackground = true;
            th1.Start();

            //判断服务器是否启动
            Thread th2 = new Thread(new ThreadStart(ReveiceData2));
            th2.IsBackground = true;
            th2.Start();
        }
        
        private void ReveiceData1()
        {
            try
            {
                while (true)
                {
                    serverSocket = sSocket.Accept();
                    string recStr = "";
                    byte[] recByte = new byte[4096];
                    int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                    recStr += Encoding.UTF8.GetString(recByte, 0, bytes);
                    //解析数据
                    string[] s = recStr.Split(',');
                    XmlDocument xml = new XmlDocument();
                    xml.Load(path);//加载xml文件
                    XmlNode root = xml.SelectSingleNode("services");//查找<root>
                    XmlNodeList list = root.ChildNodes;
                    foreach (XmlNode node in list)
                    {
                        if (node.Attributes["name"].InnerText.ToString() == s[0])
                        {
                            node.ChildNodes[0].InnerText = s[1];
                            xml.Save(path);
                            Action action = delegate () { ShowData(); };
                            Invoke(action);
                        }
                    }
                }
            }
            catch(Exception ex) { MessageBox.Show(ex.ToString()); }
        }
        private void ReveiceData2()
        {
            while (true)
            {
                //判断是否已经运行
                string FileName = ConfigurationManager.AppSettings["FileName"];
                Process[] prc = Process.GetProcesses();
                bool b_isStart = false;
                foreach (Process pr in prc)
                {
                    if (FileName == pr.ProcessName)
                    {
                        b_isStart = true;
                    }
                }
                if(!b_isStart)
                {
                    b_serverSwitch = false;
                    button2.Text = "打开服务器";
                    XmlDocument xml = new XmlDocument();
                    xml.Load(path);//加载xml文件
                    XmlNode root = xml.SelectSingleNode("services");//查找<root>
                    XmlNodeList list = root.ChildNodes;
                    foreach (XmlNode node in list)
                    {
                            node.ChildNodes[0].InnerText = "False";
                            xml.Save(path);
                            Action action = delegate () { ShowData(); };
                            Invoke(action);
                        
                    }
                }
                Thread.Sleep(3000);
            }
        }
        //添加服务
        private void button1_Click(object sender, EventArgs e)
        {
            AddServerSet addServerSet = new AddServerSet();
            DialogResult result= addServerSet.ShowDialog();
            if(result==DialogResult.OK)
            {
                ShowData();
            }
        }

        private void ShowData()
        {
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.Load(path);
                XmlNode root = xmlDoc.SelectSingleNode("services");
                dataGridView1.Rows.Clear();
                treeView1.Nodes[0].Nodes.Clear();
                foreach (XmlNode item in root.ChildNodes)
                {
                    string DisplayName = item.Attributes["DisplayName"].InnerText;
                    TreeNode node = new TreeNode(DisplayName);
                    node.Tag = item.Attributes["name"].InnerText;
                    treeView1.Nodes[0].Nodes.Add(node);

                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = DisplayName;
                    dataGridView1.Rows[index].Cells[1].Value = item.Attributes["name"].InnerText;
                    dataGridView1.Rows[index].Cells[2].Value = item.Attributes["ip"].InnerText;
                    dataGridView1.Rows[index].Cells[3].Value = item.Attributes["port"].InnerText;
                    string status = item.ChildNodes[0].InnerText;
                    if(status=="True" )
                    {
                        dataGridView1.Rows[index].Cells[4].Value = "已运行";
                    }
                    else if(status == "False")
                    {
                        dataGridView1.Rows[index].Cells[4].Value = "已停止";
                    }
                    else
                    {
                        dataGridView1.Rows[index].Cells[4].Value = "";
                    }
                }
                treeView1.ExpandAll();


            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            //XmlDocument xmlDoc = new XmlDocument();
            //try
            //{
            //    xmlDoc.Load(path);
            //    XmlNode root = xmlDoc.SelectSingleNode("services");
            //    foreach (XmlNode item in root.ChildNodes)
            //    {
            //        string DisplayName = item.Attributes["DisplayName"].InnerText;
            //        if (DisplayName == node.Text)
            //        {
            //            label6.Text = DisplayName;
            //            label7.Text = item.Attributes["name"].InnerText;
            //            label8.Text = item.Attributes["ip"].InnerText;
            //            label9.Text = item.Attributes["port"].InnerText;
            //            string status = item.SelectSingleNode("serverStatus").InnerText;
            //            if (status == "True")
            //            {
            //                label10.Text = "已运行";
            //            }
            //            else
            //            {
            //                label10.Text = "已停止";
            //            }
            //        }
            //    }
            //    treeView1.ExpandAll();
            //}
            //catch
            //{ }
            if(e.Button==MouseButtons.Right)
            {
                if(e.Node.Level==1)
                    treeView1.ContextMenuStrip = contextMenuStrip1;
                else
                    treeView1.ContextMenuStrip = null;
            }

        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string DisplayName = treeView1.SelectedNode.Text;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                var root = xmlDoc.DocumentElement;
                var element = root.SelectNodes("server");

                foreach (XmlNode item in element)
                {
                    if (item.Attributes["DisplayName"].InnerText == DisplayName)
                    {
                        string name = item.Attributes["name"].InnerText;//ServerName
                        root.RemoveChild(item);
                        xmlDoc.Save(path);

                        #region 操作服务器中的配置文件App.config
                        Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                        string SuperSocketPath = config.AppSettings.Settings["SuperSocketPath"].Value;
                        string FileName = config.AppSettings.Settings["FileName"].Value;
                        XmlDocument xml = new XmlDocument();
                        xml.Load(SuperSocketPath + @"\" + FileName + ".exe.config");
                        var root2 = xml.DocumentElement;
                        XmlNodeList nodes = root2.ChildNodes;
                        for (int i = 0; i < nodes.Count; i++)
                        {
                            if (nodes[i].Name == "superSocket")
                            {
                                XmlNodeList childNodes = nodes[i].ChildNodes;
                                for (int j = 0; j < childNodes.Count; j++)
                                {
                                    if (childNodes[j].Name == "servers")
                                    {
                                        for (int k = 0; k < childNodes[j].ChildNodes.Count; k++)
                                        {
                                            if(childNodes[j].ChildNodes[k].Attributes["name"].InnerText==name)
                                            {
                                                childNodes[j].RemoveChild(childNodes[j].ChildNodes[k]);
                                                xml.Save(SuperSocketPath + @"\" + FileName + ".exe.config");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        #endregion
                        treeView1.Nodes.Remove(treeView1.SelectedNode);
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1.Rows[i].Cells[0].Value.ToString() == DisplayName)
                            {
                                dataGridView1.Rows.RemoveAt(i);
                                break;
                            }
                        }
                    }
                }
            }
            catch(Exception ex) { Console.Write(ex.ToString()); MessageBox.Show("删除失败！"); }
        }
        //单个服务启动
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        { //连接服务器管理器
            tcp1 = new TcpClient();
            try
            {
                string ManagementServerIP = config.AppSettings.Settings["ManagementServerIP"].Value;
                int ManagementServerPort = int.Parse(config.AppSettings.Settings["ManagementServerPort"].Value);
                tcp1.Connect(ManagementServerIP, ManagementServerPort);
                stream1 = tcp1.GetStream();
                string message = "StartServer " + treeView1.SelectedNode.Tag.ToString()+"\r\n";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream1.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器管理器连接失败！");
            }

        }
        //单个服务关闭
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {//连接服务器管理器
            tcp1 = new TcpClient();
            try
            {
                string ManagementServerIP = config.AppSettings.Settings["ManagementServerIP"].Value;
                int ManagementServerPort = int.Parse(config.AppSettings.Settings["ManagementServerPort"].Value);
                tcp1.Connect(ManagementServerIP, ManagementServerPort);
                stream1 = tcp1.GetStream();
                string message = "StopServer " + treeView1.SelectedNode.Tag.ToString()+"\r\n";
                byte[] data = Encoding.UTF8.GetBytes(message);
                stream1.Write(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                MessageBox.Show("服务器管理器连接失败！");
            }
        }
        //启动supersocket
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (!b_serverSwitch)
            {
                //读取app.config获取RCCP启动位置
                
                string SuperSocketPath = config.AppSettings.Settings["SuperSocketPath"].Value;
                string FileName = config.AppSettings.Settings["FileName"].Value;
                //判断是否已经运行
                Process[] prc = Process.GetProcesses();
                foreach (Process pr in prc)
                {
                    if (FileName == pr.ProcessName)
                    {
                        ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                        SetForegroundWindow(pr.MainWindowHandle);
                        return;
                    }
                }

                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = FileName + ".exe";
                info.WorkingDirectory = SuperSocketPath;
                try
                {
                    pro = Process.Start(info);
                }
                catch (Win32Exception ex)
                {
                    Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                    return;
                }
                b_serverSwitch = true;
                btn.Text = "关闭服务器";
               
            }
            else
            {
                pro.Close();
                b_serverSwitch = false;
                btn.Text = "打开服务器";
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                sSocket.Close();
                serverSocket.Close();
            }
            catch { }
        }
    }
}
