using System;

namespace Client.Entities.AlarmEntity
{
    public class AlarmMessage
    {
        public DateTime DT_Alarm;//报警时间
        public string DeviceID;//设备标识，数据大小4
        public string AlarmDeviceID;//报警器标识，数据大小4
        public string AlarmFingerprintID;//报警ID，数据大小8
        public float AlarmPosition_X;//报警位置，经度X，数据大小4
        public float AlarmPosition_Y;//报警位置，纬度Y，数据大小4
        public long DefendAreaID;//所在防区，数据大小4
        public int AlarmTargetType;//报警目标类型，数据大小1
        public int AlarmLevel;//报警等级，数据大小1
        public int AlarmSpeed;//目标速度，数据大小4
        public int AlarmTargetNum;//报警目标个数，数据大小1
        public int AlarmPositon;//报警方位，数据大小4
        public int AlarmDistance;//目标距离，数据大小4
        //0---------------视频临时报警
        //1---------------视频报警器
        //4---------------雷达报警器
        //5---------------震动光缆报警器
        //6---------------SmartWall报警器
        //7---------------微波墙报警器
        public int AlarmType;//报警方式，数据大小1
        public int AlarmDescription;//报警事件描述，数据大小1
        public int AlarmStage;//报警阶段描述，数据大小1
        public string AlarmAreaName;//报警器名称
        public string AlarmString;//报警时设备触发上报的信息
    }
    public class AlarmMessageToClient
    {
        public AlarmMessage alarmmessage;//报警信息
        public LinkageDataStruct Now_LinkageData;//当前联动信息
    }
    public struct LinkageDataStruct
    {
        public string LinkageID;//联动ID
        public string LinkageStage;//联动阶段：1-联动响应阶段；2-处置阶段；3-未处置阶段
        public string Video_DeviceID;//联动显示的视频ID，超过两个以上的用","间隔，例如"5001,5002,5003"
        public string PTZ_DeviceID;//前端控制ID
        public string Preset;//前端控制预置位
        public string Switch_DeviceID;//开关量ID
        public string SwitchOperation;//开关量开关
        public string SwitchOperationTimeDelay;//开关量是否延迟
        public string VideoRecording;//视频录像
        //public string VideoRecordingTimeDelay;//录像停止延时
        //public string VideoFlashing;//视频框闪烁
        //public string VideoFlashingTimeDelay;//视频框停止延时
        public string AlarmSound;//报警声音
        public string AlarmSoundTimeDelay;//报警声音停止延时
        public bool Reset;//复位
        public bool isAlarm;//表示当前流程是否已经被执行
        public string Description;//描述
        public string Mark;//备注,未处置流程---未处置流程执行延迟时间
    }
}
