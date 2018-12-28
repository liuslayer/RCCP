using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using MyTool;
using CADS.Model;
using CADS.BLL;

namespace EPM
{
    public partial class Form_PlanInfo : Form
    {
        CADS.BLL.PlanManageInfoList plan = null;
        public Form_PlanInfo()
        {
            InitializeComponent();
            plan = new CADS.BLL.PlanManageInfoList();
        }


        private void EPM_MainForm_Load(object sender, EventArgs e)
        {
            RefreshDataGridView();
        }

        private void RefreshDataGridView()
        {
            //try
            //{
            //    deviceInfo device = new deviceInfo();
            //    log_tabel condition = new log_tabel();
            //    int Recordcount = device.GetRecordCount(logs.PlanManagementInfoList, condition);
            //    myPageControl1.PageRecordCount = Recordcount;
            //    DataTable dt = device.getpage(logs.PlanManagementInfoList, condition, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
            //    dgvPlanInfos.DataSource = dt;
            //    bindingColName(dt);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            try
            {
                DataTable dt = plan.GetList("").Tables[0];
                dgvPlanInfos.DataSource = dt;
            }
            catch
            {

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    deviceInfo device = new deviceInfo();
            //    log_tabel condition = new log_tabel();
            //    if (txtPlanNo.Text.Trim() != "")
            //    {
            //        condition.addrow("PlanID", txtPlanNo.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
            //    }
            //    if (txtPlanContent.Text != "")
            //    {
            //        condition.addrow("PlanContent", txtPlanContent.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
            //        //condition.addrow("DutyEventTime", "2019-04-06", log_tabel.operatetype.lessAndEqual, log_tabel.mark.Date);
            //    }

            //    int Recordcount = device.GetRecordCount(logs.PlanManagementInfoList, condition);
            //    if (Recordcount > 0)
            //    {
            //        myPageControl1.PageRecordCount = Recordcount;
            //        DataTable dt = device.getpage(logs.PlanManagementInfoList, condition, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
            //        dgvPlanInfos.DataSource = dt;
            //        bindingColName(dt);
            //    }
            //    else
            //    {

            //        MessageBox.Show("无匹配数据，请重新更改查询条件！");

            //    }
            //    txtPlanNo.Text = "";
            //    txtPlanContent.Text = "";
            //}
            //catch (Exception ex)
            //{

            //    throw ex;
            //}

            try
            {
                string sql = " 1=1 ";
                if (txtPlanNo.Text.Trim() != "")
                {
                    sql += " and PlanID='" + txtPlanNo.Text + "'";
                }
                if (txtPlanContent.Text != "")
                {
                    sql += " and PlanTitle='" + txtPlanContent.Text + "'";
                }
                DataTable dt = plan.GetList(sql).Tables[0];
                dgvPlanInfos.DataSource = dt;
            }
            catch
            { 
            
            }
        }

        private void bindingColName(DataTable dt)
        {
            //dt.Columns[0].ColumnName = "ID";
            //dt.Columns[1].ColumnName = "预案编号";
            //dt.Columns[2].ColumnName = "预案标题";
            //dt.Columns[3].ColumnName = "预案描述";
            //dt.Columns[4].ColumnName = "预案路径";
        }

        private void btn_Dutyadd_Click(object sender, EventArgs e)
        {
            Form_PlanAdd addOrEdit = new Form_PlanAdd("add");
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("添加", addOrEdit.planInfo);
                RefreshDataGridView();
            }
        }

        private void btn_DutyEdit_Click(object sender, EventArgs e)
        {
            if (dgvPlanInfos.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            CADS.Model.PlanManageInfoList planInfo = new CADS.Model.PlanManageInfoList();
            planInfo.ID = Convert.ToInt32(dgvPlanInfos.CurrentRow.Cells[0].Value);
            planInfo.PlanID = dgvPlanInfos.CurrentRow.Cells[1].Value.ToString();
            planInfo.PlanTitle = dgvPlanInfos.CurrentRow.Cells[2].Value.ToString();
            planInfo.Description = dgvPlanInfos.CurrentRow.Cells[3].Value.ToString();
            planInfo.Path = dgvPlanInfos.CurrentRow.Cells[4].Value.ToString();
            Form_PlanAdd addOrEdit = new Form_PlanAdd("edit",planInfo);
            addOrEdit.ShowDialog();
            if (addOrEdit.DialogResult == DialogResult.OK)
            {
                OpreationDB("编辑", addOrEdit.planInfo);
                RefreshDataGridView();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPlanInfos.SelectedRows.Count < 1)
            {
                MessageBox.Show("请选中一行数据！");
                return;
            }
            if (MessageBox.Show("确定要删除该行数据？", null, MessageBoxButtons.YesNo) != DialogResult.Yes)
            {
                return;
            }
            CADS.Model.PlanManageInfoList planInfo = new CADS.Model.PlanManageInfoList();
            planInfo.ID = Convert.ToInt32(dgvPlanInfos.CurrentRow.Cells[0].Value);
            planInfo.PlanID = dgvPlanInfos.CurrentRow.Cells[1].Value.ToString();
            planInfo.PlanTitle = dgvPlanInfos.CurrentRow.Cells[2].Value.ToString();
            planInfo.Description = dgvPlanInfos.CurrentRow.Cells[3].Value.ToString();
            planInfo.Path = dgvPlanInfos.CurrentRow.Cells[4].Value.ToString();
            planInfo.Mark = dgvPlanInfos.CurrentRow.Cells[5].Value.ToString();
            if (OpreationDB("删除", planInfo))
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string planDirectory = Path.Combine(basePath, "预案模板");
                string destFileName = Path.Combine(planDirectory, planInfo.Path);
                try
                {
                    File.Delete(destFileName);
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.Message);
                }
                finally
                {
                    RefreshDataGridView();
                }
            }
        }

        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private bool OpreationDB(string Mess, CADS.Model.PlanManageInfoList planInfo)
        {
            try
            {
                string Error = "";
                bool Result = false;
                if (Mess == "添加")
                {
                    Result = plan.Add(planInfo);
                }
                if (Mess == "编辑")
                {
                    Result = plan.Update(planInfo);
                }
                if (Mess == "删除")
                {
                    Result = plan.Delete(planInfo.PlanID);
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

        /// <summary>
        /// 删除或恢复旧文件
        /// </summary>
        /// <param name="planInfo"></param>
        /// <param name="operType"></param>
        private static void DeleteOrResumeOldFile(CADS.Model.PlanManageInfoList planInfo,string operType)
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string planDirectory = Path.Combine(basePath, "预案模板");
                string destFileName = Path.Combine(planDirectory, planInfo.Path);
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(destFileName);
                string oldFileNameBak = Path.Combine(planDirectory, fileNameWithoutExt + ".bak");
                if (operType == "resume")
                {
                    if (File.Exists(destFileName))
                    {
                        File.Delete(destFileName);
                    }
                    if (File.Exists(oldFileNameBak))
                    {
                        File.Move(oldFileNameBak, destFileName);
                    }
                }
                else if (operType == "delete")
                {
                    if (File.Exists(oldFileNameBak))
                    {
                        File.Delete(oldFileNameBak);
                    }
                }
            }
            catch
            { 
            
            }
        }

        private void dgvPlanInfos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvPlanInfos.SelectedRows.Count < 1)
                return;
            string path = dgvPlanInfos.CurrentRow.Cells[4].Value.ToString();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string planDirectory = Path.Combine(basePath, "预案模板");
            string destFileName = Path.Combine(planDirectory, path);
            if (!File.Exists(destFileName))
            {
                MessageBox.Show("未找到预案文件！");
                return;
            }
            Process.Start(destFileName);
        }

        private void btn_QuikSearch_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (SearchText.Text.Trim() != "")
            //    {
            //        string title = "%" + SearchText.Text.Trim() + "%";
            //        deviceInfo deviceInfo = new deviceInfo();
            //        log_tabel log = new log_tabel();
            //        log.addrow("PlanContent", title, log_tabel.operatetype.like, log_tabel.mark.normal);
            //        int i = deviceInfo.GetRecordCount(logs.PlanManagementInfoList, log);
            //        if (i > 0)
            //        {
            //            DataTable dt = deviceInfo.getpage(logs.PlanManagementInfoList, log, myPageControl1.DataStart, myPageControl1.PageRecordNumber);
            //            dgvPlanInfos.DataSource = dt;
            //            bindingColName(dt);
            //        }
            //        else
            //        {
            //            MessageBox.Show("无匹配条件数据，请重新查询");
            //        }

            //    }
            //    else
            //    {
            //        RefreshDataGridView();
            //    }

            //}
            //catch (Exception)
            //{

            //    throw;
            //}

            try
            {
                string sql = string.Empty;
                if (SearchText.Text.Trim() != "")
                {
                    sql += " PlanTitle like'%" + SearchText.Text.Trim() + "%'";
                }
                DataTable dt = plan.GetList(sql).Tables[0];
                dgvPlanInfos.DataSource = dt;
            }
            catch
            {

            }
        }

        private void btn_Export_Click(object sender, EventArgs e)
        {
            ExcelHelper.DataGridViewToExcel(dgvPlanInfos);
        }

        private void btn_OpenFile_Click(object sender, EventArgs e)
        {
            if (dgvPlanInfos.SelectedRows.Count < 1)
                return;
            string path = dgvPlanInfos.CurrentRow.Cells[4].Value.ToString();
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string planDirectory = Path.Combine(basePath, "预案模板");
            string destFileName = Path.Combine(planDirectory, path);
            if (!File.Exists(destFileName))
            {
                MessageBox.Show("未找到预案文件！");
                return;
            }
            Process.Start(destFileName);
        }
    }
}
