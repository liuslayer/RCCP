using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class ProtocolUPS_3onedata
    {
        public static string GetUpsData()
        {
            string UpsProtocol = "";
            UpsProtocol = "Q1\r\n";
            return UpsProtocol;
        }
    }
}
