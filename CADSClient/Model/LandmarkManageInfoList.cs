using System;
namespace CADS.Model
{
	/// <summary>
	/// LandmarkManageInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class LandmarkManageInfoList
	{
		public LandmarkManageInfoList()
		{}
		#region Model
		private int _id;
		private string _landmarkid;
		private string _organizationname;
		private string _admindivision;
		private string _landmarkname;
		private string _landmarktype;
		private string _unit;
		private string _qty;
		private string _landmarkdescription;
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
		/// 地标编号
		/// </summary>
		public string LandmarkID
		{
			set{ _landmarkid=value;}
			get{return _landmarkid;}
		}
		/// <summary>
		/// 单位名称
		/// </summary>
		public string OrganizationName
		{
			set{ _organizationname=value;}
			get{return _organizationname;}
		}
		/// <summary>
		/// 行政区划
		/// </summary>
		public string AdminDivision
		{
			set{ _admindivision=value;}
			get{return _admindivision;}
		}
		/// <summary>
		/// 重要地标名称
		/// </summary>
		public string LandmarkName
		{
			set{ _landmarkname=value;}
			get{return _landmarkname;}
		}
		/// <summary>
		/// 地标性质
		/// </summary>
		public string LandmarkType
		{
			set{ _landmarktype=value;}
			get{return _landmarktype;}
		}
		/// <summary>
		/// 单位
		/// </summary>
		public string Unit
		{
			set{ _unit=value;}
			get{return _unit;}
		}
		/// <summary>
		/// 数量
		/// </summary>
		public string QTY
		{
			set{ _qty=value;}
			get{return _qty;}
		}
		/// <summary>
		/// 相关说明
		/// </summary>
		public string LandmarkDescription
		{
			set{ _landmarkdescription=value;}
			get{return _landmarkdescription;}
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

