using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class ProtocolUPS_3onedata_Business
    {

        static public string GetUPSData(Guid? CommunicationGuid, string CommunicationType)
        {
            string tmpData = null;
            string UPSProtocolData =  ProtocolUPS_3onedata.GetUpsData();
            //CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, UPSProtocolData);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, UPSProtocolData);
            return tmpData;
        }
    }
}
