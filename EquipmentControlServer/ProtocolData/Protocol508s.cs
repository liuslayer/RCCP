using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol508s
    {
        static byte[] m_byteBuff;
        //static byte[] m_byteBuff2;
        /// <summary>
        /// 校验位计算
        /// </summary>
        /// <param name="bAddr"></param>
        /// <param name="bCmd"></param>
        /// <param name="bD1"></param>
        /// <param name="bD2"></param>
        /// <param name="bD3"></param>
        /// <param name="bD4"></param>
        /// <returns></returns>
        private static byte Protocol_Bale(byte bHd, byte bAddr, byte bLen, byte bC1, byte bC2, byte bD1, byte bD2, byte bD3, byte bD4)
        {
            byte bSum = (byte)(bHd ^ bAddr ^ bLen ^ bC1 ^ bC2 ^ bD1 ^ bD2 ^ bD3 ^ bD4);
            return bSum;
            //return bSum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bHd"></param>
        /// <param name="bAddr"></param>
        /// <param name="bLen"></param>
        /// <param name="bC1"></param>
        /// <param name="bC2"></param>
        /// <param name="bD1"></param>
        /// <param name="bD2"></param>
        /// <returns></returns>
        private static byte Protocol_Bale(byte bHd, byte bAddr, byte bLen, byte bC1, byte bC2, byte bD1, byte bD2)
        {
            byte bSum = (byte)(bHd ^ bAddr ^ bLen ^ bC1 ^ bC2 ^ bD1 ^ bD2);
            return bSum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bHd"></param>
        /// <param name="bAddr"></param>
        /// <param name="bLen"></param>
        /// <param name="bC1"></param>
        /// <param name="bD1"></param>
        /// <param name="bD2"></param>
        /// <param name="bD3"></param>
        /// <param name="bD4"></param>
        /// <returns></returns>
        private static byte Protocol_Bale(byte bHd, byte bAddr, byte bLen, byte bC1, byte bD1, byte bD2, byte bD3, byte bD4)
        {
            byte bSum = (byte)(bHd ^ bAddr ^ bLen ^ bC1 ^ bD1 ^ bD2 ^ bD3 ^ bD4);
            return bSum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bHd"></param>
        /// <param name="bAddr"></param>
        /// <param name="bLen"></param>
        /// <param name="bC1"></param>
        /// <param name="bC2"></param>
        /// <param name="bD1"></param>
        /// <param name="bD2"></param>
        /// <param name="bD3"></param>
        /// <param name="bD4"></param>
        /// <param name="bD5"></param>
        /// <param name="bD6"></param>
        /// <param name="bD7"></param>
        /// <param name="bD8"></param>
        /// <returns></returns>
        private static byte Protocol_Bale(byte bHd, byte bAddr, byte bLen, byte bC1, byte bC2, byte bD1, byte bD2, byte bD3, byte bD4, byte bD5, byte bD6, byte bD7, byte bD8)
        {
            byte bSum = (byte)(bHd ^ bAddr ^ bLen ^ bC1 ^ bC2 ^ bD1 ^ bD2 ^ bD3 ^ bD4 ^ bD5 ^ bD6 ^ bD7 ^ bD8);
            return bSum;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAction"></param>
        /// <param name="iAddr"></param>
        /// <param name="iSpeed"></param>
        /// <returns></returns>
        public static byte[] Protocol_Turntable(int iAction, int iAddr, int iSpeed)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 101://DPS复位
                    {
                    }
                    break;
                case 102://开电机
                    {
                    }
                    break;
                case 103://关电机
                    {
                    }
                    break;
                case 104://自检
                    {
                    }
                    break;
                case 106://上
                    {
                        m_byteBuff = new byte[11];
                        iSpeed = iSpeed * 100;
                        byte[] bSpeed = System.BitConverter.GetBytes(iSpeed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = bSpeed[1];
                        m_byteBuff[8] = bSpeed[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 107://下
                    {
                        m_byteBuff = new byte[11];
                        iSpeed = ~(iSpeed * 100) + 1;
                        byte[] bSpeed = System.BitConverter.GetBytes(iSpeed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = bSpeed[1];
                        m_byteBuff[8] = bSpeed[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 108://左
                    {
                        m_byteBuff = new byte[11];
                        iSpeed = ~(iSpeed * 100) + 1;
                        byte[] bSpeed = System.BitConverter.GetBytes(iSpeed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed[1];
                        m_byteBuff[6] = bSpeed[0];
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = 0x00;
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 109://右
                    {
                        m_byteBuff = new byte[11];
                        iSpeed = iSpeed * 100;
                        byte[] bSpeed = System.BitConverter.GetBytes(iSpeed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed[1];
                        m_byteBuff[6] = bSpeed[0];
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = 0x00;
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 110://左上
                    {
                        m_byteBuff = new byte[11];
                        int tmp_Speed = 0;
                        iSpeed = iSpeed * 100;
                        tmp_Speed = ~iSpeed + 1;
                        byte[] bSpeed1 = System.BitConverter.GetBytes(iSpeed);
                        byte[] bSpeed2 = System.BitConverter.GetBytes(tmp_Speed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed2[1];
                        m_byteBuff[6] = bSpeed2[0];
                        m_byteBuff[7] = bSpeed1[1];
                        m_byteBuff[8] = bSpeed1[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 111://左下
                    {
                        m_byteBuff = new byte[11];
                        int tmp_Speed = 0;
                        iSpeed = iSpeed * 100;
                        tmp_Speed = ~iSpeed + 1;
                        //byte[] bSpeed1 = System.BitConverter.GetBytes(iSpeed);
                        byte[] bSpeed2 = System.BitConverter.GetBytes(tmp_Speed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed2[1];
                        m_byteBuff[6] = bSpeed2[0];
                        m_byteBuff[7] = bSpeed2[1];
                        m_byteBuff[8] = bSpeed2[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 112://右上
                    {
                        m_byteBuff = new byte[11];
                        iSpeed = iSpeed * 100;
                        byte[] bSpeed1 = System.BitConverter.GetBytes(iSpeed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed1[1];
                        m_byteBuff[6] = bSpeed1[0];
                        m_byteBuff[7] = bSpeed1[1];
                        m_byteBuff[8] = bSpeed1[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 113://右下
                    {
                        m_byteBuff = new byte[11];
                        int tmp_Speed = 0;
                        iSpeed = iSpeed * 100;
                        tmp_Speed = ~iSpeed + 1;
                        byte[] bSpeed1 = System.BitConverter.GetBytes(iSpeed);
                        byte[] bSpeed2 = System.BitConverter.GetBytes(tmp_Speed);
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = bSpeed1[1];
                        m_byteBuff[6] = bSpeed1[0];
                        m_byteBuff[7] = bSpeed2[1];
                        m_byteBuff[8] = bSpeed2[0];
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 114://停
                    {
                        m_byteBuff = new byte[11];
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x4D;
                        m_byteBuff[4] = 0x58;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = 0x00;
                        m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 115://风扇1 开
                    {
                    }
                    break;
                case 116://风扇1 关
                    {
                    }
                    break;
                case 117://风扇2 开
                    {
                    }
                    break;
                case 118://风扇2 关
                    {
                    }
                    break;
                case 119://加热片1 开
                    {
                    }
                    break;
                case 120://加热片1 关
                    {
                    }
                    break;
                case 121://加热片2 开
                    {
                    }
                    break;
                case 122://加热片2 关
                    {
                    }
                    break;
                case 123://方位查询
                    {
                        m_byteBuff = new byte[11];
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x51;
                        m_byteBuff[4] = 0x50;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = 0x00;
                        m_byteBuff[9] = 0x00;
                        m_byteBuff[10] = 0xAF;
                    }
                    break;
                case 124://俯仰查询
                    {
                        m_byteBuff = new byte[11];
                        m_byteBuff[0] = 0xA1;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x51;
                        m_byteBuff[4] = 0x50;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = 0x00;
                        m_byteBuff[9] = 0x00;
                        m_byteBuff[10] = 0xAF;
                    }
                    break;

            }
            return m_byteBuff;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAction"></param>
        /// <param name="iAddr"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static byte[] Protocol_CCD(int iAction, int iAddr, int iSpeed, int iValue)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 201://变焦+
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x56;
                        m_byteBuff[4] = 0x41;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xBC;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 202://变焦+ 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x56;
                        m_byteBuff[4] = 0x53;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xAE;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 203://变焦- 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x56;
                        m_byteBuff[4] = 0x4D;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xB0;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 204://变焦- 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x56;
                        m_byteBuff[4] = 0x53;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xAE;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 205://聚焦+ 
                    {
                        int n_Speed = 0;
                        if (iSpeed < 50)
                        {
                            n_Speed = 50;
                        }
                        else if (iSpeed > 250)
                        {
                            n_Speed = 250;
                        }
                        else
                        {
                            n_Speed = iSpeed;
                        }
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x46;
                        m_byteBuff[4] = 0x4D;
                        m_byteBuff[5] = (byte)n_Speed;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 206://聚焦+ 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x46;
                        m_byteBuff[4] = 0x53;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 207://聚焦-
                    {
                        int n_Speed = 0;
                        if (iSpeed < 50)
                        {
                            n_Speed = 50;
                        }
                        else if (iSpeed > 250)
                        {
                            n_Speed = 250;
                        }
                        else
                        {
                            n_Speed = iSpeed;
                        }
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x46;
                        m_byteBuff[4] = 0x41;
                        m_byteBuff[5] = (byte)n_Speed;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 208://聚焦-停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x46;
                        m_byteBuff[4] = 0x53;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 209://光圈+
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x49;
                        m_byteBuff[4] = 0x41;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xA3;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 210://光圈 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x49;
                        m_byteBuff[4] = 0x53;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xB1;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 211://光圈-
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x49;
                        m_byteBuff[4] = 0x4D;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xAF;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 212://手动光圈
                    {

                    }
                    break;
                case 213://自动光圈
                    {

                    }
                    break;
                case 214://自动聚焦 开
                    {

                    }
                    break;
                case 215://自动聚焦 关
                    {

                    }
                    break;
                case 216://打开白光
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x43;
                        m_byteBuff[4] = 0x4E;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xA6;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 217://关闭白光
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x43;
                        m_byteBuff[4] = 0x46;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xAE;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 218://透雾 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x42;
                        m_byteBuff[4] = 0x4C;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xA5;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 219://透雾 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x43;
                        m_byteBuff[4] = 0x4C;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xA4;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 220://Abf 开
                    {

                    }
                    break;
                case 221://Abf 关
                    {

                    }
                    break;
                case 222://扩展器 + 
                    {

                    }
                    break;
                case 223://扩展器 停 
                    {

                    }
                    break;
                case 224://扩展器 - 
                    {

                    }
                    break;
                case 225://滤光镜 + 
                    {

                    }
                    break;
                case 226://滤光镜 停
                    {

                    }
                    break;
                case 227://滤光镜 -
                    {

                    }
                    break;
                case 228://光圈遥控 开
                    {
                    }
                    break;
                case 229://光圈遥控 关
                    {
                    }
                    break;
                case 230://变倍信息
                    {
                    }
                    break;
                case 231://聚焦信息
                    {
                    }
                    break;
            }
            return m_byteBuff;
        }

        /// <summary>
        /// 红外控制
        /// </summary>
        /// <param name="iAction"></param>
        /// <param name="iAddr"></param>
        /// <param name="iSpeed"></param>
        /// <param name="iValue"></param>
        /// <returns></returns>
        public static byte[] Protocol_IR(int iAction, int iAddr, int iSpeed, int iValue)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 301://变焦+
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 302://变焦 停
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 303://变焦- 
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x02;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 304://聚焦+ 
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x06;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 305://聚焦 停
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x08;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 306://聚焦-
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x70;
                        m_byteBuff[4] = 0x07;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 307://十字叉 开
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x18;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 308://十字叉 关
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x18;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 309://白热模式
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x06;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 310://黑热模式
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x06;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 311://1X 镜
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x05;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 312://2X 镜
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x05;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 313://自动聚焦 开
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x74;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 314://自动聚焦 关
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff[0] = 0xA3;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0A;
                        m_byteBuff[3] = 0x74;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0x00;
                        m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
                        m_byteBuff[9] = 0xAF;
                    }
                    break;
                case 315://亮度
                    {
                    }
                    break;
                case 316://对比度
                    {
                    }
                    break;
                case 317://伪彩
                    {
                    }
                    break;
                case 318://伽马校验
                    {
                    }
                    break;
                case 319://手动校验
                    {
                    }
                    break;
                case 320://背景校验
                    {
                    }
                    break;
                case 321://红外 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x49;
                        m_byteBuff[4] = 0x4E;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xAC;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
                case 322://红外 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xA2;
                        m_byteBuff[1] = 0x00;
                        m_byteBuff[2] = 0x09;
                        m_byteBuff[3] = 0x49;
                        m_byteBuff[4] = 0x46;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = 0xA4;
                        m_byteBuff[8] = 0xAF;
                    }
                    break;
            }
            return m_byteBuff;
        }
        /// <summary>
        /// 转台-预置位
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_HorizontalVertical(int iAddr, int iHorizontal, int iVertical)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[15];
            byte[] tmp_H = BitConverter.GetBytes(iHorizontal);
            byte[] tmp_V = BitConverter.GetBytes(iVertical);

            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0F;
            m_byteBuff[3] = 0x50;
            m_byteBuff[4] = 0x32;
            m_byteBuff[5] = tmp_H[3];
            m_byteBuff[6] = tmp_H[2];
            m_byteBuff[7] = tmp_H[1];
            m_byteBuff[8] = tmp_H[0];
            m_byteBuff[9] = tmp_V[3];
            m_byteBuff[10] = tmp_V[2];
            m_byteBuff[11] = tmp_V[1];
            m_byteBuff[12] = tmp_V[0];
            m_byteBuff[13] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7],
                m_byteBuff[8], m_byteBuff[9], m_byteBuff[10], m_byteBuff[11], m_byteBuff[12]);
            m_byteBuff[14] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Open(int iAddr)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[10];
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0B;
            m_byteBuff[3] = 0x50;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = 0x00;
            m_byteBuff[7] = 0x00;
            m_byteBuff[8] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7]);
            m_byteBuff[9] = 0xAF;
            return m_byteBuff;
        }
        public static byte[] PrePointSend_Depth(int iAddr, int iDepth)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[9];
            byte[] tmpbsz_D = System.BitConverter.GetBytes(iDepth);
            m_byteBuff[0] = 0xA2;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x09;
            m_byteBuff[3] = 0x50;
            m_byteBuff[4] = 0x41;
            m_byteBuff[5] = tmpbsz_D[0];
            m_byteBuff[6] = tmpbsz_D[1];
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_1(int iAddr)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[11];
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0B;
            m_byteBuff[3] = 0x50;
            m_byteBuff[4] = 0x02;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = 0x00;
            m_byteBuff[7] = 0x00;
            m_byteBuff[8] = 0x00;
            m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
            m_byteBuff[10] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_2(int iAddr)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[11];
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0B;
            m_byteBuff[3] = 0x43;
            m_byteBuff[4] = 0x51;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = 0x00;
            m_byteBuff[7] = 0x00;
            m_byteBuff[8] = 0x02;
            m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
            m_byteBuff[10] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iTimeNo"></param>
        /// <param name="iTime"></param>
        /// <returns></returns>
        public static byte[] SanScan_Time(int iAddr, int iTimeNo,int iTime)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[11];
            iTime = iTime * 1000;
            byte[] tmp_Time = System.BitConverter.GetBytes(iTime);
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0B;
            m_byteBuff[3] = 0x43;
            m_byteBuff[4] = 0x48;
            m_byteBuff[5] = (byte)iTimeNo;
            m_byteBuff[6] = 0x00;
            m_byteBuff[7] = tmp_Time[1];
            m_byteBuff[8] = tmp_Time[0];
            m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
            m_byteBuff[10] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontalSpeed"></param>
        /// <param name="iVerticalSpeed"></param>
        /// <returns></returns>
        public static byte[] SanScan_Speed(int iAddr,int iHorizontalSpeed,int iVerticalSpeed)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[11];
            iHorizontalSpeed = iHorizontalSpeed * 100;
            iVerticalSpeed = iVerticalSpeed * 100;
            byte[] tmpHorizontalSpeed = System.BitConverter.GetBytes(iHorizontalSpeed);
            byte[] tmpVerticalSpeed = System.BitConverter.GetBytes(iVerticalSpeed);
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0B;
            m_byteBuff[3] = 0x43;
            m_byteBuff[4] = 0x53;
            m_byteBuff[5] = tmpHorizontalSpeed[1];
            m_byteBuff[6] = tmpHorizontalSpeed[0];
            m_byteBuff[7] = tmpVerticalSpeed[1];
            m_byteBuff[8] = tmpVerticalSpeed[0];
            m_byteBuff[9] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7], m_byteBuff[8]);
            m_byteBuff[10] = 0xAF;
            return m_byteBuff;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        public static byte[] SanScan_HorizontalVertical(int iAddr, int iHorizontal, int iVertical)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[15];
            byte[] tmp_H = BitConverter.GetBytes(iHorizontal);
            byte[] tmp_V = BitConverter.GetBytes(iVertical);
            m_byteBuff[0] = 0xA1;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x0F;
            m_byteBuff[3] = 0x43;
            m_byteBuff[4] = 0x50;
            m_byteBuff[5] = tmp_H[3];
            m_byteBuff[6] = tmp_H[2];
            m_byteBuff[7] = tmp_H[1];
            m_byteBuff[8] = tmp_H[0];
            m_byteBuff[9] = tmp_V[3];
            m_byteBuff[10] = tmp_V[2];
            m_byteBuff[11] = tmp_V[1];
            m_byteBuff[12] = tmp_V[0];
            m_byteBuff[13] = Protocol_Bale(m_byteBuff[0], m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6], m_byteBuff[7],
                m_byteBuff[8], m_byteBuff[9], m_byteBuff[10], m_byteBuff[11], m_byteBuff[12]);
            m_byteBuff[14] = 0xAF;
            return m_byteBuff;
        }
    }
}
