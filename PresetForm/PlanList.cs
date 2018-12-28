using Client.Entities.AlarmEntity;
using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresetForm
{

    public partial class PlanList : Form
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
        [DllImport("user32.dll", EntryPoint = "AnimateWindow")]
        private static extern bool AnimateWindow(IntPtr handle, int ms, int flags);
        public const Int32 AW_CENTER = 0x00000010;//
        public const Int32 AW_HIDE = 0x00010000;//
        private Microsoft.Office.Interop.Word.Application m_word;
        private Microsoft.Office.Interop.Word.Document m_doc;
        AutoSizeForm ASF = new AutoSizeForm();
        public static List<Pre_arrangeList> pre_arrangeList = new List<Pre_arrangeList>();
        public static List<Pre_arrangeList> Time_pre_arrangeList = new List<Pre_arrangeList>();
        Pre_arrangeList_Command.Pre_Command temp_Pre_Command = new Pre_arrangeList_Command.Pre_Command();

        string PicPath = @".\images\AlarmSetting\";

        PictureBox[] p = new PictureBox[16];
        public PlanList()
        {
            InitializeComponent();
            //ASF.controllInitializeSize(this);
            bool result1 = CommunicationClass.Init();
            if (result1)
            {
                MessageBox.Show("通讯初始化成功！");
                ////初始化设备数据
                //Class1 class1 = new Class1();
                //class1.Init();
                pre_arrangeList = temp_Pre_Command.Pre_arrangeList_QueryData();
            }
            else
            {
                MessageBox.Show("通讯初始化失败！");
            }
            comboBox1.SelectedIndex = 0;

            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }

        private void PlanList_Load(object sender, EventArgs e)
        {
            //ASF.controlAutoSize(this);
            if (pre_arrangeList.Count != 0)
            {
                for (int i = 0; i < pre_arrangeList.Count; i++)
                { 
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = pre_arrangeList[i].Pre_arrangeName;
                    dataGridView1.Rows[index].Cells[1].Value = pre_arrangeList[i].Pre_arrangeType;
                    dataGridView1.Rows[index].Cells[2].Value = pre_arrangeList[i].CreatTime;
                    dataGridView1.Rows[index].Cells[3].Value = pre_arrangeList[i].ReviseTime;
                    dataGridView1.Rows[index].Cells[4].Value = pre_arrangeList[i].PlanPath;
                    dataGridView1.Rows[index].Cells[5].Value = pre_arrangeList[i].AlarmName;
                    dataGridView1.Rows[index].Cells[6].Value = pre_arrangeList[i].Description;
                }
            }
            else
            {
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditWord EW = new EditWord(this);
            EW.Show();
        }
        public void DataFresh()
        {
            pre_arrangeList.Clear();
            pre_arrangeList = temp_Pre_Command.Pre_arrangeList_QueryData();
            dataGridView1.Rows.Clear();
            if (pre_arrangeList.Count != 0)
            {
                for (int i = 0; i < pre_arrangeList.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = pre_arrangeList[i].Pre_arrangeName;
                    dataGridView1.Rows[index].Cells[1].Value = pre_arrangeList[i].Pre_arrangeType;
                    dataGridView1.Rows[index].Cells[2].Value = pre_arrangeList[i].CreatTime;
                    dataGridView1.Rows[index].Cells[3].Value = pre_arrangeList[i].ReviseTime;
                    dataGridView1.Rows[index].Cells[4].Value = pre_arrangeList[i].PlanPath;
                    dataGridView1.Rows[index].Cells[5].Value = pre_arrangeList[i].AlarmName;
                    dataGridView1.Rows[index].Cells[6].Value = pre_arrangeList[i].Description;
                }
            }
            else
            {
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (dataGridView1.Rows.Count != 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.FileName = dataGridView1.Rows[index].Cells[4].Value.ToString();
                Pre_arrangeList temp_Pre_arrangeList = new Pre_arrangeList();
                temp_Pre_arrangeList = pre_arrangeList[index];
                temp_Pre_arrangeList.ReviseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                List<Pre_arrangeList> Re_pre_arrangeList = new List<Pre_arrangeList>();
                Re_pre_arrangeList.Add(temp_Pre_arrangeList);
                temp_Pre_Command.Pre_arrangeList_ReviseData(Re_pre_arrangeList);

                m_word = new Microsoft.Office.Interop.Word.Application();
                Object filename = dataGridView1.Rows[index].Cells[0].Value;
                Object filefullname = dataGridView1.Rows[index].Cells[4].Value.ToString();
                Object confirmConversions = Type.Missing;
                Object readOnly = Type.Missing;
                Object addToRecentFiles = Type.Missing;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = Type.Missing;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing;
                Object visible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = Type.Missing;

                for (int i = 1; i <= m_word.Documents.Count; i++)
                {
                    String str = m_word.Documents[i].FullName.ToString();
                    if (str == filefullname.ToString())
                    {
                        MessageBox.Show("请勿重复打开该文档");
                        return;
                    }
                }
                try
                {
                    m_word.Documents.Open(ref filefullname,
                        ref confirmConversions, ref readOnly, ref addToRecentFiles,
                        ref passwordDocument, ref passwordTemplate, ref revert,
                        ref writePasswordDocument, ref writePasswordTemplate,
                        ref format, ref encoding, ref visible, ref openConflictDocument,
                        ref openAndRepair, ref documentDirection, ref noEncodingDialog
                        );
                    m_word.Visible = true;
                }
                catch (System.Exception ex)
                {
                    MessageBox.Show("打开Word文档出错");
                }
            }
            button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Time_pre_arrangeList.Clear();
            string StartTime = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string EndTime = dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss");
            string W_TimeType;
            if (comboBox1.Text=="创建时间")
            {
                W_TimeType = "CreatTime";
            }
            else
            {
                W_TimeType = "ReviseTime";
            }
            string sql = string.Format("WHERE "+ W_TimeType+" BETWEEN '" + StartTime + "' AND '" + EndTime + "'");
            Time_pre_arrangeList = temp_Pre_Command.Pre_arrangeList_GetListWithCondition(sql);
            dataGridView1.Rows.Clear();
            if (Time_pre_arrangeList.Count != 0)
            {
                for (int i = 0; i < Time_pre_arrangeList.Count; i++)
                {
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = Time_pre_arrangeList[i].Pre_arrangeName;
                    dataGridView1.Rows[index].Cells[1].Value = Time_pre_arrangeList[i].Pre_arrangeType;
                    dataGridView1.Rows[index].Cells[2].Value = Time_pre_arrangeList[i].CreatTime;
                    dataGridView1.Rows[index].Cells[3].Value = Time_pre_arrangeList[i].ReviseTime;
                    dataGridView1.Rows[index].Cells[4].Value = Time_pre_arrangeList[i].PlanPath;
                    dataGridView1.Rows[index].Cells[5].Value = Time_pre_arrangeList[i].AlarmName;
                    dataGridView1.Rows[index].Cells[6].Value = Time_pre_arrangeList[i].Description;
                }
            }
            else
            {
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            if (dataGridView1.Rows.Count != 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                if (dataGridView1.Rows[index].Cells[4].Value==null)
                {
                    MessageBox.Show("该预案路径不存在");
                    return;
                }
                string fileFullPath = dataGridView1.Rows[index].Cells[4].Value.ToString();
                Pre_arrangeList temp_Pre_arrangeList = new Pre_arrangeList();
                temp_Pre_arrangeList = pre_arrangeList[index];
                Guid[] De_pre_arrangeList = new Guid[1];
                De_pre_arrangeList[0] = temp_Pre_arrangeList.Pre_arrangedID;
                temp_Pre_Command.Pre_arrangeList_DelData(De_pre_arrangeList);
                try
                {

                }
                catch 
                { }
                // 1、首先判断文件或者文件路径是否存在
                if (File.Exists(fileFullPath))
                {
                    // 2、根据路径字符串判断是文件还是文件夹
                    FileAttributes attr = File.GetAttributes(fileFullPath);
                    // 3、根据具体类型进行删除
                    if (attr == FileAttributes.Directory)
                    {
                        // 3.1、删除文件夹
                        Directory.Delete(fileFullPath, true);
                    }
                    else
                    {
                        // 3.2、删除文件
                        File.Delete(fileFullPath);
                    }
                    File.Delete(fileFullPath);
                }
                button2.Enabled = true;
                DataFresh();
            }
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

        private void PlanList_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            if (dataGridView1.Rows.Count != 0)
            {
                int index = dataGridView1.CurrentRow.Index;
                //OpenFileDialog ofd = new OpenFileDialog();
                //ofd.FileName = dataGridView1.Rows[index].Cells[4].Value.ToString();
                Pre_arrangeList temp_Pre_arrangeList = new Pre_arrangeList();
                temp_Pre_arrangeList = pre_arrangeList[index];
                temp_Pre_arrangeList.ReviseTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                List<Pre_arrangeList> Re_pre_arrangeList = new List<Pre_arrangeList>();
                Re_pre_arrangeList.Add(temp_Pre_arrangeList);
                temp_Pre_Command.Pre_arrangeList_ReviseData(Re_pre_arrangeList);
            }
        }
        /// <summary>
        /// 显示"显示屏"轮巡图片
        /// </summary>
        public void DisplayPic(DataGridView d, Rectangle rect, int i)
        {
            p[i] = new PictureBox();
            p[i].Visible = false;
            d.Controls.Add(p[i]);
            p[i].Size = new Size(rect.Height, rect.Height);
            p[i].Location = new Point((rect.Width - rect.Height) / 2 + rect.Left, rect.Top);
            p[i].Image = Image.FromFile(PicPath + @"巡.png");
            p[i].SizeMode = PictureBoxSizeMode.StretchImage;
            p[i].Visible = true;
        }
    }
}
