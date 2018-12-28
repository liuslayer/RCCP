using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RCCP.Repository.Entities;
using System.Collections.Generic;
using RCCP.Repository.Concrete;
using OMServer.Model;
using OMServer;
using System.IO;
using System.Threading;
using RCCP.Common;
using LogServer;
using RCCP.Repository.Entities.DynamicEntity;
using Newtonsoft.Json;

namespace RCCP.UnitTest
{
    [TestClass]
    public class CRUDTest
    {
        [TestMethod]
        public void InsertTest()
        {
            //UserPermissionList newUserPermission = new UserPermissionList();
            //UserPermissionListRepository repository = new UserPermissionListRepository();
            //newUserPermission.UserPermissionID = repository.GetGuid();
            //wancheng Guid g = repository.Insert(newUserPermission);
            //SerialCOMListRepository repo = new SerialCOMListRepository();
            //SerialCOMList deviceList = new SerialCOMList();
            //deviceList.DeviceID = repo.GetGuid();
            //deviceList.COMNo = "COM3";
            //repo.Insert(deviceList);
            //for (int i = 0; i < 8; i++)
            //{
            //    deviceList.DeviceID = repo.GetGuid();
            //    deviceList.VideoIP = "192.168.10.14";
            //    Guid result = repo.Insert(deviceList);
            //}
            //using (FileStream fs = new FileStream("Image\\Turntable.png", FileMode.Open, FileAccess.Read))
            //{
            //    byte[] buffer = new byte[1024];
            //    int count = fs.Read(buffer, 0, buffer.Length);
            //    deviceList.Image1 = buffer;
            //}

            //RunLogRepository repo = new RunLogRepository();
            //for (int i = 0; i < 105; i++)
            //{
            //    RunLog log = new RunLog();
            //    log.OperationTime = DateTime.Now.ToString();
            //    log.OperationType = 1;
            //    log.Operator = "ly";
            //    log.OperationContent = "登录";
            //    repo.Insert(log);
            //    Thread.Sleep(100);
            //}

            //AlarmLogRepository repo = new AlarmLogRepository();
            //for (int i = 0; i < 105; i++)
            //{
            //    AlarmLog log = new AlarmLog();
            //    log.AlarmTime = DateTime.Now.ToString();
            //    log.AlarmDeviceID = new Guid();
            //    log.Operator = "无";
            //    log.AlarmID = new Guid();
            //    log.AlarmLevel = 1;
            //    log.AlarmName = "测试报警" + i;
            //    log.AlarmStatus = 1;
            //    log.AlarmType = 1;
            //    log.Alt = i;
            //    log.Lat = i;
            //    log.Lon = i;
            //    repo.Insert(log);
            //    Thread.Sleep(100);
            //}

            //ErrLogRepository repo = new ErrLogRepository();
            //for (int i = 0; i < 105; i++)
            //{
            //    try
            //    {
            //        throw new Exception("TestException" + i);
            //    }
            //    catch(Exception ex)
            //    {
            //        LogServerManager.AddErrLog(LogServerManager.ErrLogType.InnerErr, ex);
            //    }
            //    Thread.Sleep(100);
            //}

            //StationListRepository repo = new StationListRepository();
            //StationList station = new StationList();
            //station.PStationID = Guid.Parse("e2061d09-111e-413b-8ab5-6b71d4c38b3d");
            //station.Name = "监控站2";
            //station.Lon = 104.317792;
            //station.Lat = 30.541620;
            //station.TypeID = 9;
            //repo.Insert(station);

            //for (int i = 0; i < 16; i++)
            //{
            //    TurnTableListRepository repo = new TurnTableListRepository();
            //    TurnTableList TurnTableList = new TurnTableList();
            //    TurnTableList.StationID = Guid.Parse("e2061d09-111e-413b-8ab5-6b71d4c38b3d");
            //    TurnTableList.Name = "转台";
            //    TurnTableList.TypeID = 7;
            //    repo.Insert(TurnTableList);
            //}

            //for (int i = 0; i < 12; i++)
            //{
            //    StreamMediaListRepository repo = new StreamMediaListRepository();
            //    StreamMediaList streamMediaList = new StreamMediaList();
            //    //streamMediaList.VideoIP = "192.168.10.1" + i;
            //    streamMediaList.Name = "监控站1-转台1-白光";
            //    streamMediaList.TypeID = 1;
            //    repo.Insert(streamMediaList);
            //}

            //for (int i = 1; i <= 12; i++)
            //{
            //    CameraListRepository repo = new CameraListRepository();
            //    CameraList CameraList = new CameraList();
            //    CameraList.VideoName = "监控站-转台-白光";
            //    CameraList.VideoChannel = 1;
            //    CameraList.VideoType = "101";
            //    CameraList.TypeID = 4;
            //    repo.Insert(CameraList);
            //}

            //for (int i = 0; i < 3; i++)
            //{
            //    UPSListRepository repo = new UPSListRepository();
            //    UPSList upslist = new UPSList();
            //    upslist.Name = "UPS";
            //    upslist.TypeID = 8;
            //    repo.Insert(upslist);
            //}

            for (int i = 0; i < 3; i++)
            {
                SolarEnergyListRepository repo = new SolarEnergyListRepository();
                SolarEnergyList SolarEnergyList = new SolarEnergyList();
                SolarEnergyList.Name = "太阳能";
                SolarEnergyList.TypeID = 6;
                repo.Insert(SolarEnergyList);
            }
        }

        [TestMethod]
        public void GetTest()
        {
            //CameraListRepository repo = new CameraListRepository();
            //List<CameraList> cameraList = repo.GetList();
            //CameraList camera = repo.GetEntityById(cameraList[0].DeviceID);
            //cameraList = repo.GetListWithCondition(new { VideoType = camera.VideoType });
            //cameraList = repo.GetListWithCondition("where VideoType=1 and VideoName like'14%'");

            //TurnTableListRepository repo = new TurnTableListRepository();
            //List<TurnTableList> result = repo.GetList();

            //PresetListRepository repo = new PresetListRepository();
            //List<PresetList> CameraList = repo.GetList();

            RunLogRepository repo = new RunLogRepository();
            List<RunLog> result = repo.GetListPaged(1, 0, null, "OperationTime desc");
            //List<RunLog> result1 = repo.GetListPaged(2, 10, null, "OperationTime desc");
            //List<RunLog> result2 = repo.GetListPaged(3, 10, null, "OperationTime desc");
            //List<RunLog> result3 = repo.GetListPaged(4, 10, null, "OperationTime desc");
        }

        [TestMethod]
        public void UpdateTest()
        {
            CameraListRepository repo = new CameraListRepository();
            List<CameraList> cameraList = repo.GetList();
            //cameraList[0].VideoName = DateTime.Now.ToString();
            //cameraList[1].Stream_MainID = repo.GetGuid();
            //int result = repo.Update(cameraList[0]);
        }

        [TestMethod]
        public void DeleteTest()
        {
            CameraListRepository repo = new CameraListRepository();
            List<CameraList> cameraList = repo.GetList();
            //int result = repo.Delete(cameraList[0].DeviceID);
            //result = repo.DeleteList(new { VideoType = cameraList[1].VideoType });
            int result = repo.DeleteList("where VideoType=2");

        }

        [TestMethod]
        public void RecordCountTest()
        {
            CameraListRepository repo = new CameraListRepository();
            int count = repo.RecordCount();
        }
    }
}