using Dapper;
using System;

namespace RCCP.Repository.Entities
{
    [Serializable]
    public class LensProtection
    {
        public LensProtection()
        { }
        #region Model
        private Guid _camera_deviceid;
        private string _summermont; 
        private int _summerdetermine;
        private string _summertimebegin;
        private string _summertimeend;
        private string _wintermonth;
        private int _winterdetermine;
        private string _wintertimebegin;
        private string _wintertimeend;
        private string _description;
        private string _mark;

        [Key]
        public Guid Camera_DeviceID
        {
            set { _camera_deviceid = value; }
            get { return _camera_deviceid; }
        }

        public string SummerMonth
        {
            set { _summermont = value; }
            get { return _summermont; }
        }

        public int SummerDetermine
        {
            set { _summerdetermine = value; }
            get { return _summerdetermine; }
        }

        public string SummerTimeBegin
        {
            set { _summertimebegin = value; }
            get { return _summertimebegin; }
        }

        public string SummerTimeEnd
        {
            set { _summertimeend = value; }
            get { return _summertimeend; }
        }

        public string WinterMonth
        {
            set { _wintermonth = value; }
            get { return _wintermonth; }
        }

        public int WinterDetermine
        {
            set { _winterdetermine = value; }
            get { return _winterdetermine; }
        }
        public string WinterTimeBegin
        {
            set { _wintertimebegin = value; }
            get { return _wintertimebegin; }
        }
        public string WinterTimeEnd
        {
            set { _wintertimeend = value; }
            get { return _wintertimeend; }
        }
        public string Description
        {
            set { _description  = value; }
            get { return _description; }
        }
        public string Mark
        {
            set { _mark = value; }
            get { return _mark; }
        }
        #endregion Model
    }
}
