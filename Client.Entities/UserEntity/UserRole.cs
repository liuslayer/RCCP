using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Entities.UserEntity
{
    public class UserRole
    {
        private int _roleID;
        private string _roleName;
        private int? _role_type_id;
        private int? _parent_UR_id;
        private int? _permission_ID;

        
        public int RoleID
        {
            get
            {
                return _roleID;
            }

            set
            {
                _roleID = value;
            }
        }

        public string RoleName
        {
            get
            {
                return _roleName;
            }

            set
            {
                _roleName = value;
            }
        }

        public int? Parent_UR_id
        {
            get
            {
                return _parent_UR_id;
            }

            set
            {
                _parent_UR_id = value;
            }
        }

        public int? Permission_ID
        {
            get
            {
                return _permission_ID;
            }

            set
            {
                _permission_ID = value;
            }
        }

        public int? Role_type_id
        {
            get
            {
                return _role_type_id;
            }

            set
            {
                _role_type_id = value;
            }
        }
    }
}
