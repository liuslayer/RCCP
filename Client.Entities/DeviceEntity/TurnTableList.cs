using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Entities
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
        private Guid? _serialcomid;
        private string _name;
        private int? _typeid;
        private string _lon;
        private string _lat;
        private string _alt;
        private string _erectingheight;
        private string _azimuthangle;
        private string _normalcolor;
        private string _alarmcolor;
        private int? _protocoltype;
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
        /// 
        /// </summary>
        public Guid? SerialComID
        {
            set { _serialcomid = value; }
            get { return _serialcomid; }
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
        public int? TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 经度
        /// </summary>
        public string Lon
        {
            set { _lon = value; }
            get { return _lon; }
        }
        /// <summary>
        /// 纬度
        /// </summary>
        public string Lat
        {
            set { _lat = value; }
            get { return _lat; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Alt
        {
            set { _alt = value; }
            get { return _alt; }
        }
        /// <summary>
        /// 架设高度
        /// </summary>
        public string ErectingHeight
        {
            set { _erectingheight = value; }
            get { return _erectingheight; }
        }
        /// <summary>
        /// 偏北角
        /// </summary>
        public string AzimuthAngle
        {
            set { _azimuthangle = value; }
            get { return _azimuthangle; }
        }
        /// <summary>
        /// 正常颜色
        /// </summary>
        public string NormalColor
        {
            set { _normalcolor = value; }
            get { return _normalcolor; }
        }
        /// <summary>
        /// 报警颜色
        /// </summary>
        public string AlarmColor
        {
            set { _alarmcolor = value; }
            get { return _alarmcolor; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? ProtocolType
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
