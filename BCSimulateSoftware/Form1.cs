using System;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using static Client.Entities.ControlCommandData;

namespace BCSimulateSoftware
{
    public partial class Form1 : Form
    {
        //建立socket服务器监听外部数据中心发送回来的命令
        Socket sSocket1;
        Socket serverSocket1;
        XmlDocument xml = new XmlDocument();
        string path = @".\DeviceList.xml";
        IPAddress ExternalDataCentreService_IP;
        int ExternalDataCentreService_Port1;
        IPEndPoint ipe1;
        public Form1()
        {
            InitializeComponent();
            #region 监听外部数据中心发回的数据
            string host = ConfigurationManager.AppSettings["ListenIP"];
            int port = int.Parse(ConfigurationManager.AppSettings["ListenPort"]);
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            sSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            sSocket1.Bind(ipe);
            sSocket1.Listen(0);
            Thread th1 = new Thread(new ThreadStart(ReveiceData1));
            th1.IsBackground = true;
            th1.Start();
            #endregion
            //读取设备列表
            try
            {
                xml.Load(path);
                XmlNode root = xml.SelectSingleNode("devices");
                treeView1.Nodes.Clear();
                foreach (XmlNode item in root.ChildNodes)
                {
                    string DeviceName = item.InnerText;
                    TreeNode node = new TreeNode(DeviceName);
                    node.Tag = item.Attributes["Guid"].InnerText+","+item.Attributes["VideoType"].InnerText;
                    treeView1.Nodes.Add(node);
                }
                treeView1.SelectedNode = treeView1.Nodes[0];
                treeView1.ExpandAll();
            }
            catch (Exception ex)
            {
                Console.WriteLine("业务协同模拟软件1读取DeviceList.xml失败。错误信息：" + ex.ToString());
            }
        }
        int i = 0;
        private void ReveiceData1()
        {
            while (true)
            {
                serverSocket1 = sSocket1.Accept();
              
                byte[] recByte = new byte[1024];
                int bytes = serverSocket1.Receive(recByte, recByte.Length, 0);
             
                ShowMessage(recByte);
            }
        }
        public void ShowMessage(byte[] recByte)
        {
            string recStr = Encoding.UTF8.GetString(recByte);
            string[] str = recStr.Split(',');
            str[3] = i.ToString();
            i++;

            Action action = delegate ()
            {
                label3.Text = str[1];
                label4.Text = str[2];
                label7.Text = str[3];
                label6.Text = str[4];
            };
            Invoke(action);
        }
        //叠加字符
        private void button14_Click(object sender, EventArgs e)
        {
            string IP = textBox8.Text;
            string nchannel = textBox10.Text;
            string sendStr = "AlarmService/11,"+IP+"_"+nchannel +"_"+ textBox1.Text;
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);

            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }
      

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex("^[0-9\b\r\n]*$");
            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                MessageBox.Show("请输入数字。");
                e.Handled = true;
            }
        }

        private void button9_MouseDown(object sender, MouseEventArgs e)
        {
            int i_Action = -1;
            Button btn = sender as Button;
            string[] str = treeView1.SelectedNode.Tag.ToString().Split(',');
            if (str.Length != 2) return;
            switch (btn.Text)
            {
                case "左上":
                    i_Action = 1;
                    break;
                case "上":
                    i_Action = 2;
                    break;
                case "右上":
                    i_Action = 3;
                    break;
                case "左":
                    i_Action = 4;
                    break;
                case "初始位":
                    i_Action = 5;
                    break;
                case "右":
                    i_Action = 6;
                    break;
                case "左下":
                    i_Action = 7;
                    break;
                case "下":
                    i_Action = 8;
                    break;
                case "右下":
                    i_Action = 9;
                    break;
                case "视场-":
                    i_Action = 10;
                    break;
                case "视场+":
                    i_Action = 12;
                    break;
                case "聚焦-":
                    i_Action = 14;
                    break;
                case "聚焦+":
                    i_Action = 16;
                    break;
            }
            string sendStr = "EquipmentControl/1," + str[0] + "," + str[1] + "," + i_Action + "," + textBox2.Text;
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }

        private void button9_MouseUp(object sender, MouseEventArgs e)
        {
            int i_Action = -1;
            Button btn = sender as Button;
            string[] str = treeView1.SelectedNode.Tag.ToString().Split(',');
            if (str.Length != 2) return;
            switch (btn.Text)
            {
                case "左上":
                    i_Action = 0;
                    break;
                case "上":
                    i_Action = 0;
                    break;
                case "右上":
                    i_Action = 0;
                    break;
                case "左":
                    i_Action = 0;
                    break;
                case "初始位":
                    i_Action = 0;
                    break;
                case "右":
                    i_Action = 0;
                    break;
                case "左下":
                    i_Action = 0;
                    break;
                case "下":
                    i_Action = 0;
                    break;
                case "右下":
                    i_Action = 0;
                    break;
                case "视场-":
                    i_Action = 11;
                    break;
                case "视场+":
                    i_Action = 13;
                    break;
                case "聚焦-":
                    i_Action = 15;
                    break;
                case "聚焦+":
                    i_Action = 17;
                    break;

            }
            if (str.Length != 2) return;
            string sendStr = "EquipmentControl/1," + str[0] + "," + str[1] + "," + i_Action + "," + textBox2.Text;
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }
        //
        private void button15_Click(object sender, EventArgs e)
        {
            string[] str = treeView1.SelectedNode.Tag.ToString().Split(',');
            if (str.Length != 2) return;
            Button btn = sender as Button;
            string sendStr="";
            switch (btn.Text)
            {
                case "扇扫开":
                    sendStr = "EquipmentControl/4,"+str[0]+"," + textBox3.Text + "," + textBox4.Text + "," + textBox7.Text + "," + textBox5.Text + "," + textBox6.Text;
                    btn.Text = "扇扫关";
                    break;
                case "扇扫关":
                    sendStr = "EquipmentControl/5,"+str[0];
                    btn.Text = "扇扫开";
                    break;
            }
           byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }
        //预置位调用
        private void button16_Click(object sender, EventArgs e)
        {
            string[] str = treeView1.SelectedNode.Tag.ToString().Split(',');
            if (str.Length != 2) return;
            string sendStr = "EquipmentControl/6,"+str[0]+","+ textBox9.Text;
            byte[] sendBytes = Encoding.UTF8.GetBytes(sendStr);
            try
            {
                IPAddress ExternalDataCentreService_IP = IPAddress.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_IP"]);
                int ExternalDataCentreService_Port1 = int.Parse(ConfigurationManager.AppSettings["ExternalDataCentreService_Port1"]);
                IPEndPoint ipe1 = new IPEndPoint(ExternalDataCentreService_IP, ExternalDataCentreService_Port1);
                Socket clientSocket1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                clientSocket1.Connect(ipe1);
                clientSocket1.Send(sendBytes);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("数据发送失败！");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }
    }
}
