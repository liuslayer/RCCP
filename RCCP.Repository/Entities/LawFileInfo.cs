using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    [Serializable]
    public class LawFileInfo
    {
        public LawFileInfo()
        { }
        #region Model
        private long _id;
        private string _lawfilename;
        private string _lawfilepath;
        private string _lawfiletype;
        private DateTime _issuetime;
        private string _issueorganization;
        private string _issueversion;
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
        /// 文件名
        /// </summary>
        public string LawFileName
        {
            set { _lawfilename = value; }
            get { return _lawfilename; }
        }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string LawFilePath
        {
            set { _lawfilepath = value; }
            get { return _lawfilepath; }
        }
        /// <summary>
        /// 文件类型
        /// </summary>
        public string LawFileType
        {
            set { _lawfiletype = value; }
            get { return _lawfiletype; }
        }
        /// <summary>
        /// 颁发时间
        /// </summary>
        public DateTime IssueTime
        {
            set { _issuetime = value; }
            get { return _issuetime; }
        }
        /// <summary>
        /// 颁发机构
        /// </summary>
        public string IssueOrganization
        {
            set { _issueorganization = value; }
            get { return _issueorganization; }
        }
        /// <summary>
        /// 颁发版本号
        /// </summary>
        public string IssueVersion
        {
            set { _issueversion = value; }
            get { return _issueversion; }
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
