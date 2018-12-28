using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresetForm
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
            //Application.Run(new Intercom("192.168.20.20",1));
            Application.Run(new PresetForm());
            //Application.Run(new Cms_AlarmSetting("192.168.1.150",1,0, new Guid("e2060710-301a-40b0-b713-f8247287e0e2")));
            //Application.Run(new PlanList());
        }
    }
}
