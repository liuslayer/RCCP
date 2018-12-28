using AccessOperation.ole;
using Client.Entities;
using Client.Entities.AlarmEntity;
using Client.Entities.DeviceEntity;
using Client.Entities.UserEntity;
using DeviceBaseData;
using Newtonsoft.Json;
using PresetForm;
using RecDll;
using RecDll.ole;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using SystemSetupDLL.UserManagement;
using TurntableControlInterface;
using UserManagementDLL;
using static DeviceBaseData.PlanData;

namespace SystemSetupDLL
{
    public partial class SystemSetup : Form
    {
        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion
        //开关量信息
        List<DVRorNVR_SwitchList> switchList;
        //红外保护信息
        LensProtection lensProtection = new LensProtection();
        public SystemSetup()
        {
            InitializeComponent();
        }

        private void GetRecInfo()
        {
            string message = "GetPre_arrangedPlanning/Query1\r\n";
            Byte[] data = Encoding.ASCII.GetBytes(message);
            if (CommunicationClass.stream2 == null) return;
            CommunicationClass.stream2.Write(data, 0, data.Length);

            string responseData = String.Empty;

            data = new Byte[1024 * 100];
            while (true)
            {
                int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
                responseData += Encoding.UTF8.GetString(data, 0, bytes);
                List<Pre_arrangedPlanning> pre_arrangedPlanning = JsonConvert.DeserializeObject<List<Pre_arrangedPlanning>>(responseData);
                Action action = delegate ()
                {
                    dataGridView1.DataSource = pre_arrangedPlanning;
                    dataGridView1.Columns["PlanDeviceID"].HeaderText = "ID";
                    dataGridView1.Columns["PlanType"].HeaderText = "录像";
                    dataGridView1.Columns["PlanTypeID"].Visible = false;
                    dataGridView1.Columns["TimeType"].HeaderText = "时间类型";
                    dataGridView1.Columns["StartDate"].HeaderText = "开始日期";
                    dataGridView1.Columns["StartWeek"].HeaderText = "开始星期";
                    dataGridView1.Columns["StartTime"].HeaderText = "开始时间";
                    dataGridView1.Columns["EndDate"].HeaderText = "结束日期";
                    dataGridView1.Columns["EndWeek"].HeaderText = "结束星期";
                    dataGridView1.Columns["EndTime"].HeaderText = "结束时间";
                    dataGridView1.Columns["Description"].HeaderText = "描述";
                    dataGridView1.Columns["Mark"].Visible=false;
                    dataGridView1.Columns["DeviceID"].HeaderText = "设备ID";
                    dataGridView1.Columns["DeviceType"].Visible=false;
                    dataGridView1.Columns["PlanPath"].Visible=false;
                };
                Invoke(action);
                break;
            }
        }

        #region 初始化信息
        //用户列表
        private void dataGridView3Init()
        {
            string message = "GetUserList\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (CommunicationClass.stream2 == null)
            {
                MessageBox.Show("数据服务未连接，获取用户列表失败！");
                return;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);
            string responseData = string.Empty;
            data = new byte[1024 * 100];
            try
            {
                int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
                responseData += Encoding.UTF8.GetString(data, 0, bytes);
                List<UserList> userList = JsonConvert.DeserializeObject<List<UserList>>(responseData);
                Action action = delegate () { Add_DataGridView3(userList); };
                dataGridView3.Invoke(action);
            }
            catch(Exception ex)
            {
                //服务器连接断开
            }
        }

        private void Add_DataGridView3(List<UserList> userList)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("UserID");
            dt.Columns.Add("用户名");
            dt.Columns.Add("UserPassword");
            dt.Columns.Add("权限等级");
            dt.Columns.Add("描述");
            dt.Columns.Add("备注");
            for (int i = 0; i <userList.Count; i++)
            {
                DataRow dr = dt.Rows.Add();
                dr["UserID"] = userList[i].UserID;
                dr["用户名"] = userList[i].Username;
                dr["UserPassword"] = userList[i].UserPassword;
                dr["权限等级"] = userList[i].UserPermissionID;
                dr["描述"] = userList[i].Description;
                dr["备注"] = userList[i].Mark;
            }
            dataGridView3.DataSource = dt;
            dataGridView3.Columns["UserID"].Visible = false;
            dataGridView3.Columns["UserPassword"].Visible = false;
        }

        public void ListView1Init()
        {
            while (true)
            {
                if (Class1.IsDone)
                {
                    AddListView1Items();
                    break;
                }
            }
        }
        //开关量列表
        public void ListView2Init()
        {
            string message = "GetSwitchList\r\n";
            Byte[] data = Encoding.ASCII.GetBytes(message);
            if (CommunicationClass.stream2 == null)
            {
                MessageBox.Show("数据服务未连接，获取开关量列表失败！");
                return;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);
            string responseData = string.Empty;
            data = new Byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData += Encoding.UTF8.GetString(data, 0, (int)bytes);
            switchList = JsonConvert.DeserializeObject<List<DVRorNVR_SwitchList>>(responseData);

            AddListView2Items();
        }
        public delegate void AddListViewItemsDelegate();
        public void AddListView1Items()
        {
            if (listView1.InvokeRequired)
            {
                AddListViewItemsDelegate d = AddListView1Items;
                listView1.Invoke(d);
            }
            else
            {
                if (Class1.cameraList != null)
                {
                    for(int i=0;i<Class1.cameraList.Count;i++)
                    {
                        ListViewItem lvi = new ListViewItem(Class1.cameraList[i].VideoName);
                        lvi.Tag = Class1.cameraList[i].DeviceID;
                        listView1.Items.Add(lvi);
                    }
                }
            }
        }
        public void AddListView2Items()
        {
            if (listView2.InvokeRequired)
            {
                AddListViewItemsDelegate d = AddListView2Items;
                listView2.Invoke(d);
            }
            else
            {
                if (switchList != null)
                {
                    for (int i = 0; i < switchList.Count; i++)
                    {
                        ListViewItem lvi = new ListViewItem(switchList[i].Name);
                        lvi.Tag = switchList[i].DeviceID;
                        listView2.Items.Add(lvi);
                    }
                }
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn =e.Node;
            if(tn.Level==1)
            {
                switch(tn.Text)
                {
                    case "录像设置":
                        tabControl1.SelectedIndex = 0;
                        break;
                    case "开关量设置":
                        tabControl1.SelectedIndex = 1;
                        break;
                    case "其他设置":
                        tabControl1.SelectedIndex = 2;
                        break;
                    case "用户管理":
                        tabControl1.SelectedIndex = 3;
                        break;
                }
            }
        }
        #region 自动录像
        /// <summary>
        /// 保存自动录像信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void page1_save_Click(object sender, EventArgs e)
        {
            #region 本地存储
            //string errorInfo = "";
            ////时间类型
            //string AutoRecMode = "1";
            //for(int i=0;i<4;i++)
            //{
            //    if (radioButton1.Checked)
            //    {
            //        AutoRecMode = "1";
            //        break;
            //    }
            //    else if (radioButton2.Checked)
            //    {
            //        AutoRecMode = "2";
            //        break;
            //    }
            //    else if (radioButton3.Checked)
            //    {
            //        AutoRecMode = "3";
            //        break;
            //    }
            //    else if (radioButton4.Checked)
            //    {
            //        AutoRecMode = "4";
            //        break;
            //    }
            //}

            ////起始日期
            //string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            ////结束日期
            //string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            ////开始星期
            //string startWeek = dateTimePicker1.Value.DayOfWeek.ToString();
            ////结束星期
            //string endWeek = dateTimePicker2.Value.DayOfWeek.ToString();
            ////开始时间
            //string startTime = dateTimePicker3.Text;
            ////结束时间
            //string endTime = dateTimePicker4.Text;
            //foreach (ListViewItem lvi in listView1.SelectedItems)
            //{
            //    AutoRecInfoList autoRecInfoList = new AutoRecInfoList();
            //    autoRecInfoList.DeviceID = lvi.Tag.ToString();
            //    autoRecInfoList.StartDate = startDate;
            //    autoRecInfoList.StartWeek = startWeek;
            //    autoRecInfoList.StartTime = startTime;
            //    autoRecInfoList.EndDate = endDate;
            //    autoRecInfoList.EndWeek = endWeek;
            //    autoRecInfoList.EndTime = endTime;
            //    autoRecInfoList.AutoRecFlag = "1";
            //    autoRecInfoList.AutoRecMode = AutoRecMode;
            //    if(!AutoRecInfoClass.Add(autoRecInfoList,ref errorInfo))
            //    {
            //        MessageBox.Show(lvi.Text+"添加失败！");
            //        break;
            //    }
            //}
            ////显示录像设置信息
            //DataSet ds = AutoRecInfoClass.SelectAll(ref errorInfo);
            //if(ds==null)
            //{
            //    MessageBox.Show(errorInfo);
            //    return;
            //}
            //dataGridView1.DataSource = ds.Tables["AutoRecInfoList"];
            #endregion

            #region 服务器端存储
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                temp_AlarmMessageForAll.PlanDeviceID = Guid.NewGuid().ToString();
                for (int i = 0; i < 4; i++)
                {
                    if (radioButton1.Checked)
                    {
                        temp_AlarmMessageForAll.TimeType = "1";
                        break;
                    }
                    else if (radioButton2.Checked)
                    {
                        temp_AlarmMessageForAll.TimeType = "2";
                        break;
                    }
                    else if (radioButton3.Checked)
                    {
                        temp_AlarmMessageForAll.TimeType = "3";
                        break;
                    }
                    else if (radioButton4.Checked)
                    {
                        temp_AlarmMessageForAll.TimeType = "4";
                        break;
                    }
                }
                temp_AlarmMessageForAll.PlanType = 2;
                temp_AlarmMessageForAll.PlanTypeID = "0";
                temp_AlarmMessageForAll.DeviceID = lvi.Tag.ToString();
                temp_AlarmMessageForAll.DeviceType = "0";
                temp_AlarmMessageForAll.StartDate= dateTimePicker1.Value.ToString("yyyy-MM-dd");
                temp_AlarmMessageForAll.StartWeek = dateTimePicker1.Value.DayOfWeek.ToString();
                temp_AlarmMessageForAll.StartTime = dateTimePicker3.Text;
                temp_AlarmMessageForAll.EndDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
                temp_AlarmMessageForAll.EndWeek = dateTimePicker2.Value.DayOfWeek.ToString();
                temp_AlarmMessageForAll.EndTime = dateTimePicker4.Text;
                temp_AlarmMessageForAll.Description = "录像预案";
                string str = JsonConvert.SerializeObject(temp_AlarmMessageForAll);
                string message = "GetPre_arrangedPlanning/Add," + str + "\r\n";
                byte[] b = Encoding.UTF8.GetBytes(message);
                CommunicationClass.stream2.Write(b, 0, b.Length);
            }
            GetRecInfo();
            #endregion
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            string errorInfo = "";
            DialogResult dr = MessageBox.Show("确定删除选中项并停止该自动录像？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    #region 本地数据库
                    // //删除数据库
                    //if(!AutoRecInfoClass.Delete(int.Parse(dgvr.Cells[0].Value.ToString()),ref errorInfo))
                    // {
                    //     MessageBox.Show(errorInfo);
                    //     break;
                    // }
                    // //停止自动录像（待完成）

                    //移除列表
                    //dataGridView1.Rows.Remove(dgvr);
                    #endregion
                    #region 服务器数据库
                    AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                    temp_AlarmMessageForAll.PlanDeviceID = dgvr.Cells[0].Value.ToString();
                    string str = JsonConvert.SerializeObject(temp_AlarmMessageForAll);
                    string message = "GetPre_arrangedPlanning/Del," + str + "\r\n";
                    byte[] b = Encoding.UTF8.GetBytes(message);
                    CommunicationClass.stream2.Write(b, 0, b.Length);
                    GetRecInfo();
                    #endregion

                }
            }
        }
        #endregion

        #region 开关量
        /// <summary>
        /// 保存开关量设置信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            string errorInfo = "";
            //时间类型
            string timeType = "1";
            for (int i = 0; i < 4; i++)
            {
                if (radioButton8.Checked)
                {
                    timeType = "1";
                    break;
                }
                else if (radioButton7.Checked)
                {
                    timeType = "2";
                    break;
                }
                else if (radioButton6.Checked)
                {
                    timeType = "3";
                    break;
                }
                else if (radioButton5.Checked)
                {
                    timeType = "4";
                    break;
                }
            }

            //起始日期
            string startDate = dateTimePicker5.Value.ToString("yyyy-MM-dd");
            //结束日期
            string endDate = dateTimePicker6.Value.ToString("yyyy-MM-dd");
            //开始星期
            string startWeek = dateTimePicker5.Value.DayOfWeek.ToString();
            //结束星期
            string endWeek = dateTimePicker6.Value.DayOfWeek.ToString();
            //开始时间
            string startTime = dateTimePicker7.Text;
            //结束时间
            string endTime = dateTimePicker8.Text;
            foreach (ListViewItem lvi in listView2.SelectedItems)
            {
                SwitchDateList switchDateList = new SwitchDateList();
                TimeSpan ts = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1);
                switchDateList.DateID = ts.TotalMilliseconds.ToString();
                switchDateList.DeviceID = lvi.Tag.ToString();
                switchDateList.StartDate = startDate;
                switchDateList.StartWeek = startWeek;
                switchDateList.StartTime = startTime;
                switchDateList.EndDate = endDate;
                switchDateList.EndWeek = endWeek;
                switchDateList.EndTime = endTime;
                switchDateList.TimeType = timeType;
                if(!SwitchDateClass.Add(switchDateList,ref errorInfo))
                {
                    MessageBox.Show(errorInfo);
                    break;
                }
            }
            //显示录像设置信息
            DataSet ds = SwitchDateClass.SelectAll(ref errorInfo);
            if (ds == null) MessageBox.Show(errorInfo);
            dataGridView2.DataSource = ds.Tables["SwitchDateList"];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string errorInfo = "";
            DialogResult dr = MessageBox.Show("确定删除选中项？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (DataGridViewRow dgvr in dataGridView2.SelectedRows)
                {
                    //删除数据库
                    if(SwitchDateClass.Delete(int.Parse(dgvr.Cells[0].Value.ToString()),ref errorInfo))
                    {
                        MessageBox.Show(errorInfo);
                        break;
                    }
                   
                    //移除列表
                    dataGridView2.Rows.Remove(dgvr);
                }
            }
        }
        #endregion

        #region 其他设置

        private void LocalDisk()
        {
            WqlObjectQuery wmiquery = new WqlObjectQuery("select * from Win32_LogiCalDisk");
            ManagementObjectSearcher wmifind = new ManagementObjectSearcher(wmiquery);
            //显示
            ShowInfo(wmifind);
        }
        private void ShowInfo(ManagementObjectSearcher wmifind)
        {
            long gb = 1024 * 1024 * 1024;
            string type = "";
            string str = "";
            string errorInfo = "";
            double freePath = 0d;
            foreach (var mobj in wmifind.Get())
            {
                type = mobj["Description"].ToString();
                //判断是否是本机固盘
                if (type == "Local Fixed Disk")
                {
                    str = mobj["Name"].ToString();
                    freePath = Math.Round(Convert.ToDouble(mobj["FreeSpace"]) / gb, 1);
                    str += " 可用空间:" + freePath + "G";
                    str += " 实际大小:" + Math.Round(Convert.ToDouble(mobj["Size"].ToString()) / gb, 1) + "G";
                    
                    checkedListBox1.Items.Add(str);
                    checkedListBox2.Items.Add(str);
                }
            }
            DataSet ds = RecPathClass.SelectAll(ref errorInfo);
            if(ds!=null)
            {
                for (int i = 0; i < ds.Tables["RecPath"].Rows.Count; i++)
                {
                    if (ds.Tables["RecPath"].Rows[i]["Usefor"].ToString() == "录像")
                    {
                        string str1 = ds.Tables["RecPath"].Rows[i]["Disk"].ToString();
                        string[] disk = str1.Split(new char[] { ',' });
                        string capacityClear1 = ds.Tables["RecPath"].Rows[i]["CapacityClear"].ToString();
                        for (int j = 0; j < checkedListBox1.Items.Count; j++)
                        {
                            for (int k = 0; k < disk.Length; k++)
                            {
                                if (disk[k] == checkedListBox1.Items[j].ToString().Split(new char[] { ':' })[0])
                                    checkedListBox1.SetItemChecked(j, true);
                            }
                        }
                        videoAutoClear.Text = capacityClear1;
                    }
                    if (ds.Tables["RecPath"].Rows[i]["Usefor"].ToString() == "截图")
                    {
                        string str1 = ds.Tables["RecPath"].Rows[i]["Disk"].ToString();
                        string[] disk = str1.Split(new char[] { ',' });
                        string capacityClear1 = ds.Tables["RecPath"].Rows[i]["CapacityClear"].ToString();
                        for (int j = 0; j < checkedListBox2.Items.Count; j++)
                        {
                            for (int k = 0; k < disk.Length; k++)
                            {
                                if (disk[k] == checkedListBox2.Items[j].ToString().Split(new char[] { ':' })[0])
                                    checkedListBox2.SetItemChecked(j, true);
                            }
                        }
                        comboBox1.Text = capacityClear1;
                    }
                }
            }
            else
            {
                MessageBox.Show(errorInfo + "，获取录像存储信息失败！");
            }
        }

        #endregion

        /// <summary>
        /// 录像路径存储
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoPathSave_Click(object sender, EventArgs e)
        {
            RecPathList recPathList = new RecPathList();
            string disk="";
            foreach (int i in checkedListBox1.CheckedIndices)
            {
                    disk += checkedListBox1.Items[i].ToString().Split(new char[] { ':' })[0]+",";
            }
            recPathList.Disk = disk.Substring(0, disk.Length - 1);
            recPathList.CapacityClear = videoAutoClear.Text;
            recPathList.Userfor = "录像";
            string errorInfo = "";
            if(RecPathClass.Update(recPathList,ref errorInfo))
            { MessageBox.Show("保存成功！"); }
            else { MessageBox.Show(errorInfo); }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            RecPathList recPathList = new RecPathList();
            string disk = "";
            foreach (int i in checkedListBox2.CheckedIndices)
            {
                disk += checkedListBox2.Items[i].ToString().Split(new char[] { ':' })[0]+",";
            }
            recPathList.Disk = disk.Substring(0, disk.Length - 1);
            recPathList.CapacityClear = comboBox1.Text;
            recPathList.Userfor = "截图";
            string errorInfo = "";
            if (RecPathClass.Update(recPathList, ref errorInfo))
            { MessageBox.Show("保存成功！"); }
            else{ MessageBox.Show(errorInfo); }
        }
        //设备授时
        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ManualRec.userIDList.Count; i++)
            {
                bool temp_bool=TimingSet.TimingSetByAuto(ManualRec.userIDList.ElementAt(i).Value);
                if (temp_bool)
                    MessageBox.Show("授时成功");
                else
                    MessageBox.Show("授时失败");
            }
        }

        #region 用户操作
        //添加用户
        private void button15_Click(object sender, EventArgs e)
        {
            User_Add addForm = new User_Add();
            addForm.ShowDialog();
            dataGridView3Init();
        }
        //查询用户
        private void button10_Click(object sender, EventArgs e)
        {
            int pageNumber;
            int.TryParse(RecPageBtn.Text, out pageNumber);
            int rowsPerPage;
            int.TryParse(comboBox4.Text, out rowsPerPage);
            string message = "GetUserPagedList/" + pageNumber + "," + rowsPerPage + "\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            if(CommunicationClass.stream2==null)
            {
                MessageBox.Show("数据服务未连接，获取用户列表失败！");
                return;
            }
            CommunicationClass.stream2.Write(data, 0, data.Length);
            string responseData = string.Empty;
            data = new byte[1024 * 100];

            Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            responseData = Encoding.UTF8.GetString(data, 0, (int)bytes);
            List<UserList> userList = JsonConvert.DeserializeObject<List<UserList>>(responseData);
            Add_DataGridView3(userList);
        }
        //删除用户
        private void button16_Click(object sender, EventArgs e)
        {
            string message ;
            if(dataGridView3.SelectedRows.Count>0)
            {
                for (int i = 0; i < dataGridView3.Rows.Count;)
                {
                    DataGridViewRow row = dataGridView3.Rows[i];
                    if (row.Selected)
                    {
                        string UserID = row.Cells["UserID"].Value.ToString();
                        message = "DeleteUser/" + UserID + "\r\n";
                        byte[] data = Encoding.UTF8.GetBytes(message);
                        if (CommunicationClass.stream2 == null)
                        {
                            MessageBox.Show("数据服务未连接，用户删除失败！");
                            return;
                        }
                        CommunicationClass.stream2.Write(data, 0, data.Length);
                        string responseData = string.Empty;
                        data = new byte[1024];
                        Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
                        responseData = Encoding.UTF8.GetString(data, 0, (int)bytes);
                        if (responseData.Replace("\r\n", "") == "False")
                        {
                            MessageBox.Show("删除" + row.Cells["用户名"].ToString() + "失败！");
                        }
                        else
                        {
                            dataGridView3.Rows.Remove(row);
                        }
                    }
                    else
                        i++;
                }
            }
            else
            {
                MessageBox.Show("请选择需要删除的用户信息！");
            }
        }
        //修改用户
        private void button17_Click(object sender, EventArgs e)
        {
            UserList userList = new UserList();
            if(dataGridView3.SelectedRows.Count>0)
            {
                DataGridViewRow dgvr = dataGridView3.SelectedRows[0];
                userList.UserID= Guid.Parse(dgvr.Cells["UserID"].Value.ToString());
                userList.Username = dgvr.Cells["用户名"].Value.ToString();
                userList.UserPassword = dgvr.Cells["UserPassword"].Value.ToString();
                userList.UserPermissionID = Int32.Parse(dgvr.Cells["权限等级"].Value.ToString());
                userList.Description = dgvr.Cells["描述"].Value.ToString();
                userList.Mark = dgvr.Cells["备注"].Value.ToString();

                User_Modify user_Modify = new User_Modify(userList);
                user_Modify.Show();

            }
            else
            {
                MessageBox.Show("请选中一行要修改的数据！");
                return;
            }
        }
        #endregion

        private void SystemSetup_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        //用户权限
        private void button18_Click(object sender, EventArgs e)
        {
            UserAuthority userAuthority = new UserAuthority();
            userAuthority.Show();

        }
        //用户角色
        private void button19_Click(object sender, EventArgs e)
        {
            UserRoleForm userRoleForm = new UserRoleForm();
            userRoleForm.Show();
        }
        //红外保护
        private void infraBtn_Click(object sender, EventArgs e)
        {
            lensProtection.SummerMonth = textBox1.Text + "-" + textBox2.Text;
            lensProtection.SummerDetermine = 1;
            lensProtection.SummerTimeBegin = S_startTime.Text;
            lensProtection.SummerTimeEnd = S_endTime.Text;
            lensProtection.WinterMonth = textBox3.Text + "-" + textBox4.Text;
            lensProtection.WinterDetermine = 1;
            lensProtection.WinterTimeBegin = W_startTime.Text;
            lensProtection.WinterTimeEnd = W_endTime.Text;
            //写入SQL
            string message = "LensProtectionCommand/Set/" + JsonConvert.SerializeObject(lensProtection)+"\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(data,0,data.Length);
            data = new byte[10];
            int bytes= CommunicationClass.stream2.Read(data, 0, data.Length);
            message = Encoding.UTF8.GetString(data,0,bytes).Replace("\r\n","").Trim();
            switch(message)
            {
                case "True":
                    MessageBox.Show("保存成功！");
                    InterfaceControl.ResetIRProtect();

                    break;
                case "False":
                    MessageBox.Show("保存失败！");
                    break;
            }
        }

        private void SystemSetup_Load(object sender, EventArgs e)
        {
            string errorInfo = "";
            //1、初始化通信类（服务器）
            bool result1 = CommunicationClass.Init();
            if (!result1)
            {
                MessageBox.Show("连接服务器失败！");
                return;
            }
            treeView1.ExpandAll();
            //2、初始化设备数据（服务器数据库）
            Class1 class1 = new Class1();
            class1.Init();
            ManualRec.LogIn();
            //获取录像设备选择列表
            Thread th1 = new Thread(new ThreadStart(ListView1Init));
            th1.IsBackground = true;
            th1.Start();
            //显示录像设置信息
            Thread th4 = new Thread(new ThreadStart(GetRecInfo));
            th4.IsBackground = true;
            th4.Start();
            //显示开关量设置信息
            DataSet ds2 = SwitchDateClass.SelectAll(ref errorInfo);
            if (ds2 == null)
                MessageBox.Show(errorInfo + "获取开关量设置信息失败！");
            else
            {
                dataGridView2.DataSource = ds2.Tables["SwitchDateList"];
            }
            //显示其他设置的磁盘信息
            LocalDisk();
            //显示红外保护信息（服务器数据库）
            Thread th5 = new Thread(new ThreadStart(GetLensProtection));
            th5.IsBackground = true;
            th5.Start();
            lensProtection.Camera_DeviceID = Guid.NewGuid();
            //获取开关量列表（服务器数据库）
            Thread th2 = new Thread(new ThreadStart(ListView2Init));
            th2.IsBackground = true;
            th2.Start();

            //获取用户列表（服务器数据库）
            Thread th3 = new Thread(new ThreadStart(dataGridView3Init));
            th3.IsBackground = true;
            th3.Start();
        }

        private void GetLensProtection()
        {
            string message = "LensProtectionCommand/Get\r\n";
            byte[] data = Encoding.UTF8.GetBytes(message);
            if (CommunicationClass.stream2 == null) return;
            CommunicationClass.stream2.Write(data,0,data.Length);
            data = new byte[1024 * 100];
            int bytes = CommunicationClass.stream2.Read(data, 0, data.Length);
            message = Encoding.UTF8.GetString(data, 0, bytes).Replace("\r\n", "");
            List < LensProtection > lensProtectionList = JsonConvert.DeserializeObject<List<LensProtection>>(message);
            lensProtection = lensProtectionList[0];
            Action action = delegate ()
            {
                textBox1.Text = lensProtection.SummerMonth.Split('-')[0];
                textBox2.Text = lensProtection.SummerMonth.Split('-')[1];
                textBox3.Text = lensProtection.WinterMonth.Split('-')[0];
                textBox4.Text = lensProtection.WinterMonth.Split('-')[1];
                S_startTime.Text = lensProtection.SummerTimeBegin;
                S_endTime.Text = lensProtection.SummerTimeEnd;
                W_startTime.Text = lensProtection.WinterTimeBegin;
                W_endTime.Text = lensProtection.WinterTimeEnd;
            };
            Invoke(action);
        }
        //每周时间设置
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
                dateTimePicker1.CustomFormat = "dddd";
                dateTimePicker2.CustomFormat = "dddd";
            }
        }
        //某日时间设置
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
                dateTimePicker1.CustomFormat = "yyyy-MM-dd";
                dateTimePicker2.CustomFormat = "yyyy-MM-dd";
            }
        }

      //全时段设置
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = false;
                dateTimePicker4.Enabled = false;
            }
        }
        //每日时间设置
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked)
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                dateTimePicker3.Enabled = true;
                dateTimePicker4.Enabled = true;
            }
        }
    }
}
