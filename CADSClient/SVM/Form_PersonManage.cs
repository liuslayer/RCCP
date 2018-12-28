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
    public partial class Form_PersonManage : Form
    {

        public Form_PersonManage()
        {
            InitializeComponent();
            dtp_Intime.Text = "";
        }


        private void btn_PersonManage_Click(object sender, EventArgs e)
        {
            Form_PersonAdd form = new Form_PersonAdd();
            form.Show();
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                //if (SearchText.Text.Trim() != "")
                //{
                //    string Condition = SearchText.Text.Trim();
                //    deviceInfo device = new deviceInfo();
                //    string sql = "select * from PersonnelInfoList where PersonName like '%" + Condition + "%'";
                //    DataSet ds = device.gettablebycondition(sql);
                //    DataTable dt = ds.Tables[0];
                //    if (dt.Rows.Count > 0 && dt != null)
                //    {
                //        DataView.DataSource = dt;
                //        PersonResult = dt;
                //    }
                //    else
                //    {
                //        MessageBox.Show("找不到符合条件的人员相关信息，请重新输入！");
                //    }
                //}
                if (SearchText.Text.Trim() != "")
                {
                    string name = "%"+SearchText.Text.Trim()+"%";
                    deviceInfo PersonInfo = new deviceInfo();
                    log_tabel log = new log_tabel();
                    log.addrow("PersonName", name, log_tabel.operatetype.like, log_tabel.mark.normal);
                   int i= PersonInfo.GetRecordCount(logs.PersonnelInfoList, log);
                   if (i > 0)
                   {
                       DataTable dt = PersonInfo.getpage(logs.PersonnelInfoList, log, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
                       DataView.DataSource = dt;
                       bindingColName(dt);
                   }
                   else
                   {
                       MessageBox.Show("无匹配条件数据，请重新查询");
                   }
                   
                }

            }
            catch (Exception)
            {
                
                throw;
            }

        }

        private void myPageControl1_OnPageChanged(object sender, EventArgs e)
        {
            if (SearchText.Text!="")
            {
                btn_Search_Click(sender,e);
            }
            else
            {
                btn_Ok_Click(sender, e);
            }
           
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                deviceInfo device = new deviceInfo();
                log_tabel condition = new log_tabel();
                if (tbx_Name.Text.Trim() != "")
                {
                    condition.addrow("PersonName", tbx_Name.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
                }
                if (dtp_Intime.Text!="")
                {
                    condition.addrow("EnlistmentTime", dtp_Intime.Value.ToString("yyyy-MM-dd"), log_tabel.operatetype.equal, log_tabel.mark.Date);
                }
                int Recordcount = device.GetRecordCount(logs.PersonnelInfoList, condition);
                if (Recordcount > 0)
                {
                    myPageControl1.PageRecordCount = Recordcount;
                    DataTable dt = device.getpage(logs.PersonnelInfoList, condition, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
                    DataView.DataSource = dt;
                    bindingColName(dt);
                }
                else
                {
                    MessageBox.Show("无匹配数据，请重新更改查询条件！");
                }
                tbx_Name.Text = "";
                dtp_Intime.Text = "";
            }
            catch (Exception)
            {
                
                throw;
            }

        }
        private void bindingColName(DataTable dt) 
        {
            dt.Columns[1].ColumnName="编号";
            dt.Columns[2].ColumnName = "姓名";
            dt.Columns[3].ColumnName = "民族";
            dt.Columns[4].ColumnName = "籍贯";
            dt.Columns[5].ColumnName = "出生日期";
            dt.Columns[6].ColumnName = "学历";
            dt.Columns[7].ColumnName = "入伍时间";
            dt.Columns[8].ColumnName = "退伍时间";
            dt.Columns[9].ColumnName = "联系方式";
            dt.Columns[10].ColumnName = "职务";
            dt.Columns[11].ColumnName = "个人描述";
            dt.Columns[12].ColumnName = "所属单位";

        
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(this.DataView);
        }

        private void Form_PersonManage_Load(object sender, EventArgs e)
        {
            btn_Ok_Click(sender, e);
        }


    }
}
