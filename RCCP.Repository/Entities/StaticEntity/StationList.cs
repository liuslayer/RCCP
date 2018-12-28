using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// StationList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class StationList
    {
        public StationList()
        { }
        #region Model
        private Guid _stationid;
        private Guid? _pstationid;
        private string _name;
        private string _ip;
        private double? _lon;
        private double? _lat;
        private int _typeid;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 上级工作站ID
        /// </summary>
        public Guid? PStationID
        {
            set { _pstationid = value; }
            get { return _pstationid; }
        }
        /// <summary>
        /// 名字
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// IP
        /// </summary>
        public string IP
        {
            set { _ip = value; }
            get { return _ip; }
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
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
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
