using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol209sRY_Business
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
            byte[] tmp_byte = Protocol209sRY.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }
        /// <summary>
        /// 白光控制
        /// </summary>
        /// <param name="iAction"></param>
        /// <param name="strAddr"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <param name="strCommunicationID"></param>
        /// <returns></returns>
        static public string SetCCD(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_byte = Protocol209sRY.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strCCDResult;
        }
        /// <summary>
        /// 红外控制
        /// </summary>
        /// <param name="iAction"></param>
        /// <param name="strAddr"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <param name="strCommunicationID"></param>
        /// <returns></returns>
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, 
            string strCommunicationType)
        {
            string strIRResult = "";
            byte[] tmp_byte = Protocol209sRY.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, strCommunicationType, tmp_byte);
            return strIRResult;
        }

        /// <summary>
        /// 转台预置位
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        static public string SetPresetTurntable(string strAddr, int iHorizontal, int iVertical, Guid? CommunicationGuid, 
            string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_H_V = Protocol209sRY.PrePointSend_HorizontalVertical(Convert.ToInt32(strAddr), iHorizontal, iVertical);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_H_V);
            return strTurntableResult;
        }
        /// <summary>
        /// 白光预置位
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iDepth"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        static public string SetPresetCCD(string strAddr, int iDepth, int iFocus, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_D_F = Protocol209sRY.PrePointSend_DepthFocus(Convert.ToInt32(strAddr), iDepth, iFocus);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_D_F);
            return strCCDResult;
        }
        /// <summary>
        /// 红外预置位--暂无
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iDepth"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        static public string SetPresetIR(string strAddr, int iDepth, int iFocus)
        {
            string strIRResult = "";

            return strIRResult;
        }
        /// <summary>
        /// 扇扫开启
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Open(int iAddr, int iHorizontlSt, int iHorizontlEnd, int iSpeed_H, int iVerticalSt, 
            int iVerticalEnd, int iSpeed_V, Guid? CommunicationGuid, string CommunicationType)
        {
            string strSanScanResult = "";
            byte[] tmpSanScan_V = Protocol209sRY.SanScan_Vertical(iAddr, iVerticalSt, iVerticalEnd, iSpeed_V);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_V);
            Thread.Sleep(50);
            byte[] tmpSanScan_H = Protocol209sRY.SanScan_Horizontl(iAddr, iHorizontlSt, iHorizontlEnd, iSpeed_H);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_H);
            return strSanScanResult;
        }

        /// <summary>
        /// 扇扫关闭
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Off(int iAddr, Guid? CommunicationGuid, string CommunicationType)
        {
            string strSanScanResult = "";
            byte[] tmpSanScan_Off = Protocol209sRY.SanScan_Off(iAddr);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_Off);
            return strSanScanResult;
        }
    }
}
