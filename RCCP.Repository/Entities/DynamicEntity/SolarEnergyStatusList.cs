using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities
{
	/// <summary>
	/// SolarEnergyStatusList:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class SolarEnergyStatusList
	{
		public SolarEnergyStatusList()
		{}
		#region Model
		private long _id;
		private Guid _deviceid;
        private string _name;
		private string _voltage;
		private string _solarcurrent;
		private string _resistance;
		private string _temp;
		private string _humi;
		private int _alarm;
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
		/// 
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
		/// 电压，单位伏
		/// </summary>
		public string Voltage
		{
			set{ _voltage=value;}
			get{return _voltage;}
		}
		/// <summary>
		/// 电流，单位安
		/// </summary>
		public string SolarCurrent
		{
			set{ _solarcurrent=value;}
			get{return _solarcurrent;}
		}
		/// <summary>
		/// 电池内阻，单位欧姆
		/// </summary>
		public string Resistance
		{
			set{ _resistance=value;}
			get{return _resistance;}
		}
		/// <summary>
		/// 温度
		/// </summary>
		public string Temp
		{
			set{ _temp=value;}
			get{return _temp;}
		}
		/// <summary>
		/// 湿度（绝对湿度），单位D
		/// </summary>
		public string Humi
		{
			set{ _humi=value;}
			get{return _humi;}
		}
		/// <summary>
		/// 异常报警类型（0无、1过压、2欠压）
		/// </summary>
		public int Alarm
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

