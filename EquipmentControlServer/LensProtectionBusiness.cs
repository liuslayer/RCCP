using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EquipmentControlServer
{
    public class LensProtectionBusiness
    {
        Thread t;
        List<LensProtection> _ListLensProtection = new List<LensProtection>();
        LensProtectionRepository _LensProtectionRepository = new LensProtectionRepository();
        int month;
        public string seviceInfo()
        {
            string StartUpType = "0" ;
            _ListLensProtection = _LensProtectionRepository.GetList();
            if (_ListLensProtection.Count > 0)
            {
                t = new Thread(Protect);
                StartUpType = "1";
            }
            else
            {
                StartUpType = "-1";
            }
            return StartUpType;
        }

        public void Protect()
        {
            while (true)
            {

                for (int i = 0; i < _ListLensProtection.Count; i++)
                {
                    if (string.IsNullOrEmpty(_ListLensProtection[i].SummerMonth) || string.IsNullOrEmpty(_ListLensProtection[i].WinterMonth))
                    { return; }
                    //获取夏时令的开始月份与结束月份
                    int str1 = int.Parse(_ListLensProtection[i].SummerMonth.Split(new char[] { '-' })[0]);
                    int str2 = int.Parse(_ListLensProtection[i].SummerMonth.Split(new char[] { '-' })[1]);
                    //获取冬时令的开始月份月结束月份
                    int str3 = int.Parse(_ListLensProtection[i].WinterMonth.Split(new char[] { '-' })[0]);
                    int str4 = int.Parse(_ListLensProtection[i].WinterMonth.Split(new char[] { '-' })[1]);
                    month = DateTime.Now.Month;
                    if (str1 < str2)
                    {
                        if (str1.CompareTo(month) <= 0 && str2.CompareTo(month) >= 0)
                        {
                            if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].SummerTimeBegin)
                            {
                                if(_ListLensProtection[i].SummerDetermine == (int)VideoProtectType.Protect_Off)
                                {
                                    //关闭设备 进入保护状态
                                    //_ListLensProtection[i].Camera_DeviceID;
                                    foreach(CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Off;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                    
                                }
                            }
                            else if(DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].SummerTimeEnd)
                            {
                                if(_ListLensProtection[i].SummerDetermine == (int)VideoProtectType.Protect_Open)
                                {
                                    //开启设备 退出保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Open;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].WinterTimeBegin)
                            {
                                if (_ListLensProtection[i].SummerDetermine == (int)VideoProtectType.Protect_Off)
                                {
                                    //关闭设备 进入保护状态
                                    //_ListLensProtection[i].Camera_DeviceID;
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Off;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }

                                }
                            }
                            else if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].WinterTimeEnd)
                            {
                                if (_ListLensProtection[i].SummerDetermine == (int)VideoProtectType.Protect_Open)
                                {
                                    //开启设备 退出保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Open;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (str3.CompareTo(month) <= 0 && str4.CompareTo(month) >= 0)
                        {
                            if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].WinterTimeBegin)
                            {
                                if (_ListLensProtection[i].WinterDetermine == (int)VideoProtectType.Protect_Off)
                                {
                                    //关闭设备 进入保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Off;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                            else if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].WinterTimeEnd)
                            {
                                if (_ListLensProtection[i].WinterDetermine == (int)VideoProtectType.Protect_Open)
                                {
                                    //开启设备 退出保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Open;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].SummerTimeBegin)
                            {
                                if (_ListLensProtection[i].WinterDetermine == (int)VideoProtectType.Protect_Off)
                                {
                                    //关闭设备 进入保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Off;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                            else if (DateTime.Now.ToString("HH:mm") == _ListLensProtection[i].SummerTimeEnd)
                            {
                                if (_ListLensProtection[i].WinterDetermine == (int)VideoProtectType.Protect_Open)
                                {
                                    //开启设备 退出保护状态
                                    foreach (CameraList mc in ControlBusinessData.CameraList_Dictionary.Values)
                                    {
                                        int iVideoType = Convert.ToInt32(mc.VideoType);
                                        if (iVideoType == (int)VideoCommandType.VideoIR)
                                        {
                                            ControlData tmp_ControlData = new ControlData();
                                            tmp_ControlData.VideoGuid = mc.DeviceID;
                                            tmp_ControlData.iAction = (int)IRCommand.IR_Open;
                                            ProtocolBusinessLogic.SetIRControl_Business(tmp_ControlData);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 启动线程
        /// </summary>
        public void ThreadOpen()
        {
            t.Start();
        }

        /// <summary>
        /// 关闭线程
        /// </summary>
        public void ThreadStop()
        {
            t.Abort();
        }
    }
}
