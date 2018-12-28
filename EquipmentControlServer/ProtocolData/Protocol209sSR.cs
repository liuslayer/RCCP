using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer.ProtocolData
{
    public class Protocol209sSR
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
            switch (iAction)
            {
                case 101://DPS复位
                    { }
                    break;
                case 102://开电机
                    { }
                    break;
                case 103://关电机
                    { }
                    break;
                case 104://自检
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x07;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x63;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 106://上
                    {
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
                    { }
                    break;
                case 111://左下
                    { }
                    break;
                case 112://右上
                    { }
                    break;
                case 113://右下
                    { }
                    break;
                case 114://停
                    {
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
                    { }
                    break;
                case 121://加热片2 开
                    { }
                    break;
                case 122://加热片2 关
                    { }
                    break;
                case 123://方位查询
                    {
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
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
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
            switch (iAction)
            {
                case 201://变焦+
                    {
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
                    {

                    }
                    break;
                case 213://自动光圈
                    {
 
                    }
                    break;
                case 214://自动聚焦 开
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x2B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 215://自动聚焦 关
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x2B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 216://打开白光
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 217://关闭白光
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x0B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 218://透雾 开
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x02;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);

                    }
                    break;
                case 219://透雾 关
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x02;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
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
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x55;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 231://聚焦信息
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x65;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
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
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x20;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 302://变焦 停
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 303://变焦- 
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x40;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 304://聚焦+ 
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x80;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 305://聚焦 停
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 306://聚焦-
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x01;
                        m_byteBuff[3] = 0x00;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 307://十字叉 开
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x08;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 308://十字叉 关
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x08;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0xFF;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 309://白热模式
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 310://黑热模式
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 311://1X 镜
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x0B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 312://2X 镜
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x0B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0xFF;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 313://自动聚焦 开
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x2B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x00;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 314://自动聚焦 关
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x2B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 315://亮度
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x01;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iValue;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 316://对比度
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x05;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iValue;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 317://伪彩
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iValue;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 318://伽马校验
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x03;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = (byte)iValue;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 319://手动校验
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x05;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 320://背景校验
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0xAA;
                        m_byteBuff[3] = 0x06;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x01;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 321://红外 开
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x09;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x03;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
                case 322://红外 关
                    {
                        m_byteBuff[0] = 0xFF;
                        m_byteBuff[1] = (byte)iAddr;
                        m_byteBuff[2] = 0x00;
                        m_byteBuff[3] = 0x0B;
                        m_byteBuff[4] = 0x00;
                        m_byteBuff[5] = 0x03;
                        m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
                    }
                    break;
            }
            return m_byteBuff;
        }
        /// <summary>
        /// 转台-预置位水平
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iHorizontal"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Horizontal(int iAddr,int iHorizontal)
        {
            byte[] tmp_H = BitConverter.GetBytes(iHorizontal);
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x4B;
            m_byteBuff[4] = tmp_H[1];
            m_byteBuff[5] = tmp_H[0];
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 转台-预置位俯仰
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iVertical"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Vertical(int iAddr, int iVertical)
        {
            byte[] tmp_V = BitConverter.GetBytes(iVertical);
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x4D;
            m_byteBuff[4] = tmp_V[1];
            m_byteBuff[5] = tmp_V[0];
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 镜头-预置位视场
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iDepth"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Depth(int iAddr,int iDepth)
        {
            byte[] tmp_D = BitConverter.GetBytes(iDepth);
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x4F;
            m_byteBuff[4] = tmp_D[1];
            m_byteBuff[5] = tmp_D[0];
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 镜头-预置位聚焦
        /// </summary>
        /// <param name="iAddr"></param>
        /// <param name="iFocus"></param>
        /// <returns></returns>
        public static byte[] PrePointSend_Focus(int iAddr,int iFocus)
        {
            byte[] tmp_F = BitConverter.GetBytes(iFocus);
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x5F;
            m_byteBuff[4] = tmp_F[1];
            m_byteBuff[5] = tmp_F[0];
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 扇扫 起点
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_Origins(int iAddr)
        {
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x11;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;

        }
        /// <summary>
        /// 扇扫 终点
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_Destinations(int iAddr)
        {
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x13;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 扇扫 开
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_Open(int iAddr)
        {
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x1B;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
        /// <summary>
        /// 扇扫 关
        /// </summary>
        /// <param name="iAddr"></param>
        /// <returns></returns>
        public static byte[] SanScan_Off(int iAddr)
        {
            m_byteBuff[0] = 0xFF;
            m_byteBuff[1] = (byte)iAddr;
            m_byteBuff[2] = 0x00;
            m_byteBuff[3] = 0x1D;
            m_byteBuff[4] = 0x00;
            m_byteBuff[5] = 0x00;
            m_byteBuff[6] = Protocol_Bale(m_byteBuff[1], m_byteBuff[2], m_byteBuff[3], m_byteBuff[4], m_byteBuff[5]);
            return m_byteBuff;
        }
    }
}
