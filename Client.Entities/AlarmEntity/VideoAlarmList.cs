using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Entities.AlarmEntity
{
    /// <summary>
    /// VideoAlarmList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class VideoAlarmList
    {
        public VideoAlarmList()
        { }
        #region Model
        private Guid _deviceid;
        private string _alarmname;
        private int? _alarmtype;
        private string _alarmpointselect;
        private Guid? _alarmsnapshotscheck;
        private int? _typeid;
        private string _com;
        private string _ip;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AlarmName
        {
            set { _alarmname = value; }
            get { return _alarmname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? AlarmType
        {
            set { _alarmtype = value; }
            get { return _alarmtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string AlarmPointSelect
        {
            set { _alarmpointselect = value; }
            get { return _alarmpointselect; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AlarmSnapshotsCheck
        {
            set { _alarmsnapshotscheck = value; }
            get { return _alarmsnapshotscheck; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string COM
        {
            set { _com = value; }
            get { return _com; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Description
        {
            set { _description = value; }
            get { return _description; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        #endregion Model

    }
}

