using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol11s
    {
        static byte[] m_byteBuff;
        static public byte Protocol_Bale(byte bD1, byte bD2, byte bD3, byte bD4)
        {
            byte bSum = (byte)(bD1 + bD2 + bD3 + bD4);
            return bSum;
        }
        static public byte Protocol_Bale(byte bD1, byte bD2, byte bD3)
        {
            byte bSum = (byte)(bD1 + bD2 + bD3);
            return bSum;
        }

        public static byte[] Protocol_Turntable(int iAction, int iAddr, int iSpeed)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 101://DPS 水平复位
                    { }
                    break;
                case 102://开电机
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xF1;
                        m_byteBuff[5] = 0xF3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 103://关电机
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xF0;
                        m_byteBuff[5] = 0xF2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 104://自检
                    { }
                    break;
                case 106://上
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x01;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 107://下
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x02;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 108://左
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x03;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 109://右
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x04;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 110://左上
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x05;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = (byte)(iSpeed);
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xCF;
                    }
                    break;
                case 111://左下
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x07;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = (byte)(iSpeed);
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xCF;
                    }
                    break;
                case 112://右上
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x06;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = (byte)(iSpeed);
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xCF;
                    }
                    break;
                case 113://右下
                    {
                        m_byteBuff = new byte[9];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;

                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x08;
                        m_byteBuff[5] = (byte)(iSpeed);
                        m_byteBuff[6] = (byte)(iSpeed);
                        m_byteBuff[7] = Protocol_Bale(m_byteBuff[3], m_byteBuff[4], m_byteBuff[5], m_byteBuff[6]);
                        m_byteBuff[8] = 0xCF;
                    }
                    break;
                case 114://停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 115://风扇1 开
                    { }
                    break;
                case 116://风扇1 关
                    { }
                    break;
                case 117://风扇2 开
                    { }
                    break;
                case 118://风扇2 关
                    { }
                    break;
                case 119://加热片1 开
                    { }
                    break;
                case 120://加热片1 关
                    {
                    }
                    break;
                case 121://加热片2 开
                    { }
                    break;
                case 122://加热片2 关
                    {
                    }
                    break;
                case 123://方位查询
                    { }
                    break;
                case 124://俯仰查询
                    { }
                    break;
                case 125://俯仰 停
                    { }
                    break;
                case 126://俯仰电机 开
                    { }
                    break;
                case 127://俯仰电机 关
                    { }
                    break;
                case 128://DPS 俯仰复位
                    { }
                    break;

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
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x0D;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x8E;
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 202://变焦+ 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 203://变焦- 
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x0E;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x8F;
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 204://变焦- 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 205://聚焦+ 
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x10;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x91;
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 206://聚焦+ 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 207://聚焦-
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x0F;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x90;
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 208://聚焦-停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 209://光圈+
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x12;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x93;
                        m_byteBuff[7] = 0xCF;
                    }
                    break;
                case 210://光圈 停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xB0;
                        m_byteBuff[5] = 0xB2;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 211://光圈-
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x03;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0x11;
                        m_byteBuff[5] = 0x7F;
                        m_byteBuff[6] = 0x92;
                        m_byteBuff[7] = 0xCF;
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
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xF1;
                        m_byteBuff[5] = 0xF3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 217://关闭白光
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xE1;
                        m_byteBuff[5] = 0xE3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 218://透雾 开
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xD1;
                        m_byteBuff[5] = 0xD3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 219://透雾 关
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xD0;
                        m_byteBuff[5] = 0xD2;
                        m_byteBuff[6] = 0xCF;
                    }
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
                    { }
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
        public static byte[] Protocol_IR(int iAction, int iAddr, int iSpeed, int iValue)
        {
            m_byteBuff = null;
            switch (iAction)
            {
                case 301://变焦+
                    {
                    }
                    break;
                case 302://变焦 停
                    {
                    }
                    break;
                case 303://变焦- 
                    {
                    }
                    break;
                case 304://聚焦+ 
                    {
                    }
                    break;
                case 305://聚焦 停
                    {
                    }
                    break;
                case 306://聚焦-
                    {
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
                    }
                    break;
                case 310://黑热模式
                    {
                    }
                    break;
                case 311://1X 镜
                    {
                    }
                    break;
                case 312://2X 镜
                    {
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
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xE1;
                        m_byteBuff[5] = 0xE3;
                        m_byteBuff[6] = 0xCF;
                    }
                    break;
                case 322://红外 关
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xC0;
                        m_byteBuff[1] = 0xC0;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = 0xF1;
                        m_byteBuff[5] = 0xF3;
                        m_byteBuff[6] = 0xCF;
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
                case 327://快门校正
                    {
                    }
                    break;
                case 328://图像增强 开
                    {
                    }
                    break;
                case 329://图像增强 关
                    {
                    }
                    break;
                case 330://自动校正 开
                    {
                    }
                    break;
                case 331://自动校正 关
                    {
                    }
                    break;
                case 332:// 获取红外变倍信息
                    {
                    }
                    break;
            }
            return m_byteBuff;
        }
    }
}
