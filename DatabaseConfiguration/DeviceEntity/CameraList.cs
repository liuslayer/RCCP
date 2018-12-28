
using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseConfiguration.DeviceEntitiy
{
    /// <summary>
    /// CameraList:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
[Serializable]
	public class CameraList
	{
		public CameraList()
		{}
		#region Model
		private Guid _deviceid;
		private string _videoname;
		private Guid? _streammedia_deviceid;
		private int _videochannel;
        private string _stream_mainid;
        private string _stream_subid;
        private string _videoType;
        private double? _depthmax;
        private double? _focusmax;
        private double? _horizontalmax;
        private double? _verticalmax;
        private double? _visualdistancemax;
		private int _typeid;
		private Guid? _turntable_ptz_deviceid;
		private string _description;
		private string _mark;
		/// <summary>
		/// 
		/// </summary>
        [Key]
        public Guid DeviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoName
		{
			set{ _videoname=value;}
			get{return _videoname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? StreamMedia_DeviceID
		{
			set{ _streammedia_deviceid=value;}
			get{return _streammedia_deviceid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int VideoChannel
		{
			set{ _videochannel=value;}
			get{return _videochannel;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Stream_MainID
		{
			set{ _stream_mainid=value;}
			get{return _stream_mainid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Stream_SubID
		{
			set{ _stream_subid=value;}
			get{return _stream_subid;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double? DepthMAX
		{
			set{ _depthmax=value;}
			get{return _depthmax;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double? FocusMAX
		{
			set{ _focusmax=value;}
			get{return _focusmax;}
		}
		/// <summary>
		/// 
		/// </summary>
        public double? HorizontalMAX
		{
			set{ _horizontalmax=value;}
			get{return _horizontalmax;}
		}

        public double? VerticalMAX
        {
            set { _verticalmax = value; }
            get { return _verticalmax; }
        }

        /// <summary>
        /// 
        /// </summary>
        public double? VisualDistanceMAX
		{
			set{ _visualdistancemax=value;}
			get{return _visualdistancemax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? Turntable_PTZ_DeviceID
		{
			set{ _turntable_ptz_deviceid=value;}
			get{return _turntable_ptz_deviceid;}
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

        public string VideoType
        {
            get
            {
                return _videoType;
            }

            set
            {
                _videoType = value;
            }
        }
        #endregion Model

    }
}

