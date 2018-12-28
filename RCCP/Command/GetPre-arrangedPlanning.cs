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
using System.Threading.Tasks;

namespace RCCP.Command
{
    public class GetPre_arrangedPlanning :CommandBase<AppSession, StringRequestInfo>
    {
        static Pre_arrangedPlanningRepository Pre_arrangedPlanning = new Pre_arrangedPlanningRepository();
        static ArmAndDisArmListRepository ArmAndDisArm = new ArmAndDisArmListRepository();
        static LinkageDataRepository LinkageDataComand = new LinkageDataRepository();
        static StreamServerListRepository StreamServerList = new StreamServerListRepository();
        static StreamMediaListRepository StreamMediaList = new StreamMediaListRepository();
        static CameraListRepository CameraList = new CameraListRepository();
        public class PlanData
        {
            public List<CameraList> cameraList;
            public List<StreamMediaList> streamMediaList;
            public List<StreamServerList> streamServerList;
            public List<Pre_arrangedPlanning> pre_arrangedPlanning;
            public List<ArmAndDisarmList> armAndDisarmList;
            public List<LinkageData> linkageData;
        }
        public class AlarmMessageForAll
        {
            public string AlarmDeviceID;//报警器ID
            public string AlarmName;//报警器名称
            public string PlanDeviceID;//预案ID
            public LinkageData Trigger_LinkageData;//联动数据
            public LinkageData Disposal_LinkageData;//处置数据
            public LinkageData Untreated_LinkageData;//未处置数据
            public int PlanType;//预案类型（报警预案：1）
            public string PlanTypeID;//预案类型ID（报警器ID）
            public string DeviceID;
            public string DeviceType;
            public string TimeType;//（时间类型：星期---1;日期---2;定时---3;全时段---4）
            public string StartDate;//起始日期
            public string StartWeek;//起始星期
            public string StartTime;//起始时间
            public string EndDate;//结束日期
            public string EndWeek;//结束星期
            public string EndTime;//结束时间
            public string Description;//描述
            public string Mark;
        }
        public override void ExecuteCommand(AppSession session, StringRequestInfo requestInfo)
        {
            PlanData data = new PlanData();
            AlarmMessageForAll dataForOne = new AlarmMessageForAll();
            switch (requestInfo[0])
            {
                case "Add"://添加
                    {
                        string str = requestInfo.Body.Substring(4);
                        dataForOne = JsonConvert.DeserializeObject<AlarmMessageForAll>(str);
                        try
                        {
                            //插入预案数据
                            Pre_arrangedPlanning temp_Pre_arrangedPlanning = new Pre_arrangedPlanning();
                            temp_Pre_arrangedPlanning.PlanDeviceID = new Guid(dataForOne.PlanDeviceID);
                            temp_Pre_arrangedPlanning.PlanType = dataForOne.PlanType;
                            temp_Pre_arrangedPlanning.PlanTypeID = dataForOne.PlanTypeID;
                            temp_Pre_arrangedPlanning.DeviceID = dataForOne.DeviceID;
                            temp_Pre_arrangedPlanning.DeviceType = int.Parse(dataForOne.DeviceType);
                            temp_Pre_arrangedPlanning.StartDate = dataForOne.StartDate;
                            temp_Pre_arrangedPlanning.StartTime = dataForOne.StartTime;
                            temp_Pre_arrangedPlanning.StartWeek = dataForOne.StartWeek;
                            temp_Pre_arrangedPlanning.TimeType = dataForOne.TimeType;
                            temp_Pre_arrangedPlanning.EndDate = dataForOne.EndDate;
                            temp_Pre_arrangedPlanning.EndTime = dataForOne.EndTime;
                            temp_Pre_arrangedPlanning.EndWeek = dataForOne.EndWeek;
                            temp_Pre_arrangedPlanning.Description = dataForOne.Description;
                            temp_Pre_arrangedPlanning.Mark = dataForOne.Mark;
                            Pre_arrangedPlanning.Insert(temp_Pre_arrangedPlanning);
                            //插入联动数据
                            LinkageData Trigger_LinkageData = dataForOne.Trigger_LinkageData;//联动数据
                            if (Trigger_LinkageData != null)
                            {
                                LinkageDataComand.Insert(Trigger_LinkageData);
                            }
                            LinkageData Disposal_LinkageData = dataForOne.Disposal_LinkageData;//处置数据
                            if (Disposal_LinkageData != null)
                            {
                                LinkageDataComand.Insert(Disposal_LinkageData);
                            }
                            LinkageData Untreated_LinkageData = dataForOne.Untreated_LinkageData;//未处置数据 
                            if (Untreated_LinkageData != null)
                            {
                                LinkageDataComand.Insert(Untreated_LinkageData);
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.ToString());
                        }
                    }
                    break;
                case "Del"://删除
                    {
                        string str = requestInfo.Body.Substring(4);
                        dataForOne = JsonConvert.DeserializeObject<AlarmMessageForAll>(str);
                        try
                        {
                            Pre_arrangedPlanning.Delete(new Guid(dataForOne.PlanDeviceID));
                            LinkageData Trigger_LinkageData = dataForOne.Trigger_LinkageData;//联动数据
                            if (Trigger_LinkageData != null)
                            {
                                LinkageDataComand.Delete(Trigger_LinkageData);
                            }
                            LinkageData Disposal_LinkageData = dataForOne.Disposal_LinkageData;//处置数据
                            if (Disposal_LinkageData != null)
                            {
                                LinkageDataComand.Delete(Disposal_LinkageData);
                            }
                            LinkageData Untreated_LinkageData = dataForOne.Untreated_LinkageData;//未处置数据 
                            if (Untreated_LinkageData != null)
                            {
                                LinkageDataComand.Delete(Untreated_LinkageData);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    break;
                case "Revise"://修改
                    {
                        string str = requestInfo.Body.Substring(7);
                        dataForOne = JsonConvert.DeserializeObject<AlarmMessageForAll>(str);
                        try
                        {
                            //插入预案数据
                            Pre_arrangedPlanning temp_Pre_arrangedPlanning = new Pre_arrangedPlanning();
                            temp_Pre_arrangedPlanning.PlanDeviceID = new Guid(dataForOne.PlanDeviceID);
                            temp_Pre_arrangedPlanning.PlanType = dataForOne.PlanType;
                            temp_Pre_arrangedPlanning.PlanTypeID = dataForOne.PlanTypeID;
                            temp_Pre_arrangedPlanning.DeviceID = dataForOne.DeviceID;
                            temp_Pre_arrangedPlanning.DeviceType = int.Parse(dataForOne.DeviceType);
                            temp_Pre_arrangedPlanning.StartDate = dataForOne.StartDate;
                            temp_Pre_arrangedPlanning.StartTime = dataForOne.StartTime;
                            temp_Pre_arrangedPlanning.StartWeek = dataForOne.StartWeek;
                            temp_Pre_arrangedPlanning.TimeType = dataForOne.TimeType;
                            temp_Pre_arrangedPlanning.EndDate = dataForOne.EndDate;
                            temp_Pre_arrangedPlanning.EndTime = dataForOne.EndTime;
                            temp_Pre_arrangedPlanning.EndWeek = dataForOne.EndWeek;
                            temp_Pre_arrangedPlanning.Description = dataForOne.Description;
                            temp_Pre_arrangedPlanning.Mark = dataForOne.Mark;
                            Pre_arrangedPlanning.Update(temp_Pre_arrangedPlanning);
                            //插入联动数据
                            LinkageData Trigger_LinkageData = dataForOne.Trigger_LinkageData;//联动数据
                            if (Trigger_LinkageData != null)
                            {
                                LinkageDataComand.Update(Trigger_LinkageData);
                            }
                            LinkageData Disposal_LinkageData = dataForOne.Disposal_LinkageData;//处置数据
                            if (Disposal_LinkageData != null)
                            {
                                LinkageDataComand.Update(Disposal_LinkageData);
                            }
                            LinkageData Untreated_LinkageData = dataForOne.Untreated_LinkageData;//未处置数据 
                            if (Untreated_LinkageData != null)
                            {
                                LinkageDataComand.Update(Untreated_LinkageData);
                            }
                        }
                        catch (Exception)
                        {

                            throw;
                        }
                    }
                    break;
                case "Query"://查询
                    {
                        List<Pre_arrangedPlanning> pre_arrangedPlanning;
                        List<ArmAndDisarmList> armAndDisarmList;
                        List<LinkageData> linkageData;
                        List<CameraList> cameraList;
                        List<StreamMediaList> streamMediaList;
                        List<StreamServerList> streamServerList;
                        //获取数据库的所有设备信息
                        pre_arrangedPlanning = Pre_arrangedPlanning.GetList();
                        armAndDisarmList = ArmAndDisArm.GetList();
                        linkageData = LinkageDataComand.GetList();
                        cameraList = CameraList.GetList();
                        streamMediaList = StreamMediaList.GetList();
                        streamServerList = StreamServerList.GetList();
                        //组装数据
                        data.pre_arrangedPlanning = pre_arrangedPlanning;
                        data.armAndDisarmList = armAndDisarmList;
                        data.linkageData = linkageData;
                        data.cameraList = cameraList;
                        data.streamMediaList = streamMediaList;
                        data.streamServerList = streamServerList;
                        //转json
                        string str = JsonConvert.SerializeObject(data);
                        session.Send(str);
                    }
                    break;
                case "Query1":
                    List<Pre_arrangedPlanning> pre_arrangedPlanning1;
                    pre_arrangedPlanning1 = Pre_arrangedPlanning.GetList();
                    for (int i = 0; i < pre_arrangedPlanning1.Count; i++)
                    {
                        if (pre_arrangedPlanning1[i].PlanType != 2) pre_arrangedPlanning1.Remove(pre_arrangedPlanning1[i]);
                    }
                    //转json
                    string str1 = JsonConvert.SerializeObject(pre_arrangedPlanning1);
                    session.Send(str1);
                    break;

            }
        }
    }
}
