using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
    /// <summary>
    /// LinkageData:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class LinkageData
    {
        public LinkageData()
        { }
        #region Model
        private Guid _linkageid;
        private Guid? _alarmdeviceid;
        private Guid? _plandeviceid;
        private int _linakgestage;
        private string _videodeviceid;
        private string _ptzdeviceid;
        private string _preset;
        private string _switchdeviceid;
        private string _switchoperation;
        private string _switchoperationtimedelay;//开关量是否延迟
        private string _videorecording;
        private string _alarmsound;
        private string _alarmsoundtimedelay;
        private bool _reset;
        private string _description;
        private string _mark;
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid LinkageID
        {
            set { _linkageid = value; }
            get { return _linkageid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Guid? AlarmDeviceID
        {
            set { _alarmdeviceid = value; }
            get { return _alarmdeviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int LinakgeStage
        {
            set { _linakgestage = value; }
            get { return _linakgestage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string VideoDeviceID
        {
            set { _videodeviceid = value; }
            get { return _videodeviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PTZDeviceID
        {
            set { _ptzdeviceid = value; }
            get { return _ptzdeviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Preset
        {
            set { _preset = value; }
            get { return _preset; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SwitchDeviceID
        {
            set { _switchdeviceid = value; }
            get { return _switchdeviceid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SwitchOperation
        {
            set { _switchoperation = value; }
            get { return _switchoperation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public bool Reset
        {
            set { _reset = value; }
            get { return _reset; }
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

        public string Switchoperationtimedelay
        {
            get
            {
                return _switchoperationtimedelay;
            }

            set
            {
                _switchoperationtimedelay = value;
            }
        }

        public string Videorecording
        {
            get
            {
                return _videorecording;
            }

            set
            {
                _videorecording = value;
            }
        }

        public string Alarmsound
        {
            get
            {
                return _alarmsound;
            }

            set
            {
                _alarmsound = value;
            }
        }

        public string Alarmsoundtimedelay
        {
            get
            {
                return _alarmsoundtimedelay;
            }

            set
            {
                _alarmsoundtimedelay = value;
            }
        }

        public Guid? PlanDeviceID
        {
            get
            {
                return _plandeviceid;
            }

            set
            {
                _plandeviceid = value;
            }
        }
        #endregion Model

    }
}
