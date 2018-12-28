using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol209sPT100
    {
        static byte[] m_byteBuff1;
        static byte[] m_byteBuff2;

        private struct CMD209PT100
        {
            public byte bHd1;
            public byte bHd2;
            public byte bAddr1;
            public byte bAddr2;
            public byte[] bData;
            public byte bCmd;
            public byte bD1;
            public byte bD2;
            public byte bD3;
            public byte bD4;
            public byte bD5;
            public byte bD6;
            public byte bD7;
            public byte bD8;
            public byte bD9;
            public byte bSum;
            public byte bTail;
        }

        private CMD209PT100 tmp_PT200;
        private static byte Protocol_Bale(byte[] bData, int len)
        {
            byte i = 0; byte j = 0;
            byte crc_register = 0;
            while (len-- != 0)
            {
                for (i = 0x80; i != 0; i /= 2)
                {
                    if ((crc_register & 0x80) != 0)
                    {
                        crc_register *= 2;
                        crc_register ^= 0x07;
                    } /* 余式CRC乘以2再求CRC */
                    else crc_register *= 2;
                    if ((bData[j] & i) != 0) crc_register ^= 0x07; /* 再加上本位的CRC */
                }
                j++;
            }
            return crc_register;
        }
        public static byte[] Protocol_Turntable(int iAction, int iAddr, int iSpeed)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            switch (iAction)
            {
                case 101://DPS 水平复位
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x42;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 102://开电机
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x41;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 103://关电机
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x40;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 104://自检
                    {
                    }
                    break;
                case (int)HDCommand.Up://上
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        iSpeed = iSpeed * 2;
                        if (iSpeed > 350)
                        {
                            iSpeed = 350;
                        }
                        iSpeed = 65535 - (iSpeed - 1);

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x46;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = (byte)iSpeed;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = (byte)(iSpeed >> 8);//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)HDCommand.Down://下
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        iSpeed = iSpeed * 2;
                        if (iSpeed > 350)
                        {
                            iSpeed = 350;
                        }

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x46;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = (byte)iSpeed;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = (byte)(iSpeed >> 8);//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)HDCommand.Left://左
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        iSpeed = iSpeed * 2;
                        iSpeed = 65535 - (iSpeed - 1);

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x46;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = (byte)iSpeed;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = (byte)(iSpeed >> 8);//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)HDCommand.Right://右
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        iSpeed = iSpeed * 2;

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x46;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = (byte)iSpeed;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = (byte)(iSpeed >> 8);//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7; ;
                    }
                    break;
                case 110://左上
                    {
                    }
                    break;
                case 111://左下
                    {
                    }
                    break;
                case 112://右上
                    {
                    }
                    break;
                case 113://右下
                    {
                    }
                    break;
                case 114://停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x45;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
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
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x48;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 124://俯仰查询
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x48;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 125://俯仰 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x45;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 126://俯仰电机 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x40;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 127://俯仰电机 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x41;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 128://DPS 俯仰复位
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x42;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;

            }
            return m_byteBuff1;
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
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            switch (iAction)
            {
                case (int)CCDCommand.CCD_TurnLong://变焦+
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x00;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_TurnLongStop://变焦+ 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x02;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_TurnShort://变焦- 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x01;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_TurnShortStop://变焦- 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x02;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_FocusLong://聚焦+ 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x03;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iSpeed;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_FocusLongStop://聚焦+ 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x05;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_FocusShort://聚焦-
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x04;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iSpeed;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_FocusShortStop://聚焦-停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x05;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 209://光圈+
                    {
                    }
                    break;
                case 210://光圈 停
                    {
                    }
                    break;
                case 211://光圈-
                    {
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
                case (int)CCDCommand.CCD_AutofocusOpen://自动聚焦 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x17;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_AutofocusOff://自动聚焦 关
                    {

                    }
                    break;
                case (int)CCDCommand.CCD_Open://打开白光
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x12;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_Off://关闭白光
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x13;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_PenetratingFogOpen://透雾 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0B;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_PenetratingFogOff://透雾 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0C;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_RearFocus://Abf 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0A;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 221://Abf 关
                    {

                    }
                    break;
                case 222://扩展器 + 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x08;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 223://扩展器 停 
                    {

                    }
                    break;
                case 224://扩展器 - 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x09;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 225://滤光镜 + 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0B;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 226://滤光镜 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0D;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 227://滤光镜 -
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x0C;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7; ;
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
                case (int)CCDCommand.CCD_TurnShortQuery://变倍信息
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x06;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)CCDCommand.CCD_FocusLongQuery://聚焦信息
                    {
                    }
                    break;
                case 232://镜头温度
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x15;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 233://摄像机温度
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x16;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
            }
            return m_byteBuff1;
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
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            switch (iAction)
            {
                case (int)IRCommand.IR_TurnLong://变焦+
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2A;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_TurnLongStop://变焦 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x30;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_TurnShort://变焦- 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2A;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_FocusLong://聚焦+ 
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2B;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_FocusStop://聚焦 停
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x30;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_FocusShort://聚焦-
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2B;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_CrossForksOpen://十字叉 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x22;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_CrossForksOff://十字叉 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x22;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_WhiteHeatModel://白热模式
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x26;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_BlackHeatModel://黑热模式
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x26;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_1XLens://1X 镜
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x27;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_2XLens://2X 镜
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x27;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_AutofocusOpen://自动聚焦 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x23;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_AutofocusOff://自动聚焦 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x23;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_Brightness://亮度
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2C;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iValue;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_ContrastRatio://对比度
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2D;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iValue;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_FalseColor://伪彩
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x2E;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iValue;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_GammaCorrection://伽马校验
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x31;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = (byte)iValue;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_ManualCorrection://手动校验
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x28;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x02;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_BackgroundCorrection://背景校验
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x28;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x03;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_Open://红外 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x20;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_Off://红外 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x20;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case 323://天地模式
                    {
                    }
                    break;
                case 324://内部非均匀校正
                    {
                    }
                    break;
                case 325://稳像 开
                    {
                    }
                    break;
                case 326://稳像 关 
                    {
                    }
                    break;
                case (int)IRCommand.IR_ShutterCorrection://快门校正
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x28;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x04;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_ImageEnhancementOpen://图像增强 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x25;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_ImageEnhancementOff://图像增强 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x25;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_AutomaticCorrectionOpen://自动校正 开
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x28;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x01;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_AutomaticCorrectionOff://自动校正 关
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x01;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x28;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
                case (int)IRCommand.IR_TurnShortQuery:// 获取红外变倍信息
                    {
                        m_byteBuff1 = new byte[16];
                        m_byteBuff2 = new byte[12];

                        m_byteBuff1[0] = 0x55;//
                        m_byteBuff1[1] = 0xAA;//
                        m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
                        m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
                        m_byteBuff1[4] = m_byteBuff2[2] = 0x07;//ICmd
                        m_byteBuff1[5] = m_byteBuff2[3] = 0x00;//D1
                        m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
                        m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                        m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
                        m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
                        m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
                        m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
                        m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
                        m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
                        m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
                        m_byteBuff1[15] = 0xE7;
                    }
                    break;
            }
            return m_byteBuff1;
        }
        /// <summary>
        /// 预置位-水平
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Horizontal(int iAddr, int iHorizontal)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];
            byte[] tmp_H = System.BitConverter.GetBytes(iHorizontal);
            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x44;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = tmp_H[0];//D1
            m_byteBuff1[6] = m_byteBuff2[4] = tmp_H[1];//D2
            m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
            m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
            m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;

            return m_byteBuff1;
        }
        /// <summary>
        /// 预置位-俯仰
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Vertical(int iAddr, int iVertical)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];
            byte[] tmp_V = System.BitConverter.GetBytes(iVertical);
            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x03;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x44;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = tmp_V[0];//D1
            m_byteBuff1[6] = m_byteBuff2[4] = tmp_V[1];//D2
            if (iVertical < 0)
            {
                m_byteBuff1[7] = m_byteBuff2[5] = 0xFF;//D3
                m_byteBuff1[8] = m_byteBuff2[6] = 0xFF;//D4
            }
            else
            {
                m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
                m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
            }
            m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;

            return m_byteBuff1;
        }
        /// <summary>
        /// 预置位-变倍
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iDepth"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Depth(int iAddr, int iDepth)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];

            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x19;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = (byte)iDepth;//D1
            m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
            m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
            m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
            m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;

            return m_byteBuff1;
        }
        /// <summary>
        /// 预置位-聚焦
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Focus(int iAddr, int iFocus)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];

            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x00;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x18;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = (byte)iFocus;//D1
            m_byteBuff1[6] = m_byteBuff2[4] = 0x00;//D2
            m_byteBuff1[7] = m_byteBuff2[5] = 0x00;//D3
            m_byteBuff1[8] = m_byteBuff2[6] = 0x00;//D4
            m_byteBuff1[9] = m_byteBuff2[7] = 0x00;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = 0x00;//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;

            return m_byteBuff1;
        }
        /// <summary>
        /// 扇扫-水平
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontlSt"></param>
        /// <param name="iHorizontlEnd"></param>
        /// <param name="iHorizontlSpeed"></param>
        /// <returns></returns>
        public static byte[] SanScan_Horizontl(int iAddr, int iHorizontlSt, int iHorizontlEnd, int iHorizontlSpeed)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];

            int tmpH_St = iHorizontlSt * 4096 / 360;
            int tmpH_End = iHorizontlEnd * 4096 / 360;
            int tmpSpeed = iHorizontlSpeed * 2;


            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x47;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = (byte)tmpH_St;//D1
            m_byteBuff1[6] = m_byteBuff2[4] = (byte)(tmpH_St >> 8);//D2
            m_byteBuff1[7] = m_byteBuff2[5] = (byte)tmpH_End; ;//D3
            m_byteBuff1[8] = m_byteBuff2[6] = (byte)(tmpH_End >> 8);//D4
            m_byteBuff1[9] = m_byteBuff2[7] = (byte)tmpSpeed;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = (byte)(tmpSpeed >> 8);//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;

            return m_byteBuff1;
        }
        /// <summary>
        /// 扇扫-俯仰
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iVerticalSt"></param>
        /// <param name="iVerticalEnd"></param>
        /// <param name="iVerticalSpeed"></param>
        /// <returns></returns>
        public static byte[] SanScan_Vertical(int iAddr, int iVerticalSt, int iVerticalEnd, int iVerticalSpeed)
        {
            m_byteBuff1 = null;
            m_byteBuff2 = null;
            m_byteBuff1 = new byte[16];
            m_byteBuff2 = new byte[12];
            int tmpV_St;
            int tmpV_End;
            int tmpSpeed;

            if (iVerticalSt >= 0)
            { tmpV_St = iVerticalSt * 4096 / 360; }
            else
            {
                tmpV_St = iVerticalSt * 4096 / 360;
                tmpV_St = -tmpV_St;
                tmpV_St = 65535 - (tmpV_St - 1);
            }

            if (iVerticalEnd >= 0)
            { tmpV_End = iVerticalEnd * 4096 / 360; }
            else
            {
                tmpV_End = iVerticalEnd * 4096 / 360;
                tmpV_End = -tmpV_End;
                tmpV_End = 65535 - (tmpV_End - 1);
            }
            tmpSpeed = iVerticalSpeed * 2;

            m_byteBuff1[0] = 0x55;//
            m_byteBuff1[1] = 0xAA;//
            m_byteBuff1[2] = m_byteBuff2[0] = (byte)iAddr;//addr1
            m_byteBuff1[3] = m_byteBuff2[1] = 0x02;//addr2
            m_byteBuff1[4] = m_byteBuff2[2] = 0x47;//ICmd
            m_byteBuff1[5] = m_byteBuff2[3] = (byte)tmpV_St;//D1
            m_byteBuff1[6] = m_byteBuff2[4] = (byte)(tmpV_St >> 8);//D2
            m_byteBuff1[7] = m_byteBuff2[5] = (byte)tmpV_End; ;//D3
            m_byteBuff1[8] = m_byteBuff2[6] = (byte)(tmpV_End >> 8);//D4
            m_byteBuff1[9] = m_byteBuff2[7] = (byte)tmpSpeed;//D5
            m_byteBuff1[10] = m_byteBuff2[8] = (byte)(tmpSpeed >> 8);//D6
            m_byteBuff1[11] = m_byteBuff2[9] = 0x00;//D7
            m_byteBuff1[12] = m_byteBuff2[10] = 0x00;//D8
            m_byteBuff1[13] = m_byteBuff2[11] = 0x00;//D9
            m_byteBuff1[14] = Protocol_Bale(m_byteBuff2, 12);
            m_byteBuff1[15] = 0xE7;
            return m_byteBuff1;
        }

    }
}
