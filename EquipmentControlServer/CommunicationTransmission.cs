using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class CommunicationTransmission
    {
       
        //static public void CommunicationWrite(Guid? GuidCommunicationID, string strCommunicationType, byte[] tmp_Data)
        //{
        //    switch (strCommunicationType)
        //    {
        //        case "1"://串口
        //            { SerialCOMInit.WriteCom(GuidCommunicationID, tmp_Data); }
        //            break;
        //        case "2"://网络
        //            { }
        //            break;
        //    }
        //}

        //static public void CommunicationWrite(Guid? GuidCommunicationID, string strCommunicationType, string tmp_Data)
        //{
        //    switch (strCommunicationType)
        //    {
        //        case "1"://串口
        //            { SerialCOMInit.WrirtCom_str(GuidCommunicationID, tmp_Data); }
        //            break;
        //        case "2"://网络
        //            { }
        //            break;
        //    }
        //}

        static public void CommunicationWrite(Guid? GuidCommunicationID, string strCommunicationType, byte[] tmp_Data)
        {
            string falseMsg = string.Empty;
            if (GuidCommunicationID != null)
            {
                switch (strCommunicationType)
                {
                    case "1"://串口
                        { SerialCOMInit.WriteCom(GuidCommunicationID.Value, tmp_Data, out falseMsg); }
                        break;
                    case "2"://网络
                        {
                        }
                        break;
                }
            }
            
        }
        static public void CommunicationWrite(Guid? GuidCommunicationID, string strCommunicationType, string tmp_Data)
        {
            string falseMsg = string.Empty;
            if (GuidCommunicationID != null)
            {
                switch (strCommunicationType)
                {
                    case "1"://串口
                        {
                            SerialCOMInit.WrirtCom_str(GuidCommunicationID.Value, tmp_Data, out falseMsg);
                        }
                        break;
                    case "2"://网络
                        {

                        }
                        break;
                }
            }
        }
    }
}
