
using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConfiguration.DeviceEntitiy
{
    /// <summary>
    /// VibrationCableList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PersonnelInformationList
    {
        
        public PersonnelInformationList()
        { }
        #region Model
        private Guid _id;
        private Guid? _stationid;
        private string _name;
        private int _numberofpersonnel;
        private int _equipmentquantity;
        private string _description;
        private string _mark;
        [Key]
        public Guid ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public Guid? StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
        public int NumberOfPersonnel
        {
            set { _numberofpersonnel = value; }
            get { return _numberofpersonnel; }
        }
        public int EquipmentQuantity
        {
            set { _equipmentquantity = value; }
            get { return _equipmentquantity; }
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
        #endregion
    }
}
