using Client.Entities;
using Client.Entities.AlarmEntity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using static DeviceBaseData.PlanData;

namespace DeviceBaseData
{
    public class ClassPlan
    {
        public static List<CameraList> cameraList;
        public static List<StreamMediaList> streamMediaList;
        public static List<StreamServerList> streamServerList;
        public static List<Pre_arrangedPlanning> pre_arrangedPlanning;
        public static List<ArmAndDisarmList> armAndDisarmList;
        public static List<LinkageData> linkageData;
        public static List<Pre_arrangeList> pre_arrangeList;
        public static Dictionary<string, AlarmMessageForAll> temp_PlanDataforAll = new Dictionary<string, AlarmMessageForAll>();//包含所有预案数据的字典
        public static bool IsDone;

        public void PlanInit()
        {
            //从服务器获取设备基础数据
            // string message = "GetPre_arrangedPlanning/add," + +"\r\n";
            string message = "GetPre_arrangedPlanning/Query\r\n";
            Byte[] data = Encoding.ASCII.GetBytes(message);
            CommunicationClass.stream2.Write(data, 0, data.Length);

            string responseData = String.Empty;

            data = new Byte[1024 * 100];
            while (true)
            {
                Int64 bytes = CommunicationClass.stream2.Read(data, 0, data.Length);

                responseData += Encoding.UTF8.GetString(data, 0, (int)bytes);
                temp_PlanDataforAll.Clear();
                PlanData plandata = JsonConvert.DeserializeObject<PlanData>(responseData);
                AssemblePlan(plandata);
                //pre_arrangedPlanning = plandata.pre_arrangedPlanning;
                //armAndDisarmList = plandata.armAndDisarmList;
                //linkageData = plandata.linkageData;
                IsDone = true;
                break;
            }

        }
        public void PlanAdd(AlarmMessageForAll temp_AlarmMessageForAll)
        {
            string str = JsonConvert.SerializeObject(temp_AlarmMessageForAll);
            string message = "GetPre_arrangedPlanning/Add," + str + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
        public void PlanRevise(AlarmMessageForAll temp_AlarmMessageForAll)
        {
            string str = JsonConvert.SerializeObject(temp_AlarmMessageForAll);
            string message = "GetPre_arrangedPlanning/Revise," + str + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
        public void PlanDel(AlarmMessageForAll temp_AlarmMessageForAll)
        {
            string str = JsonConvert.SerializeObject(temp_AlarmMessageForAll);
            string message = "GetPre_arrangedPlanning/Del," + str + "\r\n";
            byte[] b = Encoding.UTF8.GetBytes(message);
            CommunicationClass.stream2.Write(b, 0, b.Length);
        }
        private void AssemblePlan(PlanData plandata)
        {
            pre_arrangedPlanning = plandata.pre_arrangedPlanning;
            armAndDisarmList = plandata.armAndDisarmList;
            linkageData = plandata.linkageData;
            cameraList = plandata.cameraList;
            streamMediaList = plandata.streamMediaList;
            streamServerList = plandata.streamServerList;
            for (int i = 0; i < armAndDisarmList.Count; i++)
            {
                for (int j = 0; j < pre_arrangedPlanning.Count; j++)
                {
                    if (armAndDisarmList[i].AlarmDeviceID.ToString() == pre_arrangedPlanning[j].PlanTypeID.ToString())
                    {
                        AlarmMessageForAll temp_AlarmMessageForAll = new AlarmMessageForAll();
                        //--------------------------------对报警器结构体赋值①------------------------------------
                        temp_AlarmMessageForAll.AlarmDeviceID = armAndDisarmList[i].AlarmDeviceID.ToString();
                        temp_AlarmMessageForAll.AlarmName = armAndDisarmList[i].AlarmName;
                        //----------------------------------------------------------------------------------------
                        //----------------------若在预案表单中找出ID一致，对进行赋值-------------------
                        temp_AlarmMessageForAll.PlanDeviceID = pre_arrangedPlanning[j].PlanDeviceID.ToString();
                        temp_AlarmMessageForAll.PlanType = pre_arrangedPlanning[j].PlanType;//报警预案:1
                        if (temp_AlarmMessageForAll.PlanType != 1)
                        {
                            return;
                        }
                        temp_AlarmMessageForAll.PlanTypeID = pre_arrangedPlanning[j].PlanTypeID;
                        temp_AlarmMessageForAll.DeviceID = pre_arrangedPlanning[j].DeviceID;
                        temp_AlarmMessageForAll.DeviceType = pre_arrangedPlanning[j].DeviceType.ToString();
                        temp_AlarmMessageForAll.TimeType = pre_arrangedPlanning[j].TimeType;//（时间类型：星期---1;日期---2;定时---3;全时段---4）
                        temp_AlarmMessageForAll.StartTime = pre_arrangedPlanning[j].StartTime;//起始时间
                        temp_AlarmMessageForAll.StartDate = pre_arrangedPlanning[j].StartDate;//起始日期
                        temp_AlarmMessageForAll.StartWeek = pre_arrangedPlanning[j].StartWeek;//起始星期
                        temp_AlarmMessageForAll.EndDate = pre_arrangedPlanning[j].EndDate;//结束日期
                        temp_AlarmMessageForAll.EndWeek = pre_arrangedPlanning[j].EndWeek;//结束星期
                        temp_AlarmMessageForAll.EndTime = pre_arrangedPlanning[j].EndTime;//结束时间
                        temp_AlarmMessageForAll.Description = pre_arrangedPlanning[j].Description;//描述
                        temp_AlarmMessageForAll.Mark = pre_arrangedPlanning[j].Mark;
                        //--------------------赋值完毕，下一步进行联动数据赋值--------------------------
                        LinkageData temp_LinkageData_1 = new LinkageData();
                        temp_LinkageData_1 = linkageData.Find(_ => _.PlanDeviceID.ToString() == temp_AlarmMessageForAll.PlanDeviceID && _.LinakgeStage == 1);
                        LinkageData temp_LinkageData_2 = new LinkageData();
                        temp_LinkageData_2 = linkageData.Find(_ => _.PlanDeviceID.ToString() == temp_AlarmMessageForAll.PlanDeviceID && _.LinakgeStage == 2);
                        LinkageData temp_LinkageData_3 = new LinkageData();
                        temp_LinkageData_3 = linkageData.Find(_ => _.PlanDeviceID.ToString() == temp_AlarmMessageForAll.PlanDeviceID && _.LinakgeStage == 3);
                        if (temp_LinkageData_1 != null)
                        {
                            temp_AlarmMessageForAll.Trigger_LinkageData = temp_LinkageData_1;
                        }
                        if (temp_LinkageData_2 != null)
                        {
                            temp_AlarmMessageForAll.Disposal_LinkageData = temp_LinkageData_2;
                        }
                        if (temp_LinkageData_3 != null)
                        {
                            temp_AlarmMessageForAll.Untreated_LinkageData = temp_LinkageData_3;
                        }
                        if (!temp_PlanDataforAll.ContainsKey(temp_AlarmMessageForAll.PlanDeviceID))
                        {
                            temp_PlanDataforAll.Add(temp_AlarmMessageForAll.PlanDeviceID, temp_AlarmMessageForAll);
                        }
                    }
                }
            }
        }
    }
    public class PlanData
    {
        public List<CameraList> cameraList;
        public List<StreamMediaList> streamMediaList;
        public List<StreamServerList> streamServerList;
        public List<Pre_arrangedPlanning> pre_arrangedPlanning;
        public List<ArmAndDisarmList> armAndDisarmList;
        public List<LinkageData> linkageData;
        public List<Pre_arrangeList> pre_arrangeList;
        public class AlarmMessageForAll
        {
            public string AlarmDeviceID;//报警器ID
            public string AlarmName;//报警器名称
            public string PlanDeviceID;//预案ID
            public LinkageData Trigger_LinkageData;//联动数据
            public LinkageData Disposal_LinkageData;//处置数据
            public LinkageData Untreated_LinkageData;//未处置数据
            public int PlanType;//预案类型（报警预案：1、自动录像预案：2）
            public string PlanTypeID;//预案类型ID（报警器ID）
            public string DeviceID;//设备ID
            public string DeviceType;//设备类型，视频---1
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
        //public class AlarmMessageForAll

        //{
        //    public string AlarmDeviceID;//报警器ID
        //    public string AlarmName;//报警器名称
        //    public PlanMessage PlanMessageForEachAlarm;//每个报警器对应报警预案计划
        //    //public AlarmMessage alarmmessage;//报警信息①
        //    //public PlanMessage temp_PlanMessage;//预案信息②
        //    //public LinkageData Trigger_LinkageData;//联动信息③
        //    //public LinkageData Disposal_LinkageData;//处置信息④
        //    //public LinkageData Untreated_LinkageData;//未处置信息⑤
        //}
        //public struct PlanMessage
        //{
        //    public string PlanDeviceID;//预案ID
        //    public int PlanType;//预案类型（报警预案：1）
        //    public string PlanTypeID;//预案类型ID（报警器ID）
        //    public LinkageData Trigger_LinkageData;//联动数据
        //    public LinkageData Disposal_LinkageData;//处置数据
        //    public LinkageData Untreated_LinkageData;//未处置数据
        //    public string TimeType;//（时间类型：星期---1;日期---2;定时---3;全时段---4）
        //    public string StartDate;//起始日期
        //    public string StartWeek;//起始星期
        //    public string StartTime;//起始时间
        //    public string EndDate;//结束日期
        //    public string EndWeek;//结束星期
        //    public string EndTime;//结束时间
        //    public string Description;//描述
        //    public string Mark;
        //}
    }
}
