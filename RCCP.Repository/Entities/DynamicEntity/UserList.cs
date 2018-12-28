using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities.DynamicEntity
{
    public class UserList
    {
        private Guid _userID;
        private string _username;
        private string _userPassword;
        private int? _userPermissionID;
        private int? _userRoleID;
        private string _description;
        private string _mark;
        [Key]
        public Guid UserID
        {
            get
            {
                return _userID;
            }

            set
            {
                _userID = value;
            }
        }

        public string Username
        {
            get
            {
                return _username;
            }

            set
            {
                _username = value;
            }
        }

        public string UserPassword
        {
            get
            {
                return _userPassword;
            }

            set
            {
                _userPassword = value;
            }
        }

        public int? UserPermissionID
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

        public int? UserRoleID
        {
            get
            {
                return _userRoleID;
            }

            set
            {
                _userRoleID = value;
            }
        }
    }
}
