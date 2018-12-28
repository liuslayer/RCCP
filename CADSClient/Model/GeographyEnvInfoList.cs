using System;
namespace CADS.Model
{
	/// <summary>
	/// GeographyEnvInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class GeographyEnvInfoList
	{
		public GeographyEnvInfoList()
		{}
		#region Model
		private int _id;
		private string _zoneid;
		private string _zonescale;
		private string _geographyenv;
		private string _roadtransport;
		private string _watersystem;
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
		/// 战区编号
		/// </summary>
		public string ZoneID
		{
			set{ _zoneid=value;}
			get{return _zoneid;}
		}
		/// <summary>
		/// 作战范围
		/// </summary>
		public string ZoneScale
		{
			set{ _zonescale=value;}
			get{return _zonescale;}
		}
		/// <summary>
		/// 地形环境
		/// </summary>
		public string GeographyEnv
		{
			set{ _geographyenv=value;}
			get{return _geographyenv;}
		}
		/// <summary>
		/// 道路交通
		/// </summary>
		public string RoadTransport
		{
			set{ _roadtransport=value;}
			get{return _roadtransport;}
		}
		/// <summary>
		/// 水系
		/// </summary>
		public string WaterSystem
		{
			set{ _watersystem=value;}
			get{return _watersystem;}
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

