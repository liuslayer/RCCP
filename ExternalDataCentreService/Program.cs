using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExternalDataCentreService
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
            CommunicationClass com = new CommunicationClass();
            com.Start();
            Form2 form2 = new Form2();
            com.ReceiveDataPackageEvent+=new CommunicationClass.ReceiveDataPackageDelegate(form2.ShowMessage);
            Application.Run(form2);
        }
    }
}
