using Client.Entities.AlarmEntity;
using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static DeviceBaseData.PlanData;

namespace PresetForm
{
    public partial class PresetForm : Form
    {
        ClassPlan classplan;
        AutoSizeForm ASF = new AutoSizeForm();

        private Guid temp_Add_AlarmDeviceID;//用于新增报警预案的报警器ID
        #region 窗体特效
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        #endregion

        #region 窗体随意拖动
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        private static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0X0112;
        public const int SC_MOVE = 0XF010;
        public const int HTCAPTION = 0X0002;
        #endregion
        public PresetForm()
        {
            InitializeComponent();
            ASF.controllInitializeSize(this);
            bool result1 = CommunicationClass.Init();
            if (result1)
            {
                MessageBox.Show("通讯初始化成功！");
                ////初始化设备数据
                //Class1 class1 = new Class1();
                //class1.Init();
                //报警预案数据初始化
                classplan = new ClassPlan();
                classplan.PlanInit();
            }
            else
            {
                MessageBox.Show("通讯初始化失败！");
            }
            DataLoad();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }
        private void DataLoad()
        {
            //窗体添加报警器项
            //listBox1.Items.Add("测试报警器1");
            listBox1.Items.Clear();
            if (ClassPlan.armAndDisarmList!=null)
            {
                for (int i = 0; i < ClassPlan.armAndDisarmList.Count; i++)
                {
                    listBox1.Items.Add(ClassPlan.armAndDisarmList.ElementAt(i).AlarmName);
                }
            }
            if (dataGridView1.DataSource!=null)
            {
                DataTable dt_1 = (DataTable)dataGridView1.DataSource;
                dt_1.Rows.Clear();
                dataGridView1.DataSource = dt_1;
            }
            else
            {
                dataGridView1.Rows.Clear();
            }
            if (dataGridView2.DataSource!=null)
            {
                DataTable dt_2 = (DataTable)dataGridView2.DataSource;
                dt_2.Rows.Clear();
                dataGridView1.DataSource = dt_2;
            }
            else
            {
                dataGridView2.Rows.Clear();
            }
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string temp_AlarmName = listBox1.SelectedItem.ToString();
                //PlanData.AlarmMessageForAll temp_AlarmMessageForAll = new PlanData.AlarmMessageForAll();
                var result = ClassPlan.temp_PlanDataforAll.Where(_ => _.Value.AlarmName == listBox1.SelectedItem.ToString());
                List<PlanData.AlarmMessageForAll> temp_AlarmMessageForAlls = result.Select(_ => _.Value).ToList();
                //getSelectedPlanList(temp_AlarmMessageForAlls, temp_AlarmName);
            }
        }
        public void getSelectedPlanList(List<PlanData.AlarmMessageForAll> temp_AlarmMessageForAlls,string AlarmName)
        {
            dataGridView1.Rows.Clear();
            if (temp_AlarmMessageForAlls.Count != 0)
            {
                for (int i = 0; i < temp_AlarmMessageForAlls.Count; i++)
                {
                    //DataGridViewRow dgvr = dataGridView1.Rows[dataGridView1.Rows.Add()];
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = temp_AlarmMessageForAlls[i].Description;
                    dataGridView1.Rows[index].Cells[1].Value = "报警预案";
                    switch (temp_AlarmMessageForAlls[i].TimeType)
                    {
                        case "1":
                            dataGridView1.Rows[index].Cells[2].Value = "日期";
                            break;
                        case "2":
                            dataGridView1.Rows[index].Cells[2].Value = "星期";
                            break;
                        case "3":
                            dataGridView1.Rows[index].Cells[2].Value = "全时段";
                            break;
                    }
                    dataGridView1.Rows[index].Cells[3].Value = temp_AlarmMessageForAlls[i].StartWeek;
                    dataGridView1.Rows[index].Cells[4].Value = temp_AlarmMessageForAlls[i].StartDate;
                    dataGridView1.Rows[index].Cells[5].Value = temp_AlarmMessageForAlls[i].StartTime;
                    dataGridView1.Rows[index].Cells[6].Value = temp_AlarmMessageForAlls[i].EndWeek;
                    dataGridView1.Rows[index].Cells[7].Value = temp_AlarmMessageForAlls[i].EndDate;
                    dataGridView1.Rows[index].Cells[8].Value = temp_AlarmMessageForAlls[i].EndTime;
                    dataGridView1.Rows[index].Cells[9].Value= temp_AlarmMessageForAlls[i].PlanDeviceID;
                } 
            }
            else
            {
            }
        }
        private string temp_PlanDeviceID = "";//用于查询相应联动ID的报警预案
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0)
            {
                dataGridView2.Rows.Clear();
                int index = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[index].Cells[9].Value != null)
                {
                    temp_PlanDeviceID = dataGridView1.Rows[index].Cells[9].Value.ToString();
                    var result = ClassPlan.linkageData.Where(_ => _.PlanDeviceID.ToString() == temp_PlanDeviceID);
                    List<LinkageData> temp_LinkageDataList = result.Select(_ => _).ToList();
                    for (int i = 0; i < temp_LinkageDataList.Count; i++)
                    {
                        int index_b = dataGridView2.Rows.Add();
                        switch (temp_LinkageDataList[i].LinakgeStage)
                        {
                            case 1:
                                dataGridView2.Rows[index_b].Cells[0].Value = "联动阶段";
                                break;
                            case 2:
                                dataGridView2.Rows[index_b].Cells[0].Value = "处置阶段";
                                break;
                            case 3:
                                dataGridView2.Rows[index_b].Cells[0].Value = "未处置阶段";
                                break;
                        }
                        dataGridView2.Rows[index_b].Cells[1].Value = temp_LinkageDataList[i].VideoDeviceID;
                        dataGridView2.Rows[index_b].Cells[2].Value = temp_LinkageDataList[i].PTZDeviceID;
                        dataGridView2.Rows[index_b].Cells[3].Value = temp_LinkageDataList[i].Preset;
                        dataGridView2.Rows[index_b].Cells[4].Value = temp_LinkageDataList[i].SwitchDeviceID;
                        dataGridView2.Rows[index_b].Cells[5].Value = temp_LinkageDataList[i].SwitchOperation;
                        dataGridView2.Rows[index_b].Cells[6].Value = temp_LinkageDataList[i].Switchoperationtimedelay;
                        dataGridView2.Rows[index_b].Cells[7].Value = temp_LinkageDataList[i].Videorecording;
                        dataGridView2.Rows[index_b].Cells[8].Value = temp_LinkageDataList[i].Alarmsound;
                        dataGridView2.Rows[index_b].Cells[9].Value = temp_LinkageDataList[i].Alarmsoundtimedelay;
                    }
                }
            }
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string temp_AlarmName = listBox1.SelectedItem.ToString();
                //PlanData.AlarmMessageForAll temp_AlarmMessageForAll = new PlanData.AlarmMessageForAll();
                var result = ClassPlan.temp_PlanDataforAll.Where(_ => _.Value.AlarmName == listBox1.SelectedItem.ToString());
                List<PlanData.AlarmMessageForAll> temp_AlarmMessageForAlls = result.Select(_ => _.Value).ToList();
                getSelectedPlanList(temp_AlarmMessageForAlls, temp_AlarmName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell == null)
            {
                MessageBox.Show("请选择需要删除的报警预案");
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            Guid Add_PlanDeviceID = new Guid(dataGridView1.Rows[index].Cells[9].Value.ToString());
            AlarmMessageForAll temp_AlarmMessageForAll = ClassPlan.temp_PlanDataforAll[Add_PlanDeviceID.ToString()];
            classplan.PlanDel(temp_AlarmMessageForAll);
           // ClassPlan.temp_PlanDataforAll.Remove(Add_PlanDeviceID.ToString());
            classplan.PlanInit();
            DataLoad();
            //PlanSet PS = new PlanSet();
            //PS.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //测试数据
            //PlanSet PS = new PlanSet(classplan, new Guid());
            //PS.Show();
            if (listBox1.SelectedItem != null)
            {
                string temp_AlarmName = listBox1.SelectedItem.ToString();
                ArmAndDisarmList[] L_ArmAndDisarmList = ClassPlan.armAndDisarmList.ToArray();
                ArmAndDisarmList temp_ArmAndDisarmList = Array.Find(L_ArmAndDisarmList, _ => _.AlarmName == temp_AlarmName);
                temp_Add_AlarmDeviceID = temp_ArmAndDisarmList.AlarmDeviceID;
                PlanSet PS = new PlanSet(classplan, temp_Add_AlarmDeviceID, new Guid("00000000-0000-0000-0000-000000000000"), new Guid(temp_ArmAndDisarmList.DeviceID.ToString()), temp_ArmAndDisarmList.AlarmType);
                PS.Show();
            }
            else
            {
                MessageBox.Show("请选择需要设置报警预案的报警器");
                return;
            }
        }

        private void PresetForm_Load(object sender, EventArgs e)
        {
            ASF.controlAutoSize(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //classplan = new ClassPlan();
            classplan.PlanInit();
            DataLoad();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell==null)
            {
                MessageBox.Show("请选择需要修改的报警预案");
                return;
            }
            int index = dataGridView1.CurrentCell.RowIndex;
            if (listBox1.SelectedItem  != null)
            {
                string temp_AlarmName = listBox1.SelectedItem.ToString();
                ArmAndDisarmList[] L_ArmAndDisarmList = ClassPlan.armAndDisarmList.ToArray();
                ArmAndDisarmList temp_ArmAndDisarmList = Array.Find(L_ArmAndDisarmList, _ => _.AlarmName == temp_AlarmName);
                temp_Add_AlarmDeviceID = temp_ArmAndDisarmList.AlarmDeviceID;
                Guid Add_PlanDeviceID =new Guid(dataGridView1.Rows[index].Cells[9].Value.ToString());
                PlanSet PS = new PlanSet(classplan, temp_Add_AlarmDeviceID, Add_PlanDeviceID, new Guid(temp_ArmAndDisarmList.DeviceID.ToString()), temp_ArmAndDisarmList.AlarmType);
                PS.Show();
            }
            else
            {
                MessageBox.Show("请选择需要设置报警预案的报警器");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell!=null)
            {
                if (radioButton1.Checked==false&& radioButton2.Checked==false&& radioButton3.Checked==false)
                {
                    MessageBox.Show("请选择具体的时间设置类型！");
                    return;
                }
                int index = dataGridView1.CurrentCell.RowIndex;
                AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                Pre_arrangedPlanning temp_Pre_arrangedPlanning = new Pre_arrangedPlanning();
                string temp_PlanDeviceID = dataGridView1.Rows[index].Cells[9].Value.ToString();
                temp_Pre_arrangedPlanning = ClassPlan.pre_arrangedPlanning.Find(_ => _.PlanDeviceID.ToString() == temp_PlanDeviceID);
                if (temp_Pre_arrangedPlanning == null)
                    return;
                temp_AlarmMessageForAll.StartDate = Start_data1.Value.Date.ToString("yyyy/MM/dd");
                temp_AlarmMessageForAll.StartWeek = Start_data1.Value.DayOfWeek.ToString();
                temp_AlarmMessageForAll.StartTime = Start_time1.Text;
                temp_AlarmMessageForAll.EndDate = Start_data2.Value.Date.ToString("yyyy/MM/dd");
                temp_AlarmMessageForAll.EndWeek = Start_data2.Value.DayOfWeek.ToString();
                temp_AlarmMessageForAll.EndTime = Start_time2.Text;
                temp_AlarmMessageForAll.Description = temp_Pre_arrangedPlanning.Description;
                temp_AlarmMessageForAll.DeviceID = temp_Pre_arrangedPlanning.DeviceID.ToString();
                temp_AlarmMessageForAll.DeviceType = temp_Pre_arrangedPlanning.DeviceType.ToString();
                temp_AlarmMessageForAll.Mark = temp_Pre_arrangedPlanning.Mark;
                temp_AlarmMessageForAll.PlanDeviceID = temp_Pre_arrangedPlanning.PlanDeviceID.ToString() ;
                temp_AlarmMessageForAll.PlanType = temp_Pre_arrangedPlanning.PlanType;
                temp_AlarmMessageForAll.PlanTypeID = temp_Pre_arrangedPlanning.PlanTypeID;
                if (radioButton1.Checked == true)
                {
                    temp_AlarmMessageForAll.TimeType = "1";
                }
                else if (radioButton2.Checked == true)
                {
                    temp_AlarmMessageForAll.TimeType = "2";
                }
                else if (radioButton3.Checked == true)
                {
                    temp_AlarmMessageForAll.TimeType = "3";
                }
                classplan.PlanRevise(temp_AlarmMessageForAll);
            }
            //classplan = new ClassPlan();
            classplan.PlanInit();//重新获取所有预案数据
            DataLoad();
        }

        private void button_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }

        private void PresetForm_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }
    }
}
