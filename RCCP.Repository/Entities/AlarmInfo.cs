using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// AlarmInfo:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class AlarmInfo
    {
        public AlarmInfo()
        { }
        #region Model
        private long _id;
        private string _alarmid;
        private DateTime _alarmtime;
        private string _alarmlocation;
        private int _alarmtype;
        private int _targetattribute;
        private string _description;
        private string _mark;
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
        /// 报警编号
        /// </summary>
        public string AlarmID
        {
            set { _alarmid = value; }
            get { return _alarmid; }
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
        /// 报警地理位置
        /// </summary>
        public string AlarmLocation
        {
            set { _alarmlocation = value; }
            get { return _alarmlocation; }
        }
        /// <summary>
        /// 报警类别：0其他，1视频，2雷达，3震动光缆，4微波墙
        /// </summary>
        public int AlarmType
        {
            set { _alarmtype = value; }
            get { return _alarmtype; }
        }
        /// <summary>
        /// 目标性质：0其他，1人，2车
        /// </summary>
        public int TargetAttribute
        {
            set { _targetattribute = value; }
            get { return _targetattribute; }
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
