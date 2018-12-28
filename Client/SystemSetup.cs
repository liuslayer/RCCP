using AccessOperation.ole;
using Client.Entities.DeviceEntity;
using Client.Entities.UserEntity;
using Client.UserManagement;
using DeviceBaseData;
using Newtonsoft.Json;
using PresetForm;
using RecDll;
using RecDll.ole;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    public partial class SystemSetup : Form
    {
        //开关量信息
        List<DVRorNVR_SwitchList> switchList;
        public SystemSetup()
        {
            InitializeComponent();
            treeView1.ExpandAll();
            //获取录像设备选择列表
            Thread th1 = new Thread(new ThreadStart(ListView1Init));
            th1.IsBackground = true;
            th1.Start();
            //显示录像设置信息
            DataSet ds = AutoRecInfoClass.SelectAll();
            dataGridView1.DataSource = ds.Tables["AutoRecInfoList"];
            //显示开关量设置信息
            DataSet ds2 = SwitchDateClass.SelectAll();
            dataGridView2.DataSource = ds2.Tables["SwitchDateList"];
            //显示其他设置的磁盘信息
            LocalDisk();
            //获取开关量列表（服务器数据库）
            Thread th2 = new Thread(new ThreadStart(ListView2Init));
            th2.IsBackground = true;
            th2.Start();

            //获取用户列表（服务器数据库）
            Thread th3 = new Thread(new ThreadStart(dataGridView3Init));
            th3.IsBackground = true;
            th3.Start();
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
            //时间类型
            string AutoRecMode = "1";
            for(int i=0;i<4;i++)
            {
                if (radioButton1.Checked)
                {
                    AutoRecMode = "1";
                    break;
                }
                else if (radioButton2.Checked)
                {
                    AutoRecMode = "2";
                    break;
                }
                else if (radioButton3.Checked)
                {
                    AutoRecMode = "3";
                    break;
                }
                else if (radioButton4.Checked)
                {
                    AutoRecMode = "4";
                    break;
                }
            }

            //起始日期
            string startDate = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            //结束日期
            string endDate = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            //开始星期
            string startWeek = dateTimePicker1.Value.DayOfWeek.ToString();
            //结束星期
            string endWeek = dateTimePicker2.Value.DayOfWeek.ToString();
            //开始时间
            string startTime = dateTimePicker3.Text;
            //结束时间
            string endTime = dateTimePicker4.Text;
            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                AutoRecInfoList autoRecInfoList = new AutoRecInfoList();
                autoRecInfoList.DeviceID = lvi.Tag.ToString();
                autoRecInfoList.StartDate = startDate;
                autoRecInfoList.StartWeek = startWeek;
                autoRecInfoList.StartTime = startTime;
                autoRecInfoList.EndDate = endDate;
                autoRecInfoList.EndWeek = endWeek;
                autoRecInfoList.EndTime = endTime;
                autoRecInfoList.AutoRecFlag = "1";
                autoRecInfoList.AutoRecMode = AutoRecMode;
                AutoRecInfoClass.Add(autoRecInfoList);
            }
            //显示录像设置信息
            DataSet ds = AutoRecInfoClass.SelectAll();
            dataGridView1.DataSource = ds.Tables["AutoRecInfoList"];
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除选中项并停止该自动录像？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                {
                    //删除数据库
                    AutoRecInfoClass.Delete(int.Parse(dgvr.Cells[0].Value.ToString()));
                    //停止自动录像（待完成）

                    //移除列表
                    dataGridView1.Rows.Remove(dgvr);
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
                SwitchDateClass.Add(switchDateList);
            }
            //显示录像设置信息
            DataSet ds = SwitchDateClass.SelectAll();
            dataGridView2.DataSource = ds.Tables["SwitchDateList"];
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确定删除选中项？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (DataGridViewRow dgvr in dataGridView2.SelectedRows)
                {
                    //删除数据库
                    SwitchDateClass.Delete(int.Parse(dgvr.Cells[0].Value.ToString()));
                   
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
            DataSet ds = RecPathClass.SelectAll();
            for (int i = 0; i < ds.Tables["RecPath"].Rows.Count; i++)
            {
                if (ds.Tables["RecPath"].Rows[i]["Usefor"].ToString() == "录像")
                {
                    string str1 = ds.Tables["RecPath"].Rows[i]["Disk"].ToString();
                    string[] disk = str1.Split(new char[] { ',' });
                    string capacityClear1 = ds.Tables["RecPath"].Rows[i]["CapacityClear"].ToString();
                    for (int j=0;j< checkedListBox1.Items.Count;j++)
                    {
                        for(int k=0;k<disk.Length;k++)
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
                        for(int k=0;k<disk.Length;k++)
                        {
                            if (disk[k] == checkedListBox2.Items[j].ToString().Split(new char[] { ':' })[0])
                                checkedListBox2.SetItemChecked(j, true);
                        }
                    }
                    comboBox1.Text = capacityClear1;
                }
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
            if(RecPathClass.Update(recPathList))
            { MessageBox.Show("保存成功！"); }
            else { MessageBox.Show("保存失败！"); }
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
            if(RecPathClass.Update(recPathList))
            { MessageBox.Show("保存成功！"); }
            else{ MessageBox.Show("保存成功！"); }
        }
        //设备授时
        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ManualRec.userIDList.Count; i++)
            {
                bool temp_bool=TimingSet.TimingSetByAuto(ManualRec.userIDList.ElementAt(i).Value);
            }
        }

        #region 用户操作
        //添加用户
        private void button15_Click(object sender, EventArgs e)
        {
            User_Add addForm = new User_Add();
            addForm.Show();
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
                userList.UserPermissionID = Guid.Parse(dgvr.Cells["权限等级"].Value.ToString());
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
    }
}
