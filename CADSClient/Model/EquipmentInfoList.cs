using System;
namespace CADS.Model
{
	/// <summary>
	/// EquipmentInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class EquipmentInfoList
	{
		public EquipmentInfoList()
		{}
		#region Model
		private int _id;
		private string _equipmentid;
		private string _equipmenttype;
		private string _equipmentmodel;
		private string _equipmentname;
		private string _personincharge;
		private string _allotteddate;
		private string _unit;
		private string _returndate;
		private string _equipmentstate;
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
		/// 设备编号
		/// </summary>
		public string EquipmentID
		{
			set{ _equipmentid=value;}
			get{return _equipmentid;}
		}
		/// <summary>
		/// 设备类型
		/// </summary>
		public string EquipmentType
		{
			set{ _equipmenttype=value;}
			get{return _equipmenttype;}
		}
		/// <summary>
		/// 设备型号
		/// </summary>
		public string EquipmentModel
		{
			set{ _equipmentmodel=value;}
			get{return _equipmentmodel;}
		}
		/// <summary>
		/// 设备名称
		/// </summary>
		public string EquipmentName
		{
			set{ _equipmentname=value;}
			get{return _equipmentname;}
		}
		/// <summary>
		/// 责任人
		/// </summary>
		public string PersonIncharge
		{
			set{ _personincharge=value;}
			get{return _personincharge;}
		}
		/// <summary>
		/// 配发日期
		/// </summary>
		public string AllottedDate
		{
			set{ _allotteddate=value;}
			get{return _allotteddate;}
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
		/// 回收日期
		/// </summary>
		public string ReturnDate
		{
			set{ _returndate=value;}
			get{return _returndate;}
		}
		/// <summary>
		/// 设备状态
		/// </summary>
		public string EquipmentState
		{
			set{ _equipmentstate=value;}
			get{return _equipmentstate;}
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

