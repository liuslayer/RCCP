using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class MailMainForm : Form
    {
        private string localIP;
        private string userName;
        private string serverIP;
        private int serverPort = 0;
        private MailServerCommunicate mailServerCommunicate;
        private List<MailUser> mailUserList = new List<MailUser>();//邮件用户列表
        private List<MailUser> ReceiverList = new List<MailUser>();//收件人列表
        private List<MailTable> mailRecordsReceived = new List<MailTable>();
        private List<MailTable> mailRecordsSent = new List<MailTable>();
        //private DataTable dtReceived;
        //private DataTable dtSent;

        public MailMainForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            InitControl();
        }

        private void InitControl()
        {
            checkedListBox_Contact.DisplayMember = "DisplayMember";
            checkedListBox_Contact.ValueMember = "ValueMember";


            DataTable dtReceived = new DataTable();
            dtReceived.Columns.Add("全选", typeof(bool));
            dtReceived.Columns.Add("MailID", typeof(string));
            dtReceived.Columns.Add("状态", typeof(string));
            dtReceived.Columns.Add("发送人", typeof(string));
            dtReceived.Columns.Add("主题", typeof(string));
            dtReceived.Columns.Add("时间", typeof(string));
            dataGridView_Received.DataSource = dtReceived;
            dataGridView_Received.Columns[1].Visible = false;
            dataGridView_Received.Columns[0].ReadOnly = false;

            DataTable dtSent = new DataTable();
            dtSent.Columns.Add("全选", typeof(bool));
            dtSent.Columns.Add("MailID", typeof(string));
            dtSent.Columns.Add("状态", typeof(string));
            dtSent.Columns.Add("收件人", typeof(string));
            dtSent.Columns.Add("主题", typeof(string));
            dtSent.Columns.Add("时间", typeof(string));
            dataGridView_Sent.DataSource = dtSent;
            dataGridView_Sent.Columns[1].Visible = false;
            dataGridView_Sent.Columns[0].ReadOnly = false;

            sideNav1.SelectedItem = sideNavItem_Write;
        }

        private void MailMainForm_Load(object sender, EventArgs e)
        {
            LoadConfiguration();
            mailServerCommunicate = new MailServerCommunicate(serverIP, serverPort, localIP);

            mailServerCommunicate.MsgHint += MsgHint;
            mailServerCommunicate.DisConnect += DisConnect;
            mailServerCommunicate.InitSendProgress += InitProgress;
            mailServerCommunicate.DisplayProgress += DisplayProgress;
            mailServerCommunicate.Connected += Connected;
            mailServerCommunicate.MailUsersResponse += MailUsersResponse;
            mailServerCommunicate.UpdateMailUsers += UpdateMailUsers;
            mailServerCommunicate.MailRecordsResponse += MailRecordsResponse;
            mailServerCommunicate.SocketCreateConnect();
        }

        private void UpdateMailUsers(MailUser mailUser)
        {
            MailUser tempMailUser = mailUserList.Find(_ => _.MailUserID == mailUser.MailUserID);
            if (tempMailUser == null)
            {
                mailUserList.Add(mailUser);
                checkedListBox_Contact.Items.Add(new ListItem { DisplayMember = string.Format("{0}<{1}>", mailUser.UserName, mailUser.UserIP), ValueMember = mailUser.MailUserID.ToString() });
            }
            else
            {
                tempMailUser.IsOnline = mailUser.IsOnline;
                tempMailUser.UserName = mailUser.UserName;
                for (int i = 0; i < checkedListBox_Contact.Items.Count; i++)
                {
                    var item = checkedListBox_Contact.Items[i] as ListItem;
                    if (item.ValueMember.Equals(tempMailUser.MailUserID.ToString()))
                    {
                        item.DisplayMember = string.Format("{0}<{1}>", mailUser.UserName, mailUser.UserIP);
                    }
                }
            }
            checkedListBox_Contact.Refresh();
        }

        private void LoadConfiguration()
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "Config.ini");
                if (!File.Exists(filePath))
                {
                    //File.Create(filePath);
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine("[Settings]");
                        sw.WriteLine("LocalIP=");
                        sw.WriteLine("UserName=");
                        sw.WriteLine("ServerIP=");
                        sw.WriteLine("ServerPort=");
                    }
                }
                AccessIni accessIni = new AccessIni();
                localIP = accessIni.ReadIni("Settings", "LocalIP", "", filePath);
                userName = accessIni.ReadIni("Settings", "UserName", "", filePath);
                serverIP = accessIni.ReadIni("Settings", "ServerIP", "", filePath);
                int.TryParse(accessIni.ReadIni("Settings", "ServerPort", "0", filePath), out serverPort);
                if (!ValidData(localIP, userName, serverIP, serverPort.ToString()))
                {
                    MessageBox.Show("文电管理尚未正确配置数据，请前往“设置”菜单进行设置！");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool ValidData(string localIP, string userName, string serverIP, string serverPort)
        {
            IPAddress address;
            int port = 0;
            if (!IPAddress.TryParse(localIP, out address))
            {
                //MessageBox.Show("本地IP地址格式不正确");
                return false;
            }
            if (string.IsNullOrWhiteSpace(userName))
            {
                //MessageBox.Show("用户名不能为空或只包含空格");
                return false;
            }
            if (!IPAddress.TryParse(serverIP, out address))
            {
                //MessageBox.Show("文电服务器IP地址格式不正确");
                return false;
            }
            if (!int.TryParse(serverPort, out port))
            {
                //MessageBox.Show("文电服务器端口号必须为数字");
                return false;
            }
            return true;
        }

        private void DisplayProgress(int currentValue)
        {
            progressBar1.Value = currentValue;
        }

        private void InitProgress(int maxValue)
        {
            progressBar1.Maximum = maxValue;
        }

        delegate void MailRecordsResponseDel(MailTableAssemble mailTableAssemble);
        private void MailRecordsResponse(MailTableAssemble mailTableAssemble)
        {
            if (this.dataGridView_Received.InvokeRequired)
            {
                MailRecordsResponseDel del = new
                 MailRecordsResponseDel(MailRecordsResponse);
                this.Invoke(del, mailTableAssemble);
            }
            else
            {
                if (mailTableAssemble.MailType == "receive")
                {
                    mailRecordsReceived.Clear();
                    DataTable dt = (DataTable)dataGridView_Received.DataSource;
                    if (dt.Rows.Count > 0)
                    {
                        dt.Rows.Clear();
                    }

                    myPageControl_Received.PageIndex = mailTableAssemble.PageNumber;
                    myPageControl_Received.PageRecordNumber = mailTableAssemble.rowsPerPage;
                    myPageControl_Received.PageRecordCount = mailTableAssemble.MailCount;

                    foreach (var item in mailTableAssemble.MailTableList)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = false;
                        row[1] = item.MailID;
                        row[2] = item.IsRead ? "已读" : "未读";
                        row[3] = item.Receiver;
                        row[4] = item.MailTitle;
                        row[5] = item.SendTime;
                        dt.Rows.Add(row);
                        Thread.Sleep(10);
                    }
                    dataGridView_Received.DataSource = dt;
                    mailRecordsReceived.AddRange(mailTableAssemble.MailTableList);
                }
                else
                {
                    mailRecordsSent.Clear();
                    DataTable dt = (DataTable)dataGridView_Sent.DataSource;
                    dt.Rows.Clear();

                    myPageControl_Sent.PageIndex = mailTableAssemble.PageNumber;
                    myPageControl_Sent.PageRecordNumber = mailTableAssemble.rowsPerPage;
                    myPageControl_Sent.PageRecordCount = mailTableAssemble.MailCount;
                    foreach (var item in mailTableAssemble.MailTableList)
                    {
                        DataRow row = dt.NewRow();
                        row[0] = false;
                        row[1] = item.MailID;
                        row[2] = item.IsRead ? "已读" : "未读";
                        row[3] = item.Receiver;
                        row[4] = item.MailTitle;
                        row[5] = item.SendTime;
                        dt.Rows.Add(row);
                    }
                    dataGridView_Sent.DataSource = dt;
                    mailRecordsSent.AddRange(mailTableAssemble.MailTableList);
                }
            }           
        }

        private void MailUsersResponse(List<MailUser> mailUserList)
        {
            this.mailUserList = mailUserList;

            var mailUserItems = mailUserList.Where(_ => _.UserIP != localIP).Select(_ =>
            {
                return new ListItem { DisplayMember = string.Format("{0}<{1}>", _.UserName, _.UserIP), ValueMember = _.MailUserID.ToString() };

            });
            foreach (var item in mailUserItems)
            {
                checkedListBox_Contact.Items.Add(item);
            }
        }

        private void Connected()
        {
            //MessageBox.Show("已连接");
            labelX_Status.Text = "上线";
            string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailUserLoginRequest.ToString(), localIP, userName);
            mailServerCommunicate.SendMsgToServer(sendMsg);
        }

        private void DisConnect()
        {
            labelX_Status.Text = "下线";
            checkedListBox_Contact.Items.Clear();
        }

        private void MsgHint(string msg)
        {
            labelX_Hint.Text = msg;
        }

        private void checkedListBox_Contact_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListItem item = checkedListBox_Contact.SelectedItem as ListItem;
            if (item == null)
                return;
            MailUser mailUser = mailUserList.Find(_ => _.MailUserID.ToString().Equals(item.ValueMember));
            if (e.NewValue == CheckState.Checked)
            {
                ReceiverList.Add(mailUser);
            }
            else
            {
                ReceiverList.Remove(mailUser);
            }
            DisplayReceivers();
        }

        private void DisplayReceivers()
        {
            textBoxX_Receiver.Clear();
            var mailUserItems = ReceiverList.Select(_ =>
            {
                return string.Format("{0}<{1}>;", _.UserName, _.UserIP);

            });
            foreach (var item in mailUserItems)
            {
                textBoxX_Receiver.Text += item;
            }
        }

        private void buttonX_AddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "请选择要发送的文件";
            ofd.ShowDialog();
            string filePath = ofd.FileName;
            if (filePath == "")
            {
                return;
            }
            textBoxX_FileName.Text = filePath;
        }

        private void buttonX_ClearFile_Click(object sender, EventArgs e)
        {
            textBoxX_FileName.Clear();
        }

        private void buttonX_Send_Click(object sender, EventArgs e)
        {
            MailTable mailTable = new MailTable();
            if (ReceiverList.Count <= 0)
            {
                MessageBox.Show("请选择接收人");
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxX_Title.Text))
            {
                MessageBox.Show("请添加主题");
                return;
            }
            buttonX_Send.Enabled = false;
            buttonX_Cancel.Enabled = false;
            if (ReceiverList.Count == 1)
            {
                mailTable.ReceiverIP = ReceiverList[0].UserIP;
                mailTable.Receiver = ReceiverList[0].UserName;
            }
            foreach (var item in ReceiverList)
            {
                mailTable.ReceiverDic = new Dictionary<string, string>();
                mailTable.ReceiverDic.Add(item.UserIP, item.UserName);
            }
            mailTable.Sender = userName;
            mailTable.SenderIP = localIP;
            mailTable.SendTime = DateTime.Now;
            mailTable.MailTitle = textBoxX_Title.Text;
            mailTable.MailFileName = Path.GetFileName(textBoxX_FileName.Text);
            mailTable.MailContent = textBoxX_MailContent.Text;

            if (mailServerCommunicate.SendMail(mailTable, textBoxX_FileName.Text))
            {
                MessageBox.Show("已发送");
            }
            else
            {
                MessageBox.Show("发送失败");
            }
            
            buttonX_Send.Enabled = true;
            buttonX_Cancel.Enabled = true;
            ClearMailSendControl();
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            ClearMailSendControl();
        }

        private void ClearMailSendControl()
        {
            for (int i = 0; i < checkedListBox_Contact.Items.Count; i++)
                checkedListBox_Contact.SetItemChecked(i, false);
            textBoxX_Title.Clear();
            textBoxX_FileName.Clear();
            textBoxX_MailContent.Clear();
            progressBar1.Value = 0;
        }

        private void myPageControl_Received_OnPageChanged(object sender, EventArgs e)
        {
            myPageControl_Received.PageIndex = myPageControl_Received.PageIndex <= 0 ? 1 : myPageControl_Received.PageIndex;
            string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "receive", myPageControl_Received.PageIndex.ToString(), myPageControl_Received.PageRecordNumber.ToString());
            mailServerCommunicate.SendMsgToServer(sendMsg);
            Thread.Sleep(100);
        }

        private void myPageControl_Sent_OnPageChanged(object sender, EventArgs e)
        {
            myPageControl_Sent.PageIndex = myPageControl_Sent.PageIndex <= 0 ? 1 : myPageControl_Sent.PageIndex;
            string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.MailRecordsRequest.ToString(), localIP, "send", myPageControl_Sent.PageIndex.ToString(), myPageControl_Sent.PageRecordNumber.ToString());
            mailServerCommunicate.SendMsgToServer(sendMsg);
            Thread.Sleep(100);
        }

        private void dataGridView_Received_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            string mailID = dataGridView_Received.Rows[e.RowIndex].Cells[1].Value.ToString();

            MailTable seletedMail = mailRecordsReceived.Find(_ => _.MailID.ToString().Equals(mailID));
            if (seletedMail == null)
                return;
            //请求服务器更新邮件状态
            if (!seletedMail.IsRead)
            {
                Task.Factory.StartNew(() =>
                {
                    string sendMsg = CommonUtils.GetCommand(MailServerCommunicate.MailServerCommand.UpdateMailStatusRequest.ToString(), localIP, mailID);
                    mailServerCommunicate.SendMsgToServer(sendMsg);
                });
            }
            seletedMail.IsRead = true;

            MailInfoForm MailInfoForm = new MailInfoForm(seletedMail, mailServerCommunicate);
            MailInfoForm.StartPosition = FormStartPosition.CenterParent;
            MailInfoForm.ShowDialog();

            DataTable dt = (DataTable)dataGridView_Received.DataSource;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr[1].Equals(mailID))
                {
                    dr[2] = "已读";
                    //dataGridView_Received.DataSource = dtReceived;
                    break;
                }
            }
            dataGridView_Received.DataSource = dt;
        }

        private void dataGridView_Received_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != 0)
                return;
            if (dataGridView_Received.Columns[0].HeaderText.Equals("全选"))
            {
                dataGridView_Received.Columns[0].HeaderText = "取消全选";
                for (int i = 0; i < dataGridView_Received.Rows.Count; i++)
                {
                    dataGridView_Received.Rows[i].Cells[0].Value = true;
                }
            }
            else
            {
                dataGridView_Received.Columns[0].HeaderText = "全选";
                for (int i = 0; i < dataGridView_Received.Rows.Count; i++)
                {
                    dataGridView_Received.Rows[i].Cells[0].Value = false;
                }
            }
        }

        private void sideNavItem_Setting_Click(object sender, EventArgs e)
        {
            SettingForm sf = new SettingForm();
            sf.StartPosition = FormStartPosition.CenterParent;
            sf.ShowDialog();
        }

        private void textBoxX_Title_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && textBoxX_Title.Text.Length == 25)
            {
                e.Handled = true;
                MessageBox.Show("主题信息不得超过25个字符");
            }
        }
    }

    public class ListItem
    {
        public string DisplayMember { get; set; }
        public string ValueMember { get; set; }
    }
}
