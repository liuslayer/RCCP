using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using EPM;
using MSSM;
using SVM;
using MSG;


namespace CADS
{
    public partial class CAD_MainForm : Form
    {
        Svm_MainForm Svm_MainForm = null;
        EPM_MainForm EPM_MainForm = null;
        MSSM_MainForm MSSM_MainForm = null;
        MSG_MainForm MSG_MainForm = null;

        public CAD_MainForm()
        {
            InitializeComponent();
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            this.Close();
            Process.GetCurrentProcess().Kill();//直接干掉进程
            //1.this.Close();   只是关闭当前窗口，若不是主窗体的话，是无法退出程序的，另外若有托管线程（非主线程），也无法干净地退出；
            //2.Application.Exit();  强制所有消息中止，退出所有的窗体，但是若有托管线程（非主线程），也无法干净地退出；
            //3.Application.ExitThread(); 强制中止调用线程上的所有消息，同样面临其它线程无法正确退出的问题；
            //4.System.Environment.Exit(0);   这是最彻底的退出方式，不管什么线程都被强制退出，把程序结束的很干净。
        }

        private void button_min_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        static int width = Screen.PrimaryScreen.Bounds.Width;//屏幕宽度
        static int height = Screen.PrimaryScreen.Bounds.Height;//屏幕高度
        //子窗体水平间隙
        static int gapX = 5;
        //子窗体垂直间隙
        static int gapY = 5;
        //"标题栏"高度
        static int TopY = Convert.ToInt32(height * 0.07);
        private void CADMainForm_Load(object sender, EventArgs e)
        {
            //添加logo
            logo.Size = new System.Drawing.Size(50, 50);
            logo.Location = new Point(30, 10);

            //添加logo文字
            //logoText.Size = new System.Drawing.Size(200, 35);
            //logoText.Location = new Point(logo.Left + logo.Width + 5, 15);

            //添加四个大按钮
            int btnWidth = 115;
            this.btnEPM.Size = new System.Drawing.Size(btnWidth, TopY);
            this.btnEPM.Location = new System.Drawing.Point((width - btnWidth * 4) / 2, 0);
            this.btnEPM.BackgroundImage = Image.FromFile(".\\Images\\Head\\预案管理-正常.png");
            this.btnEPM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnEPM.Visible = false;

            this.btnMSSM.Size = new System.Drawing.Size(btnWidth, TopY);
            this.btnMSSM.Location = new System.Drawing.Point((width - btnWidth * 4) / 2 + btnWidth * 3, 0);
            this.btnMSSM.BackgroundImage = Image.FromFile(".\\Images\\Head\\文电管理-正常.png");
            this.btnMSSM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSSM.Visible = false;

            this.btnSVM.Size = new System.Drawing.Size(btnWidth, TopY);
            this.btnSVM.Location = new System.Drawing.Point((width - btnWidth * 4) / 2 + btnWidth, 0);
            this.btnSVM.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnSVM.Visible = false;

            this.btnMSG.Size = new System.Drawing.Size(btnWidth, TopY);
            this.btnMSG.Location = new System.Drawing.Point((width - btnWidth * 4) / 2 + btnWidth * 2, 0);
            this.btnMSG.BackgroundImage = Image.FromFile(".\\Images\\Head\\兵要地志-正常.png");
            this.btnMSG.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSG.Visible = false;

            #region 加载预案管理界面
            EPM_MainForm = new EPM.EPM_MainForm();
            EPM_MainForm.StartPosition = FormStartPosition.Manual;
            EPM_MainForm.Size = new System.Drawing.Size(width - gapX * 2, height - gapY - TopY);
            EPM_MainForm.Location = new Point(gapX, TopY);
            EPM_MainForm.Owner = this;
            EPM_MainForm.ShowInTaskbar = false;
            #endregion

            #region 加载勤务管理界面
            Svm_MainForm = new Svm_MainForm();
            Svm_MainForm.StartPosition = FormStartPosition.Manual;
            Svm_MainForm.Size = new System.Drawing.Size(width - gapX * 2, height - gapY - TopY);
            Svm_MainForm.Location = new Point(gapX, TopY);
            Svm_MainForm.Owner = this;
            Svm_MainForm.ShowInTaskbar = false;
            #endregion

            #region 加载文电管理界面
            MSSM_MainForm = new MSSM_MainForm();
            MSSM_MainForm.StartPosition = FormStartPosition.Manual;
            MSSM_MainForm.Size = new System.Drawing.Size(width - gapX * 2, height - gapY - TopY);
            MSSM_MainForm.Location = new Point(gapX, TopY);
            MSSM_MainForm.Owner = this;
            MSSM_MainForm.ShowInTaskbar = false;
            #endregion

            #region 加载兵要地志界面
            MSG_MainForm = new MSG_MainForm();
            MSG_MainForm.StartPosition = FormStartPosition.Manual;
            MSG_MainForm.Size = new System.Drawing.Size(width - gapX * 2, height - gapY - TopY);
            MSG_MainForm.Location = new Point(gapX, TopY);
            MSG_MainForm.Owner = this;
            MSG_MainForm.ShowInTaskbar = false;
            #endregion

            this.Svm_MainForm.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-选中.png");
            this.Svm_MainForm.BackgroundImageLayout = ImageLayout.Zoom;
            Svm_MainForm.Show();
        }

        private void btnSVM_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnEPM.BackgroundImage = Image.FromFile(".\\Images\\Head\\预案管理-正常.png");
            this.btnEPM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnSVM.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-选中.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSSM.BackgroundImage = Image.FromFile(".\\Images\\Head\\文电管理-正常.png");
            this.btnMSSM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSG.BackgroundImage = Image.FromFile(".\\Images\\Head\\兵要地志-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            EPM_MainForm.Hide();
            Svm_MainForm.Show();
            MSSM_MainForm.Hide();
            MSG_MainForm.Hide();
        }

        private void btnMSSM_Click(object sender, EventArgs e)
        {
            this.btnEPM.BackgroundImage = Image.FromFile(".\\Images\\Head\\预案管理-正常.png");
            this.btnEPM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnSVM.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSSM.BackgroundImage = Image.FromFile(".\\Images\\Head\\文电管理-选中.png");
            this.btnMSSM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSG.BackgroundImage = Image.FromFile(".\\Images\\Head\\兵要地志-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            EPM_MainForm.Hide();
            Svm_MainForm.Hide();
            MSSM_MainForm.Show();
            MSG_MainForm.Hide();
        }

        private void btnEPM_Click(object sender, EventArgs e)
        {
            this.btnEPM.BackgroundImage = Image.FromFile(".\\Images\\Head\\预案管理-选中.png");
            this.btnEPM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnSVM.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSSM.BackgroundImage = Image.FromFile(".\\Images\\Head\\文电管理-正常.png");
            this.btnMSSM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSG.BackgroundImage = Image.FromFile(".\\Images\\Head\\兵要地志-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            EPM_MainForm.Show();
            Svm_MainForm.Hide();
            MSSM_MainForm.Hide();
            MSG_MainForm.Hide();
        }

        private void btnMSG_Click(object sender, EventArgs e)
        {
            this.btnEPM.BackgroundImage = Image.FromFile(".\\Images\\Head\\预案管理-正常.png");
            this.btnEPM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnSVM.BackgroundImage = Image.FromFile(".\\Images\\Head\\勤务管理-正常.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSSM.BackgroundImage = Image.FromFile(".\\Images\\Head\\文电管理-正常.png");
            this.btnMSSM.BackgroundImageLayout = ImageLayout.Zoom;
            this.btnMSG.BackgroundImage = Image.FromFile(".\\Images\\Head\\兵要地志-选中.png");
            this.btnSVM.BackgroundImageLayout = ImageLayout.Zoom;
            EPM_MainForm.Hide();
            Svm_MainForm.Hide();
            MSSM_MainForm.Hide();
            MSG_MainForm.Show();
        }
    }
}
