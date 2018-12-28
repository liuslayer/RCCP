using System;
namespace CADS.Model
{
	/// <summary>
	/// EconomicDevInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EconomicDevInfoList
	{
		public EconomicDevInfoList()
		{}
		#region Model
		private int _id;
		private string _agriculture;
		private string _industry;
		private string _service;
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
		/// 农业
		/// </summary>
		public string Agriculture
		{
			set{ _agriculture=value;}
			get{return _agriculture;}
		}
		/// <summary>
		/// 工业
		/// </summary>
		public string Industry
		{
			set{ _industry=value;}
			get{return _industry;}
		}
		/// <summary>
		/// 服务业
		/// </summary>
		public string Service
		{
			set{ _service=value;}
			get{return _service;}
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

