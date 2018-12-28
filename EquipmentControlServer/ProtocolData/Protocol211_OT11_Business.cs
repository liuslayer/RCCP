using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol211_OT11_Business
    {
        /// <summary>
        /// 转台控制
        /// </summary>
        /// <param name="iAction">动作</param>
        /// <param name="iAddr">地址</param>
        /// <param name="iSpeed">速度</param>
        /// <param name="iCommunicationID">通信ID</param>
        /// <returns></returns>
        static public string SetTurntable(int iAction, string strAddr, int iSpeed, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_byte = Protocol211_OT11.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }

        static public string SetCCD(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_CCD = Protocol211_OT11.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_CCD);
            return strCCDResult;
        }
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strIRResult = "";
            byte[] tmp_IR = Protocol211_OT11.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_IR);
            return strIRResult;
        }

        static public string SetPresetTurntable(string strAddr, int iHorizontal, int iVertical, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strTurntableResult = "";
            return strTurntableResult;
        }

        static public string SetPresetCCD(string strAddr, int iDepth, int iFocus, Guid GuidCommunicationID, string strCommunicationType)
        {
            string strCCDResult = "";
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
            return strSanScanResult;
        }
    }
}
