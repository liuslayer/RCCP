using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// ProtocolTypeList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class ProtocolTypeList
    {
        public ProtocolTypeList()
        { }
        #region Model
        private Guid _id;
        private int _protocoltypeid;
        private string _protocoltypename;
        private int _typeid;
        /// <summary>
        /// 
        /// </summary>
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int ProtocolTypeID
        {
            set { _protocoltypeid = value; }
            get { return _protocoltypeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ProtocolTypeName
        {
            set { _protocoltypename = value; }
            get { return _protocoltypename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        #endregion Model

    }
}
