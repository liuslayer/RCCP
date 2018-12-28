using PreviewDemo;
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
using static PresetForm.IntercomShoutData;
using static PreviewDemo.CHCNetSDK;

namespace PresetForm
{
    public partial class Intercom : Form
    {
        public static Dictionary<string, IntercomShoutMapped> Dic_IntercomShoutMapped = new Dictionary<string, IntercomShoutMapped>();
        public string IP_Channel;
        //private static fVoiceDataCallBack VoiceCB;
        private static int m_lUserID;
        private static int lVoiceComHandle;//NET_DVR_StartVoiceCom或NET_DVR_StartVoiceCom_V30、NET_DVR_StartVoiceCom_MR或NET_DVR_StartVoiceCom_MR_V30的返回值 

        public Intercom(string VideoIP, int VideoChannel)
        {

            IP_Channel = VideoIP + "," + VideoChannel.ToString();
            IntercomShoutDataInit();
            NET_DVR_Init();
            string IPAddress ="192.168.10.101"; //设备IP地址或者域名
            int PortNumber = 8000;//设备服务端口号
            string UserName = "admin";//设备登录用户名
            string Password = "12345";//设备登录密码

            CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

            //登录设备 Login the device
            m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
            ////启用对讲回调函数
            //VoiceCB =new fVoiceDataCallBack(RVoiceCallBack);
            InitializeComponent();
        }
        public void RVoiceCallBack(int lVoiceComHandle, [MarshalAs(UnmanagedType.LPArray)]  byte[] pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, uint dwUser)
        {

        }
        public void IntercomShoutDataInit()
        {
            string SQL = "Select * From IntercomShoutList";
            DataTable dt = new DataTable();
            string path = "xwxayj_Local.mdb";
            dt = AccessDBHelper.dataTable(SQL,path);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string temp_IP_Channel = dt.Rows[i]["VideoIP"].ToString()+","+ dt.Rows[i]["VideoChannel"].ToString();
                if (!Dic_IntercomShoutMapped.ContainsKey(temp_IP_Channel))
                {
                    IntercomShoutMapped temp_IntercomShoutMapped = new IntercomShoutMapped();
                    temp_IntercomShoutMapped.VideoIP= dt.Rows[i]["VideoIP"].ToString();
                    temp_IntercomShoutMapped.VideoChannel = int.Parse(dt.Rows[i]["VideoChannel"].ToString());
                    temp_IntercomShoutMapped.ShoutIP = dt.Rows[i]["ShoutIP"].ToString();
                    temp_IntercomShoutMapped.ShoutChannel = int.Parse(dt.Rows[i]["ShoutChannel"].ToString());
                    temp_IntercomShoutMapped.IntercomIP = dt.Rows[i]["IntercomIP"].ToString();
                    temp_IntercomShoutMapped.IntercomChannel = int.Parse(dt.Rows[i]["IntercomChannel"].ToString());
                    Dic_IntercomShoutMapped.Add(temp_IP_Channel, temp_IntercomShoutMapped);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)//喊话
        {
            if (button1.Text == "打开喊话")
            {
                bool temp_shout = ShoutSwitch(1, "192.168.10.101", 1, m_lUserID);
                if (temp_shout = true)
                {
                    button1.Text = "关闭喊话";
                }
            }
            else
            {
                bool temp_shout = ShoutSwitch(0, "192.168.10.101", 1, m_lUserID);
                if (temp_shout = true)
                {
                    button1.Text = "打开喊话";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//对讲
        {

        }
        ///// <summary>
        ///// 喊话开关
        ///// </summary>
        ///// <param name="SwitchParam">开关参数：0-关闭，1-打开</param>
        ///// <param name="IP"></param>
        ///// <param name="Nchannel"></param>
        //private bool ShoutSwitch(int SwitchParam,string IP,int Nchannel,int m_lUserID)
        //{
        //    //配置数据库中包含该喊话配置信息
        //    if (Dic_IntercomShoutMapped.ContainsKey(IP_Channel))
        //    {
        //        //命令参数为打开
        //        if (SwitchParam == 1)
        //        {
        //            //打开相应喊话通道
        //            lVoiceComHandle = NET_DVR_StartVoiceCom(m_lUserID, VoiceCB,0);
        //            if (lVoiceComHandle >= 0)
        //            {
        //                Console.WriteLine("打开喊话成功");
        //                return true;
        //            }
        //            else
        //            {
        //                uint Error = NET_DVR_GetLastError();
        //                return false;
        //            }
        //        }
        //        //命令参数为关闭
        //        else
        //        {
        //            //关闭相应喊话通道
        //            bool temp_bool = IntercomShoutData.NET_DVR_StopVoiceCom(lVoiceComHandle);
        //            if (temp_bool == true)
        //            {
        //                Console.WriteLine("关闭喊话成功");
        //            }
        //            else
        //            {
        //                uint Error = NET_DVR_GetLastError();
        //            }
        //            //关闭相应喊话通道
        //            return temp_bool;
        //        }
        //    }
        //    else//配置数据库中未包含相关喊话配置信息，则直接使用传入的IP和通道号进行喊话
        //    {
        //        if (SwitchParam == 1)
        //        {
        //            //打开相应喊话通道
        //            lVoiceComHandle = NET_DVR_StartVoiceCom(m_lUserID, VoiceCB, 0);
        //            if (lVoiceComHandle >= 0)
        //            {
        //                Console.WriteLine("打开喊话成功");
        //                return true;
        //            }
        //            else
        //            {
        //                uint Error = NET_DVR_GetLastError();
        //                return false;
        //            }
        //        }
        //        //命令参数为关闭
        //        else
        //        {
        //            bool temp_bool = IntercomShoutData.NET_DVR_StopVoiceCom(lVoiceComHandle);
        //            if (temp_bool==true)
        //            {
        //                Console.WriteLine("关闭喊话成功");
        //            }
        //            else
        //            {
        //                uint Error = NET_DVR_GetLastError();
        //            }
        //            //关闭相应喊话通道
        //            return temp_bool;
        //        }
        //    }
        //}
        /// <summary>
        /// 对讲开关
        /// </summary>
        /// <param name="SwitchParam"></param>
        /// <param name="IP"></param>
        /// <param name="Nchannel"></param>
        private bool IntercomSwitch(int SwitchParam, string IP, int Nchannel)
        {
            //配置数据库中包含该对讲配置信息
            if (Dic_IntercomShoutMapped.ContainsKey(IP_Channel))
            {
                //命令参数为打开
                if (SwitchParam == 1)
                {
                    //打开相应对讲通道
                }
                //命令参数为关闭
                else
                {
                    //关闭相应对讲通道
                }
                return true;
            }
            else//配置数据库中未包含相关对讲配置信息，则直接使用传入的IP和通道号进行对讲请求
            {
                if (SwitchParam == 1)
                {
                    //打开相应对讲通道
                }
                //命令参数为关闭
                else
                {
                    //关闭相应对讲通道
                }
                return true;
            }
        }
    }
}
