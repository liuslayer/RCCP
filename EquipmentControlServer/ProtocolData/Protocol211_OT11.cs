using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol211_OT11
    {
        static byte[] m_byteBuff;
        private static byte Protocol_Bale(byte bAddr,byte bD1,byte bD2,byte bD3,byte bD4)
        {
            byte bSum = (byte)(bAddr + bD1 + bD2 + bD3 + bD4);
            return bSum;
        }
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
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
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
                        m_byteBuff[1] = (byte)(iAddr);
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
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x04;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 109://右
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x02;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 110://左上
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x0C;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 111://左下
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x14;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 112://右上
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x0A;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 113://右下
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x12;
                        m_byteBuff[4] = (byte)iSpeed;
                        m_byteBuff[5] = (byte)iSpeed;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 114://停
                    {
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
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
                        m_byteBuff = new byte[7];
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)(iAddr);
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
                        m_byteBuff[1] = (byte)(iAddr);
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x53;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);

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
                    }
                    break;
                case 202://变焦+ 停
                    {
                    }
                    break;
                case 203://变焦- 
                    {
                    }
                    break;
                case 204://变焦- 停
                    {
                    }
                    break;
                case 205://聚焦+ 
                    {
                      
                    }
                    break;
                case 206://聚焦+ 停
                    {
                    }
                    break;
                case 207://聚焦-
                    {
                       
                    }
                    break;
                case 208://聚焦-停
                    {
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
                    }
                    break;
                case 217://关闭白光
                    {
                    }
                    break;
                case 218://透雾 开
                    {
                    }
                    break;
                case 219://透雾 关
                    {
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
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x15;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x15;
                   }
                    break;
                case 302://变焦 停
                    {
                    }
                    break;
                case 303://变焦- 
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x16;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x16;
                    }
                    break;
                case 304://聚焦+ 
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x18;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x18;
                    }
                    break;
                case 305://聚焦 停
                    {

                    }
                    break;
                case 306://聚焦-
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x17;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x17;
                    }
                    break;
                case 307://十字叉 开
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x07;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x07;
                    }
                    break;
                case 308://十字叉 关
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x27;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x27;
                    }
                    break;
                case 309://白热模式
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x02;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x02;
                    }
                    break;
                case 310://黑热模式
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x22;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x22;
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
                    }
                    break;
                case 322://红外 关
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x05;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x05;
                    }
                    break;
                case 323://天地模式
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x19;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x19;
                    }
                    break;
                case 324://内部非均匀校正
                    {
                        m_byteBuff = new byte[5];
                        m_byteBuff[0] = 0xCC;
                        m_byteBuff[1] = 0x02;
                        m_byteBuff[2] = 0x0C;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x0C;
                    }
                    break;
                case 325://稳像 开 A0 FF 18 00 00 00 AF E8
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xA0;
                        m_byteBuff[1] = 0xFF;
                        m_byteBuff[2] = 0x18;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0xAF;
                        m_byteBuff[7] = 0xE8;
                    }
                    break;
                case 326://稳像 关 A0 FF 18 03 00 00 AF EB
                    {
                        m_byteBuff = new byte[8];
                        m_byteBuff[0] = 0xA0;
                        m_byteBuff[1] = 0xFF;
                        m_byteBuff[2] = 0x18;
                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = 0xAF;
                        m_byteBuff[7] = 0xE8;
                    }
                    break;
            }
            return m_byteBuff;
        }
    }
}
