using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol209sSR_Business
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
            byte[] tmp_byte;
            if (iAction == 110)/**左上*/
            {
                tmp_byte = Protocol209sSR.Protocol_Turntable(108, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sSR.Protocol_Turntable(106, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);

            }
            else if (iAction == 111)/**左下*/
            {
                tmp_byte = Protocol209sSR.Protocol_Turntable(108, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sSR.Protocol_Turntable(107, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);

            }
            else if (iAction == 112)/**右上*/
            {
                tmp_byte = Protocol209sSR.Protocol_Turntable(109, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sSR.Protocol_Turntable(106, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == 113)/**右下*/
            {
                tmp_byte = Protocol209sSR.Protocol_Turntable(109, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sSR.Protocol_Turntable(107, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else
            {
                tmp_byte = Protocol209sSR.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            return strTurntableResult;
        }

        static public string SetCCD(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_CCD = Protocol209sSR.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_CCD);
            return strCCDResult;
        }
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strIRResult = "";
            byte[] tmp_IR = Protocol209sSR.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_IR);
            return strIRResult;
        }

        static public string SetPresetTurntable(string strAddr, int iHorizontal, int iVertical, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_H = Protocol209sSR.PrePointSend_Horizontal(Convert.ToInt32(strAddr),iHorizontal);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_H);
            Thread.Sleep(50);
            byte[] tmp_V = Protocol209sSR.PrePointSend_Vertical(Convert.ToInt32(strAddr), iVertical);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_V);
            return strTurntableResult;
        }

        static public string SetPresetCCD(string strAddr, int iDepth, int iFocus, Guid? CommunicationGuid, string CommunicationType)
        {
            string strCCDResult = "";
            byte[] tmp_D = Protocol209sSR.PrePointSend_Depth(Convert.ToInt32(strAddr), iDepth);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_D);
            Thread.Sleep(50);
            byte[] tmp_F = Protocol209sSR.PrePointSend_Focus(Convert.ToInt32(strAddr), iFocus);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_F);
            return strCCDResult;
        }
        /// <summary>
        /// 红外预置位--暂无
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iDepth"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        static public string SetPresetIR(string strAddr, int iDepth, int iFocus, Guid? GuidCommunicationID, string strCommunicationType)
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
            //
            byte[] tmp_HSt = Protocol209sSR.PrePointSend_Horizontal(iAddr, iHorizontlSt);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_HSt);
            byte[] tmp_VSt = Protocol209sSR.PrePointSend_Vertical(iAddr, iVerticalSt);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_VSt);

            byte[] tmp_Origins = Protocol209sSR.SanScan_Origins(iAddr);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_Origins);
            Thread.Sleep(50);
            byte[] tmp_HEnd = Protocol209sSR.PrePointSend_Horizontal(iAddr, iHorizontlEnd);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_HEnd);
            byte[] tmp_VEnd = Protocol209sSR.PrePointSend_Vertical(iAddr, iVerticalEnd);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_VEnd);
            byte[] tmp_Destinations = Protocol209sSR.SanScan_Destinations(iAddr);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_Destinations);
            Thread.Sleep(50);
            byte[] tmp_Open = Protocol209sSR.SanScan_Open(iAddr);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_Open);
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
            byte[] tmp_Off = Protocol209sSR.SanScan_Off(iAddr);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_Off); 
            return strSanScanResult;
        }
    }
}
