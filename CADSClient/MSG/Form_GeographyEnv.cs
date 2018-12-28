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
    public partial class Form_GeographyEnv : Form
    {

        public CADS.Model.GeographyEnvInfoList geographyEnvInfo = new CADS.Model.GeographyEnvInfoList();
        public CADS.BLL.GeographyEnvInfoList geographyEnv = new CADS.BLL.GeographyEnvInfoList();
        public Form_GeographyEnv()
        {
            InitializeComponent();
        }

        private void Form_GeographyEnv_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = geographyEnv.GetList("").Tables[0];
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
                if (txt_ZoneID.Text.Trim() != "")
                {
                    sql += " and ZoneID='" + txt_ZoneID.Text + "'";
                }
                if (txt_ZoneScale.Text.Trim() != "")
                {
                    sql += " and ZoneScale='" + txt_ZoneScale.Text + "'";
                }
                DataTable dt = geographyEnv.GetList(sql).Tables[0];
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
        private bool OpreationDB(string Mess, CADS.Model.GeographyEnvInfoList geographyEnvInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = geographyEnv.Add(geographyEnvInfo);
                }
                if (Mess == "编辑")
                {
                    Result = geographyEnv.Update(geographyEnvInfo);
                }
                if (Mess == "删除")
                {
                    Result = geographyEnv.Delete(geographyEnvInfo.ZoneID);
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
            Form_GeographyEnvAdd addOrEdit = new Form_GeographyEnvAdd("add", null);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.geographyEnvInfo);
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
            CADS.Model.GeographyEnvInfoList geographyEnvInfo = new CADS.Model.GeographyEnvInfoList();
            geographyEnvInfo.ID = Convert.ToInt32(DataView.CurrentRow.Cells[0].Value);
            geographyEnvInfo.ZoneID = DataView.CurrentRow.Cells[1].Value.ToString();
            geographyEnvInfo.ZoneScale = DataView.CurrentRow.Cells[2].Value.ToString();
            geographyEnvInfo.GeographyEnv = DataView.CurrentRow.Cells[3].Value.ToString();
            geographyEnvInfo.RoadTransport = DataView.CurrentRow.Cells[4].Value.ToString();
            geographyEnvInfo.WaterSystem = DataView.CurrentRow.Cells[5].Value.ToString();
            geographyEnvInfo.Description = DataView.CurrentRow.Cells[6].Value.ToString();
            Form_GeographyEnvAdd addOrEdit = new Form_GeographyEnvAdd("edit", geographyEnvInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.geographyEnvInfo);
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
            CADS.Model.GeographyEnvInfoList geographyEnvInfo = new CADS.Model.GeographyEnvInfoList();
            geographyEnvInfo.ZoneID = DataView.CurrentRow.Cells[1].Value.ToString();
            OpreationDB("删除", geographyEnvInfo);
            RefreshDataGridView();
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(DataView);
        }

        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "战区编号";
            dt.Columns[2].ColumnName = "作战范围";
            dt.Columns[3].ColumnName = "地形环境";
            dt.Columns[4].ColumnName = "道路交通";
            dt.Columns[5].ColumnName = "水系";
            dt.Columns[6].ColumnName = "描述";
        }
    }
}
