using System;
namespace CADS.Model
{
	/// <summary>
	/// DutyRecordInfoList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class DutyRecordInfoList
	{
		public DutyRecordInfoList()
		{}
		#region Model
		private int _id;
		private string _dutyperson;
		private string _personid;
		private string _dutydate;
		private string _dutyevent;
		private string _dutyeventtime;
		private string _dutyroute;
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
		/// 执勤人
		/// </summary>
		public string DutyPerson
		{
			set{ _dutyperson=value;}
			get{return _dutyperson;}
		}
		/// <summary>
		/// 执勤人编号
		/// </summary>
		public string PersonID
		{
			set{ _personid=value;}
			get{return _personid;}
		}
		/// <summary>
		/// 执勤日期
		/// </summary>
		public string DutyDate
		{
			set{ _dutydate=value;}
			get{return _dutydate;}
		}
		/// <summary>
		/// 执勤事件记录
		/// </summary>
		public string DutyEvent
		{
			set{ _dutyevent=value;}
			get{return _dutyevent;}
		}
		/// <summary>
		/// 事件发生时间
		/// </summary>
		public string DutyEventTime
		{
			set{ _dutyeventtime=value;}
			get{return _dutyeventtime;}
		}
		/// <summary>
		/// 执勤路线
		/// </summary>
		public string DutyRoute
		{
			set{ _dutyroute=value;}
			get{return _dutyroute;}
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

