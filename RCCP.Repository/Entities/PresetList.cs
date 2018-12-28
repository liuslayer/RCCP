using Dapper;
using System;
namespace RCCP.Repository.Entities
{
    /// <summary>
    /// PresetList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class PresetList
    {
        public PresetList()
        { }
        #region Model
        private Guid _presetid;
        private string _presetname;
        private Guid _cameradeviceid;
        private int _presettype;
        private int _presetno;
        private string _horizontal_data;
        private string _vertical_data;
        private string _ccdorir_depth;
        private string _ccdorir_focus;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid PresetID
        {
            set { _presetid = value; }
            get { return _presetid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PresetName
        {
            set { _presetname = value; }
            get { return _presetname; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid CameraDeviceID
        {
            set { _cameradeviceid = value; }
            get { return _cameradeviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PresetType
        {
            set { _presettype = value; }
            get { return _presettype; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PresetNo
        {
            set { _presetno = value; }
            get { return _presetno; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Horizontal_Data
        {
            set { _horizontal_data = value; }
            get { return _horizontal_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Vertical_Data
        {
            set { _vertical_data = value; }
            get { return _vertical_data; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCDorIR_Depth
        {
            set { _ccdorir_depth = value; }
            get { return _ccdorir_depth; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CCDorIR_Focus
        {
            set { _ccdorir_focus = value; }
            get { return _ccdorir_focus; }
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

