using System;
using System.ComponentModel.DataAnnotations;

namespace Client.Entities
{
	/// <summary>
	/// StreamServerList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class StreamServerList
	{
		public StreamServerList()
		{}
		#region Model
		private Guid _deviceid;
		private string _streamserverip;
		private string _username;
		private string _password;
		private int _port;
		private int? _typeid;
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
		public string StreamServerIP
		{
			set{ _streamserverip=value;}
			get{return _streamserverip;}
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
		public int Port
		{
			set{ _port=value;}
			get{return _port;}
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

