using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Common
{
    public static class CommandUtils
    {
        /// <summary>
        /// 标准命令行协议
        /// </summary>
        /// <param name="command"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static string TerminalCommandAssemble(string command,string content)
        {
            return command + " " + content + "\r\n";
        }
    }
}
