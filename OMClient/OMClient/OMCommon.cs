using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public static class OMCommon
    {
        /// <summary>
        /// 将原始报警数据转换成界面显示数据
        /// </summary>
        /// <param name="alarm"></param>
        /// <returns></returns>
        public static string UPSAlarmConvert(string alarm)
        {
            if (string.IsNullOrEmpty(alarm))
                return string.Empty;
            string[] alarmDescritpions = { "市电异常", "市电电压低", "旁路模式", "UPS故障", "UPS后备式", "测试进行中", "关机", "" };
            string[] normalDescritpions = { "市电正常", "市电电压正常", "主路模式", "UPS正常", "UPS在线式", "测试完毕", "开机", "" };
            char[] alarmArray = alarm.ToCharArray();
            string alarmDesciption = string.Empty;
            for (int i = 0; i < alarmArray.Length - 1; i++)
            {
                if (alarmArray[i] == '1')
                {
                    alarmDesciption += alarmDescritpions[i] + "；";
                }
                else
                {
                    alarmDesciption += normalDescritpions[i] + "；";
                }
                if (i != alarmArray.Length - 1)
                    alarmDesciption += "\n";
            }
            return alarmDesciption;
        }

        public static string CameraExceptionConvert(int signal, int hardware)
        {
            string exception = string.Empty;
            exception += signal == 2 ? "信号丢失|" : "";
            exception += hardware == 2 ? "硬件异常" : "";
            return exception;
        }
    }
}
