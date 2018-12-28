using System;
using System.ComponentModel.DataAnnotations;
namespace DatabaseConfiguration.DeviceEntitiy
{
	/// <summary>
	/// StreamMediaList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StreamMediaList
	{
		public StreamMediaList()
		{}
		#region Model
		private Guid _deviceid;
		private Guid? _streamserverid;
		private string _videoip;
		private Guid? _serialcomid;
		private string _name;
		private string _username;
		private string _password;
		private int _channelnum;
		private int _networkport;
		private int _streammediaport;
		private int? _typeid;
		private string _description;
		private string _mark;
        private Guid? _stationid;
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
		/// 
		/// </summary>
		public Guid? StreamServerID
		{
			set{ _streamserverid=value;}
			get{return _streamserverid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string VideoIP
		{
			set{ _videoip=value;}
			get{return _videoip;}
		}
		/// <summary>
		/// 
		/// </summary>
		public Guid? SerialCOMID
		{
			set{ _serialcomid=value;}
			get{return _serialcomid;}
		}
        public Guid? StationID
        {
            set { _stationid = value; }
            get { return _stationid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string PassWord
		{
			set{ _password=value;}
			get{return _password;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int ChannelNum
		{
			set{ _channelnum=value;}
			get{return _channelnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Port
		{
			set{ _networkport=value;}
			get{return _networkport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int StreamMediaPort
		{
			set{ _streammediaport=value;}
			get{return _streammediaport;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? TypeID
		{
			set{ _typeid=value;}
			get{return _typeid;}
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

