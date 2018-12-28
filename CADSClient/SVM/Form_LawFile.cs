using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataInterfaceModule;
using BaseDataClass;
using System.Diagnostics;
using MyTool;

namespace SVM
{
    public partial class Form_LawFile : Form
    {
        List<string> _infoList = new List<string>();//用来存储当前选中单元格的信息
        CADS.BLL.LawsFileInfo lawsFile = new CADS.BLL.LawsFileInfo();
        public Form_LawFile()
        {
            InitializeComponent();
        }


        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_FileLayer_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btn_DeleteFile_Click(object sender, EventArgs e)
        {
            if (dgv_LawsFileInfo.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            if (MessageBox.Show("确定要删除该行数据？", null, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            CADS.Model.LawsFileInfo lawsFileInfo = new CADS.Model.LawsFileInfo();
            lawsFileInfo.ID = Convert.ToInt32(dgv_LawsFileInfo.CurrentRow.Cells[0].Value);
            lawsFileInfo.FileName = dgv_LawsFileInfo.CurrentRow.Cells[1].Value.ToString();
            lawsFileInfo.FileType = dgv_LawsFileInfo.CurrentRow.Cells[2].Value.ToString();
            lawsFileInfo.IssueTime = dgv_LawsFileInfo.CurrentRow.Cells[3].Value.ToString();
            lawsFileInfo.IssueOrganization = dgv_LawsFileInfo.CurrentRow.Cells[4].Value.ToString();
            lawsFileInfo.IssueVersion = dgv_LawsFileInfo.CurrentRow.Cells[5].Value.ToString();
            lawsFileInfo.FilePath = dgv_LawsFileInfo.CurrentRow.Cells[6].Value.ToString();
            lawsFileInfo.Descrpition = dgv_LawsFileInfo.CurrentRow.Cells[7].Value.ToString();
            OpreationDB("删除", lawsFileInfo);
            RefreshDataGridView();
        }

        /// <summary>
        /// 获取选中的单元格的数据信息
        /// </summary>
        private void GetDataGridViewValueSelect()
        {
            _infoList.Clear();
            if (dgv_LawsFileInfo.SelectedRows.Count > 0)
            {
                int RowsLine = dgv_LawsFileInfo.CurrentRow.Index;
                for (int i = 0; i < dgv_LawsFileInfo.Columns.Count; i++)
                {
                    _infoList.Add(dgv_LawsFileInfo.Rows[RowsLine].Cells[i].Value.ToString());
                }

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                GetDataGridViewValueSelect();
            }
            
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (dgv_LawsFileInfo.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            string path = dgv_LawsFileInfo.CurrentRow.Cells[6].Value.ToString();
            if (!File.Exists(path))
            {
                MessageBox.Show("未找到法规文件！");
                return;
            }
            Process.Start(path);
        }

        private void btn_AddFile_Click(object sender, EventArgs e)
        {
            Form_LawFileAdd addOrEdit = new Form_LawFileAdd("add");
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.lawsFileInfo);
                RefreshDataGridView();
            }
        }

        private void btn_DutyEdit_Click(object sender, EventArgs e)
        {
            if (dgv_LawsFileInfo.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            CADS.Model.LawsFileInfo lawsFileInfo = new CADS.Model.LawsFileInfo();
            lawsFileInfo.ID = Convert.ToInt32(dgv_LawsFileInfo.CurrentRow.Cells[0].Value);
            lawsFileInfo.FileName = dgv_LawsFileInfo.CurrentRow.Cells[1].Value.ToString();
            lawsFileInfo.FileType = dgv_LawsFileInfo.CurrentRow.Cells[2].Value.ToString();
            lawsFileInfo.IssueTime = dgv_LawsFileInfo.CurrentRow.Cells[3].Value.ToString();
            lawsFileInfo.IssueOrganization = dgv_LawsFileInfo.CurrentRow.Cells[4].Value.ToString();
            lawsFileInfo.IssueVersion = dgv_LawsFileInfo.CurrentRow.Cells[5].Value.ToString();
            lawsFileInfo.FilePath = dgv_LawsFileInfo.CurrentRow.Cells[6].Value.ToString();
            lawsFileInfo.Descrpition = dgv_LawsFileInfo.CurrentRow.Cells[7].Value.ToString();
            Form_LawFileAdd addOrEdit = new Form_LawFileAdd("edit", lawsFileInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.lawsFileInfo);
                RefreshDataGridView();
            }
        }

        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private bool OpreationDB(string Mess, CADS.Model.LawsFileInfo lawsFileInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = lawsFile.Add(lawsFileInfo);
                }
                if (Mess == "编辑")
                {
                    Result = lawsFile.Update(lawsFileInfo);
                }
                if (Mess == "删除")
                {
                    Result = lawsFile.Delete(lawsFileInfo.ID);
                }
                if (Result == true)
                {
                    MessageBox.Show("文件法规信息" + Mess + "成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("文件法规信息" + Mess + "失败，请稍后再试！");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("文件法规信息" + Mess + "失败:" + e.Message);
                return false;
            }


        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = lawsFile.GetList("").Tables[0];
                dgv_LawsFileInfo.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " 1=1 ";
                if (!string.IsNullOrEmpty(tbx_FileName.Text.Trim()))
                {
                    sql += " and FileName='" + tbx_FileName.Text.Trim() + "'";
                }
                if (!string.IsNullOrEmpty(tbx_FileType.Text.Trim()))
                {
                    sql += " and FileType='" + tbx_FileType.Text.Trim() + "'";
                }
                DataTable dt = lawsFile.GetList(sql).Tables[0];
                dgv_LawsFileInfo.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "文件名";
            dt.Columns[2].ColumnName = "文件类型";
            dt.Columns[3].ColumnName = "发布时间";
            dt.Columns[4].ColumnName = "发布单位";
            dt.Columns[5].ColumnName = "发布版本号";
            dt.Columns[6].ColumnName = "文件路径";
            dt.Columns[7].ColumnName = "描述";
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(dgv_LawsFileInfo);
        }


    }
}
