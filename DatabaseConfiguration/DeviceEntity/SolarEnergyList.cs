
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace DatabaseConfiguration.DeviceEntitiy
{
    /// <summary>
    /// SolarEnergyList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SolarEnergyList
    {
        public SolarEnergyList()
        { }
        #region Model
        private Guid _deviceid;
        private Guid? _communicationid;
        private int _communicationtype;
        private Guid? _stationid;
        private string _name;
        private int _typeid;
        private string _ip;
        private string _port;
        private string _username;
        private string _password;
        private double? _lon;
        private double? _lat;
        private double _alt;
        private double _erectingheight;
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
        /// 
        /// </summary>
        public Guid? CommunicationID
        {
            set { _communicationid = value; }
            get { return _communicationid; }
        }
        /// <summary>
        /// 
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
        /// 太阳能名字
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
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Port
        {
            set { _port = value; }
            get { return _port; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Password
        {
            set { _password = value; }
            get { return _password; }
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
        /// 
        /// </summary>
        public double ErectingHeight
        {
            set { _erectingheight = value; }
            get { return _erectingheight; }
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

