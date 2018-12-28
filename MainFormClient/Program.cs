using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //1、初始化通信类
            bool result1 = DeviceBaseData.CommunicationClass.Init();
            Login login = new Login();
            login.ShowDialog();

            if (login.result == DialogResult.OK)
            {
                mainform form1 = new mainform();
                Application.Run(form1);
            }
            
        }
    }
}
