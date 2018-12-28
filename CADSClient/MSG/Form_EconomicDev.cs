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
    public partial class Form_EconomicDev : Form
    {
        public CADS.Model.EconomicDevInfoList EconomicDevInfo = new CADS.Model.EconomicDevInfoList();
        public CADS.BLL.EconomicDevInfoList EconomicDev = new CADS.BLL.EconomicDevInfoList();

        public Form_EconomicDev()
        {
            InitializeComponent();
        }

        private void Form_EconomicDev_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = EconomicDev.GetList("").Tables[0];
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
                if (txt_Agriculture.Text.Trim() != "")
                {
                    sql += " and Agriculture='" + txt_Agriculture.Text + "'";
                }
                if (txt_Industry.Text.Trim() != "")
                {
                    sql += " and Industry='" + txt_Industry.Text + "'";
                }
                if (txt_Service.Text.Trim() != "")
                {
                    sql += " and Service='" + txt_Service.Text + "'";
                }
                DataTable dt = EconomicDev.GetList(sql).Tables[0];
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
        private bool OpreationDB(string Mess, CADS.Model.EconomicDevInfoList EconomicDevInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = EconomicDev.Add(EconomicDevInfo);
                }
                if (Mess == "编辑")
                {
                    Result = EconomicDev.Update(EconomicDevInfo);
                }
                if (Mess == "删除")
                {
                    Result = EconomicDev.Delete(EconomicDevInfo.ID);
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
            Form_EconomicDevAdd addOrEdit = new Form_EconomicDevAdd("add", null);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.EconomicDevInfo);
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
            CADS.Model.EconomicDevInfoList EconomicDevInfo = new CADS.Model.EconomicDevInfoList();
            EconomicDevInfo.ID = Convert.ToInt32(DataView.CurrentRow.Cells[0].Value);
            EconomicDevInfo.Agriculture = DataView.CurrentRow.Cells[1].Value.ToString();
            EconomicDevInfo.Industry = DataView.CurrentRow.Cells[2].Value.ToString();
            EconomicDevInfo.Service = DataView.CurrentRow.Cells[3].Value.ToString();
            Form_EconomicDevAdd addOrEdit = new Form_EconomicDevAdd("edit", EconomicDevInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.EconomicDevInfo);
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
            CADS.Model.EconomicDevInfoList EconomicDevInfo = new CADS.Model.EconomicDevInfoList();
            EconomicDevInfo.ID = Convert.ToInt32(DataView.CurrentRow.Cells[0].Value);
            OpreationDB("删除", EconomicDevInfo);
            RefreshDataGridView();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {

        }

        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "农业";
            dt.Columns[2].ColumnName = "工业";
            dt.Columns[3].ColumnName = "服务业";
        }
    }
}
