using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class ProtocolOP3_Business
    {
        static public string SetTurntable(int iAction, string strAddr, int iSpeed, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_byte = ProtocolOP3.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }
        static public string SetCCD(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_CCD = ProtocolOP3.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_CCD);
            return strCCDResult;
        }
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? GuidCommunicationID, string strCommunicationType)
        {
            string strIRResult = "";
            //byte[] tmp_IR = ProtocolOP3.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            return strIRResult;
        }

        static public string SetPresetTurntable(string strAddr, int iHorizontal, int iVertical, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strTurntableResult = "";
            //byte[] tmp_HV = ProtocolOP3.PrePointSend_HorizontalVertical(Convert.ToInt32(strAddr), iHorizontal, iVertical);
            return strTurntableResult;
        }

        static public string SetPresetCCD(string strAddr, int iDepth, int iFocus, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strCCDResult = "";
            //byte[] tmp_DF = ProtocolOP3.PrePointSend_DepthFocus(Convert.ToInt32(strAddr), iDepth, iFocus);
            return strCCDResult;
        }
        /// <summary>
        /// 红外预置位--暂无
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iDepth"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        static public string SetPresetIR(string strAddr, int iDepth, int iFocus, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strIRResult = "";
            return strIRResult;
        }

        /// <summary>
        /// 扇扫开启
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Open(string strAddr, int iHorizontlSt, int iHorizontlEnd, int iSpeed_H, int iVerticalSt, int iVerticalEnd, int iSpeed_V, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strSanScanResult = "";
            //byte[] tmp_SanScan_OpenH = ProtocolOP3.SanScan_Horizontl(Convert.ToInt32(strAddr), iHorizontlSt, iHorizontlEnd, iSpeed_H);
            //byte[] tmp_SanScan_OpenV = ProtocolOP3.SanScan_Vertical(Convert.ToInt32(strAddr), iVerticalSt, iVerticalEnd, iSpeed_V);
            return strSanScanResult;
        }
        /// <summary>
        /// 扇扫关闭
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Off(string strAddr, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strSanScanResult = "";
            //byte[] tmp_Off = ProtocolOP3.SanScan_Off(Convert.ToInt32(strAddr));
            return strSanScanResult;
        }
    }
}
