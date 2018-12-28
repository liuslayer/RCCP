using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    [Serializable]
    public class Pre_arrangedPlanning
    {
        public Pre_arrangedPlanning()
        { }
        #region Model
        private Guid _plandeviceid;
        private int _plantype;
        private string _plantypeid;
        private string _deviceid;
        private int _devicetype;
        private string _timetype;
        private string _startdate;
        private string _startweek;
        private string _starttime;
        private string _enddate;
        private string _endweek;
        private string _endtime;
        private string _planpath;
        private string _description;
        private string _mark;
        [Key]
        public Guid PlanDeviceID
        {
            get
            {
                return _plandeviceid;
            }

            set
            {
                _plandeviceid = value;
            }
        }

        public int PlanType
        {
            get
            {
                return _plantype;
            }

            set
            {
                _plantype = value;
            }
        }

        public string PlanTypeID
        {
            get
            {
                return _plantypeid;
            }

            set
            {
                _plantypeid = value;
            }
        }

        public string TimeType
        {
            get
            {
                return _timetype;
            }

            set
            {
                _timetype = value;
            }
        }

        public string StartDate
        {
            get
            {
                return _startdate;
            }

            set
            {
                _startdate = value;
            }
        }

        public string StartWeek
        {
            get
            {
                return _startweek;
            }

            set
            {
                _startweek = value;
            }
        }

        public string StartTime
        {
            get
            {
                return _starttime;
            }

            set
            {
                _starttime = value;
            }
        }

        public string EndDate
        {
            get
            {
                return _enddate;
            }

            set
            {
                _enddate = value;
            }
        }

        public string EndWeek
        {
            get
            {
                return _endweek;
            }

            set
            {
                _endweek = value;
            }
        }

        public string EndTime
        {
            get
            {
                return _endtime;
            }

            set
            {
                _endtime = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                _description = value;
            }
        }

        public string Mark
        {
            get
            {
                return _mark;
            }

            set
            {
                _mark = value;
            }
        }
        public string DeviceID
        {
            get
            {
                return _deviceid;
            }

            set
            {
                _deviceid = value;
            }
        }

        public int DeviceType
        {
            get
            {
                return _devicetype;
            }

            set
            {
                _devicetype = value;
            }
        }
        public string PlanPath
        {
            get
            {
                return _planpath;
            }

            set
            {
                _planpath = value;
            }
        }
        #endregion Model
    }
}
