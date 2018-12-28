using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class ProtocolPelcoD_Business
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
            if (iAction == 1)/**左上*/
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(108, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(106, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == 1)/**左下*/
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(108, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(107, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == 1)/**右上*/
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(109, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(106, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == 1)/**右下*/
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(109, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(107, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == 1)/**获取转台方位、俯仰*/
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(123, Convert.ToInt32(strAddr), iSpeed);/**水平-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(124, Convert.ToInt32(strAddr), iSpeed);/**俯仰-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else
            {
                tmp_byte = ProtocolPelcoD.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
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
            byte[] tmp_byte = ProtocolPelcoD.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
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
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? GuidCommunicationID, string strCommunicationType)
        {
            string strIRResult = "";
            //byte[] tmp_byte = ProtocolPelcoD.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            //缺少对外输出的接口
            return strIRResult;
        }

        /// <summary>
        /// 转台预置位
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>GetPreset
        static public string GetPreset(string strAddr, int iPresetNum, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_byte = ProtocolPelcoD.SetPreset(Convert.ToInt32(strAddr), iPresetNum);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }
        static public string SetPreset(string strAddr, int iPresetNum, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_byte = ProtocolPelcoD.GetPreset(Convert.ToInt32(strAddr), iPresetNum);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }

        static public string DelPreset(string strAddr, int iPresetNum, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_byte = ProtocolPelcoD.DelPreset(Convert.ToInt32(strAddr), iPresetNum);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strTurntableResult;
        }
        /// <summary>
        /// 扇扫开启
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Open(string strAddr, int iHorizontlSt, int iHorizontlEnd, int iSpeed_H, int iVerticalSt, 
            int iVerticalEnd, int iSpeed_V, Guid? GuidCommunicationID, string strCommunicationType)
        {
            string strSanScanResult = "";
            return strSanScanResult;
        }

        /// <summary>
        /// 扇扫关闭
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Off(string strAddr, Guid? GuidCommunicationID, string strCommunicationType)
        {
            string strSanScanResult = "";
            byte[] tmpSanScan_Off_V = ProtocolPelcoD.Protocol_Turntable(125, Convert.ToInt32(strAddr), 0);
            Thread.Sleep(50);
            byte[] tmpSanScan_Off_H = ProtocolPelcoD.Protocol_Turntable(114, Convert.ToInt32(strAddr), 0);

            return strSanScanResult;
        }
    }
}
