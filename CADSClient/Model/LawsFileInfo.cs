using System;
namespace CADS.Model
{
	/// <summary>
	/// LawsFileInfo:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LawsFileInfo
	{
		public LawsFileInfo()
		{}
		#region Model
		private int _id;
		private string _filename;
		private string _filetype;
		private string _issuetime;
		private string _issueorganization;
		private string _issueversion;
		private string _filepath;
		private string _descrpition;
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
		/// 文件名
		/// </summary>
		public string FileName
		{
			set{ _filename=value;}
			get{return _filename;}
		}
		/// <summary>
		/// 文件类型
		/// </summary>
		public string FileType
		{
			set{ _filetype=value;}
			get{return _filetype;}
		}
		/// <summary>
		/// 发布时间
		/// </summary>
		public string IssueTime
		{
			set{ _issuetime=value;}
			get{return _issuetime;}
		}
		/// <summary>
		/// 发布单位
		/// </summary>
		public string IssueOrganization
		{
			set{ _issueorganization=value;}
			get{return _issueorganization;}
		}
		/// <summary>
		/// 发布版本号
		/// </summary>
		public string IssueVersion
		{
			set{ _issueversion=value;}
			get{return _issueversion;}
		}
		/// <summary>
		/// 文件路径
		/// </summary>
		public string FilePath
		{
			set{ _filepath=value;}
			get{return _filepath;}
		}
		/// <summary>
		/// 描述
		/// </summary>
		public string Descrpition
		{
			set{ _descrpition=value;}
			get{return _descrpition;}
		}
		/// <summary>
		/// 预留标记
		/// </summary>
		public string Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		#endregion Model

	}
}

