using RCCP.Repository.Entities;
using RCCP.Repository.Entities.DynamicEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementService;

namespace RCCP.BusinessCollaborationService
{
    public class CheckUser
    {
        public bool check(string username,string password, out LoginUserInfomation loginUserInfomation)
        {
          return new CheckUserService().check(username,password, out loginUserInfomation);
           
        }
    }
}
