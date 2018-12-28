using Dapper;
using System;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// ServerList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ServerList
    {
        public ServerList()
        { }
        #region Model
        private Guid _deviceid;
        private string _name;
        private int _typeid;
        private string _ip;
        private Guid? _stationid;
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
        public string Ip
        {
            set { _ip = value; }
            get { return _ip; }
        }
        public Guid? StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
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
        #endregion Model
    }
}
