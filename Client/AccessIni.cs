using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Client
{
   public class AccessIni
    {
        /// <summary>
        /// 写入INI文件
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string value, string filePath);

        /// <summary>
        /// 读取INI文件
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="defValue">未读到的默认值</param>
        /// <param name="retValue">读到的默认值</param>
        /// <param name="size">大小</param>
        /// <param name="filePath">路径</param>
        /// <returns></returns>
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defValue, StringBuilder retValue, int size, string filePath);


        /// <summary>
        /// 读取ini文件
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="defValue">未读取到值时的默认值</param>
        /// <param name="filepath">文件路径</param>
        /// <returns></returns>
        public static string ReadIni(string section, string key, string defValue, string filepath)
        {
            string strValue = "";
            StringBuilder retValue = new StringBuilder();
            GetPrivateProfileString(section, key, defValue, retValue, 256, filepath);
            strValue = retValue.ToString();
            return strValue;
        }

        /// <summary>
        /// 写入ini文件
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        /// 
        public static long WriteIni(string section, string key, string value, string filePath)
        {
            return WritePrivateProfileString(section, key, value, filePath);
        }

        /// <summary>
        /// 删除节
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static long DeleteSection(string section, string filePath)
        {
            return WritePrivateProfileString(section, null, null, filePath);
        }

        /// <summary>
        /// 删除键
        /// </summary>
        /// <param name="section">节</param>
        /// <param name="key">键</param>
        /// <param name="filePath">文件路径</param>
        /// <returns></returns>
        public static long DeleteKey(string section, string key, string filePath)
        {
            return WritePrivateProfileString(section, key, null, filePath);
        }
    }
}
