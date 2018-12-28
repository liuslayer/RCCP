using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseDataClass;
using DataInterfaceModule;
using MyTool;

namespace SVM
{
    public partial class Form_AttendanceRecord : Form
    {
        List<string> _infoList = new List<string>();//用来存储当前选中单元格的信息
        CADS.BLL.AttendanceRecordInfoList attendanceRecordInfoList = null;
        public Form_AttendanceRecord()
        {
            InitializeComponent();
            TimePicker.Text = "";
            attendanceRecordInfoList = new CADS.BLL.AttendanceRecordInfoList();
        }

        private void RefreshDataGridView()
        {
            try
            {
                DataTable dt = attendanceRecordInfoList.GetList("").Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }
        }



        private void myPageControl1_OnPageChanged(object sender, EventArgs e)
        {
                btn_Ok_Click(sender, e);  
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = " 1=1 ";
                if (tbx_Name.Text.Trim() != "")
                {
                    sql += " and PersonName='" + tbx_Name.Text + "'";
                }
                if (TimePicker.Text != "")
                {
                    sql += " and TimeGo='" + TimePicker.Value.ToString("yyyy-MM-dd") + "'";
                }
                if (cbx_Isabsent.Text != "全部" && cbx_Isabsent.Text != "")
                {
                    sql += " and IsAbsent='" + cbx_Isabsent.Text + "'";
                }
                //DataSet ds = attendanceRecordInfoList.GetList(sql);
                DataTable dt = attendanceRecordInfoList.GetList(sql).Tables[0];
                DataView.DataSource = dt;
                bindingColName(dt);
            }
            catch
            {

            }

        }
        private void bindingColName(DataTable dt) 
        {
            dt.Columns[1].ColumnName = "值班员";
            dt.Columns[2].ColumnName = "值班编号";
            dt.Columns[3].ColumnName = "值班领导";
            dt.Columns[4].ColumnName = "值班起始时间";
            dt.Columns[5].ColumnName = "值班结束时间";
            dt.Columns[6].ColumnName = "是否缺席";
            dt.Columns[7].ColumnName = "缺席原因";
            dt.Columns[8].ColumnName = "描述";
            DataView.Columns[8].Width = 400;
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(this.DataView);
        }



        /// <summary>
        /// 获取选中的单元格的数据信息
        /// </summary>
        private void GetDataGridViewValueSelect()
        {
            _infoList.Clear();
            if (DataView.SelectedRows.Count > 0)
            {
                int RowsLine = DataView.CurrentRow.Index;
                for (int i = 0; i < DataView.Columns.Count; i++)
                {
                    _infoList.Add(DataView.Rows[RowsLine].Cells[i].Value.ToString());
                }
            }
        }

        private void btn_Dutyadd_Click(object sender, EventArgs e)
        {
            Form_AttendanceRecordAdd form = new Form_AttendanceRecordAdd("添加");
            form.Show();
            if (form.DialogResult == DialogResult.OK)
            {
                RefreshDataGridView();
            }
        }

        private void btn_DutyEdit_Click(object sender, EventArgs e)
        {
            Form_AttendanceRecordAdd onduty = new Form_AttendanceRecordAdd("编辑");
            if (_infoList.Count>0)
            {
                onduty.infoList = _infoList;
                onduty.Show();
                if (onduty.DialogResult == DialogResult.OK)
                {
                    RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("请在表单中选择需要编辑的数据！");
            }

        }

        private void btn_DutyDelete_Click(object sender, EventArgs e)
        {
            Form_AttendanceRecordAdd onduty = new Form_AttendanceRecordAdd("删除");
            if (_infoList.Count>0)
            {
                onduty.infoList = _infoList;
                onduty.Show();
                if (onduty.DialogResult == DialogResult.OK)
                {
                    RefreshDataGridView();
                }
            }
            else
            {
                MessageBox.Show("请在表单中选择需要删除的数据！");
            }

        }

        private void DataView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>-1)
            {
                GetDataGridViewValueSelect();
            }
            
        }

        private void btn_SwitchAdd_Click(object sender, EventArgs e)
        {
            Form_SwitchManage form = new Form_SwitchManage();
            form.Show();
        }

        private void Form_AttendanceRecord_Load(object sender, EventArgs e)
        {
            cbx_Isabsent.SelectedIndex = 0;
            RefreshDataGridView();
        }


    }
}
