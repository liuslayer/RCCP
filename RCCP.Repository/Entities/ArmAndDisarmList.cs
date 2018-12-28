using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
    [Serializable]
    public class ArmAndDisarmList
    {
        public ArmAndDisarmList()
		{}
		#region Model
		private Guid _alarmdeviceid;
		private Guid? _deviceid;
		private int _timetype;
		private int _alarmtype;
		private int _alarmsensitive;
		private string _alarmname;
        private Guid? _presetid;
        private string _presetname;
        private string _pictureboxsize;
		private string _screenresolution;
		private int _screenframe;
		private int _alarmlevel;
		private string _alarmline;
		private Guid? _alarmrecpictureid;
		private bool _isarm;
		private bool _currentarmstatus;
		private bool _isvideorecording;
		private bool _isvideoflashing;
		private bool _isalarmsound;
		private string _description;
		private string _mark;
		/// <summary>
		/// 
		/// </summary>
        [Key]
		public Guid AlarmDeviceID
		{
			set{ _alarmdeviceid=value;}
			get{return _alarmdeviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? DeviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TimeType
		{
			set{ _timetype=value;}
			get{return _timetype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AlarmType
		{
			set{ _alarmtype=value;}
			get{return _alarmtype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AlarmSensitive
		{
			set{ _alarmsensitive=value;}
			get{return _alarmsensitive;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AlarmName
		{
			set{ _alarmname=value;}
			get{return _alarmname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PictureboxSize
		{
			set{ _pictureboxsize=value;}
			get{return _pictureboxsize;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ScreenResolution
		{
			set{ _screenresolution=value;}
			get{return _screenresolution;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ScreenFrame
		{
			set{ _screenframe=value;}
			get{return _screenframe;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int AlarmLevel
		{
			set{ _alarmlevel=value;}
			get{return _alarmlevel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AlarmLine
		{
			set{ _alarmline=value;}
			get{return _alarmline;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? AlarmRecPictureID
		{
			set{ _alarmrecpictureid=value;}
			get{return _alarmrecpictureid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsArm
		{
			set{ _isarm=value;}
			get{return _isarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool CurrentArmStatus
		{
			set{ _currentarmstatus=value;}
			get{return _currentarmstatus;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsVideoRecording
		{
			set{ _isvideorecording=value;}
			get{return _isvideorecording;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsVideoFlashing
		{
			set{ _isvideoflashing=value;}
			get{return _isvideoflashing;}
		}
		/// <summary>
		/// 
		/// </summary>
		public bool IsAlarmSound
		{
			set{ _isalarmsound=value;}
			get{return _isalarmsound;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Description
		{
			set{ _description=value;}
			get{return _description;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
        public Guid? PresetID
        {
            get
            {
                return _presetid;
            }

            set
            {
                _presetid = value;
            }
        }

        public string PresetName
        {
            get
            {
                return _presetname;
            }

            set
            {
                _presetname = value;
            }
        }
        #endregion Model
    }
}
