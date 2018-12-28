using RCCP.Repository.Concrete;
using RCCP.Repository.Entities;
using RCCP.Repository.Entities.DynamicEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UserManagementService
{
    public class CheckUserService
    {
        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <returns></returns>
        public bool check(string username,string password, out LoginUserInfomation loginUserInfomation)
        {
            bool result=false;
            loginUserInfomation = new LoginUserInfomation();
            UserListRepository userListRepository = new UserListRepository();
            List<UserList> user= userListRepository.GetListWithCondition(new { Username = username, UserPassword = password });
            if (user.Count != 0)
            {
                result = true;
                loginUserInfomation.user = user[0];
                UserPermissionListRepository userPermissionListRepository = new UserPermissionListRepository();
                if(user[0].UserPermissionID.HasValue)
                {
                    UserPermissionList temp_userPermission = userPermissionListRepository.GetEntityById(user[0].UserPermissionID.Value);
                    if (temp_userPermission != null)
                        loginUserInfomation.userPermission = temp_userPermission;
                }
                UserRoleRepository userRoleRepository = new UserRoleRepository();
                if(user[0].UserRoleID.HasValue)
                {
                    UserRole temp_userRole = userRoleRepository.GetEntityById(user[0].UserRoleID.Value);
                    if (temp_userRole != null)
                        loginUserInfomation.userRole = temp_userRole;
                }
            }
            return result;
        }
    }
}
