
using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConfiguration.DeviceEntitiy
{
    /// <summary>
    /// VibrationCableList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class VibrationCableList
    {
        public VibrationCableList()
        { }
        #region Model
        private Guid _deviceid;
        private string _name;
        private int _typeid;
        private double? _lon;
        private double? _lat;
        private double? _alt;
        private int _communicationtype;
        private Guid? _communicationid;
        private Guid? _stationid;
        private int _protocoltype;
        private string _description;
        private string _mark;

        [Key]
        public Guid DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }

        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
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
        public double? Alt
        {
            set { _alt = value; }
            get { return _alt; }
        }

        public int CommunicationType
        {
            set { _communicationtype = value; }
            get { return _communicationtype; }
        }

        public Guid? CommunicationID
        {
            set { _communicationid = value; }
            get { return _communicationid; }
        }
        public Guid? StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        public int ProtocolType
        {
            set { _protocoltype = value; }
            get { return _protocoltype; }
        }
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
        #endregion
    }
}
