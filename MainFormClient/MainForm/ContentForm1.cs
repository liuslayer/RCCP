using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using Project2;
using DeviceBaseData;

namespace Client
{
    public partial class ContentForm1 : Form
    {
        [DllImport("USER32.DLL")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);


        public List<Process> processList = new List<Process>();//已经启动的近程List
        public List<Panel> panels = new List<Panel>();//各个服务按钮容器
        public ContentForm1()
        {
            InitializeComponent();

            panels.Add(panel1);
            panels.Add(panel2);
            panels.Add(panel3);
            panels.Add(panel4);
            panels.Add(panel5);
            panels.Add(panel6);
            panels.Add(panel7);
            panels.Add(panel8);
            panels.Add(panel9);//设备管理默认显示

            if (Class1.loginUserInfomation.userPermission == null)
            {
                panel1.Visible = false;
                panel2.Visible = false;
                panel3.Visible = false;
                panel4.Visible = false;
                panel5.Visible = false;
                panel6.Visible = false;
                panel7.Visible = false;
                panel8.Visible = false;
                panel9.Visible = false;
                return;
            }
            if (!Class1.loginUserInfomation.userPermission.BEWSSAuthority)
            {
                Arrangement(0);
                panel1.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.RTSMSAuthority)
            {
                Arrangement(1);
                panel2.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.OMManagementAuthority)
            {
                Arrangement(2);
                panel3.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.CommandDispatchAuthority)
            {
                Arrangement(3);
                panel4.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.CommunicationManagementAuthority)
            {
                Arrangement(4);
                panel5.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.ManagementOfMessagesAuthority)
            {
                Arrangement(5);
                panel6.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.SystemSettingsCheck)
            {
                Arrangement(6);
                panel7.Visible = false;
            }
            if (!Class1.loginUserInfomation.userPermission.InformationManagementAuthority)
            {
                Arrangement(7);
                panel8.Visible = false;
            }
        }
        private void Arrangement(int index)
        {
            for (int i = panels.Count - 1; i >= index + 1; i--)
            {
                panels[i].Location = panels[i - 1].Location;
            }
        }

        private void WarningSurveillance_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "Client";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "Client.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\Client\bin\Debug";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }

        //通信管理
        private void ComM_Click(object sender, EventArgs e)
        {
            Control c_parent = this.Parent;
            ContentForm2 contentForm2 = new ContentForm2();
            contentForm2.myHigher = this;
            contentForm2.TopLevel = false;
            c_parent.Controls.Add(contentForm2);
            Hide();
            contentForm2.Show();

        }

        //指挥调度
        private void userControl13_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "CADS";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;

                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "CADS.exe";
            info.WorkingDirectory = @"..\指挥调度和勤务管理";
            System.Diagnostics.Process pro;
            try
            {
                pro = System.Diagnostics.Process.Start(info);
                processList.Add(pro);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }

        //态势显控
        private void userControl11_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "RTSMS";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;

                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "RTSMS.exe";
            info.WorkingDirectory = @"..\态势图";
            System.Diagnostics.Process pro;
            try
            {
                pro = System.Diagnostics.Process.Start(info);
                processList.Add(pro);
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }

        //运维
        private void userControl12_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "OMClient";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "OMClient.exe";
            info.WorkingDirectory = @"..\运维管理";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }
        //预案设置
        private void userControl14_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "PresetForm";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "PresetForm.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\PresetForm\bin\Debug";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }
        //系统设置
        private void userControl15_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "SystemSetupDLL";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "SystemSetupDLL.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\SystemSetupDLL\bin\Debug";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }

        }
        //情报管理
        private void userControl16_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "InformationManagementDLL";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "InformationManagementDLL.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\InformationManagementDLL\bin\Debug";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }
        //设备管理
        private void userControl17_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "DatabaseConfiguration";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "DatabaseConfiguration.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\DatabaseConfiguration\bin\Debug";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                Console.WriteLine("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }
        //电视墙
        private void userControl18_Click(object sender, EventArgs e)
        {
            //判断是否已经运行
            string FileName = "VMClient";
            Process[] prc = Process.GetProcesses();
            foreach (Process pr in prc)
            {
                if (FileName == pr.ProcessName)
                {
                    ShowWindow(pr.MainWindowHandle, 1);//0,表示隐藏，1表示正常显示，2表示最小化，3表示最大化
                    SetForegroundWindow(pr.MainWindowHandle);
                    return;
                }
            }

            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "VMClient.exe";
            info.WorkingDirectory = @"C:\Users\Administrator\Desktop\RCCP\MainFormClient\bin\Debug\电视墙";
            Process pro;
            try
            {
                pro = Process.Start(info);
                processList.Add(pro);
            }
            catch (Win32Exception ex)
            {
                MessageBox.Show("系统找不到指定的文件。\r{0}", ex.ToString());
                return;
            }
        }
        //会议系统
        private void userControl19_Click(object sender, EventArgs e)
        {
            MessageBox.Show("会议系统待开发中……");
        }
    }
}
