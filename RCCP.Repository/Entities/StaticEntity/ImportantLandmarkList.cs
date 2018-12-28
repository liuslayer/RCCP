using Dapper;
using System;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// ImportantLandmarkList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ImportantLandmarkList
    {
        
        public ImportantLandmarkList()
        { }
        #region Model
        private Guid _id;
        private string _name;
        private double? _lon;
        private double? _lat;
        private double? _alt;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
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
        #endregion
    }
}
