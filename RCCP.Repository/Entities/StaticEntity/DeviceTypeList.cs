using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// DeviceTypeList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class DeviceTypeList
    {
        public DeviceTypeList()
        { }
        #region Model
        private Guid _id;
        private int _typeid;
        private string _typename;
        private byte[] _image1;
        private byte[] _image2;
        private byte[] _image3;
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
        public int TypeID
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TypeName
        {
            set { _typename = value; }
            get { return _typename; }
        }
        /// <summary>
        /// 正常状态
        /// </summary>
        public byte[] Image1
        {
            set { _image1 = value; }
            get { return _image1; }
        }
        /// <summary>
        /// 离线状态
        /// </summary>
        public byte[] Image2
        {
            set { _image2 = value; }
            get { return _image2; }
        }
        /// <summary>
        /// 异常状态
        /// </summary>
        public byte[] Image3
        {
            set { _image3 = value; }
            get { return _image3; }
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
