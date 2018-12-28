using MyTool;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MSG
{
    public partial class Form_NationSociety : Form
    {
        public CADS.Model.NationalSocialInfoList nationalSocialInfo = new CADS.Model.NationalSocialInfoList();
        public CADS.BLL.NationalSocialInfoList nationalSocial = new CADS.BLL.NationalSocialInfoList();

        public Form_NationSociety()
        {
            InitializeComponent();
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = nationalSocial.GetList("").Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "民族编号";
            dt.Columns[2].ColumnName = "民族名称";
            dt.Columns[3].ColumnName = "宗教";
            dt.Columns[4].ColumnName = "习惯";
            dt.Columns[5].ColumnName = "社会团体";
            dt.Columns[6].ColumnName = "描述";
        }

        private void Form_NationSociety_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " 1=1 ";
                if (txt_NationID.Text.Trim() != "")
                {
                    sql += " and NationID='" + txt_NationID.Text + "'";
                }
                if (txt_NationName.Text.Trim() != "")
                {
                    sql += " and NationName='" + txt_NationName.Text + "'";
                }
                DataTable dt = nationalSocial.GetList(sql).Tables[0];
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
        private bool OpreationDB(string Mess, CADS.Model.NationalSocialInfoList nationalSocialInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = nationalSocial.Add(nationalSocialInfo);
                }
                if (Mess == "编辑")
                {
                    Result = nationalSocial.Update(nationalSocialInfo);
                }
                if (Mess == "删除")
                {
                    Result = nationalSocial.Delete(nationalSocialInfo.NationID);
                }
                if (Result == true)
                {
                    MessageBox.Show("预案信息" + Mess + "成功");
                    return true;
                }
                else
                {
                    MessageBox.Show("预案信息" + Mess + "失败，请稍后再试！");
                    return false;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("预案信息" + Mess + "失败:" + e.Message);
                return false;
            }


        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Form_NationSocietyAdd addOrEdit = new Form_NationSocietyAdd("add", null);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.nationalSocialInfo);
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
            CADS.Model.NationalSocialInfoList nationalSocialInfo = new CADS.Model.NationalSocialInfoList();
            nationalSocialInfo.ID = Convert.ToInt32(DataView.CurrentRow.Cells[0].Value);
            nationalSocialInfo.NationID = DataView.CurrentRow.Cells[1].Value.ToString();
            nationalSocialInfo.NationName = DataView.CurrentRow.Cells[2].Value.ToString();
            nationalSocialInfo.Religion = DataView.CurrentRow.Cells[3].Value.ToString();
            nationalSocialInfo.Habit = DataView.CurrentRow.Cells[4].Value.ToString();
            nationalSocialInfo.SocialGroup = DataView.CurrentRow.Cells[5].Value.ToString();
            nationalSocialInfo.Description = DataView.CurrentRow.Cells[6].Value.ToString();
            Form_NationSocietyAdd addOrEdit = new Form_NationSocietyAdd("edit", nationalSocialInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.nationalSocialInfo);
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
            CADS.Model.NationalSocialInfoList nationalSocialInfo = new CADS.Model.NationalSocialInfoList();
            nationalSocialInfo.NationID = DataView.CurrentRow.Cells[1].Value.ToString();
            OpreationDB("删除", nationalSocialInfo);
            RefreshDataGridView();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(DataView);
        }
    }
}
