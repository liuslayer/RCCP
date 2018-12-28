using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OMClient
{
    public class ProtocolHandlerBase
    {
        private string partialProtocal = string.Empty;
        public virtual string[] GetProtocol(string input)
        {
            return GetProtocol(input, null);
        }

        private string[] GetProtocol(string input, List<string> outputList)
        {
            if (outputList == null)
            {
                outputList = new List<string>();
            }
            if (string.IsNullOrEmpty(input))
            {
                return outputList.ToArray();
            }
            if (!string.IsNullOrEmpty(partialProtocal))
            {
                input = partialProtocal + input;
            }

            string pattern = "\r\n";//回车换行符
            int index = input.IndexOf(pattern);
            if (index != -1)//找到一条完整数据
            {
                string oneProtocol = input.Substring(0, index);
                outputList.Add(oneProtocol);
                partialProtocal = "";
                input = input.Substring(index + 2);
                GetProtocol(input, outputList);
            }
            else
            {
                partialProtocal = input;
            }
            return outputList.ToArray();
        }
    }
}
