using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    class ProtocolAnalysis
    {
        byte dirHB, dirLB;
        int nH;
        byte pitchLB, pitchHB;
        int nV;
        byte DepthHB, DepthLB;
        int nCCDDepth;
        byte FocusHB, FocusLB;
        int nFocus;
        int byte_tempCCD = 0;
        int byte_tempSXJ = 0;

        float P_dir = 0;
        float P_pitch = 0;
        float P_Turn = 0;
        float P_Focus = 0;

        ControlBusinessData tmp_BusinessData = new ControlBusinessData();
        public string Analysis209s_PT100(Guid tmpGuid, byte[] temData)
        {
            string m_Analysis209sNew = "";
            switch (temData[4])
            {
                case 0x48:
                    {
                        if (temData[3] == 0x02)//水平
                        {

                            dirHB = temData[6];
                            dirLB = temData[5];
                            if (dirHB >= 128)
                            {
                                int tmpno22;
                                tmpno22 = (dirHB * 256 + dirLB);
                                tmpno22 = (65535 - tmpno22) + 1;
                                nH = -(tmpno22);
                            }
                            else
                            {
                                nH = (dirHB * 256 + dirLB);
                            }
                            tmp_BusinessData.Preservation_Horizontal(tmpGuid, nH, nH);
                        }
                        else if (temData[3] == 0x03)//俯仰
                        {

                            pitchHB = temData[6];
                            pitchLB = temData[5];
                            if (pitchHB >= 128)
                            {
                                int tmpno11;
                                tmpno11 = (pitchHB * 256 + pitchLB);
                                tmpno11 = (65535 - tmpno11) + 1;
                                nV = -(tmpno11);
                            }
                            else
                            {
                                nV = (pitchHB * 256 + pitchLB);
                            }
                            tmp_BusinessData.Preservation_Vertical(tmpGuid, nV, nV);
                        }
                    }
                    break;
                case 0x06://白光 变倍
                    {

                        DepthHB = temData[5];
                        DepthLB = temData[6];
                        nCCDDepth = (DepthHB * 256 + DepthLB);
                        tmp_BusinessData.Preservation_CCDDepth(tmpGuid, nCCDDepth, nCCDDepth);
                    }
                    break;
                case 0x07://白光 聚焦
                    {

                        FocusHB = temData[5];
                        FocusLB = temData[6];
                        nFocus = (FocusHB * 256 + FocusLB);
                        tmp_BusinessData.Preservation_CCDFocus(tmpGuid, nFocus,nFocus);
                    }
                    break;
                case 0x15://镜头温度
                    {
                        byte_tempCCD = temData[5];
                    }
                    break;
                case 0x16://摄像机温度
                    {
                        byte_tempSXJ = temData[5];
                    }
                    break;
            }
            int IR_Depth = 0;
            int IR_Focus = 0;
            int byte_tempIR = 0;
            m_Analysis209sNew = nH.ToString() + "_" + nV.ToString() + "_" + nCCDDepth.ToString() + "_" + nFocus.ToString() + "_" + IR_Depth.ToString()
            + "_" + IR_Focus.ToString() + "_" + byte_tempCCD.ToString() + "_" + byte_tempSXJ.ToString() + "_" + byte_tempIR.ToString();
            return m_Analysis209sNew;
        }

        byte[] HData508Ali = new byte[4];//水平
        byte[] VData508Ali = new byte[4];//俯仰
        byte[] ZTWData508Ali = new byte[4];//转台温度
        byte[] DData508Ali = new byte[4];//变倍
        byte[] FData508Ali = new byte[4];//聚焦
        byte[] JTWData508Ali = new byte[4];//CCD温度
        int nH508Ali, nV508Ali, nD508Ali, nF508Ali, nZTW508Ali, nJTW508Ali;
        public string Analysis508Ali(Guid tmpGuid, byte[] temData)
        {
            string m_AnalysisAli = "";
            //      00 01 02 03 04 05 06 07 08 09  10
            //方位：a1 00 0b 30 58 xx xx xx xx xor af  
            //高低：a1 00 0b 30 59 xx xx xx xx xor af 
            //温度：a1 00 0b 45 57 xx xx xx xx xor af
            if (temData.Length == 22 && temData[0] == 0xA1)
            {
                if (temData[3] == 0x30 && temData[4] == 0x58)  //水平 
                {
                    HData508Ali[0] = temData[5];
                    HData508Ali[1] = temData[6];
                    HData508Ali[2] = temData[7];
                    HData508Ali[3] = temData[8];
                    nH508Ali = System.BitConverter.ToInt32(HData508Ali, 0);
                    tmp_BusinessData.Preservation_Horizontal(tmpGuid, nH508Ali, nH508Ali);
                    VData508Ali[0] = temData[16];
                    VData508Ali[1] = temData[17];
                    VData508Ali[2] = temData[18];
                    VData508Ali[3] = temData[19];
                    nV508Ali = System.BitConverter.ToInt32(VData508Ali, 0);
                    tmp_BusinessData.Preservation_Vertical(tmpGuid, nV508Ali, nV508Ali);
                }
            }
            else if (temData.Length == 11 && temData[0] == 0xA1)
            {
                if (temData[3] == 0x30 && temData[4] == 0x58)  //水平
                {
                    HData508Ali[0] = temData[5];
                    HData508Ali[1] = temData[6];
                    HData508Ali[2] = temData[7];
                    HData508Ali[3] = temData[8];
                    nH508Ali = System.BitConverter.ToInt32(HData508Ali, 0);
                    tmp_BusinessData.Preservation_Horizontal(tmpGuid, nH508Ali, nH508Ali);
                }
                else if (temData[3] == 0x30 && temData[4] == 0x59) //俯仰
                {
                    VData508Ali[0] = temData[5];
                    VData508Ali[1] = temData[6];
                    VData508Ali[2] = temData[7];
                    VData508Ali[3] = temData[8];
                    nV508Ali = System.BitConverter.ToInt32(VData508Ali, 0);
                    tmp_BusinessData.Preservation_Vertical(tmpGuid, nV508Ali, nV508Ali);
                }
                else if (temData[3] == 0x45 && temData[4] == 0x57)//转台温度
                {
                    ZTWData508Ali[0] = temData[5];
                    ZTWData508Ali[1] = temData[6];
                    ZTWData508Ali[2] = temData[7];
                    ZTWData508Ali[3] = temData[8];
                    nZTW508Ali = System.BitConverter.ToInt32(ZTWData508Ali, 0);
                }
            }
            else if (temData.Length == 18 && temData[0] == 0xA2)
            {
                if (temData[3] == 0x56 && temData[12] == 0x46)//变焦
                {
                    DData508Ali[0] = temData[5];
                    DData508Ali[1] = temData[6];
                    DData508Ali[2] = 0;
                    DData508Ali[3] = 0;
                    nD508Ali = System.BitConverter.ToInt32(DData508Ali, 0);
                    tmp_BusinessData.Preservation_CCDDepth(tmpGuid, nD508Ali, nD508Ali);
                    //else if (temData[3] == 0x46) //聚焦
                    FData508Ali[0] = temData[14];
                    FData508Ali[1] = temData[15];
                    FData508Ali[2] = 0;
                    FData508Ali[3] = 0;
                    nF508Ali = System.BitConverter.ToInt32(FData508Ali, 0);
                    tmp_BusinessData.Preservation_CCDFocus(tmpGuid, nF508Ali, nF508Ali);
                }
            }
            else if (temData.Length == 9 && temData[0] == 0xA2)
            {
                //       00 01 02 03 04 05 06 07  08
                //变焦停 A2	00 09 56 53	00 00 xor AF
                //聚焦停 A2	00 09 46 53	00 00 xor AF
                //温度	 A2	00 09 54 42 xx xx xor AF
                if (temData[3] == 0x56)//变焦
                {
                    DData508Ali[0] = temData[5];
                    DData508Ali[1] = temData[6];
                    DData508Ali[2] = 0;
                    DData508Ali[3] = 0;
                    nD508Ali = System.BitConverter.ToInt32(DData508Ali, 0);
                    tmp_BusinessData.Preservation_CCDDepth(tmpGuid,nD508Ali,nD508Ali);
                }
                else if (temData[3] == 0x46) //聚焦
                {
                    FData508Ali[0] = temData[5];
                    FData508Ali[1] = temData[6];
                    FData508Ali[2] = 0;
                    FData508Ali[3] = 0;
                    nF508Ali = System.BitConverter.ToInt32(FData508Ali, 0);
                    tmp_BusinessData.Preservation_CCDFocus(tmpGuid, nF508Ali, nF508Ali);
                }
                else if (temData[3] == 0x54 && temData[4] == 0x41)
                {
                    ZTWData508Ali[0] = temData[5];
                    ZTWData508Ali[1] = temData[6];
                    ZTWData508Ali[2] = 0;
                    ZTWData508Ali[3] = 0;
                    nZTW508Ali = System.BitConverter.ToInt32(JTWData508Ali, 0);
                }
                else if (temData[3] == 0x54 && temData[4] == 0x42) //摄像机温度
                {
                    JTWData508Ali[0] = temData[5];
                    JTWData508Ali[1] = temData[6];
                    JTWData508Ali[2] = 0;
                    JTWData508Ali[3] = 0;
                    nJTW508Ali = System.BitConverter.ToInt32(JTWData508Ali, 0);
                }
            }
            //方位 //俯仰 //白光 视场 //白光 聚焦
            m_AnalysisAli = nH508Ali.ToString() + "_" + nV508Ali.ToString() + "_" + nD508Ali.ToString() + "_" + nF508Ali.ToString() + "_" + "0"
            + "_" + "0" + "_" + nZTW508Ali.ToString() + "_" + nJTW508Ali.ToString() + "_" + "0";
            return m_AnalysisAli;
        }
        /// <summary>
        /// 368转台 数据解析
        /// </summary>
        /// <param name="tmp_length"></param>
        /// <param name="tmp_XX"></param>
        /// <returns></returns>
        public string Analysis368s_BJ(Guid tmpGuid, byte[] tmp_XX)
        {
            string m_Analysis209s = "";
            byte dirLB, dirHB, pitchLB, pitchHB;	//方位，俯仰o
            int CCD_Depth, CCD_Focus, n_H, n_V;
            bool dirsign, pitchsign;
            dirsign = true;
            pitchsign = true;

            dirLB = tmp_XX[3];
            dirHB = tmp_XX[4];
            pitchLB = tmp_XX[5];
            pitchHB = tmp_XX[6];

            CCD_Depth = tmp_XX[7];		// 焦距
            CCD_Focus = tmp_XX[8];		// 聚焦
            if (dirHB >= 128)
            {
                dirsign = false;
            }

            if (pitchHB >= 128)
            {
                pitchsign = false;
            }
            //水平 正负值
            if (dirsign)
            {
                n_H = Convert.ToInt32(((dirHB * 256 + dirLB) * 0.00625) * 100);
            }
            else
            {
                int m_dirLB, m_dirHB;
                m_dirHB = dirHB;
                m_dirHB ^= 255;
                m_dirLB = dirLB;
                m_dirLB = (m_dirLB ^ 255) + 1;
                int tmpno222;
                tmpno222 = (m_dirHB * 256 + m_dirLB);
                tmpno222 = Convert.ToInt32((tmpno222 * 0.00625) * 100);
                n_H = -(tmpno222);
            }

            //俯仰 正负值
            if (pitchsign)
            {
                n_V = Convert.ToInt32(((pitchHB * 256 + pitchLB) * 0.00625) * 100);
            }
            else
            {
                int m_pitchLB, m_pitchHB;
                m_pitchHB = pitchHB;
                m_pitchHB ^= 255;
                m_pitchLB = pitchLB;
                m_pitchLB = (m_pitchLB ^ 255) + 1;

                int tmpno11;
                tmpno11 = (m_pitchHB * 256 + m_pitchLB);
                tmpno11 = Convert.ToInt32((tmpno11 * 0.00625) * 100);
                n_V = -(tmpno11);//俯仰
            }
            //n_H：方位;n_V：俯仰; Depth：白光视场; Focus：白光聚焦;
            m_Analysis209s = n_H.ToString() + "_" + n_V.ToString() + "_" + CCD_Depth.ToString() + "_" + CCD_Focus.ToString();
            return m_Analysis209s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ComGuid"></param>
        /// <param name="tmpData"></param>
        /// <returns></returns>
        public string Analysis209s(Guid ComGuid, byte[] tmpData)
        {
            string m_Analysis209s = "";
            byte dirLB, dirHB, pitchLB, pitchHB;	//方位，俯仰o
            int CCD_Depth, CCD_Focus, n_H, n_V, IR_Depth, IR_Focus;
            bool dirsign, pitchsign;
            dirsign = true;
            pitchsign = true;

            dirLB = tmpData[3];
            dirHB = tmpData[4];
            pitchLB = tmpData[5];
            pitchHB = tmpData[6];

            CCD_Depth = tmpData[8];		// 焦距
            CCD_Focus = tmpData[10];		// 聚焦

            byte byte_tempCCD, byte_tempSXJ, byte_tempIR;
            byte_tempCCD = tmpData[15];    //白光镜头温度
            byte_tempSXJ = tmpData[16];     //摄像机温度
            byte_tempIR = tmpData[17];      //红外温度

            IR_Depth = 0;
            IR_Focus = 0;
            if (dirHB >= 128)
            {
                dirsign = false;
            }

            if (pitchHB >= 128)
            {
                pitchsign = false;
            }
            //水平 正负值
            if (dirsign)
            {
                n_H = (dirHB * 256 + dirLB);
            }
            else
            {
                int tmpno222;
                tmpno222 = (dirHB * 256 + dirLB);
                tmpno222 = (65535 - tmpno222) + 1;
                n_H = -(tmpno222);
            }

            //俯仰 正负值
            if (pitchsign)
            {
                n_V = (pitchHB * 256 + pitchLB);
            }
            else
            {
                int tmpno11;
                tmpno11 = (pitchHB * 256 + pitchLB);
                tmpno11 = (65535 - tmpno11) + 1;
                n_V = -(tmpno11);//俯仰
            }
            tmp_BusinessData.Preservation_All(ComGuid, n_H, n_H, n_V, n_V, CCD_Depth, CCD_Depth, CCD_Focus, CCD_Focus, IR_Depth, IR_Depth, IR_Focus, IR_Focus);
            //n_H：方位;n_V：俯仰; Depth：白光视场; Focus：白光聚焦; IR_Depth：红外视场;IR_Focus：红外聚焦;
            //byte_tempCCD：CCD温度; byte_tempSXJ：摄像机温度; byte_tempIR：红外温度;
            m_Analysis209s = n_H.ToString() + "_" + n_V.ToString() + "_" + CCD_Depth.ToString() + "_" + CCD_Focus.ToString() + "_" + IR_Depth.ToString()
            + "_" + IR_Focus.ToString() + "_" + byte_tempCCD.ToString() + "_" + byte_tempSXJ.ToString() + "_" + byte_tempIR.ToString();
            
            return m_Analysis209s;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ComGuid"></param>
        /// <param name="tmpData"></param>
        /// <returns></returns>
        public string AnalysisSR(Guid ComGuid, byte[] tmpData)
        {
            string m_AnalysisSR = "";
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //byte[] temData = new byte[(tmp_length * 2)];
            //for (int i = 0; i < (tmp_length * 2); i += 2)
            //{
            //    temData[(i / 2)] = (byte)Convert.ToInt32(tmp_XX.Substring(i, 2), 16);
            //}
            //MessageBox(_T("近程！！！"), _T("提示"));
            //8E 01 87 F3 28 84 00 0F 00 01 A5 08 78 02 6D CB E8
            //00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16

            //03:方位低 04：方位高 
            //05：俯仰低 06：俯仰高
            //07：白光变倍高 08：白光变倍低 
            //09：白光聚焦高 10：白光聚焦低
            //11：红外变倍高 12：红外变倍低 
            //13：红外聚焦高 14：红外聚焦低
            byte dirLB, dirHB, pitchLB, pitchHB;//方位，俯仰
            int CCD_Depth, CCD_Focus, n_H, n_V, IR_Depth, IR_Focus;

            CCD_Depth = 0;
            CCD_Focus = 0;
            n_H = 0;
            n_V = 0;
            IR_Depth = 0;
            IR_Focus = 0;

            //方位低 方位高
            dirLB = tmpData[3];
            dirHB = tmpData[4];

            //俯仰低 俯仰高
            pitchLB = tmpData[5];
            pitchHB = tmpData[6];

            byte CDD_DepthLB, CDD_DepthHB, CDD_FocusLB, CDD_FocusHB;//变倍 聚焦

            //变倍高 变倍低
            CDD_DepthHB = tmpData[7];
            CDD_DepthLB = tmpData[8];

            //聚焦高 聚焦低
            CDD_FocusHB = tmpData[9];
            CDD_FocusLB = tmpData[10];

            byte IR_DepthLB, IR_DepthHB, IR_FocusLB, IR_FocusHB;//变倍 聚焦

            //11：红外变倍高 12：红外变倍低 
            IR_DepthHB = tmpData[11];
            IR_DepthLB = tmpData[12];
            //13：红外聚焦高 14：红外聚焦低
            IR_FocusHB = tmpData[13];
            IR_FocusLB = tmpData[14];

            byte byte_tempCCD, byte_tempSXJ, byte_tempIR;
            byte_tempCCD = 0;
            byte_tempSXJ = 0;
            byte_tempIR = 0;

            bool dirsign, pitchsign;
            dirsign = pitchsign = true;
            if (dirHB >= 0x80)
            {
                dirsign = false;
            }
            if (pitchHB >= 0x80)
            {
                pitchsign = false;
            }
            //返回
            n_H = (dirHB * 256 + dirLB);
            n_V = (pitchHB * 256 + pitchLB);
            CCD_Depth = (CDD_DepthHB * 256 + CDD_DepthLB);

            CCD_Focus = (CDD_FocusHB * 256 + CDD_FocusLB);

            IR_Depth = (IR_DepthHB * 256 + IR_DepthLB);

            IR_Focus = (IR_FocusHB * 256 + IR_FocusLB);

            tmp_BusinessData.Preservation_All(ComGuid, n_H, n_H, n_V, n_V, CCD_Depth, CCD_Depth, CCD_Focus, CCD_Focus, IR_Depth, IR_Depth, IR_Focus, IR_Focus);
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //n_H：方位;n_V：俯仰; Depth：白光视场; Focus：白光聚焦; IR_Depth：红外视场;IR_Focus：红外聚焦;
            //byte_tempCCD：CCD温度; byte_tempSXJ：摄像机温度; byte_tempIR：红外温度;
            m_AnalysisSR = n_H.ToString() + "_" + n_V.ToString() + "_" + CCD_Depth.ToString() + "_" + CCD_Focus.ToString() + "_" + IR_Depth.ToString()
            + "_" + IR_Focus.ToString() + "_" + byte_tempCCD.ToString() + "_" + byte_tempSXJ.ToString() + "_" + byte_tempIR.ToString();
            return m_AnalysisSR;
        }
        /// <summary>
        /// 高普乐 返回值解析
        /// </summary>
        /// <param name="tmp_length"></param>
        /// <param name="temData"></param>
        /// <returns></returns>
        public string AnalysisPelco_D_GPL(Guid ComGuid,byte[] temData)
        {
            string m_AnalysisGPL = "";
            if (temData[2] == 0x7A)//方位
            {
                P_dir = (temData[3] * 65536 + temData[4] * 256 + temData[5]);
                tmp_BusinessData.Preservation_Horizontal(ComGuid,P_dir,(int)P_dir);
            }
            else if (temData[2] == 0x7B)//俯仰
            {
                P_pitch = (temData[4] * 256 + temData[5]);
                tmp_BusinessData.Preservation_Vertical(ComGuid, P_pitch, (int)P_pitch);
                if (temData[3] == 1)
                {
                    // P_pitch = -P_pitch; 
                }
            }
            else if (temData[2] == 0x5D)//变倍
            {
                P_Turn = (temData[4] * 256 + temData[5]);
                tmp_BusinessData.Preservation_CCDDepth(ComGuid, (int)P_Turn, (int)P_Turn);
            }
            else if (temData[2] == 0x5F)//聚焦
            {
                P_Focus = (temData[4] * 256 + temData[5]);
                tmp_BusinessData.Preservation_CCDFocus(ComGuid, (int)P_Focus, (int)P_Focus);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (temData[9] == 0x7A)//方位
            {
                P_dir = (temData[10] * 65536 + temData[11] * 256 + temData[12]);
                tmp_BusinessData.Preservation_Horizontal(ComGuid, P_dir, (int)P_dir);
            }
            else if (temData[9] == 0x7B)//俯仰
            {
                P_pitch = (temData[11] * 256 + temData[12]);
                tmp_BusinessData.Preservation_Vertical(ComGuid, P_pitch, (int)P_pitch);
                if (temData[10] == 1)
                {
                    //  P_pitch = -P_pitch;
                }
            }
            else if (temData[9] == 0x5D)//变倍
            {
                P_Turn = (temData[11] * 256 + temData[12]);
                tmp_BusinessData.Preservation_CCDDepth(ComGuid, (int)P_Turn, (int)P_Turn);
            }
            else if (temData[9] == 0x5F)//聚焦
            {
                P_Focus = (temData[11] * 256 + temData[12]);
                tmp_BusinessData.Preservation_CCDFocus(ComGuid, (int)P_Focus, (int)P_Focus);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (temData[16] == 0x7A)//方位
            {
                P_dir = (temData[17] * 65536 + temData[18] * 256 + temData[19]);
                tmp_BusinessData.Preservation_Horizontal(ComGuid, P_dir, (int)P_dir);
            }
            else if (temData[16] == 0x7B)//俯仰
            {
                P_pitch = (temData[18] * 256 + temData[19]);
                tmp_BusinessData.Preservation_Vertical(ComGuid, P_pitch, (int)P_pitch);
                if (temData[17] == 1)
                {
                    //P_pitch = -P_pitch;
                }
            }
            else if (temData[16] == 0x5D)//变倍
            {
                P_Turn = (temData[18] * 256 + temData[19]);
                tmp_BusinessData.Preservation_CCDDepth(ComGuid, (int)P_Turn, (int)P_Turn);
            }
            else if (temData[16] == 0x5F)//聚焦
            {
                P_Focus = (temData[18] * 256 + temData[19]);
                tmp_BusinessData.Preservation_CCDFocus(ComGuid, (int)P_Focus, (int)P_Focus);
            }
            /////////////////////////////////////////////////////////////////////////////////////////
            if (temData[23] == 0x7A)//方位
            {
                P_dir = (temData[24] * 65536 + temData[25] * 256 + temData[26]);
                tmp_BusinessData.Preservation_Horizontal(ComGuid, P_dir, (int)P_dir);
            }
            else if (temData[23] == 0x7B)//俯仰
            {
                P_pitch = (temData[25] * 256 + temData[26]);
                tmp_BusinessData.Preservation_Vertical(ComGuid, P_pitch, (int)P_pitch);
                if (temData[24] == 0x01)
                {
                    //P_pitch = -P_pitch;
                }
            }
            else if (temData[23] == 0x5D)//变倍
            {
                P_Turn = (temData[25] * 256 + temData[26]);
                tmp_BusinessData.Preservation_CCDDepth(ComGuid, (int)P_Turn, (int)P_Turn);
            }
            else if (temData[23] == 0x5F)//聚焦
            {
                P_Focus = (temData[25] * 256 + temData[26]);
                tmp_BusinessData.Preservation_CCDFocus(ComGuid, (int)P_Focus, (int)P_Focus);
            }

            m_AnalysisGPL = P_dir.ToString() + "_" + P_pitch.ToString() + "_" + P_Turn.ToString() + "_" + P_Focus.ToString() + "_" + "0"
            + "_" + "0" + "_" + "0" + "_" + "0" + "_" + "0";
            return m_AnalysisGPL;
        }

        public string AnalysisPelco_D(Guid tmpGuid,byte[] tmpData)
        {
            string m_AnalysisSR = "";
            byte P_dirLB, P_dirHB, P_pitchLB, P_pitchHB, P_TurnHB, P_TurnLB;//方位，俯仰

            switch (tmpData[3])
            {
                case 0x59://水平
                    {
                        P_dirHB = tmpData[4];
                        P_dirLB = tmpData[5];
                        P_dir = (P_dirHB * 256 + P_dirLB);
                        tmp_BusinessData.Preservation_Horizontal(tmpGuid,P_dir, (int)P_dir);
                    }
                    break;
                case 0x5b://俯仰
                    {
                        P_pitchHB = tmpData[4];
                        P_pitchLB = tmpData[5];
                        P_pitch = (P_pitchHB * 256 + P_pitchLB);
                        tmp_BusinessData.Preservation_Vertical(tmpGuid,P_pitch,(int)P_pitch);
                    }
                    break;
                case 0x5d://变倍
                    {
                        P_TurnHB = tmpData[4];
                        P_TurnLB = tmpData[5];
                        P_Turn = (P_TurnHB * 256 + P_TurnLB);
                        tmp_BusinessData.Preservation_Vertical(tmpGuid, P_Turn, (int)P_Turn);
                    }
                    break;
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //n_H：方位;n_V：俯仰; Depth：白光视场; Focus：白光聚焦; IR_Depth：红外视场;IR_Focus：红外聚焦;
            //byte_tempCCD：CCD温度; byte_tempSXJ：摄像机温度; byte_tempIR：红外温度;
            m_AnalysisSR = P_dir.ToString() + "_" + P_pitch.ToString() + "_" + P_Turn.ToString() + "_" + "0" + "_" + "0"
            + "_" + "0" + "_" + "0" + "_" + "0" + "_" + "0";
            return m_AnalysisSR;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmp_length"></param>
        /// <param name="tmp_XX"></param>
        /// <returns></returns>
        int i_OP3 = 0;
        public string AnalysisPelco_D_OP3(Guid tmpGuid,byte[] temData)
        {
            string m_AnalysisGPL = "";
            byte P_dirLB, P_dirHB;
            switch (temData[3])
            {
                case 0x59://水平
                    {
                        P_dirHB = temData[4];
                        P_dirLB = temData[5];
                        P_dir = (P_dirHB * 256 + P_dirLB);
                        tmp_BusinessData.Preservation_Horizontal(tmpGuid, P_dir, (int)P_dir);
                    }
                    break;
            }
            m_AnalysisGPL = P_dir.ToString() + "_" + P_pitch.ToString() + "_" + P_Turn.ToString() + "_" + P_Focus.ToString() + "_" + "0"
            + "_" + "0" + "_" + "0" + "_" + "0" + "_" + "0";
            return m_AnalysisGPL;
        }
        /// <summary>
        /// 微波警戒 2017外贸演示添加只解析了一个防区
        /// </summary>
        /// <param name="tmp_length"></param>
        /// <param name="temData"></param>
        /// <returns></returns>
        public string AnalysisMicrowaveSurveillance(byte[] temData)
        {
            string m_AnalysisMS = "";
            string MSData1;
            MSData1 = Convert.ToString(temData[3], 2).PadLeft(8, '0');
            m_AnalysisMS = MSData1;
            return m_AnalysisMS;
        }


        public string AnalysisUPS_3onedata(Guid tmpGuid, byte[] temData)
        {
            string mAnalysisUPS="";
            string tmp_str_UpsData = "";
            string[] tmp_UpsData;
            string tmp_AlarmData;
            string[] m_ALARM = null;
            char[] Ups_Data = new char[temData.Length];
            for (int tmp_i = 0; tmp_i < temData.Length; tmp_i++)
            {
                Ups_Data[tmp_i] = (char)temData[tmp_i];
            }
            for (int tmp_j = 0; tmp_j < Ups_Data.Length; tmp_j++)
            {
                if (Ups_Data[tmp_j].ToString() != "(" && Ups_Data[tmp_j].ToString() != "\0" && Ups_Data[tmp_j].ToString() != "N"
                && Ups_Data[tmp_j].ToString() != "A" && Ups_Data[tmp_j].ToString() != "K" && Ups_Data[tmp_j].ToString() != "\r" 
                && Ups_Data[tmp_j].ToString() != "\n")
                {
                    tmp_str_UpsData += Ups_Data[tmp_j];
                }
            }
            tmp_UpsData = tmp_str_UpsData.Split(new char[] { ' ' });
            if (tmp_UpsData.Length ==8)
            {
                double INVOLTAGE = Convert.ToDouble(tmp_UpsData[0]);double LVOLTAGE = Convert.ToDouble(tmp_UpsData[1]);double OUTVOLTAGE = Convert.ToDouble(tmp_UpsData[2]);
                double LOAD = Convert.ToDouble(tmp_UpsData[3]);double FREQ = Convert.ToDouble(tmp_UpsData[4]);double CELLVOLTAGE = Convert.ToDouble(tmp_UpsData[5]);
                double TEMP = Convert.ToDouble(tmp_UpsData[6]);
                tmp_AlarmData = tmp_UpsData[7];
                m_ALARM = new string[8];
                if (tmp_UpsData[7].Length >= 8)
                {
                    //tmp_AlarmData = tmp_UpsData[7];
                    m_ALARM[0] = tmp_AlarmData.Substring(0, 1);m_ALARM[1] = tmp_AlarmData.Substring(1, 1); m_ALARM[2] = tmp_AlarmData.Substring(2, 1);
                    m_ALARM[3] = tmp_AlarmData.Substring(3, 1); m_ALARM[4] = tmp_AlarmData.Substring(4, 1); m_ALARM[5] = tmp_AlarmData.Substring(5, 1);
                    m_ALARM[6] = tmp_AlarmData.Substring(6, 1); m_ALARM[7] = tmp_AlarmData.Substring(7, 1);
                }
                tmp_BusinessData.Preservation_UPS3onedata(tmpGuid, INVOLTAGE, LVOLTAGE, OUTVOLTAGE, LOAD, FREQ, CELLVOLTAGE, TEMP,
                m_ALARM[0], m_ALARM[1], m_ALARM[2], m_ALARM[3], m_ALARM[4], m_ALARM[5], m_ALARM[6], m_ALARM[7]);
            }
            return mAnalysisUPS;
        }
    }
}
