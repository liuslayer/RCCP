using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyTool;

namespace SVM
{
    public partial class Form_Landmark : Form
    {
        CADS.BLL.LandmarkManageInfoList LandmarkManage = new CADS.BLL.LandmarkManageInfoList();
        public Form_Landmark()
        {
            InitializeComponent();
        }


        private void Form_Landmark_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void btn_LandmarkManage_Click(object sender, EventArgs e)
        {
            Form_LandmarkAdd form = new Form_LandmarkAdd();
            form.Show();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SearchText.Text.Trim()))
                return;
            try
            {
                string sql = " LandmarkName like '%" + SearchText.Text.Trim() + "%'";
                DataTable dt = LandmarkManage.GetList(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataView.DataSource = dt;
                    bindingColName(dt);
                }
                else
                {
                    MessageBox.Show("无匹配条件数据，请重新查询");
                }
            }
            catch
            { }
        }

        private void bindingColName(DataTable dt)
        {
            dt.Columns[1].ColumnName = "地标编号";
            dt.Columns[2].ColumnName = "单位名称";
            dt.Columns[3].ColumnName = "行政区划";
            dt.Columns[4].ColumnName = "重要地标名称";
            dt.Columns[5].ColumnName = "地标性质";
            dt.Columns[6].ColumnName = "单位";
            dt.Columns[7].ColumnName = "数量";
            dt.Columns[8].ColumnName = "相关说明";
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " 1=1 ";
                if (tbx_LandmarkID.Text.Trim() != "")
                {
                    sql += " and LandmarkID='" + tbx_LandmarkID.Text.Trim() + "'";
                }
                if (tbx_LandmarkName.Text.Trim() != "")
                {
                    sql += " and LandmarkName='" + tbx_LandmarkName.Text.Trim() + "'";
                }
                DataTable dt = LandmarkManage.GetList(sql).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    DataView.DataSource = dt;
                    bindingColName(dt);
                }
                else
                {
                    MessageBox.Show("无匹配数据，请重新更改查询条件！");
                }
            }
            catch
            {

            }
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = LandmarkManage.GetAllList().Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(this.DataView);
        }

    }
}
