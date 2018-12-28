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
    public partial class ImgRecForm : Form
    {
        List<ImgRec> imgRecList = new List<ImgRec>();
        public ImgRecForm()
        {
            InitializeComponent();
        }

        private void ImgRecForm_Load(object sender, EventArgs e)
        {
            RefreshVideo();
        }

        private void RefreshVideo()
        {
            ImgRecRepository repo = new ImgRecRepository();
            imgRecList = repo.GetList();
            dataGridView_ImgInfo.DataSource = imgRecList;
        }

        private void buttonX_Add_Click(object sender, EventArgs e)
        {
            ImgRecAddAndEditForm imgRecAddAndEditForm = new ImgRecAddAndEditForm("Add", null);
            if (imgRecAddAndEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshVideo();
            }
        }

        private void buttonX_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_ImgInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_ImgInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var ImgRec = imgRecList.Find(_ => _.ID == ID);
            if (ImgRec == null)
            {
                MessageBox.Show("数据错误");
                return;
            }
            ImgRecAddAndEditForm imgRecAddAndEditForm = new ImgRecAddAndEditForm("Edit", ImgRec);
            if (imgRecAddAndEditForm.ShowDialog() == DialogResult.OK)
            {
                RefreshVideo();
            }
        }

        private void buttonX_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_ImgInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_ImgInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var ImgRec = imgRecList.Find(_ => _.ID == ID);
            if (ImgRec == null)
            {
                MessageBox.Show("数据错误");
                return;
            }

            try
            {
                ImgRecRepository repo = new ImgRecRepository();
                repo.Delete(ID);
                RefreshVideo();
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
                searchCondition.Append(" and RecTime>@RecTimeStart");
            }
            if (!dateTimeInput_TimeEnd.IsEmpty)
            {
                searchCondition.Append(" and RecTime<@RecTimeEnd");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_Location.Text))
            {
                searchCondition.Append(" and RecLocation like @RecLocation");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_Src.Text))
            {
                searchCondition.Append(" and RecSrc like @RecSrc");
            }
            if (!string.IsNullOrWhiteSpace(textBoxX_EventType.Text))
            {
                searchCondition.Append(" and EventType like @EventType");
            }

            ImgRecRepository repo = new ImgRecRepository();
            imgRecList = repo.GetListWithCondition(searchCondition.ToString(), new
            {
                RecTimeStart = dateTimeInput_TimeStart.Value,
                RecTimeEnd = dateTimeInput_TimeEnd.Value,
                RecLocation = "%" + textBoxX_Location.Text + "%",
                RecSrc = "%" + textBoxX_Src.Text + "%",
                EventType = "%" + textBoxX_EventType.Text + "%"
            });
            dataGridView_ImgInfo.DataSource = imgRecList;
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

        private void dataGridView_ImgInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            long ID = (long)dataGridView_ImgInfo.Rows[e.RowIndex].Cells[0].Value;
            var imgRec = imgRecList.Find(_ => _.ID == ID);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(imgRec.ImgRecPath);
            process.Start();
        }

        private void buttonX_GenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("图片报表", dataGridView_ImgInfo);
        }
    }
}
