using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// SerialCOMList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class SerialCOMList
    {
        public SerialCOMList()
        { }
        #region Model
        private Guid _deviceid;
        private string _name;
        private string _comno;
        private int _baud;
        private int _checkbit;
        private int _databit;
        private int _stopbit;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid DeviceID
        {
            set { _deviceid = value; }
            get { return _deviceid; }
        }
        /// <summary>
        /// 串口名称
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        /// <summary>
        /// COM口号
        /// </summary>
        public string COMNo
        {
            set { _comno = value; }
            get { return _comno; }
        }
        /// <summary>
        /// 波特率
        /// </summary>
        public int Baud
        {
            set { _baud = value; }
            get { return _baud; }
        }
        /// <summary>
        /// 校验位:0 None、1 Odd、2 Even、3 Mark、4 Space
        /// </summary>
        public int CheckBit
        {
            set { _checkbit = value; }
            get { return _checkbit; }
        }
        /// <summary>
        /// 数据位
        /// </summary>
        public int DataBit
        {
            set { _databit = value; }
            get { return _databit; }
        }
        /// <summary>
        /// 停止位：0 None、1 One、2 Two、3 OnePointFive
        /// </summary>
        public int StopBit
        {
            set { _stopbit = value; }
            get { return _stopbit; }
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
