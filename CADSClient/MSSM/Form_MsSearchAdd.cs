using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSSM
{
    public partial class Form_MsSearchAdd : Form
    {
        string operType = string.Empty;
        public CADS.Model.MessManageInfoList MessManageInfo = new CADS.Model.MessManageInfoList();
        public CADS.BLL.MessManageInfoList MessManage = new CADS.BLL.MessManageInfoList();

        public Form_MsSearchAdd(string operType, CADS.Model.MessManageInfoList MessManageInfo)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType == "add")
            {
                Title_Label.Text = "文电管理添加";
            }
            else
            {
                Title_Label.Text = "文电管理修改";
                this.MessManageInfo = MessManageInfo;
            }
        }

        private void Form_MsSearchAdd_Load(object sender, EventArgs e)
        {
            if (MessManageInfo != null)
            {
                txt_MessID.Text = MessManageInfo.MessID;
                txt_Receiver.Text = MessManageInfo.Receiver;
                txt_ReceiveOrg.Text = MessManageInfo.ReceiveOrg;
                cbx_IsHandle.Text = MessManageInfo.IsHandle;
                txt_MessTitle.Text = MessManageInfo.MessTitle;
                txt_MessContent.Text = MessManageInfo.MessContent;
                txt_Attachment.Text = MessManageInfo.Attachment;
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (!CheckInput())
                return;
            MessManageInfo.MessID = txt_MessID.Text;
            MessManageInfo.Receiver = txt_Receiver.Text;
            MessManageInfo.ReceiveOrg = txt_ReceiveOrg.Text;
            MessManageInfo.MessType = "发送";
            MessManageInfo.IsHandle = cbx_IsHandle.Text;
            MessManageInfo.MessTitle = txt_MessTitle.Text;
            MessManageInfo.MessContent = txt_MessContent.Text;
            MessManageInfo.Attachment = txt_Attachment.Text;

            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }

        private void btnAttachmentInput_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "选择附件";
                ofd.ShowDialog();
                ofd.Multiselect = false;
                txt_Attachment.Text = ofd.FileName;
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {

            if (txt_MessID.Text.Trim() == "")
            {
                MessageBox.Show("请填写文电编号！");
                return false;
            }
            if (operType == "add" && !CheckIDIsrepeat())
            {
                return false;
            }
            if (txt_Receiver.Text.Trim() == "")
            {
                MessageBox.Show("请填写接收人！");
                return false;
            }
            return true;
        }

        private bool CheckIDIsrepeat()
        {
            string sql = string.Empty;
            sql += " MessID ='" + txt_MessID.Text.Trim() + "'";
            try
            {
                DataTable dt = MessManage.GetList(sql).Tables[0];
                if (dt.Rows.Count != 0)
                {
                    MessageBox.Show("文电编号重复,请重新录入！");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            if (ctrlTop.GetType() == typeof(WindowsFormsControlLibrary1.BunifuCustomTextbox))
            {
                ctrlTop.Text = "";
            }
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用  
                }
            }
        }
    }
}
