using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RCCP.Repository.Concrete;
using System.IO.Ports;
using RCCP.Repository.Entities;
using LogServer;

namespace RCCP.Common
{
    public class SerialCOMManager
    {
        private static SerialCOMManager serialCOMManager;
        private static volatile object serialLock = new object();
        private static volatile object openLock = new object();
        private Dictionary<Guid, SerialPort> SerialPortDic = new Dictionary<Guid, SerialPort>();
        public event Action<Byte[], Guid> ProcessTurntableSerialData;
        public event Action<Byte[], Guid> ProcessUPSSerialData;
        public event Action<Byte[], Guid> ProcessSolarEnergySerialData;
        private SerialCOMManager()
        {
            SerialCOMListRepository serialCOMListRepository = new SerialCOMListRepository();
            List<SerialCOMList> serialCOMList = serialCOMListRepository.GetList();
            TurnTableListRepository turnTableListRepository = new TurnTableListRepository();
            List<Guid?> turnTableSerialComIDs = turnTableListRepository.GetListWithCondition(new { CommunicationType = 1 }).Select(_ => _.CommunicationID).ToList();
            UPSListRepository UPSListRepository = new UPSListRepository();
            List<Guid?> UPSSerialComIDs = UPSListRepository.GetListWithCondition(new { CommunicationType = 1 }).Select(_ => _.CommunicationID).ToList();
            SolarEnergyListRepository solarEnergyListRepository = new SolarEnergyListRepository();
            List<Guid?> solarEnergySerialComIDs = solarEnergyListRepository.GetListWithCondition(new { CommunicationType = 1 }).Select(_ => _.CommunicationID).ToList();

            string falseMsg = string.Empty;
            foreach (var item in serialCOMList)
            {
                try
                {
                    SerialPort serialPort = new SerialPort();
                    serialPort.PortName = item.COMNo;//COM口名
                    serialPort.BaudRate = item.Baud;//波特率
                    serialPort.DataBits = item.DataBit;//每个字节的标准数据位长度
                    serialPort.Parity = (Parity)item.CheckBit;
                    serialPort.StopBits = StopBits.One;
                    if (turnTableSerialComIDs.Contains(item.DeviceID))
                    {
                        serialPort.DataReceived += TurntableSerialPortDataReceived;
                    }
                    else if (UPSSerialComIDs.Contains(item.DeviceID))
                    {
                        serialPort.DataReceived += UPSSerialPortDataReceived;
                    }
                    else if (solarEnergySerialComIDs.Contains(item.DeviceID))
                    {
                        serialPort.DataReceived += SolarEnergySerialPortDataReceived;
                    }
                    SerialPortDic[item.DeviceID] = serialPort;
                    if (!OpenSerialCOM(item.DeviceID, out falseMsg))
                    {
                        throw new Exception(falseMsg);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(falseMsg);
                    LogServerManager.AddErrLog(ErrLogType.DBErr, ex);
                    continue;
                }
            }
        }
        /// <summary>
        /// 创建串口管理器单例
        /// </summary>
        /// <returns></returns>
        public static SerialCOMManager CreateInstance()
        {
            if (serialCOMManager == null)
            {
                lock (serialLock)
                {
                    if (serialCOMManager == null)
                    {
                        serialCOMManager = new SerialCOMManager();
                    }
                }
            }
            return serialCOMManager;
        }

        private bool OpenSerialCOM(Guid SerialComID, out string falseMsg)
        {
            falseMsg = string.Empty;
            lock (openLock)
            {
                try
                {
                    SerialPort sp = SerialPortDic[SerialComID];
                    if (!sp.IsOpen)
                    {
                        //sp.ReadBufferSize = 4096;//输入缓冲区大小
                        //sp.WriteBufferSize = 2048;//输出缓冲区大小
                        //sp.ReceivedBytesThreshold = 42;//081完整数据长度为42，所以设置阈值为42
                        sp.Open();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    falseMsg = ex.Message;
                    return false;
                }
            }
        }

        public bool WriteSerialCOM(Guid SerialComID, byte[] writeBuf, out string falseMsg)
        {
            try
            {
                if (!OpenSerialCOM(SerialComID, out falseMsg))
                {
                    throw new Exception(falseMsg);
                }
                SerialPort sp = SerialPortDic[SerialComID];
                sp.Write(writeBuf, 0, writeBuf.Length);
                return true;
            }
            catch (Exception ex)
            {
                falseMsg = ex.Message;
                LogServerManager.AddErrLog(ErrLogType.DBErr, ex);
                return false;
            }
        }

        public bool WriteSerialCOM(Guid SerialComID, string writeStr, out string falseMsg)
        {
            try
            {
                if (!OpenSerialCOM(SerialComID, out falseMsg))
                {
                    throw new Exception(falseMsg);
                }
                SerialPort sp = SerialPortDic[SerialComID];
                sp.Write(writeStr);
                return true;
            }
            catch (Exception ex)
            {
                falseMsg = ex.Message;
                LogServerManager.AddErrLog(ErrLogType.DBErr, ex);
                return false;
            }
        }

        private void TurntableSerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = sender as SerialPort;
            Guid serialPortID = SerialPortDic.FirstOrDefault(_ => _.Value == serialPort).Key;
            int length = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            byte[] buf = new byte[length];//声明一个临时数组存储当前来的串口数据  
            serialPort.Read(buf, 0, length);//读取缓冲数据
            if (ProcessTurntableSerialData != null)
            {
                Delegate[] delArray = ProcessTurntableSerialData.GetInvocationList();
                foreach (Action<byte[], Guid> item in delArray)
                {
                    item.BeginInvoke(buf, serialPortID, null, null);
                }
            }
        }

        private void UPSSerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = sender as SerialPort;
            Guid serialPortID = SerialPortDic.FirstOrDefault(_ => _.Value == serialPort).Key;
            int length = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            byte[] buf = new byte[length];//声明一个临时数组存储当前来的串口数据  
            serialPort.Read(buf, 0, length);//读取缓冲数据
            if (ProcessUPSSerialData != null)
            {
                Delegate[] delArray = ProcessUPSSerialData.GetInvocationList();
                foreach (Action<byte[], Guid> item in delArray)
                {
                    item.BeginInvoke(buf, serialPortID, null, null);
                }
            }
        }

        private void SolarEnergySerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort serialPort = sender as SerialPort;
            Guid serialPortID = SerialPortDic.FirstOrDefault(_ => _.Value == serialPort).Key;
            int length = serialPort.BytesToRead;//先记录下来，避免某种原因，人为的原因，操作几次之间时间长，缓存不一致  
            byte[] buf = new byte[length];//声明一个临时数组存储当前来的串口数据  
            serialPort.Read(buf, 0, length);//读取缓冲数据
            if (ProcessSolarEnergySerialData != null)
            {
                Delegate[] delArray = ProcessSolarEnergySerialData.GetInvocationList();
                foreach (Action<byte[], Guid> item in delArray)
                {
                    item.BeginInvoke(buf, serialPortID, null, null);
                }
            }
        }
    }
}
