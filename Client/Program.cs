using ClassLibrary1;
using DeviceBaseData;
using DeviceRTStatus;
using RecDll;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        public static StatusForm statusForm;
        public static Form1 form1;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            form1 = new Form1();

            Thread th = new Thread(new ThreadStart(Init));
            th.IsBackground = true;
            th.Start();

            Application.Run(form1);
        }

        private static void Init()
        {
            //绑定服务状态事件
            CommunicationClass.ServiceStatusEvent += CommunicationClass_ServiceStatusEvent;
            //1、初始化通信类
            bool result1 = CommunicationClass.Init();
            if (result1)
            {
                ShowResult("通讯初始化成功！");
                //初始化设备数据
                Class1 class1 = new Class1();
                class1.Init();
                if (Class1.IsDone)
                {
                    NetPing.StateCallback();//状态实时信息
                }
                //报警预案数据初始化
                //ClassPlan classplan = new ClassPlan();
                //classplan.PlanInit();
            }
            else
                ShowResult("通讯初始化失败！");



            //2、流媒体初始化
            //先判断流媒体是否启用
            if(System.Configuration.ConfigurationManager.AppSettings["MediaStream"]=="1")
            {
                int result5 = CMSSdk.VM_CMS_Init();
                if (result5 != -1)
                    ShowResult("流媒体初始化成功！");
                else
                    ShowResult("流媒体初始化失败！");
                CMSSdk.LPCMS_USER_LOGIN_INFO LoginInfo = new CMSSdk.LPCMS_USER_LOGIN_INFO();
                LoginInfo.szIP = System.Configuration.ConfigurationManager.AppSettings["MediaStream_IP"];
                LoginInfo.uPort = int.Parse(System.Configuration.ConfigurationManager.AppSettings["MediaStream_Port"]);
                LoginInfo.szUser = System.Configuration.ConfigurationManager.AppSettings["MediaStream_User"];
                LoginInfo.szPassword = System.Configuration.ConfigurationManager.AppSettings["MediaStream_Password"];
                form1.lHandle = CMSSdk.VM_CMS_Login(ref LoginInfo, 0);
                if (form1.lHandle < 0)
                {
                    MessageBox.Show("媒体管理服务器登录失败!");
                }
                else
                {
                    MessageBox.Show("媒体管理服务器登录成功！");
                }
            }
            
            //3、录像初始化
            bool result6 = RecDataClass.Init();
            if (result6)
                ShowResult("SDK初始化成功！");
            else
                ShowResult("SDK初始化失败！");

            //4、报警初始化
            CommunicationClass.AlarmEvent += AlarmOperation.Alarm;
        }

        private static void CommunicationClass_ServiceStatusEvent(string message)
        {
            string[] services = message.Split(new char[] { ';' });
            for (int i = 0; i < services.Length; i++)
            {
                string[] str = services[i].Split(new char[] { '_' });
                string result = "正在运行";
                if (str[1] == "False")
                    result = "已停止";

                switch (str[0])
                {
                    case "OMServer":
                        ShowResult("运维服务" + result + "!");
                        break;
                    case "BCServer":
                        ShowResult("业务协同服务" + result + "!");
                        break;
                    case "DCServer":
                        ShowResult("数据中心服务" + result + "!");
                        break;
                    case "BMMSServer":
                        ShowResult("基础模块管理服务" + result + "!");
                        break;
                }
            }
        }

        private delegate void ShowResultDelegate(string text);
        private static void ShowResult(string text)
        {
            if(statusForm!=null&&statusForm.listBox1!=null)
            {
                if (statusForm.listBox1.InvokeRequired)
                    statusForm.listBox1.Invoke(new ShowResultDelegate(ShowResult), text);
                else
                    statusForm.listBox1.Items.Add(text);
            }
            else
            {
                //ShowResult(text);
                return;
            }
        }


    }
}
