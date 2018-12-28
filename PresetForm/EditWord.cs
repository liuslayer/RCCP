using Client.Entities.AlarmEntity;
using DeviceBaseData;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresetForm
{
    public partial class EditWord : Form
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
        Pre_arrangeList_Command.Pre_Command temp_Pre_Command = new Pre_arrangeList_Command.Pre_Command();
        PlanList temp;
        public EditWord(PlanList temp_PlanList)
        {
            InitializeComponent();
            temp = temp_PlanList;
            comboBox1.SelectedIndex = 0;
            AnimateWindow(Handle, 300, AW_CENTER);//窗体弹出效果
        }

        private void button1_Click(object sender, EventArgs e)
        {
            createWord();
        }

        private void createWord()
        {
            if (textBox1.Text=="")
            {
                MessageBox.Show("请输入预案名称！");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "All Word file|*.docx;*.docm;*.dotx;*.dotm;*.doc;*.dot";//设置文件类型
            sfd.FileName =textBox1.Text;//设置默认文件名
            sfd.DefaultExt = "doc";//设置默认格式（可以不设）
            sfd.AddExtension = true;//设置自动在文件名中添加扩展名
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    sw.WriteLineAsync(textBox2.Text);
                    Pre_arrangeList temp_Pre_arrangeList = new Pre_arrangeList();
                    temp_Pre_arrangeList.Pre_arrangedID = Guid.NewGuid();
                    temp_Pre_arrangeList.Pre_arrangeName = textBox1.Text;
                    temp_Pre_arrangeList.Pre_arrangeType = int.Parse(comboBox1.Text);
                    temp_Pre_arrangeList.CreatTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    temp_Pre_arrangeList.PlanPath = sfd.FileName;
                    List<Pre_arrangeList> pre_arrangeList = new List<Pre_arrangeList>();
                    pre_arrangeList.Add(temp_Pre_arrangeList);
                    temp_Pre_Command.Pre_arrangeList_AddData(pre_arrangeList);
                    MessageBox.Show("预案保存成功！");
                    temp.DataFresh();
                    this.Close();
                }
            }
        }

        private void EditWord_MouseDown(object sender, MouseEventArgs e)
        {
            //拖动窗体
            ReleaseCapture();
            SendMessage(Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AnimateWindow(Handle, 300, AW_HIDE + AW_CENTER);
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
    }
}
