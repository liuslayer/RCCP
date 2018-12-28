using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// VideoRec:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class VideoRec
    {
        public VideoRec()
        { }
        #region Model
        private long _id;
        private string _videorecname;
        private string _videorecpath;
        private DateTime _rectime;
        private string _reclocation;
        private string _recsrc;
        private string _eventtype;
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
        /// 录像名称
        /// </summary>
        public string VideoRecName
        {
            set { _videorecname = value; }
            get { return _videorecname; }
        }
        /// <summary>
        /// 录像存储路径
        /// </summary>
        public string VideoRecPath
        {
            set { _videorecpath = value; }
            get { return _videorecpath; }
        }
        /// <summary>
        /// 录像时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 录像地点
        /// </summary>
        public string RecLocation
        {
            set { _reclocation = value; }
            get { return _reclocation; }
        }
        /// <summary>
        /// 信息源
        /// </summary>
        public string RecSrc
        {
            set { _recsrc = value; }
            get { return _recsrc; }
        }
        /// <summary>
        /// 事件性质
        /// </summary>
        public string EventType
        {
            set { _eventtype = value; }
            get { return _eventtype; }
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
