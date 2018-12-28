using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
    /// <summary>
	/// CameraStatusList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
    public class CameraStatusList
    {
        public CameraStatusList()
        { }
        #region Model
        private long _id;
        private Guid _deviceid;
        private string _name;
        private bool _isonline;
        private int _recordstatus;
        private int _signalstatus;
        private int _hardwarestatus;
        private int _bitrate;
        private DateTime _time;
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
        /// 设备ID
        /// </summary>
        public Guid DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 是否在线,0-不在线，1-在线
        /// </summary>
        public bool IsOnline
        {
            set { _isonline = value; }
            get { return _isonline; }
        }
        /// <summary>
        /// 通道是否在录像,0表示未知，1表示未录像，2表示录像中
        /// </summary>
        public int RecordStatus
        {
            set { _recordstatus = value; }
            get { return _recordstatus; }
        }
        /// <summary>
        /// 连接的信号状态,0表示未知，1表示正常，2表示信号丢失
        /// </summary>
        public int SignalStatus
        {
            set { _signalstatus = value; }
            get { return _signalstatus; }
        }
        /// <summary>
        /// 通道硬件状态,0表示未知，1表示正常，2表示异常
        /// </summary>
        public int HardwareStatus
        {
            set { _hardwarestatus = value; }
            get { return _hardwarestatus; }
        }
        /// <summary>
        /// 实际码率，单位KBit/S
        /// </summary>
        public int BitRate
        {
            set { _bitrate = value; }
            get { return _bitrate; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime Time
        {
            set { _time = value; }
            get { return _time; }
        }
        #endregion Model

    }
}
