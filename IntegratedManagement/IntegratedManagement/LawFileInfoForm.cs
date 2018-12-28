using DevComponents.DotNetBar.Controls;
using DevComponents.Editors.DateTimeAdv;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntegratedManagement
{
    public partial class LawFileInfoForm : Form
    {
        List<LawFileInfo> lawFileInfoList = new List<LawFileInfo>();
        public LawFileInfoForm()
        {
            InitializeComponent();
        }

        private void LawFileInfoForm_Load(object sender, EventArgs e)
        {
            RefreshFileInfo();
        }
        private void RefreshFileInfo()
        {
            LawFileInfoRepository repo = new LawFileInfoRepository();
            lawFileInfoList = repo.GetList();
            dataGridView_LawFileInfo.DataSource = lawFileInfoList;
        }

        private void buttonX_Add_Click(object sender, EventArgs e)
        {
            LawFileInfoAddAndEditForm lawFileInfoAddAndEditForm = new LawFileInfoAddAndEditForm("Add", null);
            if (lawFileInfoAddAndEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshFileInfo();
            }
        }

        private void buttonX_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_LawFileInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_LawFileInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var LawFileInfo = lawFileInfoList.Find(_ => _.ID == ID);
            if (LawFileInfo == null)
            {
                MessageBox.Show("数据错误");
                return;
            }
            LawFileInfoAddAndEditForm lawFileInfoAddAndEditForm = new LawFileInfoAddAndEditForm("Edit", LawFileInfo);
            if (lawFileInfoAddAndEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshFileInfo();
            }
        }

        private void buttonX_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_LawFileInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_LawFileInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var LawFileInfo = lawFileInfoList.Find(_ => _.ID == ID);
            if (LawFileInfo == null)
            {
                MessageBox.Show("数据错误");
                return;
            }

            try
            {
                LawFileInfoRepository repo = new LawFileInfoRepository();
                repo.Delete(ID);
                RefreshFileInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void buttonX_Search_Click(object sender, EventArgs e)
        {
            StringBuilder searchCondition = new StringBuilder(" where 1=1");

            if (!dateTimeInput_TimeStart.IsEmpty)
            {
                searchCondition.Append(" and IssueTime>@IssueTimeStart");
            }
            if (!dateTimeInput_TimeEnd.IsEmpty)
            {
                searchCondition.Append(" and IssueTime<@IssueTimeEnd");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_LawFileType.Text))
            {
                searchCondition.Append(" and LawFileType like @LawFileType");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_IssueOrganization.Text))
            {
                searchCondition.Append(" and IssueOrganization like @IssueOrganization");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_LawFileName.Text))
            {
                searchCondition.Append(" and LawFileName like @LawFileName");
            }

            LawFileInfoRepository repo = new LawFileInfoRepository();
            lawFileInfoList = repo.GetListWithCondition(searchCondition.ToString(), new
            {
                IssueTimeStart = dateTimeInput_TimeStart.Value,
                IssueTimeEnd = dateTimeInput_TimeEnd.Value,
                LawFileType = "%" + textBoxX_LawFileType.Text + "%",
                IssueOrganization = "%" + textBoxX_IssueOrganization.Text + "%",
                LawFileName = "%" + textBoxX_LawFileName.Text + "%"
            });
            dataGridView_LawFileInfo.DataSource = lawFileInfoList;
        }

        private void buttonX_Clear_Click(object sender, EventArgs e)
        {
            foreach (var item in panelEx_Search.Controls)
            {
                if (item is DateTimeInput)
                {
                    var dateTimeInput = item as DateTimeInput;
                    dateTimeInput.IsEmpty = true;
                }
                if (item is TextBoxX)
                {
                    var textBoxX = item as TextBoxX;
                    textBoxX.Clear();
                }
            }
        }

        private void dataGridView_LawFileInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            long ID = (long)dataGridView_LawFileInfo.Rows[e.RowIndex].Cells[0].Value;
            var lawFileInfo = lawFileInfoList.Find(_ => _.ID == ID);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(lawFileInfo.LawFilePath);
            process.Start();
        }

        private void buttonX_GenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("文件法规报表", dataGridView_LawFileInfo);
        }
    }
}
