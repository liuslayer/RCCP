using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Common
{
    public static class CommonUtils
    {
        public static string BytesToString(byte[] byteBuf)
        {
            return Convert.ToBase64String(byteBuf);
        }

        public static byte[] StringToBytes(string strBuf)
        {
            return Convert.FromBase64String(strBuf);
        }
    }
}
