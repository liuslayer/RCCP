using AccessOperation;
using DeviceBaseData;
using PreviewDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RecDll
{
    public class CapturePic
    {
        //对当前正在预览的视频抓图
        //登录当前设备=>预览视频=>抓图

        //设备登录返回值—[string:IP]
        public static Dictionary<string, int> userIDList = new Dictionary<string, int>();

        //设备预览返回值—[string:IP+","+Channel+"_1"]
        public static Dictionary<string, int> RealHandleList = new Dictionary<string, int>();

        //截图存储路径
        public static string path = @"d:\";
        public static bool LogIn()
        {
            //登录设备
            for (int i = 0; i < Class1.streamMediaList.Count; i++)
            {
                string IPAddress = Class1.streamMediaList[i].VideoIP; //设备IP地址或者域名
                int PortNumber = Class1.streamMediaList[i].Port;//设备服务端口号
                string UserName = Class1.streamMediaList[i].UserName;//设备登录用户名
                string Password = Class1.streamMediaList[i].PassWord;//设备登录密码

                CHCNetSDK.NET_DVR_DEVICEINFO_V30 DeviceInfo = new CHCNetSDK.NET_DVR_DEVICEINFO_V30();

                //登录设备 Login the device
                int m_lUserID = CHCNetSDK.NET_DVR_Login_V30(IPAddress, PortNumber, UserName, Password, ref DeviceInfo);
                if (m_lUserID < 0)
                {

                }
                else
                {
                    //登录成功
                    Console.WriteLine("Login Success!");
                    if (!userIDList.Keys.Contains(IPAddress))
                        userIDList.Add(IPAddress, m_lUserID);
                }
            }
            return false;
        }

        /// <summary>
        /// 设备登出
        /// </summary>
        public static void Logout()
        {
            foreach (int m_lUserID in ManualRec.userIDList.Values)
            {
                //注销登录 Logout the device
                CHCNetSDK.NET_DVR_Logout(m_lUserID);
            }
        }
        static string CameraID;
        static string sBmpPicFileName;
        public static bool Capture(string IP, int Channel, int m_lRealHandle,string cameraID)
        {
            CameraID = cameraID;
            PictureBox p = new PictureBox();
             if (!ManualRec.userIDList.ContainsKey(IP)) return false;
            int m_lUserID = ManualRec.userIDList[IP];
           
            
            //图片保存路径和文件名 the path and file name to save
            sBmpPicFileName = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

            //BMP抓图 Capture a BMP picture
            bool result = CHCNetSDK.NET_DVR_CapturePicture(m_lRealHandle, path + sBmpPicFileName);
            if (result)
            {
                //CHCNetSDK.NET_DVR_StopRealPlay(m_lRealHandle);
                CaptureForm1 form = new CaptureForm1();
                form.Show();
                form.SetupValueEvent += Form_SetupValueEvent;
            }
            return result;
        }

        private static void Form_SetupValueEvent(string eventType, string Description)
        {
            //存储截图信息到本地
            DateTime dt = DateTime.Now;
            RecPictureList recPictureList = new RecPictureList();
            recPictureList.CameraID = CameraID;
            recPictureList.RecPictureName = sBmpPicFileName;
            recPictureList.RecPictureDate = dt.ToString("yyyy-MM-dd");
            recPictureList.RecPictureTime = dt.ToString("HH:mm:ss");
            recPictureList.RecPictureFile = path + sBmpPicFileName;
            recPictureList.PictureType = "截图";
            string errorInfo = "";
            if (!RecPictureClass.Add(recPictureList, ref errorInfo))
            {
                MessageBox.Show(errorInfo);
            }
            else
            {
                MessageBox.Show("保存成功！");
            }
        }

        public static void RealDataCallBack(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser)
        {
        }
    }
}
