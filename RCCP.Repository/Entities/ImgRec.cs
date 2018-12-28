using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// ImgRec:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ImgRec
    {
        public ImgRec()
        { }
        #region Model
        private long _id;
        private string _imgrecname;
        private string _imgrecpath;
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
        /// 照片存储名
        /// </summary>
        public string ImgRecName
        {
            set { _imgrecname = value; }
            get { return _imgrecname; }
        }
        /// <summary>
        /// 照片存储路径
        /// </summary>
        public string ImgRecPath
        {
            set { _imgrecpath = value; }
            get { return _imgrecpath; }
        }
        /// <summary>
        /// 照片生成时间
        /// </summary>
        public DateTime RecTime
        {
            set { _rectime = value; }
            get { return _rectime; }
        }
        /// <summary>
        /// 照片地点
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
        /// 描述
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
