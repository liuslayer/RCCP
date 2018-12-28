using RCCP.Common;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class SerialCOMInit
    {
        public static List<SerialCOMList> serialcomList;//串口信息设备信息
        public static SerialCOMListRepository tmpSerialCOMList = new SerialCOMListRepository();//摄像机设备信息SQL

        static List<TurnTableList> turntableList;
        static TurnTableListRepository tmpTurnTableList = new TurnTableListRepository();

        static List<UPSList> upsList;
        static UPSListRepository tmpUpsList = new UPSListRepository();

        static Dictionary<Guid, SerialCOMList> DeviceType_Dictionary = new Dictionary<Guid, SerialCOMList>();
        static Dictionary<Guid?, SerialPort> SerialPort_Dictionary = new Dictionary<Guid?, SerialPort>();
        static Dictionary<Guid, ProtocolAnalysis> Protocol_Dictionary = new Dictionary<Guid, ProtocolAnalysis>();
        static Dictionary<Guid, COMType> COMType_Dictionary = new Dictionary<Guid, COMType>();

        static string[] GetSysComName;
        private static SerialCOMManager serialCOMManager;

        public struct COMType
        {
            public int strCOMType;
        }

        public static void SerialCOMEquipmentInit()
        {
            DataInit();
            COMInit();
            //OpenCom();
            PublicserialCOM();
        }


        static void PublicserialCOM()
        {
            serialCOMManager = SerialCOMManager.CreateInstance();
            serialCOMManager.ProcessUPSSerialData += UPSSerialData;
            serialCOMManager.ProcessTurntableSerialData += TurntableSerialData;
        }

        /// <summary>
        /// UPS数据解析 
        /// </summary>
        /// <param name="receiveData"></param>
        /// <param name="serialPortID"></param>
        private static void UPSSerialData(byte[] receiveData, Guid serialPortID)
        {
            if(Protocol_Dictionary.ContainsKey(serialPortID)&& COMType_Dictionary.ContainsKey(serialPortID))
            {
                COMType mCOMType = COMType_Dictionary[serialPortID];
                ProtocolAnalysis m_Analysis = Protocol_Dictionary[serialPortID];
                switch (mCOMType.strCOMType)
                {
                    case (int)ControlProtocolType.UPS_3onedata:
                        { m_Analysis.AnalysisUPS_3onedata(serialPortID, receiveData); }
                        break;
                }
            } 
        }

        /// <summary>
        /// 转台数据解析
        /// </summary>
        /// <param name="receiveData"></param>
        /// <param name="serialPortID"></param>
        private static void TurntableSerialData(byte[] receiveData, Guid serialPortID)
        {
            if (Protocol_Dictionary.ContainsKey(serialPortID) && COMType_Dictionary.ContainsKey(serialPortID))
            {
                COMType mCOMType = COMType_Dictionary[serialPortID];
                ProtocolAnalysis m_Analysis = Protocol_Dictionary[serialPortID];
                switch(mCOMType.strCOMType)
                {
                    case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                        { m_Analysis.Analysis209s(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                        { m_Analysis.AnalysisSR(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                        { m_Analysis.Analysis209s_PT100(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                        { m_Analysis.Analysis368s_BJ(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                        {
                            if (receiveData[0] == 0xA1 || receiveData[0] == 0xA2)
                            { if (receiveData[0] == 0xA2 && receiveData[3] == 0x50 && receiveData[4] == 0x41) { }
                                else
                                { m_Analysis.Analysis508Ali(serialPortID, receiveData); }
                            }
                        }
                        break;
                    case (int)ControlProtocolType.GS11s:/** 11s*/
                        { }
                        break;
                    case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                        { m_Analysis.AnalysisPelco_D_GPL(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                        { }
                        break;
                    case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                        { }
                        break;
                    case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                        { m_Analysis.AnalysisPelco_D(serialPortID, receiveData); }
                        break;
                    case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                        { }
                        break;
                }
            }
        }
        public static void WrirtCom_str(Guid SerialComID, string writeStr, out string falseMsg)
        {
            serialCOMManager.WriteSerialCOM(SerialComID, writeStr, out falseMsg);
        }
        
        public static void WriteCom(Guid SerialComID, byte[] writeBuf, out string falseMsg)
        {
            serialCOMManager.WriteSerialCOM(SerialComID, writeBuf, out falseMsg);
        }
        private static void DataInit()
        {
            serialcomList = tmpSerialCOMList.GetList();
            turntableList = tmpTurnTableList.GetList();
            upsList = tmpUpsList.GetList();
        }

        private static int GetDeviceComData(Guid strComDDeviceID)
        {
            int AddData = 0;
            if(!COMType_Dictionary.ContainsKey(strComDDeviceID))
            {
                if(turntableList !=null)
                {
                    for (int i = 0; i < turntableList.Count; i++)
                    {
                        if (turntableList[i].CommunicationType == 1 && turntableList[i].CommunicationID == strComDDeviceID)
                        {
                            COMType tmp_COMType = new COMType();
                            tmp_COMType.strCOMType = turntableList[i].ProtocolType;
                            COMType_Dictionary.Add(strComDDeviceID, tmp_COMType);
                            AddData = 1;
                            break;
                        }
                    }
                }
                if (upsList != null)
                {
                    for (int j = 0; j < upsList.Count; j++)
                    {
                        if (upsList[j].CommunicationType == 1 && upsList[j].CommunicationID == strComDDeviceID)
                        {
                            COMType tmp_COMType = new COMType();
                            tmp_COMType.strCOMType = upsList[j].ProtocolType;
                            COMType_Dictionary.Add(strComDDeviceID, tmp_COMType);
                            AddData = 1;
                            break;
                        }
                    }
                }
            }
            return AddData;
        }

        private static void COMInit()
        {
            for (int i = 0; i < serialcomList.Count; i++)
            {
                try
                {
                    int AddrType = GetDeviceComData(serialcomList[i].DeviceID);
                    if (AddrType == 1)
                    {
                        //DeviceType_Dictionary.Add(serialcomList[i].DeviceID,serialcomList[i]);
                        Protocol_Dictionary.Add(serialcomList[i].DeviceID, new ProtocolAnalysis());
                    }
                }
                catch
                { }
            }
            GetSysComName = SerialPort.GetPortNames();
        }
        /// <summary>
        /// 
        /// </summary>
        private static void OpenCom()
        {
            foreach(SerialCOMList SerialCOMList_Obj in DeviceType_Dictionary.Values)
            {
                try
                {
                    SerialPort SerialPort_Obj = new SerialPort();
                    SerialPort_Obj.PortName = SerialCOMList_Obj.COMNo;//设置串口名字
                    SerialPort_Obj.BaudRate = Convert.ToInt32(SerialCOMList_Obj.Baud);//设置波特率
                    //校验位
                    if (SerialCOMList_Obj.CheckBit == 0)
                    {
                        SerialPort_Obj.Parity = Parity.None;
                    }
                    else if (SerialCOMList_Obj.CheckBit == 1)
                    {
                        SerialPort_Obj.Parity = Parity.Odd;
                    }
                    else if (SerialCOMList_Obj.CheckBit == 2)
                    {
                        SerialPort_Obj.Parity = Parity.Even;
                    }
                    //设置数据位
                    SerialPort_Obj.DataBits = Convert.ToInt32(SerialCOMList_Obj.DataBit);
                    //停止位
                    if (SerialCOMList_Obj.StopBit == 1)
                    {
                        SerialPort_Obj.StopBits = StopBits.One;
                    }
                    else if (SerialCOMList_Obj.StopBit == 2)
                    {
                        SerialPort_Obj.StopBits = StopBits.Two;
                    }
                    //存入Com字典
                    SerialPort_Dictionary.Add(SerialCOMList_Obj.DeviceID, SerialPort_Obj);
                    for(int i = 0; i < GetSysComName.Length; i++)
                    {
                        if (SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].PortName == GetSysComName[i].ToString())
                        {
                            SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].Open();
                            SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceivedEventHandler);
                        }
                    }
                }
                catch (Exception ex)
                { }
            }
        }

        public static string WriteCom(Guid? tmpComDeviceID, byte[] tmpProtocol)
        {
            string strComName = "";
            if (tmpProtocol != null && tmpProtocol.Length > 0)
            {
                if (SerialPort_Dictionary.ContainsKey(tmpComDeviceID) && SerialPort_Dictionary[tmpComDeviceID].IsOpen == true)
                {
                    SerialPort_Dictionary[tmpComDeviceID].Write(tmpProtocol,0, tmpProtocol.Length);
                }
            }
            return strComName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tmpComDeviceID"></param>
        /// <param name="tmpProtocol"></param>
        public static void WrirtCom_str(Guid? tmpComDeviceID, string tmpProtocol)
        {
            if (tmpProtocol != null)
            {
                if (SerialPort_Dictionary.ContainsKey(tmpComDeviceID) && SerialPort_Dictionary[tmpComDeviceID].IsOpen == true)
                {
                    SerialPort_Dictionary[tmpComDeviceID].Write(tmpProtocol);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void serialPort_DataReceivedEventHandler(object sender, SerialDataReceivedEventArgs e)
        {
            foreach (SerialCOMList SerialCOMList_Obj in DeviceType_Dictionary.Values)
            {
                try
                {
                    if (SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].BytesToRead != 0)
                    {
                        ProtocolAnalysis m_Analysis = Protocol_Dictionary[SerialCOMList_Obj.DeviceID];
                        COMType mCOMType = COMType_Dictionary[SerialCOMList_Obj.DeviceID];
                        int byteLen = SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].BytesToRead;
                        byte[] receiveData = new byte[byteLen];
                        SerialPort_Dictionary[SerialCOMList_Obj.DeviceID].Read(receiveData, 0, receiveData.Length);
                        switch(mCOMType.strCOMType)
                        {
                            case (int)ControlProtocolType.GS209_RY:/** 209sRY*/
                                { m_Analysis.Analysis209s(SerialCOMList_Obj.DeviceID, receiveData); }
                                break;
                            case (int)ControlProtocolType.GS209_SR:/** 209sSR*/
                                { m_Analysis.AnalysisSR(SerialCOMList_Obj.DeviceID, receiveData); }
                                break;
                            case (int)ControlProtocolType.GS209_PT100:/** 209sPT100*/
                                { m_Analysis.Analysis209s_PT100(SerialCOMList_Obj.DeviceID,receiveData); }
                                break;
                            case (int)ControlProtocolType.GS368_BJ:/** 368s*/
                                { m_Analysis.Analysis368s_BJ(SerialCOMList_Obj.DeviceID,receiveData); }
                                break;
                            case (int)ControlProtocolType.GS508_Ali:/** 508s*/
                                {
                                    if(receiveData[0] == 0xA1 || receiveData[0] == 0xA2)
                                    {
                                        if (receiveData[0] == 0xA2 && receiveData[3] == 0x50 && receiveData[4] == 0x41) { }
                                        else
                                        {
                                            m_Analysis.Analysis508Ali(SerialCOMList_Obj.DeviceID,receiveData);
                                        }
                                    }
                                }
                                break;
                            case (int)ControlProtocolType.GS11s:/** 11s*/
                                { }
                                break;
                            case (int)ControlProtocolType.CIVIL_GPL:/** 高普乐*/
                                { m_Analysis.AnalysisPelco_D_GPL(SerialCOMList_Obj.DeviceID,receiveData); }
                                break;
                            case (int)ControlProtocolType.GS5308_OP3:/** OP3*/
                                { }
                                break;
                            case (int)ControlProtocolType.GS211_OT11:/** OT11*/
                                {  }
                                break;
                            case (int)ControlProtocolType.CIVIL_PelcoD:/** PelcoD*/
                                { m_Analysis.AnalysisPelco_D(SerialCOMList_Obj.DeviceID,receiveData); }
                                break;
                            case (int)ControlProtocolType.CIVIL_PelcoP:/** PelcoP*/
                                { }
                                break;
                            //case (int)ControlProtocolType.UPS_3onedata:
                            //    { }
                            //    break;
                        }
                    }
                }
                catch
                { }
            }
        }
    }
}
