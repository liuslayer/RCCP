using System;
namespace CADS.Model
{
	/// <summary>
	/// PersonnelInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PersonnelInfoList
	{
		public PersonnelInfoList()
		{}
		#region Model
		private int _id;
		private string _personid;
		private string _personname;
		private string _personnation;
		private string _nativeplace;
		private string _dateofbirth;
		private string _degreeofeducation;
		private string _enlistmenttime;
		private string _retiredtime;
		private string _contactinfo;
		private string _post;
		private string _description;
		private string _unit;
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
		/// 人员编号
		/// </summary>
		public string PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 人员姓名
		/// </summary>
		public string PersonName
		{
			set{ _personname=value;}
			get{return _personname;}
		}
		/// <summary>
		/// 民族
		/// </summary>
		public string PersonNation
		{
			set{ _personnation=value;}
			get{return _personnation;}
		}
		/// <summary>
		/// 籍贯
		/// </summary>
		public string NativePlace
		{
			set{ _nativeplace=value;}
			get{return _nativeplace;}
		}
		/// <summary>
		/// 出生日期
		/// </summary>
		public string DateOfBirth
		{
			set{ _dateofbirth=value;}
			get{return _dateofbirth;}
		}
		/// <summary>
		/// 文化程度
		/// </summary>
		public string DegreeOfEducation
		{
			set{ _degreeofeducation=value;}
			get{return _degreeofeducation;}
		}
		/// <summary>
		/// 入伍时间
		/// </summary>
		public string EnlistmentTime
		{
			set{ _enlistmenttime=value;}
			get{return _enlistmenttime;}
		}
		/// <summary>
		/// 退伍时间
		/// </summary>
		public string RetiredTime
		{
			set{ _retiredtime=value;}
			get{return _retiredtime;}
		}
		/// <summary>
		/// 联系方式
		/// </summary>
		public string ContactInfo
		{
			set{ _contactinfo=value;}
			get{return _contactinfo;}
		}
		/// <summary>
		/// 职务
		/// </summary>
		public string Post
		{
			set{ _post=value;}
			get{return _post;}
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
		/// 所属单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 备注
		/// </summary>
		public string Mark
		{
			set{ _mark=value;}
			get{return _mark;}
		}
		#endregion Model

	}
}

