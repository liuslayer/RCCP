using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol209sPT100_Business
    {
        /// <summary>
        /// 转台控制
        /// </summary>
        /// <param name="iAction">动作</param>
        /// <param name="iAddr">地址</param>
        /// <param name="iSpeed">速度</param>
        /// <param name="iCommunicationID">通信ID</param>
        /// <returns></returns>
        static public string SetTurntable(int iAction, string strAddr, int iSpeed, Guid? CommunicationGuid, string CommunicationType, int iValue)
        {
            string strTurntableResult = "";
            byte[] tmp_byte;
            if(iAction == (int)HDCommand.InitialPoint)//复位
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(101, Convert.ToInt32(strAddr), iSpeed);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(128, Convert.ToInt32(strAddr), iSpeed);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if(iAction == (int)HDCommand.MotorOpen)/**电机开*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(102, Convert.ToInt32(strAddr), iSpeed);/**水平-电机开*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(126, Convert.ToInt32(strAddr), iSpeed);/**俯仰-电机开*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if(iAction ==(int)HDCommand.MotorOpen)/**电机关*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(103, Convert.ToInt32(strAddr), iSpeed);/**水平-电机关*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(127, Convert.ToInt32(strAddr), iSpeed);/**俯仰-电机关*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.DirectionStop)/**停*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(114, Convert.ToInt32(strAddr), iSpeed);/**水平-停*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(125, Convert.ToInt32(strAddr), iSpeed);/**俯仰-停*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(123, Convert.ToInt32(strAddr), iSpeed);/**水平-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(124, Convert.ToInt32(strAddr), iSpeed);/**俯仰-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.LeftUp)/**左上*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Up, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Left, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.LeftDown)/**左下*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Down, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Left, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.RightUp)/**右上*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Up, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Right, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.RightDown)/**右下*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Down, Convert.ToInt32(strAddr), iSpeed);/**水平控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable((int)HDCommand.Right, Convert.ToInt32(strAddr), iSpeed);/**俯仰控制*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else if (iAction == (int)HDCommand.HorizontalQuery || iAction == (int)HDCommand.VerticalQuery)/**获取转台方位、俯仰*/
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(123, Convert.ToInt32(strAddr), iSpeed);/**水平-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
                Thread.Sleep(50);
                tmp_byte = Protocol209sPT100.Protocol_Turntable(124, Convert.ToInt32(strAddr), iSpeed);/**俯仰-查询*/
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else
            {
                tmp_byte = Protocol209sPT100.Protocol_Turntable(iAction, Convert.ToInt32(strAddr), iSpeed);
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
            if (iAction == (int)CCDCommand.CCD_Autofocus)
            {
                byte[] tmp_byte = Protocol209sPT100.Protocol_CCD((int)CCDCommand.CCD_AutofocusOpen, Convert.ToInt32(strAddr), iSpeed, iValue);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }
            else
            {
                byte[] tmp_byte = Protocol209sPT100.Protocol_CCD(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
                CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            }

            
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
        static public string SetIR(int iAction, string strAddr, int iSpeed, int iValue, Guid? CommunicationGuid, string CommunicationType)
        {
            string strIRResult = "";
            byte[] tmp_byte = Protocol209sPT100.Protocol_IR(iAction, Convert.ToInt32(strAddr), iSpeed, iValue);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_byte);
            return strIRResult;
        }

        /// <summary>
        /// 转台预置位
        /// </summary>
        /// <param name="strAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        static public string SetPresetTurntable(string strAddr, int iHorizontal, int iVertical, Guid? CommunicationGuid, string CommunicationType)
        {
            string strTurntableResult = "";
            byte[] tmp_H = Protocol209sPT100.PrePointSend_Horizontal(Convert.ToInt32(strAddr), iHorizontal);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_H);
            Thread.Sleep(50);
            byte[] tmp_V = Protocol209sPT100.PrePointSend_Vertical(Convert.ToInt32(strAddr), iVertical);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_V);
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
            byte[] tmp_D = Protocol209sPT100.PrePointSend_Depth(Convert.ToInt32(strAddr), iDepth);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmp_D);
            Thread.Sleep(50);
            byte[] tmp_F = Protocol209sPT100.PrePointSend_Focus(Convert.ToInt32(strAddr), iFocus);
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
        static public string SetPresetIR(string strAddr, int iDepth, int iFocus, Guid? CommunicationGuid, string CommunicationType)
        {
            string strIRResult = "";

            return strIRResult;
        }
        /// <summary>
        /// 扇扫开启
        /// </summary>
        /// <param name="strAddr"></param>
        /// <returns></returns>
        static public string SetSanScan_Open(int iAddr, int iHorizontlSt, int iHorizontlEnd, int iSpeed_H, int iVerticalSt, int iVerticalEnd, 
            int iSpeed_V, Guid? CommunicationGuid, string CommunicationType)
        {
            string strSanScanResult = "";
            byte[] tmpSanScan_V = Protocol209sPT100.SanScan_Vertical(iAddr, iVerticalSt, iVerticalEnd, iSpeed_V);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_V);
            Thread.Sleep(50);
            byte[] tmpSanScan_H = Protocol209sPT100.SanScan_Horizontl(iAddr, iHorizontlSt, iHorizontlEnd, iSpeed_H);
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
            byte[] tmpSanScan_Off_V = Protocol209sPT100.Protocol_Turntable(125, iAddr, 0);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_Off_V);
            Thread.Sleep(50);
            byte[] tmpSanScan_Off_H = Protocol209sPT100.Protocol_Turntable(114, iAddr, 0);
            CommunicationTransmission.CommunicationWrite(CommunicationGuid, CommunicationType, tmpSanScan_Off_H);
            return strSanScanResult;
        }
    }
}
