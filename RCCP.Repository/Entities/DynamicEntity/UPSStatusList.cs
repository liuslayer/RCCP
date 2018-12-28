using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
	/// <summary>
	/// UPSStatusList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class UPSStatusList
	{
		public UPSStatusList()
		{}
		#region Model
		private long _id;
		private Guid _deviceid;
        private string _name;
		private string _involtage;
		private string _lvoltage;
		private string _outvoltage;
		private string _outputload;
		private string _freq;
		private string _cellvoltage;
		private string _temperature;
		private string _alarm;
		private DateTime _time;
		/// <summary>
		/// 
		/// </summary>
        [Key]
		public long ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 设备ID
		/// </summary>
		public Guid DeviceID
		{
			set{ _deviceid=value;}
			get{return _deviceid;}
		}
        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            set { _name = value; }
            get { return _name; }
        }
		/// <summary>
		/// 输入电压，单位伏
		/// </summary>
		public string InVoltage
		{
			set{ _involtage=value;}
			get{return _involtage;}
		}
		/// <summary>
		/// 上一次转电池放电时电压，单位伏
		/// </summary>
		public string LVoltage
		{
			set{ _lvoltage=value;}
			get{return _lvoltage;}
		}
		/// <summary>
		/// 输出电压 ,单位伏
		/// </summary>
		public string OutVoltage
		{
			set{ _outvoltage=value;}
			get{return _outvoltage;}
		}
		/// <summary>
		/// 输出负载百分比
		/// </summary>
		public string OutputLoad
		{
			set{ _outputload=value;}
			get{return _outputload;}
		}
		/// <summary>
		/// 输入频率 单位赫兹
		/// </summary>
		public string Freq
		{
			set{ _freq=value;}
			get{return _freq;}
		}
		/// <summary>
		/// 电池单元电压
		/// </summary>
		public string CellVoltage
		{
			set{ _cellvoltage=value;}
			get{return _cellvoltage;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public string Temperature
		{
			set{ _temperature=value;}
			get{return _temperature;}
		}
		/// <summary>
		/// 异常报警类型（0无， 1关机 ，2测试进行中，3UPS后备式，4UPS故障，5旁路模式，6电池电压低，7市电异常）
		/// </summary>
		public string Alarm
		{
			set{ _alarm=value;}
			get{return _alarm;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		#endregion Model

	}
}

