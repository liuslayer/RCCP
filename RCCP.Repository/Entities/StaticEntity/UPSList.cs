using Dapper;
using System;
namespace RCCP.Repository.Entities
{
    /// <summary>
    /// UPSList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class UPSList
    {
        public UPSList()
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
        private int _protocoltype;
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
        /// UPS名字
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// 设备类型
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public double? Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// 
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
        /// 协议类型
        /// </summary>
        public int ProtocolType
        {
            set { _protocoltype = value; }
            get { return _protocoltype; }
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

