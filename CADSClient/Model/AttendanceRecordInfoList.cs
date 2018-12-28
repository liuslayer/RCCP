using System;
namespace CADS.Model
{
	/// <summary>
	/// AttendanceRecordInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class AttendanceRecordInfoList
	{
		public AttendanceRecordInfoList()
		{}
		#region Model
		private int _id;
		private string _personname;
		private string _personid;
		private string _personleader;
		private string _timego;
		private string _timeend;
		private string _isabsent;
		private string _reasons;
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
		/// 考勤人姓名
		/// </summary>
		public string PersonName
		{
			set{ _personname=value;}
			get{return _personname;}
		}
		/// <summary>
		/// 考勤人编号
		/// </summary>
		public string PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 值班领导
		/// </summary>
		public string PersonLeader
		{
			set{ _personleader=value;}
			get{return _personleader;}
		}
		/// <summary>
		/// 打卡起始时间
		/// </summary>
		public string TimeGo
		{
			set{ _timego=value;}
			get{return _timego;}
		}
		/// <summary>
		/// 打卡结束时间
		/// </summary>
		public string TimeEnd
		{
			set{ _timeend=value;}
			get{return _timeend;}
		}
		/// <summary>
		/// 是否缺席
		/// </summary>
		public string IsAbsent
		{
			set{ _isabsent=value;}
			get{return _isabsent;}
		}
		/// <summary>
		/// 缺席原因
		/// </summary>
		public string Reasons
		{
			set{ _reasons=value;}
			get{return _reasons;}
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

