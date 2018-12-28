using Dapper;
using System;
namespace RCCP.Repository.Entities
{
    /// <summary>
    /// AlarmLog:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AlarmLog
    {
        public AlarmLog()
        { }
        #region Model
        private long _id;
        private string _alarmid;
        private Guid _alarmdeviceid;
        private int _alarmtype;
        private string _alarmname;
        private int _alarmlevel;
        private DateTime _alarmtime;
        private int _alarmstatus;
        private string _disposetime;
        private string _operator;
        private float? _lon;
        private float? _lat;
        private float _alt;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public long ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 报警唯一编号
        /// </summary>
        public string AlarmID
        {
            set { _alarmid = value; }
            get { return _alarmid; }
        }
        /// <summary>
        /// 报警设备编号
        /// </summary>
        public Guid AlarmDeviceID
        {
            set { _alarmdeviceid = value; }
            get { return _alarmdeviceid; }
        }
        /// <summary>
        /// 报警类别：0未知，1视频，2雷达，3震动光缆，4微波墙
        /// </summary>
        public int AlarmType
        {
            set { _alarmtype = value; }
            get { return _alarmtype; }
        }
        /// <summary>
        /// 报警名称
        /// </summary>
        public string AlarmName
        {
            set { _alarmname = value; }
            get { return _alarmname; }
        }
        /// <summary>
        /// 报警等级：1、2、3、4....
        /// </summary>
        public int AlarmLevel
        {
            set { _alarmlevel = value; }
            get { return _alarmlevel; }
        }
        /// <summary>
        /// 报警时间
        /// </summary>
        public DateTime AlarmTime
        {
            set { _alarmtime = value; }
            get { return _alarmtime; }
        }
        /// <summary>
        /// 报警状态:1报警触发、2报警处置、3报警未处置、4报警结束
        /// </summary>
        public int AlarmStatus
        {
            set { _alarmstatus = value; }
            get { return _alarmstatus; }
        }
        /// <summary>
        /// 处理时间,当报警状态处于处置阶段时填入此项
        /// </summary>
        public string DisposeTime
        {
            set { _disposetime = value; }
            get { return _disposetime; }
        }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string Operator
        {
            set { _operator = value; }
            get { return _operator; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public float? Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public float? Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 高度
        /// </summary>
        public float Alt
        {
            set { _alt = value; }
            get { return _alt; }
        }
        #endregion Model

    }
}

