using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SVM
{
    public partial class Form_LawFileAdd : Form
    {

        private string editMark = "";//用于标记是否选中修改编辑对象
        private DataTable PlanResult = null;
        string Mark = "";
        public CADS.Model.LawsFileInfo lawsFileInfo = null;
        string operType = string.Empty;
        CADS.BLL.LawsFileInfo lawsFile = null;
        public Form_LawFileAdd(string operType, CADS.Model.LawsFileInfo lawsFileInfo)
        {
            InitializeComponent();
            if (operType == "add")
            {
                Title_Label.Text = "文件添加";
            }
            else
            {
                Title_Label.Text = "文件编辑";
            }
            this.lawsFileInfo = lawsFileInfo;
            this.operType = operType;
            lawsFile = new CADS.BLL.LawsFileInfo();
        }

        public Form_LawFileAdd(string operType)
            : this(operType, new CADS.Model.LawsFileInfo())
        {
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            lawsFileInfo.FileName = tbx_FileName.Text;
            lawsFileInfo.FileType = cbx_FileType.Text;
            lawsFileInfo.IssueTime = dtp_IssueTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            lawsFileInfo.IssueOrganization = tbx_IssueOrganization.Text;
            lawsFileInfo.IssueVersion = tbx_IssueVersion.Text;
            lawsFileInfo.FilePath = tbx_FilePath.Text;
            lawsFileInfo.Descrpition = tbx_Descrpition.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void Form_LawFileAdd_Load(object sender, EventArgs e)
        {
            if (lawsFileInfo != null)
            {
                tbx_FileName.Text = lawsFileInfo.FileName;
                cbx_FileType.Text = lawsFileInfo.FileType;
                dtp_IssueTime.Text = lawsFileInfo.IssueTime;
                tbx_IssueOrganization.Text = lawsFileInfo.IssueOrganization;
                tbx_IssueVersion.Text = lawsFileInfo.IssueVersion;
                tbx_FilePath.Text = lawsFileInfo.FilePath;
                tbx_Descrpition.Text = lawsFileInfo.Descrpition;
            }
        }

        private void btnFileInput_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "选择导入的模板";
            ofd.Filter = "所有文件|*.*";
            ofd.Multiselect = false;
            ofd.ShowDialog();
            tbx_FilePath.Text = ofd.FileName;
        }
    }
}
