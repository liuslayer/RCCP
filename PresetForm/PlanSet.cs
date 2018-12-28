using Client.Entities;
using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresetForm
{
    public partial class PlanSet : Form
    {
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
        AutoSizeForm ASF = new AutoSizeForm();
        ClassPlan classplan;
        private static PlanData.AlarmMessageForAll temp_AlarmMessageForAll = new PlanData.AlarmMessageForAll();//储存当前设备的预案设置
        private static Guid Add_AlarmDeviceID;
        private static Guid Add_PlanDeviceID;//用于添加报警预案的预案ID
        private static Guid Add_DeviceID;//设备ID
        private static int Add_DeviceType;//设备类型
        private static bool Bool_Add = false;//判断该预案是否已经保存，若保存，则数据更新
        public class Trigger
        {
            public string VideoNumber;//分屏号(1)
            public List<string> CameraID;//摄像机ID
            public List<string> CameraName;//摄像机名称
            public List<string> PresetName_ID;//预置位ID
        }
        public class Video_Preset
        {
            public string CameraID;//摄像机ID
            public string CameraName;//摄像机名称
            public List<string> PresetName_ID=new List<string>();//所有的预置位ID
            public bool isUse=false;//该摄像机是否已被添加成联动摄像机
            public string PresetName_ID_Now;//目前正在使用的预置位
        }
        //存储与数据库对应的数据（DeviceID,显示屏与预置位)
        public Dictionary<string, Trigger> dic_Trigger = new Dictionary<string, Trigger>();
        //存储于数据库对应的数据(CameraID,预置位)
        public static Dictionary<string, Video_Preset> dic_Video_Preset = new Dictionary<string, Video_Preset>();
        //private ComboBox cmb = new ComboBox();//预置位下拉框
        string PicPath = @".\images\AlarmSetting\";

        public PlanSet(ClassPlan temp_ClassPlan,Guid temp_Add_AlarmDeviceID,Guid temp_PlanDeviceID,Guid temp_Add_DeviceID,int temp_DeviceType)
        {
            InitializeComponent();
            ASF.controllInitializeSize(this);
            classplan = temp_ClassPlan;
            Add_AlarmDeviceID = temp_Add_AlarmDeviceID;
            Add_PlanDeviceID = temp_PlanDeviceID;
            Add_DeviceID = temp_Add_DeviceID;
            Add_DeviceType = temp_DeviceType;
            temp_AlarmMessageForAll.Trigger_LinkageData = new Client.Entities.AlarmEntity.LinkageData();
            temp_AlarmMessageForAll.Disposal_LinkageData = new Client.Entities.AlarmEntity.LinkageData();
            temp_AlarmMessageForAll.Untreated_LinkageData = new Client.Entities.AlarmEntity.LinkageData();
            if (Add_PlanDeviceID == new Guid("00000000-0000-0000-0000-000000000000"))
            {
                Add_PlanDeviceID = Guid.NewGuid();
                temp_AlarmMessageForAll.PlanDeviceID = Add_PlanDeviceID.ToString();
                Bool_Add = false;
            }
            else
            {
                temp_AlarmMessageForAll = ClassPlan.temp_PlanDataforAll[Add_PlanDeviceID.ToString()];
                Bool_Add = true;
                DataFresh();
            }
            #region
            //----------------------测试数据-------------------------------------------
            //StreamMediaList temp_StreamMediaList = new StreamMediaList();
            //temp_StreamMediaList.DeviceID = new Guid();
            //temp_StreamMediaList.VideoIP = "192.168.1.64";
            //temp_StreamMediaList.Name = "测试NVR";
            //CameraList temp_CameraList_1 = new CameraList();
            //temp_CameraList_1.StreamMedia_DeviceID = temp_StreamMediaList.DeviceID;
            //temp_CameraList_1.DeviceID= Guid.NewGuid();
            //temp_CameraList_1.VideoName = "测试摄像机";
            //CameraList temp_CameraList_2 = new CameraList();
            //temp_CameraList_2.StreamMedia_DeviceID = temp_StreamMediaList.DeviceID;
            //temp_CameraList_2.DeviceID = Guid.NewGuid();
            //temp_CameraList_2.VideoName = "测试摄像机2";
            //ClassPlan.streamMediaList = new List<StreamMediaList>();
            //ClassPlan.cameraList = new List<CameraList>();
            //ClassPlan.streamMediaList.Add(temp_StreamMediaList);
            //ClassPlan.cameraList.Add(temp_CameraList_1);
            //ClassPlan.cameraList.Add(temp_CameraList_2);
            for (int i = 0; i < ClassPlan.cameraList.Count; i++)
            {
                Video_Preset temp_Video_Preset = new Video_Preset();
                temp_Video_Preset.CameraID = ClassPlan.cameraList[i].DeviceID.ToString();
                temp_Video_Preset.CameraName = ClassPlan.cameraList[i].VideoName;
                temp_Video_Preset.PresetName_ID.Add("预置位1");
                temp_Video_Preset.PresetName_ID.Add("预置位2");
                temp_Video_Preset.PresetName_ID.Add("预置位3");
                if (!dic_Video_Preset.ContainsKey(temp_Video_Preset.CameraID))
                {
                    dic_Video_Preset.Add(temp_Video_Preset.CameraID, temp_Video_Preset);
                }
            }
            //-----------------------end------------------------------------------------
            #endregion
            if (classplan==null)
            {
                MessageBox.Show("预案数据为空");
                //return;
            }
            //给"显示区域"添加显示屏
            for (int i = 1; i <= 16; i++)
            {
                DataGridViewRow Dgvr = this.dataGridView2.Rows[this.dataGridView2.Rows.Add()];
                Dgvr.Cells[0].Value = "分屏" + i;
            }
            comboBox1.SelectedIndex = 0;
            //处理掉DataGridViewComboBoxColumn绑定数据源后,再绑定到DataTable中的Column时,提示"System.ArgumentException:DagaGridViewComboBoxCell值无效"的错误
            //this.dataGridView1.DataError += delegate (object sender, DataGridViewDataErrorEventArgs e) { };
            Init();
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }
        public void Init()
        {
            //if (classplan!=null)
            //{
                for (int i = 0; i < ClassPlan.streamMediaList.Count; i++)
                {
                    //要添加的节点名称为空，即文本框是否为空
                    if (string.IsNullOrEmpty(ClassPlan.streamMediaList[i].Name.Trim()))
                    {
                        //MessageBox.Show("要添加的节点名称不能为空！");
                        return;
                    }
                    //添加根节点
                    TreeNode root = new TreeNode();
                    root.Text = ClassPlan.streamMediaList[i].Name;
                    root.Tag = ClassPlan.streamMediaList[i].DeviceID;
                    treeView1.Nodes.Add(root);
                    //2、添加摄像机节点
                    for (int j = 0; j < ClassPlan.cameraList.Count; j++)
                    {
                        if (ClassPlan.cameraList[j].StreamMedia_DeviceID == ClassPlan.streamMediaList[i].DeviceID)
                        {
                            TreeNode tn = new TreeNode();
                            tn.Text = ClassPlan.cameraList[j].VideoName;
                            tn.Tag = ClassPlan.cameraList[j].DeviceID;
                            root.Nodes.Add(tn);
                        }
                    }
                    //txtNodeName.Text = "";
                }
                treeView1.ExpandAll();
            //}
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            rightArrowBtn2_MouseClick(null, null);
        }
        private void rightArrowBtn2_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0 && dataGridView2.SelectedRows.Count != 0)
            {
                int index_1 = dataGridView1.CurrentRow.Index;
                int index_2 = dataGridView2.CurrentRow.Index;
                string temp_CameraID = dataGridView1.Rows[index_1].Cells[1].Tag.ToString();
                if (dic_Video_Preset[temp_CameraID].isUse == false)//该摄像机并未绑定联动数据
                {
                    if (dataGridView2.Rows[index_2].Cells[1].Value == null)
                    {
                        dataGridView2.Rows[index_2].Cells[1].Value = dataGridView1.Rows[index_1].Cells[1].Value;
                        dataGridView2.Rows[index_2].Cells[1].Tag = temp_CameraID;
                    }
                    else
                    {
                        dataGridView2.Rows[index_2].Cells[1].Value = dataGridView2.Rows[index_2].Cells[1].Value + "," + dataGridView1.Rows[index_1].Cells[1].Value;
                        dataGridView2.Rows[index_2].Cells[1].Tag = dataGridView2.Rows[index_2].Cells[1].Tag + "," + dataGridView1.Rows[index_1].Cells[1].Tag;
                    }
                    dic_Video_Preset[temp_CameraID].PresetName_ID_Now = dataGridView1.Rows[index_1].Cells[2].Value.ToString();
                    dic_Video_Preset[temp_CameraID].isUse = true;//该摄像机成功绑定联动数据

                    //判断每个分屏的视频是否超过了2个
                    string[] Snum = dataGridView2.Rows[index_2].Cells[1].Value.ToString().Split(new char[] { ',' });
                    if (Snum.Length >= 2)
                    {
                        //Rectangle rect = dataGridView2.GetCellDisplayRectangle(2, d2.Index, false);
                        //DisplayPic(dataGridView2, rect, d2.Index);
                        dataGridView2.Rows[index_2].Cells["pic_wheel"].Value = PicPath + @"巡.png";
                    }
                }
                else
                {
                    MessageBox.Show("该摄像机已绑定联动数据，请选择其他设备！");
                }
            }
            else
            {
                MessageBox.Show("请选择要添加的视频以及显示屏！");
            }
        }

        private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            rightArrowBtn1_MouseClick(null, null);
        }
        private void rightArrowBtn1_MouseClick(object sender, MouseEventArgs e)
        {
            if (treeView1.SelectedNode.Tag!=null)
            {
                string temp_CameraID = treeView1.SelectedNode.Tag.ToString();
                //如果字典中包含选取的摄像机预置位信息
                if (dic_Video_Preset.Keys.Contains(temp_CameraID))
                {
                    Video_Preset temp_Video_Preset = dic_Video_Preset[temp_CameraID];
                    AddCameraPreset(temp_Video_Preset);
                }
            }
           
        }
        private void AddCameraPreset(Video_Preset temp_Video_Preset)
        {
            bool result = false;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {      if (temp_Video_Preset.CameraID == dataGridView1.Rows[i].Cells[1].Tag.ToString())
                {
                    MessageBox.Show("该摄像机已被添加！");
                    result = true;
                }
            }
            if (!result)
            {
                int index_a = dataGridView1.Rows.Add();
                dataGridView1.Rows[index_a].Cells[0].Value = index_a + 1;
                dataGridView1.Rows[index_a].Cells[1].Value = temp_Video_Preset.CameraName;
                dataGridView1.Rows[index_a].Cells[1].Tag = temp_Video_Preset.CameraID;
                DataGridViewRow row = this.dataGridView1.Rows[index_a];
                DataGridViewComboBoxCell temp_ComboBox = row.Cells[2] as DataGridViewComboBoxCell;
                DataTable dt = new DataTable();
                //temp_ComboBox.DataSource = dt;
                dt.Columns.Add("Preset");
                temp_ComboBox.DisplayMember = "Preset";
                if (temp_ComboBox!=null)
                {
                    for (int i = 0; i < temp_Video_Preset.PresetName_ID.Count; i++)
                    {
                        //DataRow dr = dt.NewRow();
                        //dr[0] = temp_Video_Preset.PresetName_ID.ElementAt(i);
                        //dt.Rows.Add(dr);
                        //temp_ComboBox.Items.Add(temp_Video_Preset.PresetName_ID.ElementAt(i));
                        //temp_ComboBox.Items.Add(temp_Video_Preset.PresetName_ID.ElementAt(i));
                        ((DataGridViewComboBoxCell)dataGridView1.Rows[index_a].Cells[2]).Items.Add(temp_Video_Preset.PresetName_ID.ElementAt(i));
                        dataGridView1.Rows[index_a].Cells[2].ReadOnly = false;
                    }
                    //temp_ComboBox.DisplayMember = "预置位";
                    //temp_ComboBox.ValueMember = "ID";
                }
                dataGridView1.Rows[index_a].Cells[2].Value = temp_Video_Preset.PresetName_ID.ElementAt(0);//默认选择第一项的值
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            temp_AlarmMessageForAll.PlanType = 1;//报警预案:1
            temp_AlarmMessageForAll.PlanTypeID = Add_AlarmDeviceID.ToString();
            temp_AlarmMessageForAll.DeviceID = Add_DeviceID.ToString();
            temp_AlarmMessageForAll.DeviceType = Add_DeviceType.ToString();
            if (comboBox1.Text=="联动阶段")
            {
                temp_AlarmMessageForAll.Trigger_LinkageData.AlarmDeviceID = Add_AlarmDeviceID;
                temp_AlarmMessageForAll.Trigger_LinkageData.PlanDeviceID = Add_PlanDeviceID;
                if (temp_AlarmMessageForAll.Trigger_LinkageData.LinkageID== new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    temp_AlarmMessageForAll.Trigger_LinkageData.LinkageID = Guid.NewGuid();
                }
                temp_AlarmMessageForAll.Trigger_LinkageData.LinakgeStage = 1;
                temp_AlarmMessageForAll.Trigger_LinkageData.Mark = textBox1.Text;//用于记录报警停止闪烁时间
                if (radioButton1.Checked == true)
                {
                    temp_AlarmMessageForAll.Trigger_LinkageData.Reset = true;
                }
                else if(radioButton2.Checked==true)
                {
                    temp_AlarmMessageForAll.Trigger_LinkageData.Reset = false;
                }
                //开关量数据赋值
                temp_AlarmMessageForAll.Trigger_LinkageData.Switchoperationtimedelay = textBox12.Text;
                //报警声音数据赋值
                temp_AlarmMessageForAll.Trigger_LinkageData.Alarmsoundtimedelay = textBox4.Text;
                if (textBox4.Text == "0")
                {
                    temp_AlarmMessageForAll.Trigger_LinkageData.Alarmsound = "无";
                }
                else
                {
                    temp_AlarmMessageForAll.Trigger_LinkageData.Alarmsound = "有";
                }
                temp_AlarmMessageForAll.Trigger_LinkageData.Videorecording = textBox6.Text;

                string temp_VideoDeviceID = "";
                string temp_Video_Preset = "";
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (temp_VideoDeviceID == "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                    else if (temp_VideoDeviceID != "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = temp_VideoDeviceID + "," + dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                }
                if (temp_VideoDeviceID != "")
                {
                    string[] Preset_CameraID = temp_VideoDeviceID.Split(',');
                    for (int i = 0; i < Preset_CameraID.Length; i++)
                    {
                        if (temp_Video_Preset == "")
                        {
                            temp_Video_Preset = dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                        else
                        {
                            temp_Video_Preset = temp_Video_Preset + "," + dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                    }
                    temp_AlarmMessageForAll.Trigger_LinkageData.VideoDeviceID = temp_VideoDeviceID;
                }
                temp_AlarmMessageForAll.Trigger_LinkageData.Preset = temp_Video_Preset;
            }
            else if (comboBox1.Text == "处置阶段")
            {
                temp_AlarmMessageForAll.Disposal_LinkageData.AlarmDeviceID = Add_AlarmDeviceID;
                temp_AlarmMessageForAll.Disposal_LinkageData.PlanDeviceID = Add_PlanDeviceID;
                if (temp_AlarmMessageForAll.Disposal_LinkageData.LinkageID == new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    temp_AlarmMessageForAll.Disposal_LinkageData.LinkageID = Guid.NewGuid();
                }
                temp_AlarmMessageForAll.Disposal_LinkageData.LinakgeStage = 2;
                temp_AlarmMessageForAll.Disposal_LinkageData.Mark = textBox1.Text;//用于记录报警停止闪烁时间
                if (radioButton1.Checked == true)
                {
                    temp_AlarmMessageForAll.Disposal_LinkageData.Reset = true;
                }
                else if (radioButton2.Checked == true)
                {
                    temp_AlarmMessageForAll.Disposal_LinkageData.Reset = false;
                }
                //开关量数据赋值
                temp_AlarmMessageForAll.Disposal_LinkageData.Switchoperationtimedelay = textBox12.Text;
                //报警声音数据赋值
                temp_AlarmMessageForAll.Disposal_LinkageData.Alarmsoundtimedelay = textBox4.Text;
                if (textBox4.Text == "0")
                {
                    temp_AlarmMessageForAll.Disposal_LinkageData.Alarmsound = "无";
                }
                else
                {
                    temp_AlarmMessageForAll.Disposal_LinkageData.Alarmsound = "有";
                }
                temp_AlarmMessageForAll.Disposal_LinkageData.Videorecording = textBox6.Text;

                string temp_VideoDeviceID = "";
                string temp_Video_Preset = "";
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (temp_VideoDeviceID == "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                    else if (temp_VideoDeviceID != "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = temp_VideoDeviceID + "," + dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                }
                if (temp_VideoDeviceID != "")
                {
                    string[] Preset_CameraID = temp_VideoDeviceID.Split(',');
                    for (int i = 0; i < Preset_CameraID.Length; i++)
                    {
                        if (temp_Video_Preset == "")
                        {
                            temp_Video_Preset = dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                        else
                        {
                            temp_Video_Preset = temp_Video_Preset + "," + dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                    }
                    temp_AlarmMessageForAll.Disposal_LinkageData.VideoDeviceID = temp_VideoDeviceID;
                }
                temp_AlarmMessageForAll.Disposal_LinkageData.Preset = temp_Video_Preset;
            }
            else if (comboBox1.Text == "未处置阶段")
            {
                temp_AlarmMessageForAll.Untreated_LinkageData.AlarmDeviceID = Add_AlarmDeviceID;
                temp_AlarmMessageForAll.Untreated_LinkageData.PlanDeviceID = Add_PlanDeviceID;
                if (temp_AlarmMessageForAll.Untreated_LinkageData.LinkageID == new Guid("00000000-0000-0000-0000-000000000000"))
                {
                    temp_AlarmMessageForAll.Untreated_LinkageData.LinkageID = Guid.NewGuid();
                }
                temp_AlarmMessageForAll.Untreated_LinkageData.LinakgeStage = 3;
                temp_AlarmMessageForAll.Untreated_LinkageData.Mark = textBox1.Text;//用于记录报警停止闪烁时间
                if (radioButton1.Checked == true)
                {
                    temp_AlarmMessageForAll.Untreated_LinkageData.Reset = true;
                }
                else if (radioButton2.Checked == true)
                {
                    temp_AlarmMessageForAll.Untreated_LinkageData.Reset = false;
                }
                //开关量数据赋值
                temp_AlarmMessageForAll.Untreated_LinkageData.Switchoperationtimedelay = textBox12.Text;
                //报警声音数据赋值
                temp_AlarmMessageForAll.Untreated_LinkageData.Alarmsoundtimedelay = textBox4.Text;
                if (textBox4.Text=="0")
                {
                    temp_AlarmMessageForAll.Untreated_LinkageData.Alarmsound = "无";
                }
                else
                {
                    temp_AlarmMessageForAll.Untreated_LinkageData.Alarmsound = "有";
                }
                temp_AlarmMessageForAll.Untreated_LinkageData.Videorecording = textBox6.Text;

                string temp_VideoDeviceID = "";
                string temp_Video_Preset = "";
                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    if (temp_VideoDeviceID == "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                    else if (temp_VideoDeviceID != "" && dataGridView2.Rows[i].Cells[1].Value != null)
                    {
                        temp_VideoDeviceID = temp_VideoDeviceID + "," + dataGridView2.Rows[i].Cells[1].Tag.ToString();
                    }
                }
                if (temp_VideoDeviceID != "")
                {
                    string[] Preset_CameraID = temp_VideoDeviceID.Split(',');
                    for (int i = 0; i < Preset_CameraID.Length; i++)
                    {
                        if (temp_Video_Preset == "")
                        {
                            temp_Video_Preset = dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                        else
                        {
                            temp_Video_Preset = temp_Video_Preset + "," + dic_Video_Preset[Preset_CameraID[i]].PresetName_ID_Now;
                        }
                    }
                    temp_AlarmMessageForAll.Untreated_LinkageData.VideoDeviceID = temp_VideoDeviceID;
                }
                temp_AlarmMessageForAll.Untreated_LinkageData.Preset = temp_Video_Preset;
            }
            //temp_AlarmMessageForAll.StartDate = dataForOne.StartDate;
            //temp_AlarmMessageForAll.StartTime = dataForOne.StartTime;
            //temp_AlarmMessageForAll.StartWeek = dataForOne.StartWeek;
            //temp_AlarmMessageForAll.TimeType = dataForOne.TimeType;
            //temp_AlarmMessageForAll.EndDate = dataForOne.EndDate;
            //temp_AlarmMessageForAll.EndTime = dataForOne.EndTime;
            //temp_AlarmMessageForAll.EndWeek = dataForOne.EndWeek;
            //temp_AlarmMessageForAll.Description = dataForOne.Description;
            //temp_AlarmMessageForAll.Mark = dataForOne.Mark;
            DataFresh();
        }

        private void PlanSet_Load(object sender, EventArgs e)
        {
            ASF.controlAutoSize(this);
        }
        private void Pre_arrangedPlanningAdd()
        {
            classplan.PlanAdd(temp_AlarmMessageForAll);
        }
        private void DataFresh()
        {
            disposal_dgv4.Rows.Clear();
            if (temp_AlarmMessageForAll.Trigger_LinkageData != null)
            {
                int index_a = disposal_dgv4.Rows.Add();
                disposal_dgv4.Rows[index_a].Cells[0].Value = "联动阶段";
                if (temp_AlarmMessageForAll.Trigger_LinkageData.VideoDeviceID == ""|| temp_AlarmMessageForAll.Trigger_LinkageData.VideoDeviceID ==null)
                {
                    disposal_dgv4.Rows[index_a].Cells[1].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_a].Cells[1].Value = temp_AlarmMessageForAll.Trigger_LinkageData.VideoDeviceID;
                }
                if (temp_AlarmMessageForAll.Trigger_LinkageData.PTZDeviceID == ""|| temp_AlarmMessageForAll.Trigger_LinkageData.PTZDeviceID ==null)
                {
                    disposal_dgv4.Rows[index_a].Cells[2].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_a].Cells[2].Value = temp_AlarmMessageForAll.Trigger_LinkageData.PTZDeviceID;
                }
                if (temp_AlarmMessageForAll.Trigger_LinkageData.Preset == ""|| temp_AlarmMessageForAll.Trigger_LinkageData.Preset ==null)
                {
                    disposal_dgv4.Rows[index_a].Cells[3].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_a].Cells[3].Value = temp_AlarmMessageForAll.Trigger_LinkageData.Preset;
                }
                disposal_dgv4.Rows[index_a].Cells[4].Value = temp_AlarmMessageForAll.Trigger_LinkageData.SwitchDeviceID;
                disposal_dgv4.Rows[index_a].Cells[5].Value = temp_AlarmMessageForAll.Trigger_LinkageData.SwitchOperation;
                disposal_dgv4.Rows[index_a].Cells[6].Value = temp_AlarmMessageForAll.Trigger_LinkageData.Switchoperationtimedelay;
                disposal_dgv4.Rows[index_a].Cells[7].Value = temp_AlarmMessageForAll.Trigger_LinkageData.Videorecording;
                disposal_dgv4.Rows[index_a].Cells[8].Value = temp_AlarmMessageForAll.Trigger_LinkageData.Alarmsound;
                disposal_dgv4.Rows[index_a].Cells[9].Value = temp_AlarmMessageForAll.Trigger_LinkageData.Alarmsoundtimedelay;
                if (temp_AlarmMessageForAll.Trigger_LinkageData.Reset==true)
                {
                    disposal_dgv4.Rows[index_a].Cells[10].Value = "是";
                }
                else
                {
                    disposal_dgv4.Rows[index_a].Cells[10].Value = "否";
                }
            }
            if (temp_AlarmMessageForAll.Disposal_LinkageData!=null)
            {
                int index_b = disposal_dgv4.Rows.Add();
                disposal_dgv4.Rows[index_b].Cells[0].Value = "处置阶段";
                if (temp_AlarmMessageForAll.Disposal_LinkageData.VideoDeviceID == ""|| temp_AlarmMessageForAll.Disposal_LinkageData.VideoDeviceID == null)
                {
                    disposal_dgv4.Rows[index_b].Cells[1].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_b].Cells[1].Value = temp_AlarmMessageForAll.Disposal_LinkageData.VideoDeviceID;
                }
                if (temp_AlarmMessageForAll.Disposal_LinkageData.PTZDeviceID == ""|| temp_AlarmMessageForAll.Disposal_LinkageData.PTZDeviceID == null)
                {
                    disposal_dgv4.Rows[index_b].Cells[2].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_b].Cells[2].Value = temp_AlarmMessageForAll.Disposal_LinkageData.PTZDeviceID;
                }
                if (temp_AlarmMessageForAll.Disposal_LinkageData.Preset == ""|| temp_AlarmMessageForAll.Disposal_LinkageData.Preset ==null)
                {
                    disposal_dgv4.Rows[index_b].Cells[3].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_b].Cells[3].Value = temp_AlarmMessageForAll.Disposal_LinkageData.Preset;
                }
                disposal_dgv4.Rows[index_b].Cells[4].Value = temp_AlarmMessageForAll.Disposal_LinkageData.SwitchDeviceID;
                disposal_dgv4.Rows[index_b].Cells[5].Value = temp_AlarmMessageForAll.Disposal_LinkageData.SwitchOperation;
                disposal_dgv4.Rows[index_b].Cells[6].Value = temp_AlarmMessageForAll.Disposal_LinkageData.Switchoperationtimedelay;
                disposal_dgv4.Rows[index_b].Cells[7].Value = temp_AlarmMessageForAll.Disposal_LinkageData.Videorecording;
                disposal_dgv4.Rows[index_b].Cells[8].Value = temp_AlarmMessageForAll.Disposal_LinkageData.Alarmsound;
                disposal_dgv4.Rows[index_b].Cells[9].Value = temp_AlarmMessageForAll.Disposal_LinkageData.Alarmsoundtimedelay;
                if (temp_AlarmMessageForAll.Disposal_LinkageData.Reset == true)
                {
                    disposal_dgv4.Rows[index_b].Cells[10].Value = "是";
                }
                else
                {
                    disposal_dgv4.Rows[index_b].Cells[10].Value = "否";
                }
            }
            if (temp_AlarmMessageForAll.Untreated_LinkageData!=null)
            {
                int index_c = disposal_dgv4.Rows.Add();
                disposal_dgv4.Rows[index_c].Cells[0].Value = "未处置阶段";
                if (temp_AlarmMessageForAll.Untreated_LinkageData.VideoDeviceID == ""|| temp_AlarmMessageForAll.Untreated_LinkageData.VideoDeviceID == null)
                {
                    disposal_dgv4.Rows[index_c].Cells[1].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_c].Cells[1].Value = temp_AlarmMessageForAll.Untreated_LinkageData.VideoDeviceID;
                }
                if (temp_AlarmMessageForAll.Untreated_LinkageData.PTZDeviceID == ""|| temp_AlarmMessageForAll.Untreated_LinkageData.PTZDeviceID == null)
                {
                    disposal_dgv4.Rows[index_c].Cells[2].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_c].Cells[2].Value = temp_AlarmMessageForAll.Untreated_LinkageData.PTZDeviceID;
                }
                if (temp_AlarmMessageForAll.Untreated_LinkageData.Preset == ""|| temp_AlarmMessageForAll.Untreated_LinkageData.Preset == null)
                {
                    disposal_dgv4.Rows[index_c].Cells[3].Value = "无";
                }
                else
                {
                    disposal_dgv4.Rows[index_c].Cells[3].Value = temp_AlarmMessageForAll.Untreated_LinkageData.Preset;
                }
                disposal_dgv4.Rows[index_c].Cells[4].Value = temp_AlarmMessageForAll.Untreated_LinkageData.SwitchDeviceID;
                disposal_dgv4.Rows[index_c].Cells[5].Value = temp_AlarmMessageForAll.Untreated_LinkageData.SwitchOperation;
                disposal_dgv4.Rows[index_c].Cells[6].Value = temp_AlarmMessageForAll.Untreated_LinkageData.Switchoperationtimedelay;
                disposal_dgv4.Rows[index_c].Cells[7].Value = temp_AlarmMessageForAll.Untreated_LinkageData.Videorecording;
                disposal_dgv4.Rows[index_c].Cells[8].Value = temp_AlarmMessageForAll.Untreated_LinkageData.Alarmsound;
                disposal_dgv4.Rows[index_c].Cells[9].Value = temp_AlarmMessageForAll.Untreated_LinkageData.Alarmsoundtimedelay;
                if (temp_AlarmMessageForAll.Untreated_LinkageData.Reset == true)
                {
                    disposal_dgv4.Rows[index_c].Cells[10].Value = "是";
                }
                else
                {
                    disposal_dgv4.Rows[index_c].Cells[10].Value = "否";
                }
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dataGridView2.CurrentRow.Index;
            if (dataGridView2.Rows[index].Cells[1].Value != null)
            {
                //string[] Preset_CameraName = dataGridView2.Rows[index].Cells[1].Value.ToString().Split(',');
                string[] Preset_CameraID= dataGridView2.Rows[index].Cells[1].Tag.ToString().Split(',');
                for (int i = 0; i < Preset_CameraID.Length; i++)
                {
                    dic_Video_Preset[Preset_CameraID[i]].isUse = false;
                }
                dataGridView2.Rows[index].Cells[1].Value = null;
                dataGridView2.Rows[index].Cells[1].Tag = null;
            }
            try
            {
                string[] Snum = dataGridView2.Rows[index].Cells[1].Value.ToString().Split(new char[] { ',' });
                if (Snum.Length < 2)
                {
                    //Rectangle rect = dataGridView2.GetCellDisplayRectangle(2, d2.Index, false);
                    //DisplayPic(dataGridView2, rect, d2.Index);
                    dataGridView2.Rows[index].Cells["pic_wheel"].Value = null;
                }
            }
            catch
            {
                dataGridView2.Rows[index].Cells["pic_wheel"].Value = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text=="")
            {
                MessageBox.Show("预案名称为空，请输入预案名称！");
                return;
            }
            if (Bool_Add == false)
            {
                temp_AlarmMessageForAll.Description = textBox2.Text;
                classplan.PlanAdd(temp_AlarmMessageForAll);
                Bool_Add = true;
            }
            else
            {
                temp_AlarmMessageForAll.Description = textBox2.Text;
                classplan.PlanRevise(temp_AlarmMessageForAll);
            }
        }

        private void PlanSet_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Close();
            //System.Environment.Exit(0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void PlanSet_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name.Equals("pic_wheel"))
            {
                if (e.Value != null)
                {
                    string path = e.Value.ToString();
                    Bitmap myBitmap = new Bitmap(path);
                    e.Value = myBitmap.GetThumbnailImage(20, 20, null, IntPtr.Zero);
                }
                else
                {
                    dataGridView2.Columns[e.ColumnIndex].DefaultCellStyle.NullValue = null;
                }
            }
        }
    }
}
