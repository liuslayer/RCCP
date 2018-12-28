using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RCCP.Repository.Entities.StaticEntity
{
    public class DVRorNVR_SwitchList
    {

        private Guid _deviceID;
        private string _name;
        private int _typeID;
        private Guid _dVRorNVR_DeviceID;
        private int _dVRorNVR_Port;
        private bool _currentSwitchStatus;
        private string _description;
        private string _mark;
        [Key]
        public Guid DeviceID
        {
            get
            {
                return _deviceID;
            }

            set
            {
                _deviceID = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public int TypeID
        {
            get
            {
                return _typeID;
            }

            set
            {
                _typeID = value;
            }
        }

        public Guid DVRorNVR_DeviceID
        {
            get
            {
                return _dVRorNVR_DeviceID;
            }

            set
            {
                _dVRorNVR_DeviceID = value;
            }
        }

        public int DVRorNVR_Port
        {
            get
            {
                return _dVRorNVR_Port;
            }

            set
            {
                _dVRorNVR_Port = value;
            }
        }

        public bool CurrentSwitchStatus
        {
            get
            {
                return _currentSwitchStatus;
            }

            set
            {
                _currentSwitchStatus = value;
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
    }
}
