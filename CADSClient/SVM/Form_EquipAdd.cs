using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseDataClass;
using DataAssemblyClass;
using DataInterfaceModule;

namespace SVM
{
    public partial class Form_EquipAdd : Form
    {
        private string EquipEditMark = "";//用于标记是否选中修改编辑对象
        private DataTable EquipResult = null;
        string Mark = "";
        public Form_EquipAdd()
        {
            InitializeComponent();
            this.bunifuCards1.Visible = false;
        }
        //窗体关闭按钮事件
        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //添加按钮事件
        private void btn_Add_Click(object sender, EventArgs e)
        {
            this.bunifuCards1.Visible = true;
            Mark = "添加";
        }
        //编辑按钮事件
        private void btn_Edit_Click(object sender, EventArgs e)
        {
            
            if (EquipEditMark=="")
            {
                MessageBox.Show("抱歉，您还未选中任何需要修改的设备信息！");
            }
            else
            {
                foreach (DataRow item in EquipResult.Rows)
                {
                    if (EquipEditMark == item["EquipmentID"].ToString())
                    {
                        tbx_Name.Text = item["EquipmentName"].ToString();
                       tbx_ID.Text = item["EquipmentID"].ToString();
                       tbx_EquipmentState.Text = item["EquipmentState"].ToString();
                       tbx_Unit.Text=item["Unit"].ToString();
                       tbx_PersonIncharge.Text = item["PersonIncharge"].ToString();
                       TimePicker_Intime.Value = Convert.ToDateTime(item["AllottedDate"]);
                       TimePicker_ReturnDate.Value = Convert.ToDateTime(item["ReturnDate"]);
                       tbx_EquipNum.Text = item["EquipmentModel"].ToString();
                       tbx_descrip.Text = item["Description"].ToString();
                       tbx_EquipType.Text = item["EquipmentType"].ToString();
                       Mark = "编辑";
                    }
                }
                this.bunifuCards1.Visible = true;
                 
            }
        }
        //删除按钮事件
        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            if (EquipEditMark == "")
            {
                MessageBox.Show("抱歉，您还未选中任何需要删除的设备信息！");
            }
            else
            {
                foreach (DataRow item in EquipResult.Rows)
                {
                    if (EquipEditMark == item["EquipmentID"].ToString())
                    {
                        tbx_Name.Text = item["EquipmentName"].ToString();
                        tbx_ID.Text = item["EquipmentID"].ToString();
                        tbx_EquipmentState.Text = item["EquipmentState"].ToString();
                        tbx_Unit.Text = item["Unit"].ToString();
                        tbx_PersonIncharge.Text = item["PersonIncharge"].ToString();
                        TimePicker_Intime.Value = Convert.ToDateTime(item["AllottedDate"]);
                        TimePicker_ReturnDate.Value = Convert.ToDateTime(item["ReturnDate"]);
                        tbx_EquipNum.Text = item["EquipmentModel"].ToString();
                        tbx_descrip.Text = item["Description"].ToString();
                        tbx_EquipType.Text = item["EquipmentType"].ToString();
                        Mark = "删除";
                    }
                }
                this.bunifuCards1.Visible = true;
            }
        }
        //添加按钮事件
        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (CheckInput())
            {
                OpreationDB(Mark);
            }

        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            if (tbx_Search.Text.ToString()!="")
            {
                string KeyWord = tbx_Search.Text.ToString();
                GetEquipInfoByName(KeyWord);
                if (EquipResult!=null&&EquipResult.Rows.Count>0)
                {
                    Equip_List.DataSource = EquipResult;
                    Equip_List.DisplayMember = EquipResult.Columns["EquipmentName"].ToString();
                    Equip_List.ValueMember = EquipResult.Columns["EquipmentID"].ToString();
                }
            }
        }
        /// <summary>
        /// 通过姓名联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetEquipInfoByName(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from EquipmentInfoList where EquipmentName like '%" + Condition + "%'";
            DataSet ds = device.gettablebycondition(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                EquipResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的设备相关信息，请重新输入！");
            }
            
        }
        /// <summary>
        /// 通过ID联想
        /// </summary>
        /// <param name="Condition"></param>
        private void GetEquipInfoByID(string Condition) 
        {
            deviceInfo device = new deviceInfo();
            string sql = "select * from EquipmentInfoList where EquipmentName like '%" + Condition + "%'";
            DataSet ds = device.gettablebycondition(sql);
            DataTable dt = ds.Tables[0];
            if (dt.Rows.Count > 0 && dt != null)
            {
                EquipResult = dt;
            }
            else
            {
                MessageBox.Show("找不到符合条件的设备相关信息，请重新输入！");
            }
        }
        /// <summary>
        /// ListBox选中事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Person_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            EquipEditMark = Equip_List.SelectedValue.ToString();
        }

        private void tbx_Search_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar==13)
            {
                SearchBtn_Click(sender, e);
            }
        }
        /// <summary>
        /// 清除文本
        /// </summary>
        /// <param name="ctrlTop"></param>
        private void ClearText(Control ctrlTop)
        {
            this.Equip_List.Items.Clear();
            if (ctrlTop.GetType() == typeof(TextBox))
            {
                ctrlTop.Text = "";
            }
            else
            {
                foreach (Control ctrl in ctrlTop.Controls)
                {
                    ClearText(ctrl); //循环调用  
                }
            }
        }
        /// <summary>
        /// 用户数据录入查询
        /// </summary>
        private bool CheckInput()
        {
            if (tbx_PersonIncharge.Text.Trim()=="")
            {
                MessageBox.Show("请填写负责人信息！");
                return false;
            }
            if (tbx_ID.Text.Trim()=="")   
            {
                MessageBox.Show("请填写设备编号信息！");
                return false;
            }

            if (tbx_Name.Text.Trim()=="")
            {
                MessageBox.Show("请填写设备名称！");
                return false;
            }
            if (tbx_EquipNum.Text.Trim()=="")
            {
                MessageBox.Show("请填写设备编号！");
                return false;
            }
            if (tbx_EquipType.Text.Trim()=="")
            {
                MessageBox.Show("请填写设备类型！");
                return false;
            }
            if (tbx_Unit.Text.Trim()=="")
            {
                MessageBox.Show("请填写单位名称！");
            }
            return true;
        }
        /// <summary>
        /// 数据操作
        /// </summary>
        /// <param name="Mess">区别编辑还是新增还是删除</param>
        private void OpreationDB(string Mess) 
        {

            BaseDataClass.EquipmentInfoList Equiplist = new EquipmentInfoList();

            Equiplist.EquipmentID = this.tbx_ID.Text.Trim();
            Equiplist.EquipmentName = this.tbx_Name.Text.Trim();
            Equiplist.EquipmentModel = this.tbx_EquipNum.Text.Trim();
            Equiplist.EquipmentType = this.tbx_EquipType.Text.Trim();
            Equiplist.PersonIncharge = this.tbx_PersonIncharge.Text.Trim();
            Equiplist.ReturnDate = this.TimePicker_ReturnDate.Value.ToString("yyyy-MM-dd");
            Equiplist.AllottedDate = this.TimePicker_Intime.Value.ToString("yyyy-MM-dd");
            Equiplist.Description = this.tbx_descrip.Text;
            Equiplist.Unit = this.tbx_Unit.Text;
            Equiplist.EquipmentState = this.tbx_EquipmentState.Text;
            deviceInfo PersonInfo = new deviceInfo();
            string Error = "";
            bool Result = false;
            if (Mess=="添加")
            {
                if (tbx_ID.Text.Trim() != "")
                {
                    //deviceInfo device = new deviceInfo();
                    //string sql = "select * from EquipmentInfoList where EquipmentID =" + tbx_ID.Text.Trim();
                    //DataSet result= device.gettablebycondition(sql);
                    deviceInfo device = new deviceInfo();
                    log_tabel log = new log_tabel();
                    log.addrow("EquipmentID", tbx_ID.Text.Trim(), log_tabel.operatetype.equal, log_tabel.mark.normal);
                    int i = device.GetRecordCount(logs.EquipmentInfoList, log);
                    if (i > 0)
                    {
                        MessageBox.Show("设备编号重复 请重新录入！");
                        
                    }
                    else
                    {
                        Result = PersonInfo.AddBaseList(Equiplist, ref Error);
                    }
                }
               
            }
            if (Mess=="编辑")
            {
                Result = PersonInfo.UpdateBaselist(Equiplist, ref Error);
            }
            if (Mess=="删除")
            {
                Result = PersonInfo.DeleteOneRecord(BaseDataClassNames.EquipmentInfoList, Equiplist.EquipmentID, ref Error);
            }
            if (Result == true)
            {
                MessageBox.Show("设备信息"+Mess+"成功");
                ClearText(this.Content);
            }
            else
            {
                MessageBox.Show("设备信息"+Mess+"失败，请稍后再试！");
                ClearText(this.Content);
            }  
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            ClearText(Content);
        }



    }
}
