using DeviceBaseData;
using RecDll;
using RecDll.ole;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace InformationManagementDLL
{
    public partial class InformationManagement : Form
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

        int RecCount;//录像记录总数
        int PicCount;//图片记录总数
        int UserLogCount;//用户日志总数
        int RunLogCount;//运行日志总数
        List<string> DeviceIDs;//选中设备ID

        string errorInfo = "";
        public InformationManagement()
        {
            InitializeComponent();
            DeviceIDs = new List<string>();
            #region 录像管理初始化
            //获得记录总条数
            RecCount = RecFileClass.GetRecPageCount(new RecQueryStatement(),ref errorInfo);
            DataSet r_ds = RecFileClass.SelectRecInfo("1", "10",new RecQueryStatement(),ref errorInfo);
            if (r_ds == null) MessageBox.Show(errorInfo + ",获取录像管理信息失败！");
            dataGridView1.DataSource = r_ds;
            dataGridView1.DataMember = "RecFileList";
            label2.Text = "当前页" + dataGridView1.Rows.Count + "条记录/共" + RecCount + "条记录";
            //填充用户名
            List<string> r_usernames = RecFileClass.GetUserNames(ref errorInfo);
            comboBox3.DataSource = r_usernames;
            #endregion

            #region 图片管理初始化
            //获得记录总条数
            PicCount = RecPictureClass.GetPicPageCount(new PicQueryStatement(),ref errorInfo);
            //if (PicCount == -1) MessageBox.Show(errorInfo);
            DataSet p_ds = RecPictureClass.SelectPictureInfo("1", "10", new PicQueryStatement(), ref errorInfo);
            if(p_ds==null) MessageBox.Show(errorInfo+",获取图片管理信息失败！");
            dataGridView2.DataSource = p_ds;
            dataGridView2.DataMember = "RecPictureList";
            label13.Text = "当前页" + dataGridView2.Rows.Count + "条记录/共" + PicCount + "条记录";
            //填充用户名
            List<string> p_usernames = RecPictureClass.GetUserNames( ref errorInfo);
            comboBox5.DataSource = p_usernames;
            #endregion

            #region 用户日志初始化
            //获得记录总条数
            UserLogCount = UserLogClass.GetUserLogPageCount(new UserLogQueryStatement(), ref errorInfo);
            DataSet u_ds = UserLogClass.SelectUserLogInfo("1", "10", new UserLogQueryStatement(), ref errorInfo);
            if (u_ds == null) MessageBox.Show(errorInfo + ",获取用户日志信息失败！");
            dataGridView3.DataSource = u_ds;
            dataGridView3.DataMember = "UserLog";
            label17.Text = "当前页" + dataGridView3.Rows.Count + "条记录/共" + UserLogCount + "条记录";
            //填充用户名
            List<string> u_usernames = UserLogClass.GetUserNames(ref errorInfo);
            comboBox4.DataSource = u_usernames;
            //填充用户操作
            List<string> u_operation = UserLogClass.GetOperations(ref errorInfo);
            comboBox10.DataSource = u_operation;
            #endregion

            #region 运行日志初始化
            RunLogCount = RunLogClass.GetRunLogPageCount(new RunLogQueryStatement(), ref errorInfo);
            DataSet run_ds = RunLogClass.SelectRunLogInfo("1", "10", new RunLogQueryStatement(), ref errorInfo);
            if (run_ds == null) MessageBox.Show(errorInfo + ",获取运行日志信息失败！");
            dataGridView4.DataSource = run_ds;
            dataGridView4.DataMember = "RunLog";
            label23.Text = "当前页" + dataGridView4.Rows.Count + "条记录/共" + RunLogCount + "条记录";
            //填充日志类型
            List<string> run_operation = RunLogClass.GetOperations(ref errorInfo);
            comboBox8.DataSource = run_operation;
            #endregion


            #region 添加设备节点
            Thread th = new Thread(new ThreadStart(Init));
            th.IsBackground = true;
            th.Start();
            #endregion
            treeView1.ExpandAll();
        }
        #region 添加设备节点
        public void Init()
        {
            while (true)
            {
                if (Class1.IsDone)
                {
                    AddTreeNode();
                    break;
                }
            }
        }
        public delegate void AddTreeNodeDelegate();
        public void AddTreeNode()
        {
            if (treeView1.InvokeRequired)
            {
                AddTreeNodeDelegate d = AddTreeNode;
                treeView1.Invoke(d);
            }
            else
            {
                if (Class1.streamMediaList != null)
                {
                    for (int i = 0; i < Class1.streamMediaList.Count; i++)
                    {
                        TreeNode root1 = new TreeNode();
                        TreeNode root2 = new TreeNode();
                        root1.Text = Class1.streamMediaList[i].Name;
                        root1.Tag = Class1.streamMediaList[i].DeviceID;
                        root2.Text = Class1.streamMediaList[i].Name;
                        root2.Tag = Class1.streamMediaList[i].DeviceID;
                        treeView1.Nodes[0].Nodes[0].Nodes.Add(root1);
                        treeView1.Nodes[0].Nodes[1].Nodes.Add(root2);
                        //2、添加摄像机节点
                        for (int j = 0; j < Class1.cameraList.Count; j++)
                        {
                            if (Class1.cameraList[j].StreamMedia_DeviceID == Class1.streamMediaList[i].DeviceID)
                            {
                                TreeNode tn1 = new TreeNode();
                                tn1.Text = Class1.cameraList[j].VideoName;
                                tn1.Tag = Class1.cameraList[j].DeviceID;
                                TreeNode tn2 = new TreeNode();
                                tn2.Text = Class1.cameraList[j].VideoName;
                                tn2.Tag = Class1.cameraList[j].DeviceID;
                                root1.Nodes.Add(tn1);
                                root2.Nodes.Add(tn2);
                            }
                        }
                    }
                }
                //treeView1.ExpandAll();
            }
        }
        #endregion

        #region 操作按钮
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
       
        private void InformationManagement_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
        #endregion

       
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            if (tn.Level == 1)
            {
                switch (tn.Text)
                {
                    case "录像管理":
                        tabControl1.SelectedIndex = 0;
                        RecCount = RecFileClass.GetRecPageCount(new RecQueryStatement(), ref errorInfo);
                        DataSet r_ds = RecFileClass.SelectRecInfo("1", "10", new RecQueryStatement(), ref errorInfo);
                        if (r_ds == null) MessageBox.Show(errorInfo + ",获取录像管理信息失败！");
                        dataGridView1.DataSource = r_ds;
                        dataGridView1.DataMember = "RecFileList";
                        label2.Text = "当前页" + dataGridView1.Rows.Count + "条记录/共" + RecCount + "条记录";
                        break;
                    case "图片管理":
                        tabControl1.SelectedIndex = 1;
                        PicCount = RecPictureClass.GetPicPageCount(new PicQueryStatement(), ref errorInfo);
                        DataSet p_ds = RecPictureClass.SelectPictureInfo("1", "10", new PicQueryStatement(), ref errorInfo);
                        if (p_ds == null) MessageBox.Show(errorInfo + ",获取图片管理信息失败！");
                        dataGridView2.DataSource = p_ds;
                        dataGridView2.DataMember = "RecPictureList";
                        label13.Text = "当前页" + dataGridView2.Rows.Count + "条记录/共" + PicCount + "条记录";
                        break;
                    case "用户日志":
                        tabControl1.SelectedIndex = 2;
                        break;
                    case "运行日志":
                        tabControl1.SelectedIndex = 3;
                        break;
                }
            }
            else if (tn.Level == 2)
            {
                switch (tn.Parent.Text)
                {
                    case "录像管理":
                        tabControl1.SelectedIndex = 0;
                        RecChannelName.Text = tn.Text;
                        DeviceIDs.Clear();
                        //查询DVR下的摄像机？怎么查？将DVR/NVR下的设备列表全都查一遍
                        for(int i=0;i<tn.Nodes.Count;i++)
                        {
                            DeviceIDs.Add(tn.Nodes[i].Tag.ToString());
                        }
                        RecShow("1");
                        break;
                    case "图片管理":
                        tabControl1.SelectedIndex = 1;
                        PicChannelName.Text = tn.Text;
                        DeviceIDs.Clear();
                        for (int i = 0; i < tn.Nodes.Count; i++)
                        {
                            DeviceIDs.Add(tn.Nodes[i].Tag.ToString());
                        }
                        PictureShow("1");
                        break;
                    case "用户日志":
                        tabControl1.SelectedIndex = 2;
                        break;
                    case "运行日志":
                        tabControl1.SelectedIndex = 3;
                        break;
                }
            }
            else if (tn.Level == 3)
            {
                switch (tn.Parent.Parent.Text)
                {
                    case "录像管理":
                        tabControl1.SelectedIndex = 0;
                        RecChannelName.Text = tn.Text;
                        DeviceIDs.Clear();
                        DeviceIDs.Add(tn.Tag.ToString());
                        RecShow("1");
                        break;
                    case "图片管理":
                        tabControl1.SelectedIndex = 1;
                        PicChannelName.Text = tn.Text;
                        DeviceIDs.Clear();
                        DeviceIDs.Add(tn.Tag.ToString());
                        PictureShow("1");
                        break;
                }
            }
        }
        #region 录像信息
        /// <summary>
        /// 每页显示数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecShow(RecPageBtn.Text);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            RecShow("1");
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            int page = int.Parse(RecPageBtn.Text);
            if (page != 1)
                page--;
            RecShow(page.ToString());
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            int page = int.Parse(RecPageBtn.Text);
            int pageCount = RecCount / int.Parse(comboBox1.Text);
            if (RecCount % int.Parse(comboBox1.Text) != 0)
                pageCount++;
            if (page != pageCount)
                page++;
            RecShow(page.ToString());
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button7_Click(object sender, EventArgs e)
        {
            int pageCount = RecCount / int.Parse(comboBox1.Text);
            if (RecCount % int.Parse(comboBox1.Text) != 0)
                pageCount++;
            RecShow(pageCount.ToString());
        }
        /// <summary>
        /// 录像类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecShow(RecPageBtn.Text);
        }
        /// <summary>
        /// 操作用户
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecShow(RecPageBtn.Text);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button8_Click(object sender, EventArgs e)
        {
            RecShow(RecPageBtn.Text);
        }
        /// <summary>
        /// 查询录像信息
        /// </summary>
        public void RecShow(string currentPage)
        {
            RecQueryStatement qs = new RecQueryStatement();
            if (RecChannelName.Text != "")
                qs.CameraID = DeviceIDs;
            switch (comboBox2.Text)
            {
                case "手动录像":
                    qs.RecType = "1";
                    break;
                case "自动录像":
                    qs.RecType = "2";
                    break;
                case "报警录像":
                    qs.RecType = "3";
                    break;
            }
            if(comboBox3.Text!="")
            qs.UserName = comboBox3.Text;
            if (checkBox1.Checked)
                qs.RecStartDate = page1_startDate.Text.ToString();
            if (checkBox4.Checked)
                qs.RecStartTime = page1_startTime.Text.ToString();
            if (checkBox2.Checked)
                qs.RecEndDate = page1_endDate.Text.ToString();
            if (checkBox3.Checked)
                qs.RecEndTime = page1_endTime.Text.ToString();
            string errorInfo = "";
            RecCount = RecFileClass.GetRecPageCount(qs,ref errorInfo);
            if(RecCount==-1)
            {
                MessageBox.Show(errorInfo);
                return;
            }
            DataSet ds = RecFileClass.SelectRecInfo(currentPage, comboBox1.Text, qs,ref errorInfo);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "RecFileList";
            RecPageBtn.Text = currentPage;
            label2.Text = "当前页" + dataGridView1.Rows.Count + "条记录 / 共" + RecCount + "条记录";
        }

        #endregion

        #region 图片信息
        /// <summary>
        /// 查询图片信息
        /// </summary>
        public void PictureShow(string currentPage)
        {
            string errorInfo = "";
            PicQueryStatement qs = new PicQueryStatement();
            if (RecChannelName.Text != "")
                qs.CameraID = DeviceIDs;
            if (comboBox5.Text != "")
                qs.UserName = comboBox3.Text;
            if (checkBox8.Checked)
                qs.RecStartDate = dateTimePicker2.Text.ToString();
            if (checkBox6.Checked)
                qs.RecStartTime = maskedTextBox2.Text.ToString();
            if (checkBox7.Checked)
                qs.RecEndDate = dateTimePicker1.Text.ToString();
            if (checkBox5.Checked)
                qs.RecEndTime = maskedTextBox1.Text.ToString();

            DataSet ds = RecPictureClass.SelectPictureInfo(currentPage, comboBox6.Text, qs, ref errorInfo);
            if(ds==null) MessageBox.Show(errorInfo);
            PicCount = RecPictureClass.GetPicPageCount(qs,ref errorInfo);
            dataGridView2.DataSource = ds;
            dataGridView2.DataMember = "RecPictureList";
            PicPageBtn.Text = currentPage;
            label13.Text = "当前页" + dataGridView2.Rows.Count + "条记录 / 共" + RecCount + "条记录";
        }
        /// <summary>
        /// 每页显示数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            PictureShow(PicPageBtn.Text);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button13_Click(object sender, EventArgs e)
        {
            PictureShow("1");
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button12_Click(object sender, EventArgs e)
        {
            int page = int.Parse(PicPageBtn.Text);
            if (page != 1)
                page--;
            PictureShow(page.ToString());
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button10_Click(object sender, EventArgs e)
        {
            int page = int.Parse(PicPageBtn.Text);
            int pageCount = PicCount / int.Parse(comboBox6.Text);
            if (PicCount % int.Parse(comboBox6.Text) != 0)
                pageCount++;
            if (page != pageCount)
                page++;
            PictureShow(page.ToString());
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button9_Click(object sender, EventArgs e)
        {
            int pageCount = PicCount / int.Parse(comboBox6.Text);
            if (PicCount % int.Parse(comboBox6.Text) != 0)
                pageCount++;
            PictureShow(pageCount.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PictureShow(PicPageBtn.Text);
        }
        #endregion

        #region 用户日志
        /// <summary>
        /// 查询用户日志
        /// </summary>
        public void UserLogShow(string currentPage)
        {
            UserLogQueryStatement qs = new UserLogQueryStatement();
            if (comboBox4.Text != "")
                qs.Name = comboBox4.Text;
            if (comboBox10.Text != "")
                qs.Operation = comboBox10.Text;
            if (checkBox12.Checked)
                qs.StartDate = dateTimePicker4.Text.ToString();
            if (checkBox10.Checked)
                qs.StartTime = maskedTextBox4.Text.ToString();
            if (checkBox11.Checked)
                qs.EndDate = dateTimePicker3.Text.ToString();
            if (checkBox9.Checked)
                qs.EndTime = maskedTextBox3.Text.ToString();
            string errorInfo = "";
            DataSet ds = UserLogClass.SelectUserLogInfo(currentPage, comboBox7.Text, qs,ref errorInfo);
            if (ds == null) MessageBox.Show(errorInfo);
            UserLogCount = UserLogClass.GetUserLogPageCount(qs, ref errorInfo);
            dataGridView3.DataSource = ds;
            dataGridView3.DataMember = "UserLog";
            UserPageBtn.Text = currentPage;
            label17.Text = "当前页" + dataGridView3.Rows.Count + "条记录 / 共" + UserLogCount + "条记录";
        }
        /// <summary>
        /// 每页显示数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            UserLogShow(UserPageBtn.Text);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button18_Click(object sender, EventArgs e)
        {
            UserLogShow("1");
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button17_Click(object sender, EventArgs e)
        {
            int page = int.Parse(UserPageBtn.Text);
            if (page != 1)
                page--;
            UserLogShow(page.ToString());
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button15_Click(object sender, EventArgs e)
        {
            int page = int.Parse(UserPageBtn.Text);
            int pageCount = UserLogCount / int.Parse(comboBox7.Text);
            if (UserLogCount % int.Parse(comboBox7.Text) != 0)
                pageCount++;
            if (page != pageCount)
                page++;
            UserLogShow(page.ToString());

        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button14_Click(object sender, EventArgs e)
        {
            int pageCount = UserLogCount / int.Parse(comboBox7.Text);
            if (UserLogCount % int.Parse(comboBox7.Text) != 0)
                pageCount++;
            UserLogShow(pageCount.ToString());
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button11_Click(object sender, EventArgs e)
        {
            UserLogShow(UserPageBtn.Text);
        }
        #endregion

        #region 运行日志
        /// <summary>
        /// 查询运行日志
        /// </summary>
        public void RunLogShow(string currentPage)
        {
            RunLogQueryStatement qs = new RunLogQueryStatement();
            if (comboBox4.Text != "")
                qs.Operation = comboBox8.Text;
            if (comboBox10.Text != "")
                qs.IsAbnormal = comboBox11.Text;
            if (checkBox12.Checked)
                qs.StartDate = dateTimePicker6.Text.ToString();
            if (checkBox10.Checked)
                qs.StartTime = maskedTextBox6.Text.ToString();
            if (checkBox11.Checked)
                qs.EndDate = dateTimePicker5.Text.ToString();
            if (checkBox9.Checked)
                qs.EndTime = maskedTextBox5.Text.ToString();
            string errorInfo = "";
            DataSet ds = RunLogClass.SelectRunLogInfo(currentPage, comboBox9.Text, qs,ref errorInfo);
            if (ds == null) MessageBox.Show(errorInfo);
            RunLogCount = RunLogClass.GetRunLogPageCount(qs, ref errorInfo);
            dataGridView4.DataSource = ds;
            dataGridView4.DataMember = "RunLog";
            RunPageBtn.Text = currentPage;
            label23.Text = "当前页" + dataGridView4.Rows.Count + "条记录 / 共" + RunLogCount + "条记录";
        }
        /// <summary>
        /// 每页显示数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            RunLogShow(RunPageBtn.Text);
        }
        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button24_Click(object sender, EventArgs e)
        {
            RunLogShow("1");
        }
        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button23_Click(object sender, EventArgs e)
        {
            int page = int.Parse(RunPageBtn.Text);
            if (page != 1)
                page--;
            RunLogShow(page.ToString());
        }
        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button21_Click(object sender, EventArgs e)
        {
            int page = int.Parse(RunPageBtn.Text);
            int pageCount = RunLogCount / int.Parse(comboBox9.Text);
            if (RunLogCount % int.Parse(comboBox9.Text) != 0)
                pageCount++;
            if (page != pageCount)
                page++;
            RunLogShow(page.ToString());
        }
        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button20_Click(object sender, EventArgs e)
        {
            int pageCount = RunLogCount / int.Parse(comboBox9.Text);
            if (RunLogCount % int.Parse(comboBox9.Text) != 0) 
                pageCount++;
            RunLogShow(pageCount.ToString());
        }

        private void button19_Click(object sender, EventArgs e)
        {
            RunLogShow(RunPageBtn.Text);
        }

        #endregion

        //打开录像文件
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if(dataGridView1.Columns[e.ColumnIndex].Name== "录像地址")
            {
                string path = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if(File.Exists(path))
                {
                    System.Diagnostics.Process.Start(@".\VMPlayer\VMPlayer.exe", path);
                }
                else
                {
                    MessageBox.Show("文件已不存在！");
                }
            }
        }
        //打开图像文件
        private void dataGridView2_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex == -1) return;
            if (dataGridView2.Columns[e.ColumnIndex].Name == "截图地址")
            {
                string path = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (File.Exists(path))
                {
                    System.Diagnostics.Process.Start(path);
                }
                else
                {
                    MessageBox.Show("文件已不存在！");
                }
            }
        }
    }
}
