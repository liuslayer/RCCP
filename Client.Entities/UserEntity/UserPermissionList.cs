using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities.UserEntity
{
    public class UserPermissionList
    {
        private int _userPermissionID;
        private string _userPermissionName;
        private bool _addUserCheck;
        private bool _delUserCheck;
        private bool _modifyUserCheck;
        private bool _systemConfigurationCheck;
        private bool _systemSettingsCheck;
        private bool _monitorPermissionsCheck;
        private Guid _monitorPermissionsID;
        private bool _mapPermissionsCheck;
        private Guid _mapPermissionsID;
        private bool _commonAuthority;
        private bool _tableControlAuthority;
        private bool _equipmentControlAuthority;
        private bool _informationManagementAuthority;
        private bool _alarmActionSettingAuthority;

        private bool _bEWSSAuthority;
        private bool _rTSMSAuthority;
        private bool _oMManagementAuthority;
        private bool _commandDispatchAuthority;
        private bool _communicationManagementAuthority;
        private bool _managementOfMessagesAuthority;

        private string _description;
        private string _mark;
        
        public int UserPermissionID
        {
            get
            {
                return _userPermissionID;
            }

            set
            {
                _userPermissionID = value;
            }
        }

        public string UserPermissionName
        {
            get
            {
                return _userPermissionName;
            }

            set
            {
                _userPermissionName = value;
            }
        }

        public bool AddUserCheck
        {
            get
            {
                return _addUserCheck;
            }

            set
            {
                _addUserCheck = value;
            }
        }

        public bool DelUserCheck
        {
            get
            {
                return _delUserCheck;
            }

            set
            {
                _delUserCheck = value;
            }
        }

        public bool ModifyUserCheck
        {
            get
            {
                return _modifyUserCheck;
            }

            set
            {
                _modifyUserCheck = value;
            }
        }

        public bool SystemConfigurationCheck
        {
            get
            {
                return _systemConfigurationCheck;
            }

            set
            {
                _systemConfigurationCheck = value;
            }
        }
        /// <summary>
        /// 系统设置
        /// </summary>
        public bool SystemSettingsCheck
        {
            get
            {
                return _systemSettingsCheck;
            }

            set
            {
                _systemSettingsCheck = value;
            }
        }

        public bool MonitorPermissionsCheck
        {
            get
            {
                return _monitorPermissionsCheck;
            }

            set
            {
                _monitorPermissionsCheck = value;
            }
        }

        public Guid MonitorPermissionsID
        {
            get
            {
                return _monitorPermissionsID;
            }

            set
            {
                _monitorPermissionsID = value;
            }
        }

        public bool MapPermissionsCheck
        {
            get
            {
                return _mapPermissionsCheck;
            }

            set
            {
                _mapPermissionsCheck = value;
            }
        }

        public Guid MapPermissionsID
        {
            get
            {
                return _mapPermissionsID;
            }

            set
            {
                _mapPermissionsID = value;
            }
        }

        public bool CommonAuthority
        {
            get
            {
                return _commonAuthority;
            }

            set
            {
                _commonAuthority = value;
            }
        }

        public bool TableControlAuthority
        {
            get
            {
                return _tableControlAuthority;
            }

            set
            {
                _tableControlAuthority = value;
            }
        }

        public bool EquipmentControlAuthority
        {
            get
            {
                return _equipmentControlAuthority;
            }

            set
            {
                _equipmentControlAuthority = value;
            }
        }
        /// <summary>
        /// 情报管理
        /// </summary>
        public bool InformationManagementAuthority
        {
            get
            {
                return _informationManagementAuthority;
            }

            set
            {
                _informationManagementAuthority = value;
            }
        }

        public bool AlarmActionSettingAuthority
        {
            get
            {
                return _alarmActionSettingAuthority;
            }

            set
            {
                _alarmActionSettingAuthority = value;
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
        /// <summary>
        /// 预警监控软件
        /// </summary>
        public bool BEWSSAuthority
        {
            get
            {
                return _bEWSSAuthority;
            }

            set
            {
                _bEWSSAuthority = value;
            }
        }
        /// <summary>
        /// 态势显控软件
        /// </summary>
        public bool RTSMSAuthority
        {
            get
            {
                return _rTSMSAuthority;
            }

            set
            {
                _rTSMSAuthority = value;
            }
        }
        /// <summary>
        /// 运维服务
        /// </summary>
        public bool OMManagementAuthority
        {
            get
            {
                return _oMManagementAuthority;
            }

            set
            {
                _oMManagementAuthority = value;
            }
        }
        /// <summary>
        /// 指挥调度
        /// </summary>
        public bool CommandDispatchAuthority
        {
            get
            {
                return _commandDispatchAuthority;
            }

            set
            {
                _commandDispatchAuthority = value;
            }
        }
        /// <summary>
        /// 通信管理
        /// </summary>
        public bool CommunicationManagementAuthority
        {
            get
            {
                return _communicationManagementAuthority;
            }

            set
            {
                _communicationManagementAuthority = value;
            }
        }
        /// <summary>
        /// 文电管理
        /// </summary>
        public bool ManagementOfMessagesAuthority
        {
            get
            {
                return _managementOfMessagesAuthority;
            }

            set
            {
                _managementOfMessagesAuthority = value;
            }
        }
    }
}
