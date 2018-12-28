using RCCP.Repository.Entities;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MailClient
{
    public partial class MailInfoForm : Form
    {
        private MailTable mailTable;
        private MailServerCommunicate mailServerCommunicate;
        public MailInfoForm(MailTable mailTable, MailServerCommunicate mailServerCommunicate)
        {
            InitializeComponent();
            this.mailTable = mailTable;
            this.mailServerCommunicate = mailServerCommunicate;
        }

        private void MailInfoForm_Load(object sender, EventArgs e)
        {
            textBoxX_Receiver.Text = mailTable.Receiver;
            textBoxX_Sender.Text = mailTable.Sender;
            textBoxX_SendTime.Text = mailTable.SendTime.ToString();
            textBoxX_MailTitle.Text = mailTable.MailTitle;
            textBoxX_MailFileName.Text = mailTable.MailFileName;
            textBoxX_MailContent.Text = mailTable.MailContent;
            if (string.IsNullOrEmpty(textBoxX_MailFileName.Text))
            {
                buttonX_DownLoadFile.Enabled = false;
                buttonX_FileBrowser.Enabled = false;
                buttonX_OpenFIle.Enabled = false;
                textBoxX_DownloadPath.Enabled = false;
            }

            mailServerCommunicate.DownloadHint+=DownloadHint;
        }

        private void DownloadHint(string msg)
        {
            if (labelX_DownloadHint.InvokeRequired)
            {
                this.Invoke(new Action<string>(DownloadHint), msg);
            }
            else
            {
                labelX_DownloadHint.Text = msg;
            }
        }

        private void DownloadEnd()
        {
            if (buttonX_Close.InvokeRequired)
            {
                this.Invoke(new Action(DownloadEnd));
            }
            else
            {
                buttonX_Close.Enabled = true;
            }
        }

        private void DisplayDownloadProgress(int currentValue)
        {
            if (progressBar1.InvokeRequired)
            {
                this.Invoke(new Action<int>(DisplayDownloadProgress), currentValue);
            }
            else
            {
                progressBar1.Value = currentValue;
            }
        }

        private void InitDownloadProgress(int maxValue)
        {
            if (progressBar1.InvokeRequired)
            {
                this.Invoke(new Action<int>(InitDownloadProgress), maxValue);
            }
            else
            {
                progressBar1.Maximum = maxValue;
            }
        }

        private void buttonX_Close_Click(object sender, EventArgs e)
        {
            //mailServerCommunicate.InitDownloadProgress -= InitDownloadProgress;
            //mailServerCommunicate.DisplayDownloadProgress -= DisplayDownloadProgress;
            this.Close();
        }

        private void buttonX_DownLoadFile_Click(object sender, EventArgs e)
        {
            labelX_DownloadHint.Text = string.Empty;
            try
            {
                if (!Directory.Exists(textBoxX_DownloadPath.Text))
                {
                    Directory.CreateDirectory(textBoxX_DownloadPath.Text);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            buttonX_Close.Enabled = false;
            mailServerCommunicate.DownloadMailFile(mailTable, Path.Combine(textBoxX_DownloadPath.Text, textBoxX_MailFileName.Text), false, 
                InitDownloadProgress, DisplayDownloadProgress, DownloadEnd);
        }

        string defaultPath = ""; 
        private void buttonX_FileBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            //打开的文件夹浏览对话框上的描述  
            dialog.Description = "下载内容保存位置";
            //是否显示对话框左下角 新建文件夹 按钮，默认为 true  
            dialog.ShowNewFolderButton = true;
            //首次defaultPath为空，按FolderBrowserDialog默认设置（即桌面）选择  
            if (defaultPath != "")
            {
                //设置此次默认目录为上一次选中目录  
                dialog.SelectedPath = defaultPath;
            }
            //按下确定选择的按钮  
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录  
                defaultPath = dialog.SelectedPath;
                textBoxX_DownloadPath.Text = dialog.SelectedPath;
            }
        }

        private void buttonX_OpenFIle_Click(object sender, EventArgs e)
        {
            labelX_DownloadHint.Text = string.Empty;
            try
            {
                if (!Directory.Exists(textBoxX_DownloadPath.Text))
                {
                    Directory.CreateDirectory(textBoxX_DownloadPath.Text);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            buttonX_Close.Enabled = false;
            mailServerCommunicate.DownloadMailFile(mailTable, Path.Combine(textBoxX_DownloadPath.Text, textBoxX_MailFileName.Text), true, 
                InitDownloadProgress, DisplayDownloadProgress, DownloadEnd);
        }
    }
}
