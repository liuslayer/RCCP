using System;
namespace CADS.Model
{
	/// <summary>
	/// NationalSocialInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class NationalSocialInfoList
	{
		public NationalSocialInfoList()
		{}
		#region Model
		private int _id;
		private string _nationid;
		private string _nationname;
		private string _religion;
		private string _habit;
		private string _socialgroup;
		private string _description;
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
		/// 民族编号
		/// </summary>
		public string NationID
		{
			set{ _nationid=value;}
			get{return _nationid;}
		}
		/// <summary>
		/// 民族名称
		/// </summary>
		public string NationName
		{
			set{ _nationname=value;}
			get{return _nationname;}
		}
		/// <summary>
		/// 宗教
		/// </summary>
		public string Religion
		{
			set{ _religion=value;}
			get{return _religion;}
		}
		/// <summary>
		/// 习惯
		/// </summary>
		public string Habit
		{
			set{ _habit=value;}
			get{return _habit;}
		}
		/// <summary>
		/// 社会团体
		/// </summary>
		public string SocialGroup
		{
			set{ _socialgroup=value;}
			get{return _socialgroup;}
		}
		/// <summary>
		/// 描述
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

