using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedManagement
{
    public partial class LawFileInfoAddAndEditForm : Form
    {
        string operType = string.Empty;
        LawFileInfo lawFileInfo;
        public LawFileInfoAddAndEditForm(string operType, LawFileInfo lawFileInfo)
        {
            InitializeComponent();
            this.operType = operType;
            if (operType.Equals("Edit"))
            {
                this.lawFileInfo = lawFileInfo;
                labelX_Name.Text = "编辑法律法规";
                textBoxX_Path.Text = lawFileInfo.LawFilePath;
                textBoxX_Name.Text = lawFileInfo.LawFileName;
                dateTimeInput_Time.Value = lawFileInfo.IssueTime;
                textBoxX_LawFileType.Text = lawFileInfo.LawFileType;
                textBoxX_IssueOrganization.Text = lawFileInfo.IssueOrganization;
                textBoxX_IssueVersion.Text = lawFileInfo.IssueVersion;
                textBoxX_Description.Text = lawFileInfo.Description;
            }
            else
            {
                labelX_Name.Text = "新增法律法规";
            }
        }

        private void LawFileInfoAddAndEditForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonX_SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "全部|*.*|docx|*.docx|doc|*.doc|pdf|*.pdf|xls|*.xls|pptx|*.pptx|ppt|*.ppt";
            ofd.ShowDialog();
            textBoxX_Path.Text = ofd.FileName;
            textBoxX_Name.Text = Path.GetFileNameWithoutExtension(ofd.FileName);
        }

        private void buttonX_Save_Click(object sender, EventArgs e)
        {
            LawFileInfoRepository repo = new LawFileInfoRepository();
            try
            {
                if (operType.Equals("Add"))
                {
                    LawFileInfo newLawFileInfo = new LawFileInfo();
                    newLawFileInfo.LawFilePath = textBoxX_Path.Text;
                    newLawFileInfo.LawFileName = textBoxX_Name.Text;
                    newLawFileInfo.IssueTime = dateTimeInput_Time.Value;
                    newLawFileInfo.LawFileType = textBoxX_LawFileType.Text;
                    newLawFileInfo.IssueOrganization = textBoxX_IssueOrganization.Text;
                    newLawFileInfo.IssueVersion = textBoxX_IssueVersion.Text;
                    newLawFileInfo.Description = textBoxX_Description.Text;
                    repo.Insert(newLawFileInfo);

                }
                else
                {
                    lawFileInfo.LawFilePath = textBoxX_Path.Text;
                    lawFileInfo.LawFileName = textBoxX_Name.Text;
                    lawFileInfo.IssueTime = dateTimeInput_Time.Value;
                    lawFileInfo.LawFileType = textBoxX_LawFileType.Text;
                    lawFileInfo.IssueOrganization = textBoxX_IssueOrganization.Text;
                    lawFileInfo.IssueVersion = textBoxX_IssueVersion.Text;
                    lawFileInfo.Description = textBoxX_Description.Text;
                    repo.Update(lawFileInfo);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonX_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
