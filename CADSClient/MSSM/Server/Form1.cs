using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            try
            {
                string ip = AccessIni.ReadIni("本地地址", "IP", "127.0.0.1", ".\\Config.ini");
                string port = AccessIni.ReadIni("本地地址", "PORT", "12300", ".\\Config.ini");
                Socket socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                socketWatch.Bind(new IPEndPoint(IPAddress.Parse(ip), int.Parse(port)));
                socketWatch.Listen(5);
                Thread th = new Thread(Listen);
                th.IsBackground = true;
                th.Start((object)socketWatch);
            }
            catch(Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        //Dictionary<string, Socket> dicSocket = new Dictionary<string, Socket>();
        Socket remoteSocket = null;
        void Listen(object o)
        {
            Socket sockWatch = o as Socket;
            while (true)
            {
                try
                {
                    remoteSocket = sockWatch.Accept();
                    //dicSocket.Add(remoteSocket.RemoteEndPoint.ToString(), remoteSocket);
                    //cboUsers.Items.Add(remoteSocket.RemoteEndPoint.ToString());
                    //ShowMsg(remoteSocket.RemoteEndPoint.ToString() + ":" + "连接成功");
                    string tmpName = remoteSocket.RemoteEndPoint.ToString().Split(':')[0] == AccessIni.ReadIni("本地地址", "IP", "127.0.0.1", ".\\Config.ini") ? "基层1" : "基层2";
                    ShowMsg(tmpName + ":" + "连接成功");
                    Thread th = new Thread(Receice);
                    th.IsBackground = true;
                    th.Start(remoteSocket);
                }
                catch
                { }
            }
        }

        private void Receice(object o)
        {
            remoteSocket = o as Socket;
            while (true)
            {
                try
                {
                    byte[] buffer = new byte[1024 * 1024 * 10];
                    int r = remoteSocket.Receive(buffer, 0, buffer.Length, SocketFlags.None);
                    //0字节代表信息类型：0-文字，1-文件
                    //1-4字节代表文件名长度
                    //接收长度-1-4-文件名长度=有效信息长度
                    if (r == 0)
                    {
                        //cboUsers.Items.Remove(remoteSocket.RemoteEndPoint.ToString());
                        //if (cboUsers.Text == remoteSocket.RemoteEndPoint.ToString())
                        //    cboUsers.Text = "";
                        break;
                    }
                    if (buffer[0] == 0)//文字
                    {
                        string str = Encoding.UTF8.GetString(buffer, 1, r - 1);
                        ShowMsg(remoteSocket.RemoteEndPoint.ToString() + ":" + str);
                    }
                    else if (buffer[0] == 1)//文件
                    {
                        byte[] byteFileNameLen = new byte[4];
                        Buffer.BlockCopy(buffer, 1, byteFileNameLen, 0, 4);
                        int fileNameLen = BitConverter.ToInt32(byteFileNameLen, 0);
                        byte[] bytefileName = new byte[fileNameLen];
                        Buffer.BlockCopy(buffer, 5, bytefileName, 0, fileNameLen);
                        string fileName = Encoding.Default.GetString(bytefileName);
                        byte[] byteFile = new byte[r - 5 - fileNameLen];
                        Buffer.BlockCopy(buffer, 5 + fileNameLen, byteFile, 0, byteFile.Length);

                        DialogResult result = MessageBox.Show("是否接受文件？", "", MessageBoxButtons.YesNo);
                        if (result != DialogResult.Yes)
                            return;

                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.InitialDirectory = @"D:\桌面";
                        sfd.Title = "请选择要保存的文件路径";
                        sfd.Filter = "所有文件|*.*";
                        sfd.FileName = fileName;
                        DialogResult saveResult = sfd.ShowDialog(this);
                        if (DialogResult.OK == saveResult)
                        {
                            string path = sfd.FileName;
                            using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
                            {
                                fsWrite.Write(byteFile, 0, byteFile.Length);
                            }
                            MessageBox.Show("保存成功");
                        }
                    }
                }
                catch(Exception ex)
                {
                    ShowMsg(ex.Message);
                    //cboUsers.Items.Remove(remoteSocket.RemoteEndPoint.ToString());
                    //if (cboUsers.Text == remoteSocket.RemoteEndPoint.ToString())
                    //    cboUsers.Text = "";
                    break;
                }
            }
        }


        void ShowMsg(string str)
        {
            txtLog.AppendText(str + "\r\n");
        }

        private void btnSendMsg_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(cboUsers.Text))
                //{
                //    ShowMsg("请先选择下发单位！");
                //    return;
                //}
                if (remoteSocket == null)
                    return;
                List<byte> listMsg = new List<byte>();
                listMsg.Add(0);
                string str = txtMsg.Text;
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                listMsg.AddRange(buffer);
                byte[] newBuffer = listMsg.ToArray();
                //dicSocket[cboUsers.Text].Send(newBuffer, 0, newBuffer.Length, SocketFlags.None);
                remoteSocket.Send(newBuffer, 0, newBuffer.Length, SocketFlags.None);
            }
            catch(Exception ex)
            {
                ShowMsg(ex.Message);
            }
            txtMsg.Text = "";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\桌面";
            ofd.Title = "请选择要发送的文件";
            ofd.Filter = "所有文件|*.*";
            ofd.ShowDialog();

            txtPath.Text = ofd.FileName;
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            try
            {
                //if (string.IsNullOrEmpty(cboUsers.Text))
                //{
                //    ShowMsg("请先选择下发单位！");
                //    return;
                //}
                if (remoteSocket == null)
                    return;
                List<byte> listFile = new List<byte>();
                listFile.Add(1);

                string path = txtPath.Text;
                FileInfo fileInfo = new FileInfo(path);
                string fileName = fileInfo.Name;
                byte[] byteFileName = Encoding.Default.GetBytes(fileName);
                byte[] byteFileNameLen = new byte[4];
                byteFileNameLen = BitConverter.GetBytes(byteFileName.Length);
                listFile.AddRange(byteFileNameLen);
                listFile.AddRange(byteFileName);
                using (FileStream fsRead = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    byte[] buffer = new byte[1024 * 1024 * 10];
                    int r = fsRead.Read(buffer, 0, buffer.Length);
                    listFile.AddRange(buffer);
                    byte[] newBuffer=listFile.ToArray();
                    //dicSocket[cboUsers.Text].Send(newBuffer, 0, 5 + byteFileName.Length + r, SocketFlags.None);
                    remoteSocket.Send(newBuffer, 0, 5 + byteFileName.Length + r, SocketFlags.None);
                }
            }
            catch(Exception ex)
            {
                ShowMsg(ex.Message);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                checkBox1.Checked = true;
                checkBox2.Checked = true;
                checkBox3.Checked = true;
                checkBox4.Checked = true;
                checkBox5.Checked = true;
                checkBox6.Checked = true;
            }
            else if (checkBox7.Checked == false)
            {
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
        }
    }
}
