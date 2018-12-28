﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol368s
    {
        static byte[] m_byteBuff = new byte[7];
        static byte[] m_byteBuff1 = new byte[10];

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
        private static byte Protocol_Bale(byte bAddr, byte bCmd, byte bD1, byte bD2, byte bD3, byte bD4)
        {
            byte bSum = (byte)(bAddr + bCmd + bD1 + bD2 + bD3 + bD4);
            return bSum;
            //return bSum;
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
            //byte[] b_Turntable = new byte[7];
            m_byteBuff = null;
            switch (iAction)
            {
                case 101://DPS复位
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x0B;
                        m_byteBuff[3] = 0x0C;
                        m_byteBuff[4] = 0x0E;
                        m_byteBuff[5] = 0x0F;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 102://开电机
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x01;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 103://关电机
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 104://自检
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x01;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 106://上
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 107://下
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)(255 - iSpeed);
                        m_byteBuff[6] = 255;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 108://左
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(255 - iSpeed);
                        m_byteBuff[4] = 255;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 109://右
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(iSpeed);
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 110://左上
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(255 - iSpeed);
                        m_byteBuff[4] = 255;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 111://左下
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(255 - iSpeed);
                        m_byteBuff[4] = 255;
                        m_byteBuff[5] = (byte)(255 - iSpeed);
                        m_byteBuff[6] = 255;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 112://右上
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(iSpeed);
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 113://右下
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = (byte)(iSpeed);
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)(255 - iSpeed);
                        m_byteBuff[6] = 255;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 114://停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
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
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 124://俯仰查询
                    {
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
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x21;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x0A;
                        m_byteBuff[5] = 0x08;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 202://变焦+ 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x21;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 203://变焦- 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x22;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x0A;
                        m_byteBuff[5] = 0x08;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 204://变焦- 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x22;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 205://聚焦+ 
                    {
                        m_byteBuff = new byte[9];
                        int n_Speed;
                        if (iSpeed == 0) { n_Speed = iSpeed; }
                        else if (iSpeed < 13) { n_Speed = 1; }
                        else if (iSpeed == 255) { n_Speed = 20; }
                        else { n_Speed = iSpeed / 13; }

                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x23;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = (byte)n_Speed;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 206://聚焦+ 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x23;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 207://聚焦-
                    {
                        m_byteBuff = new byte[9];
                        int n_Speed;
                        if (iSpeed == 0) { n_Speed = iSpeed; }
                        else if (iSpeed < 13) { n_Speed = 1; }
                        else if (iSpeed == 255) { n_Speed = 20; }
                        else { n_Speed = iSpeed / 13; }

                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x24;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = (byte)n_Speed;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 208://聚焦-停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x24;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 209://光圈+
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x12;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 210://光圈 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x12;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 211://光圈-
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x12;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 212://手动光圈
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2E;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 213://自动光圈
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2E;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 214://自动聚焦 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x29;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 215://自动聚焦 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x29;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 216://打开白光
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x28;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 217://关闭白光
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x28;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 218://透雾 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x27;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 219://透雾 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x27;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 220://Abf 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2F;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 221://Abf 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2F;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 222://扩展器 + 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2D;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 223://扩展器 停 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2D;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 224://扩展器 - 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2D;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 225://滤光镜 + 
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2B;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 226://滤光镜 停
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2B;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 227://滤光镜 -
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2B;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 228://光圈遥控 开
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2E;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 229://光圈遥控 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x2E;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
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
            switch (iAction)
            {
                case 301://变焦+
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xA5; m_byteBuff1[7] = 0xA5;
                        m_byteBuff1[3] = 0x6E; m_byteBuff1[8] = 0x6E;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 302://变焦 停
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0x80; m_byteBuff1[7] = 0x80;
                        m_byteBuff1[3] = 0x4B; m_byteBuff1[8] = 0x4B;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 303://变焦- 
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xC5; m_byteBuff1[7] = 0xC5;
                        m_byteBuff1[3] = 0x0E; m_byteBuff1[8] = 0x0E;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 304://聚焦+ 
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xA3; m_byteBuff1[7] = 0xA3;
                        m_byteBuff1[3] = 0x68; m_byteBuff1[8] = 0x68;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 305://聚焦 停
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0x80; m_byteBuff1[7] = 0x80;
                        m_byteBuff1[3] = 0x4B; m_byteBuff1[8] = 0x4B;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 306://聚焦-
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xC3; m_byteBuff1[7] = 0xC3;
                        m_byteBuff1[3] = 0x08; m_byteBuff1[8] = 0x08;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 307://十字叉 开
                    {

                    }
                    break;
                case 308://十字叉 关
                    {

                    }
                    break;
                case 309://白热模式
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xA6; m_byteBuff1[7] = 0xA6;
                        m_byteBuff1[3] = 0x6D; m_byteBuff1[8] = 0x6D;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 310://黑热模式
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xA6; m_byteBuff1[7] = 0xA6;
                        m_byteBuff1[3] = 0x6D; m_byteBuff1[8] = 0x6D;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 311://1X 镜
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xC5; m_byteBuff1[7] = 0xC5;
                        m_byteBuff1[3] = 0x0E; m_byteBuff1[8] = 0x0E;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 312://2X 镜
                    {
                        m_byteBuff = new byte[10];
                        m_byteBuff1[0] = 0xCA; m_byteBuff1[5] = 0xCA;
                        m_byteBuff1[1] = 0x01; m_byteBuff1[6] = 0x01;
                        m_byteBuff1[2] = 0xA5; m_byteBuff1[7] = 0xA5;
                        m_byteBuff1[3] = 0x6E; m_byteBuff1[8] = 0x6E;
                        m_byteBuff1[4] = 0xF1; m_byteBuff1[9] = 0xF1;
                    }
                    break;
                case 313://自动聚焦 开
                    {
                    }
                    break;
                case 314://自动聚焦 关
                    {
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
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x62;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = 0x01;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
                    }
                    break;
                case 322://红外 关
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0x7E;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x62;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0x00;
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xE7;
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
            m_byteBuff = new byte[9];
            byte[] tmp_H = BitConverter.GetBytes(iHorizontal);
            byte[] tmp_V = BitConverter.GetBytes(iVertical);

            m_byteBuff[0] = 0x7E;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x02;
            m_byteBuff[3] = tmp_H[0];
            m_byteBuff[4] = tmp_H[1];
            m_byteBuff[5] = tmp_V[0];
            m_byteBuff[6] = tmp_V[1];
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xE7;
            return m_byteBuff;
        }
        /// <summary>
        /// 镜头 预置位
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iDepth"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_DepthFocus(int iAddr, int iDepth, int iFocus)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[9];
            m_byteBuff[0] = 0x7E;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x2A;
            m_byteBuff[3] = 0x01;
            m_byteBuff[4] = (byte)iDepth;
            m_byteBuff[5] = 0x01;
            m_byteBuff[6] = (byte)iFocus;
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xE7;
            return m_byteBuff;
        }
        /// <summary>
        /// 转台扇扫 俯仰
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iVerticalSt"></param>
        /// <param name="iVerticalEnd"></param>
        /// <param name="iSpeed"></param>
        /// <returns></returns>
        public static byte[] SanScan_Vertical(int iAddr, int iVerticalSt, int iVerticalEnd, int iSpeed)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[9];
            int i = 4;
            if (iVerticalSt < 0) { i = i | (1 << 1); iVerticalSt = -iVerticalSt; }
            if (iVerticalEnd < 0) { i = i | (1 << 0); iVerticalEnd = -iVerticalEnd; }

            m_byteBuff[0] = 0x7E;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x03;
            m_byteBuff[3] = (byte)i;
            m_byteBuff[4] = (byte)iVerticalSt;
            m_byteBuff[5] = (byte)iVerticalEnd;
            m_byteBuff[6] = (byte)iSpeed;
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xE7;
            return m_byteBuff;
        }
        /// <summary>
        /// 转台扇扫 水平
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontlSt"></param>
        /// <param name="iHorizontlEnd"></param>
        /// <param name="iSpeed"></param>
        /// <returns></returns>
        public static byte[] SanScan_Horizontl(int iAddr, int iHorizontlSt, int iHorizontlEnd, int iSpeed)
        {
            int j = 0;
            if (iHorizontlSt < 0) { j = j | (1 << 1); iHorizontlSt = -iHorizontlSt; }
            if (iHorizontlEnd < 0) { j = j | (1 << 0); iHorizontlEnd = -iHorizontlEnd; }

            m_byteBuff[0] = 0x7E;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x03;
            m_byteBuff[3] = (byte)j;
            m_byteBuff[4] = (byte)iHorizontlSt;
            m_byteBuff[5] = (byte)iHorizontlEnd;
            m_byteBuff[6] = (byte)iSpeed;
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xE7;
            return m_byteBuff;
        }
        /// <summary>
        /// 扇扫 停
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_Off(int iAddr)
        {
            m_byteBuff[0] = 0x7E;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x04;
            m_byteBuff[3] = 0;
            m_byteBuff[4] = 0;
            m_byteBuff[5] = 0;
            m_byteBuff[6] = 0;
            m_byteBuff[7] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
            m_byteBuff[8] = 0xE7;
            return m_byteBuff;
        }
    }
}
