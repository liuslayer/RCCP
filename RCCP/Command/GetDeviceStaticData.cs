using Newtonsoft.Json;
using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using SuperSocket.SocketBase;
using SuperSocket.SocketBase.Command;
using SuperSocket.SocketBase.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Command
{
    public class GetDeviceStaticData : CommandBase<AppSession, StringRequestInfo>
    {
        public class DeviceData
        {
            public List<CameraList> cameraList;
            public List<StreamMediaList> streamMediaList;
            public List<StreamServerList> streamServerList;
            public List<StationList> stationList;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            List<CameraList> cameraList;
            List<StreamMediaList> streamMediaList;
            List<StreamServerList> streamServerList;
            List<StationList> stationList;
            //获取数据库的所有设备信息，登录设备
            CameraListRepository camera = new CameraListRepository();
            cameraList = camera.GetList();
            StreamMediaListRepository streamMedia = new StreamMediaListRepository();
            streamMediaList = streamMedia.GetList();
            StreamServerListRepository streamServer = new StreamServerListRepository();
            streamServerList = streamServer.GetList();
            StationListRepository station = new StationListRepository();
            stationList = station.GetList();
            //组装数据
            DeviceData data = new DeviceData();
            data.cameraList = cameraList;
            data.streamMediaList = streamMediaList;
            data.streamServerList = streamServerList;
            data.stationList = stationList;
            //转json
            string str =JsonConvert.SerializeObject(data);
            session.Send(str);

        }
    }
}
