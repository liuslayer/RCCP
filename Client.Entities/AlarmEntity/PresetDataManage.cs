using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Client.Entities.AlarmEntity
{
    public class PresetDataManage
    {
        public string DeviceID;//设备标识，数据大小4
        public string AlarmDeviceID;//报警器标识，数据大小4
        public long AlarmFingerprintID;//报警ID，数据大小8
        public int AlarmLevel;//报警优先级
        public int UntreatedTimeDelay;//执行未处置流程延迟时间
        public LinkageData temp_LinkageData;//联动数据
    }
    public class LinkageData
    {
        public LinkageData()
        { }
        #region Model
        public Guid _linkageid;
        public Guid? _alarmdeviceid;
        private Guid? plandeviceid;
        public int _linakgestage;
        public string _videodeviceid;
        public string _ptzdeviceid;
        public string _preset;
        public string _switchdeviceid;
        public string _switchoperation;
        private string _switchoperationtimedelay;//开关量是否延迟
        private string _videorecording;
        private string _alarmsound;
        private string _alarmsoundtimedelay;
        public bool _reset;
        public string _description;
        public string _mark;
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

        public Guid? PlanDeviceID
        {
            get
            {
                return plandeviceid;
            }

            set
            {
                plandeviceid = value;
            }
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
        #endregion Model

    }
}
