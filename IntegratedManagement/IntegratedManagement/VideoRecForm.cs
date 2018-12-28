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
    public partial class VideoRecForm : Form
    {
        List<VideoRec> videoRecList = new List<VideoRec>();
        public VideoRecForm()
        {
            InitializeComponent();
        }

        private void VideoRecForm_Load(object sender, EventArgs e)
        {
            RefreshVideo();
        }

        private void RefreshVideo()
        {
            VideoRecRepository repo = new VideoRecRepository();
            videoRecList = repo.GetList();
            dataGridView_CameraInfo.DataSource = videoRecList;
        }

        private void buttonX_Add_Click(object sender, EventArgs e)
        {
            VideoRecAddAndEditForm videoForm = new VideoRecAddAndEditForm("Add", null);
            if (videoForm.ShowDialog() == DialogResult.OK)
            {
                RefreshVideo();
            }
        }

        private void buttonX_Edit_Click(object sender, EventArgs e)
        {
            if (dataGridView_CameraInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_CameraInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var videoRec = videoRecList.Find(_ => _.ID == ID);
            if (videoRec == null)
            {
                MessageBox.Show("数据错误");
                return;
            }
            VideoRecAddAndEditForm videoForm = new VideoRecAddAndEditForm("Edit", videoRec);
            if (videoForm.ShowDialog() == DialogResult.OK)
            {
                RefreshVideo();
            }
        }

        private void buttonX_Del_Click(object sender, EventArgs e)
        {
            if (dataGridView_CameraInfo.SelectedRows.Count <= 0)
            {
                MessageBox.Show("请先选中一行数据");
                return;
            }
            var row = dataGridView_CameraInfo.SelectedRows[0];
            long ID = (long)(row.Cells[0].Value);
            var videoRec = videoRecList.Find(_ => _.ID == ID);
            if (videoRec == null)
            {
                MessageBox.Show("数据错误");
                return;
            }

            if (DialogResult.Yes != MessageBox.Show("确定删除该行信息？","提示", MessageBoxButtons.YesNo))
                return;
            try
            {
                VideoRecRepository repo = new VideoRecRepository();
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

            VideoRecRepository repo = new VideoRecRepository();
            videoRecList = repo.GetListWithCondition(searchCondition.ToString(), new
            {
                RecTimeStart = dateTimeInput_TimeStart.Value,
                RecTimeEnd = dateTimeInput_TimeEnd.Value,
                RecLocation = "%" + textBoxX_Location.Text + "%",
                RecSrc = "%" + textBoxX_Src.Text + "%",
                EventType = "%" + textBoxX_EventType.Text + "%"
            });
            dataGridView_CameraInfo.DataSource = videoRecList;
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

        private void dataGridView_CameraInfo_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            long ID = (long)dataGridView_CameraInfo.Rows[e.RowIndex].Cells[0].Value;
            var videoRec = videoRecList.Find(_ => _.ID == ID);
            Process process = new Process();
            process.StartInfo = new ProcessStartInfo(videoRec.VideoRecPath);
            process.Start();
        }

        private void buttonX_GenerateExcel_Click(object sender, EventArgs e)
        {
            ExcelHelper.ExportExcels("录像报表", dataGridView_CameraInfo);
        }
    }
}
