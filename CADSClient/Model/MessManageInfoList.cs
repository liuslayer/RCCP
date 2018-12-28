using System;
namespace CADS.Model
{
	/// <summary>
	/// MessManageInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class MessManageInfoList
	{
		public MessManageInfoList()
		{}
		#region Model
		private int _id;
		private string _messid;
		private string _receiver;
		private string _receiveorg;
		private string _messtype;
		private string _ishandle;
		private string _messtitle;
		private string _messcontent;
		private string _attachment;
		private string _mark;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 文电编号
		/// </summary>
		public string MessID
		{
			set{ _messid=value;}
			get{return _messid;}
		}
		/// <summary>
		/// 接收人
		/// </summary>
		public string Receiver
		{
			set{ _receiver=value;}
			get{return _receiver;}
		}
		/// <summary>
		/// 接收单位
		/// </summary>
		public string ReceiveOrg
		{
			set{ _receiveorg=value;}
			get{return _receiveorg;}
		}
		/// <summary>
		/// 文电类型：收/发
		/// </summary>
		public string MessType
		{
			set{ _messtype=value;}
			get{return _messtype;}
		}
		/// <summary>
		/// 是否已处理
		/// </summary>
		public string IsHandle
		{
			set{ _ishandle=value;}
			get{return _ishandle;}
		}
		/// <summary>
		/// 文电标题
		/// </summary>
		public string MessTitle
		{
			set{ _messtitle=value;}
			get{return _messtitle;}
		}
		/// <summary>
		/// 文电内容
		/// </summary>
		public string MessContent
		{
			set{ _messcontent=value;}
			get{return _messcontent;}
		}
		/// <summary>
		/// 附件
		/// </summary>
		public string Attachment
		{
			set{ _attachment=value;}
			get{return _attachment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		#endregion Model

	}
}

