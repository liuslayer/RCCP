using MyTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSSM
{
    public partial class Form_MsSearch : Form
    {
        public CADS.Model.MessManageInfoList MessManageInfo = new CADS.Model.MessManageInfoList();
        public CADS.BLL.MessManageInfoList MessManage = new CADS.BLL.MessManageInfoList();

        public Form_MsSearch()
        {
            InitializeComponent();
        }

        private void Form_MsSearch_Load(object sender, EventArgs e)
        {
            cbx_MessType.SelectedIndex = 0;
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = MessManage.GetList("").Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " 1=1 ";
                if (txt_MessID.Text.Trim() != "")
                {
                    sql += " and MessID='" + txt_MessID.Text.Trim() + "'";
                }
                if (txt_MessTitle.Text.Trim() != "")
                {
                    sql += " and MessTitle='" + txt_MessTitle.Text.Trim() + "'";
                }
                if (cbx_MessType.Text != "全部" && cbx_MessType.Text != "")
                {
                    sql += " and MessType='" + cbx_MessType.Text + "'";
                }
                DataTable dt = MessManage.GetList(sql).Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private bool OpreationDB(string Mess, CADS.Model.MessManageInfoList MessManageInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = MessManage.Add(MessManageInfo);
                }
                if (Mess == "编辑")
                {
                    Result = MessManage.Update(MessManageInfo);
                }
                if (Mess == "删除")
                {
                    Result = MessManage.Delete(MessManageInfo.MessID);
                }
                if (Result == true)
                {
                    MessageBox.Show("文电信息" + Mess + "成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("文电信息" + Mess + "失败，请稍后再试！");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("文电信息" + Mess + "失败:" + e.Message);
                return false;
            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form_MsSearchAdd addOrEdit = new Form_MsSearchAdd("add", null);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.MessManageInfo);
                RefreshDataGridView();
            }
        }

        private void btn_Edit_Click(object sender, EventArgs e)
        {
            if (DataView.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            CADS.Model.MessManageInfoList MessManageInfo = new CADS.Model.MessManageInfoList();
            MessManageInfo.ID = Convert.ToInt32(DataView.CurrentRow.Cells[0].Value);
            MessManageInfo.MessID = DataView.CurrentRow.Cells[1].Value.ToString();
            MessManageInfo.Receiver = DataView.CurrentRow.Cells[2].Value.ToString();
            MessManageInfo.ReceiveOrg = DataView.CurrentRow.Cells[3].Value.ToString();
            MessManageInfo.MessType = DataView.CurrentRow.Cells[4].Value.ToString();
            MessManageInfo.IsHandle = DataView.CurrentRow.Cells[5].Value.ToString();
            MessManageInfo.MessTitle = DataView.CurrentRow.Cells[6].Value.ToString();
            MessManageInfo.MessContent = DataView.CurrentRow.Cells[7].Value.ToString();
            MessManageInfo.Attachment = DataView.CurrentRow.Cells[8].Value.ToString();
            Form_MsSearchAdd addOrEdit = new Form_MsSearchAdd("edit", MessManageInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.MessManageInfo);
                RefreshDataGridView();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (DataView.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            if (MessageBox.Show("确定要删除该行数据？", null, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            CADS.Model.MessManageInfoList MessManageInfo = new CADS.Model.MessManageInfoList();
            MessManageInfo.MessID = DataView.CurrentRow.Cells[1].Value.ToString();
            OpreationDB("删除", MessManageInfo);
            RefreshDataGridView();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(DataView);
        }


        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "文电编号";
            dt.Columns[2].ColumnName = "接收人";
            dt.Columns[3].ColumnName = "接收单位";
            dt.Columns[4].ColumnName = "文电类型";
            dt.Columns[5].ColumnName = "是否已处理";
            dt.Columns[6].ColumnName = "文电标题";
            dt.Columns[7].ColumnName = "文电内容";
            dt.Columns[8].ColumnName = "附件";
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (DataView.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据");
                return;
            }
            string path = DataView.CurrentRow.Cells[8].Value.ToString();

            if (!File.Exists(path))
            {
                MessageBox.Show("未找到附件！");
                return;
            }
            Process.Start(path);
        }

        private void DataView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DataView.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据");
                return;
            }
            string path = DataView.CurrentRow.Cells[8].Value.ToString();

            if (!File.Exists(path))
            {
                MessageBox.Show("未找到附件！");
                return;
            }
            Process.Start(path);
        }
    }
}
