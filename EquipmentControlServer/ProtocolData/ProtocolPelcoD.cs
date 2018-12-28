using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class ProtocolPelcoD
    {
        static byte[] m_byteBuff = new byte[7];

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
        private static byte Protocol_Bale(byte bAddr, byte bD1, byte bD2, byte bD3, byte bD4)
        {
            byte bSum = (byte)(bAddr + bD1 + bD2 + bD3 + bD4);
            return bSum;
        }
        public static byte[] Protocol_Turntable(int iAction, int iAddr, int iSpeed)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 101:/**DPS 水平复位*/
                    { } break;
                case 102://开电机
                    { } break;
                case 103://关电机
                    { } break;
                case 104://自检
                    { } break;
                case 106://上
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x08;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 107://下
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x10;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 108://左
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x04;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 109://右
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
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
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 115://风扇1 开
                    {
                    }
                    break;
                case 17://风扇1 关
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
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x51;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 124://俯仰查询
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x53;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 125://俯仰 停
                    { } break;
                case 126://俯仰电机 开
                    { } break;
                case 127://俯仰电机 关
                    { } break;
                case 128://DPS 俯仰复位
                    { } break;
            }
            return m_byteBuff;
        }

        public static byte[] Protocol_CCD(int iAction, int iAddr, int iSpeed, int iValue)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 201://变焦+
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x20;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 202://变焦+ 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 203://变焦- 
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x40;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 204://变焦- 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 205://聚焦+ 
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x80;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 206://聚焦+ 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 207://聚焦-
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x01;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 208://聚焦-停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 209://光圈+
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 210://光圈 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 211://光圈-
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x04;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 212://手动光圈
                    { }
                    break;
                case 213://自动光圈
                    { }
                    break;
                case 214://自动聚焦 开
                    { }
                    break;
                case 215://自动聚焦 关
                    { }
                    break;
                case 216://打开白光
                    { }
                    break;
                case 217://关闭白光
                    { }
                    break;
                case 218://透雾 开
                    { }
                    break;
                case 219://透雾 关
                    { }
                    break;
                case 220://Abf 开
                    { }
                    break;
                case 221://Abf 关
                    { }
                    break;
                case 222://扩展器 + 
                    { }
                    break;
                case 223://扩展器 停 
                    { }
                    break;
                case 224://扩展器 - 
                    { }
                    break;
                case 225://滤光镜 + 
                    { }
                    break;
                case 226://滤光镜 停
                    { }
                    break;
                case 227://滤光镜 -
                    { }
                    break;
                case 228://光圈遥控 开
                    { }
                    break;
                case 229://光圈遥控 关
                    { }
                    break;
                case 230://变倍信息
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x47;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 231://聚焦信息
                    { }
                    break;
                case 232://镜头温度
                    { }
                    break;
                case 233://摄像机温度
                    { }
                    break;
            }
            return m_byteBuff;
        }
        static public byte[] SetPreset(int iAddr,int iPresetNum)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[7];
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x03;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = (byte)iPresetNum;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }

        static public byte[] DelPreset(int iAddr, int iPresetNum)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[7];
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x05;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = (byte)iPresetNum;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        
        static public byte[] GetPreset(int iAddr,int iPresetNum)
        {
            m_byteBuff = null;
            m_byteBuff = new byte[7];
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x07;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = (byte)iPresetNum;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
    }
}
