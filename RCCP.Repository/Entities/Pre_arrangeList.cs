using Dapper;
using System;

namespace RCCP.Repository.Entities
{
    [Serializable]
    public class Pre_arrangeList
    {
        public Pre_arrangeList()
        { }
        #region Model
        private Guid _pre_arrangedid;
        private string _pre_arrangename;
        private int _pre_arrangetype;
        private string _creattime;
        private string _revisetime;
        private string _planpath;
        private Guid _alarmdeviceid;
        private string _alarmname;
        private string _description;
        private string _mark;

        [Key]
        public Guid Pre_arrangedID
        {
            get
            {
                return _pre_arrangedid;
            }

            set
            {
                _pre_arrangedid = value;
            }
        }

        public string Pre_arrangeName
        {
            get
            {
                return _pre_arrangename;
            }

            set
            {
                _pre_arrangename = value;
            }
        }

        public int Pre_arrangeType
        {
            get
            {
                return _pre_arrangetype;
            }

            set
            {
                _pre_arrangetype = value;
            }
        }

        public string CreatTime
        {
            get
            {
                return _creattime;
            }

            set
            {
                _creattime = value;
            }
        }

        public string ReviseTime
        {
            get
            {
                return _revisetime;
            }

            set
            {
                _revisetime = value;
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

        public Guid AlarmDeviceID
        {
            get
            {
                return _alarmdeviceid;
            }

            set
            {
                _alarmdeviceid = value;
            }
        }

        public string AlarmName
        {
            get
            {
                return _alarmname;
            }

            set
            {
                _alarmname = value;
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

        #endregion Model
    }
}
