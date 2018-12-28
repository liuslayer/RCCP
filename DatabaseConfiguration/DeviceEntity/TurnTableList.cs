using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConfiguration.DeviceEntitiy
{
    /// <summary>
    /// TurnTableList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class TurnTableList
    {
        public TurnTableList()
        { }
        #region Model
        private Guid _deviceid;
        private Guid? _communicationid;
        private int _communicationtype;
        private Guid? _stationid;
        private string _name;
        private int _typeid;
        private double? _lon;
        private double? _lat;
        private double _alt;
        private double _erectingheight;
        private int _erectingheighttype;
        private double _azimuthangle;
        private int _protocoltype;
        private int _turntableaddr;
        private int _ccdaddr;
        private int _iraddr;
        private string _description;
        private string _mark;
        /// <summary>
        /// 设备编号
        /// </summary>
        [Key]
        public Guid DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 通信ID
        /// </summary>
        public Guid? CommunicationID
        {
            set { _communicationid = value; }
            get { return _communicationid; }
        }
        /// <summary>
        /// 通信类型:1 串口 2 网络 3海康透明通道 4 海康SDK
        /// </summary>
        public int CommunicationType
        {
            set { _communicationtype = value; }
            get { return _communicationtype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
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
        /// 设备类型ID
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public double? Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public double? Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double Alt
        {
            set { _alt = value; }
            get { return _alt; }
        }
        /// <summary>
        /// 架设高度
        /// </summary>
        public double ErectingHeight
        {
            set { _erectingheight = value; }
            get { return _erectingheight; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ErectingHeightType
        {
            set { _erectingheighttype = value; }
            get { return _erectingheighttype; }
        }
        /// <summary>
        /// 偏北角
        /// </summary>
        public double AzimuthAngle
        {
            set { _azimuthangle = value; }
            get { return _azimuthangle; }
        }
        /// <summary>
        /// 协议类型
        /// </summary>
        public int ProtocolType
        {
            set { _protocoltype = value; }
            get { return _protocoltype; }
        }
        /// <summary>
        /// 转台协议地址
        /// </summary>
        public int TurntableAddr
        {
            set { _turntableaddr = value; }
            get { return _turntableaddr; }
        }
        /// <summary>
        /// 白光协议地址
        /// </summary>
        public int CCDAddr
        {
            set { _ccdaddr = value; }
            get { return _ccdaddr; }
        }
        /// <summary>
        /// 红外协议地址
        /// </summary>
        public int IRAddr
        {
            set { _iraddr = value; }
            get { return _iraddr; }
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

