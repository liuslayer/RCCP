using DeviceBaseData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace InformationManagementDLL
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
            Class1 c = new Class1();
            CommunicationClass.Init();
            c.Init();
            Application.Run(new InformationManagement());
        }
    }
}
