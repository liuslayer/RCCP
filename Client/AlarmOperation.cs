using Client.Entities.AlarmEntity;
using DeviceBaseData;
using Newtonsoft.Json;
using RecDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace Client
{
    public class AlarmOperation
    {
        //存储接收到的所有报警器信息
        //public static List<PresetDataManage> AletorInfo=new List<PresetDataManage>();
        public static void Alarm(object obj)
        {

            //接收从服务器业务协同端口发送过来的报警信息
            //1、判断报警类型
            AlarmMessageToClient info = (AlarmMessageToClient)obj;

            //1.1写报警日志，显示报警信息
            try
            {
                WriteTxt(info.alarmmessage);
            }
            catch
            {
                Console.WriteLine("报警日志写入失败！");
            }
            //1.3显示报警视频
            int BoxTab = -1;
            for (int i = 0; i < Form1.BoxCount; i++)
            {
                if (Form1.AlarmDeviceID[i] == info.alarmmessage.AlarmDeviceID)
                {
                    BoxTab = i;
                    break;
                }
            }
            //1.3.1临时报警
            if (info.alarmmessage.AlarmType == 0)
            {
                switch (info.alarmmessage.AlarmStage)
                {
                    //报警触发
                    case 1:
                        RealPlay.RealPlayVideo.OpenAlarm(info.alarmmessage.DeviceID,info.alarmmessage.AlarmDeviceID);
                        break;
                    //报警结束
                    case 4:
                        //取消声光报警
                        Form1.videoboxs[BoxTab].player.Stop();
                        Form1.videoboxs[BoxTab].EndAlarm();
                        Form1.flash_tag.Remove(BoxTab);
                        Form1.panels[BoxTab].BackColor = System.Drawing.Color.Transparent;
                        AlarmRec.StopRec(info.alarmmessage.DeviceID);//关闭报警录像,存储报警录像信息
                        break;
                }
            }
            else if (info.alarmmessage.AlarmType == 1)//1.3.2报警器报警
            {
                switch(info.alarmmessage.AlarmStage)
                {
                    case 1:
                        AlarmTrigger(info);
                        break;
                    case 2:
                        AlarmDispose(info, BoxTab);
                        break;
                    case 3:
                        AlarmUnDispose(info, BoxTab);
                        break;
                    case 4:
                        AlarmEnd(info, BoxTab);
                        break;
                }
            }
        }

        #region 临时报警报警
        /// <summary>
        /// 临时报警触发
        /// </summary>
        /// <param name="info"></param>
        public static void TempAlarmTrigger(AlarmMessage info)
        {
        }

        /// <summary>
        /// 临时报警结束
        /// </summary>
        /// <param name="info"></param>
        public static void TempAlarmOver(AlarmMessage info)
        {
        }
        #endregion
        
        #region 报警器报警
        /// <summary>
        /// 报警器触发
        /// </summary>
        public static void AlarmTrigger(AlarmMessageToClient info)
        {
            //1.2打开报警录像,存储报警录像信息
            string errorInfo = "";
            try
            {
                if (AlarmRec.Rec(info.alarmmessage.DeviceID, ref errorInfo) == -1)
                    Console.WriteLine(errorInfo + ",报警录像失败！");
            }
            catch { }
            //1、打开主报警器视频
            int result=RealPlay.RealPlayVideo.OpenAlarm(info.alarmmessage.DeviceID, info.alarmmessage.AlarmFingerprintID);
            //2、记录主报警器ID
            Form1.AlarmDeviceID[result] =info.alarmmessage.AlarmDeviceID;
            Form1.AlarmFingerprintID[result] = info.alarmmessage.AlarmFingerprintID;
            Form1.AlarmType[result] = info.alarmmessage.AlarmType;

            //联动视频
            LinkageDataStruct linkage = info.Now_LinkageData;
            string[] CameraIDs = linkage.Video_DeviceID.Split(new char[] { ',' });
            for (int i = 0; i < CameraIDs.Length; i++)
            {
                 result = RealPlay.RealPlayVideo.OpenAlarm(CameraIDs[i], info.alarmmessage.AlarmFingerprintID);
            }
        }

        // 报警器处置
        private static void AlarmDispose(AlarmMessageToClient info, int BoxTab)
        {
            int result;
            //处置视频
            LinkageDataStruct linkage = info.Now_LinkageData;
            string[] CameraIDs = linkage.Video_DeviceID.Split(new char[] { ',' });
            for (int i = 0; i < CameraIDs.Length; i++)
            {
                result = RealPlay.RealPlayVideo.OpenAlarm(CameraIDs[i], info.alarmmessage.AlarmFingerprintID);
            }
        }
        // 报警器未处置
        private static void AlarmUnDispose(AlarmMessageToClient info, int BoxTab)
        {
            int result;
            //未处置视频
            LinkageDataStruct linkage = info.Now_LinkageData;
            string[] CameraIDs = linkage.Video_DeviceID.Split(new char[] { ',' });
            for (int i = 0; i < CameraIDs.Length; i++)
            {
                result = RealPlay.RealPlayVideo.OpenAlarm(CameraIDs[i], info.alarmmessage.AlarmFingerprintID);
            }

        }
        /// <summary>
        /// 报警器结束
        /// </summary>
        /// <param name="info"></param>
        private static void AlarmEnd(AlarmMessageToClient info, int BoxTab)
        {
            //关闭报警录像,存储报警录像信息
            AlarmRec.StopRec(info.alarmmessage.DeviceID);

            //清理记录的报警器ID
            Form1.ClearAlarmInfo(BoxTab);
        }
        #endregion

        /// <summary>
        /// 记录报警信息txt
        /// </summary>
        /// <param name="info"></param>
        public static void WriteTxt(AlarmMessage info)
        {
            //FileStream fs = new FileStream(@".\Alarm.txt", FileMode.Create);
            //显示报警信息
            Program.form1.ThreadShow(info);

            //string str = "";
            //switch (info.AlarmStage)
            //{
            //    case 1:
            //        str = info.AlarmAreaName + ",报警触发了！";
            //        break;
            //    case 4:
            //        str = info.AlarmAreaName + ",报警结束了！";
            //        break;
            //}
            ////获得字节数组
            //byte[] data = Encoding.Default.GetBytes(str);
            ////开始写入
            //fs.Write(data, 0, data.Length);
            ////清空缓冲区、关闭流
            //fs.Flush();
            //fs.Close();
        }
    }
}
