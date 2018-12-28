using System;
namespace CADS.Model
{
	/// <summary>
	/// PlanManageInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class PlanManageInfoList
	{
		public PlanManageInfoList()
		{}
		#region Model
		private int _id;
		private string _planid;
		private string _plantitle;
		private string _description;
		private string _path;
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
		/// 预案编号
		/// </summary>
		public string PlanID
		{
			set{ _planid=value;}
			get{return _planid;}
		}
		/// <summary>
		/// 预案标题
		/// </summary>
		public string PlanTitle
		{
			set{ _plantitle=value;}
			get{return _plantitle;}
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
		/// 模板路径
		/// </summary>
		public string Path
		{
			set{ _path=value;}
			get{return _path;}
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

