using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Entities
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
		private string _videotype;
		private decimal? _depthmax;
		private decimal? _focusmax;
		private decimal? _horizontalmax;
		private decimal? _visualdistancemax;
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
		public string VideoType
		{
			set{ _videotype=value;}
			get{return _videotype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? DepthMAX
		{
			set{ _depthmax=value;}
			get{return _depthmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? FocusMAX
		{
			set{ _focusmax=value;}
			get{return _focusmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? HorizontalMAX
		{
			set{ _horizontalmax=value;}
			get{return _horizontalmax;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? VisualDistanceMAX
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
		#endregion Model

	}
}

