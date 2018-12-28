using System;
namespace CADS.Model
{
	/// <summary>
	/// SwitchManageInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class SwitchManageInfoList
	{
		public SwitchManageInfoList()
		{}
		#region Model
		private int _id;
		private string _preleader;
		private string _prename;
		private string _nextleader;
		private string _nextname;
		private string _swtichtime;
		private string _switchcontent;
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
		/// 交班领导
		/// </summary>
		public string PreLeader
		{
			set{ _preleader=value;}
			get{return _preleader;}
		}
		/// <summary>
		/// 交班人员
		/// </summary>
		public string PreName
		{
			set{ _prename=value;}
			get{return _prename;}
		}
		/// <summary>
		/// 接班领导
		/// </summary>
		public string NextLeader
		{
			set{ _nextleader=value;}
			get{return _nextleader;}
		}
		/// <summary>
		/// 接班人员
		/// </summary>
		public string NextName
		{
			set{ _nextname=value;}
			get{return _nextname;}
		}
		/// <summary>
		/// 交接时间
		/// </summary>
		public string SwtichTime
		{
			set{ _swtichtime=value;}
			get{return _swtichtime;}
		}
		/// <summary>
		/// 重要事项
		/// </summary>
		public string SwitchContent
		{
			set{ _switchcontent=value;}
			get{return _switchcontent;}
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

