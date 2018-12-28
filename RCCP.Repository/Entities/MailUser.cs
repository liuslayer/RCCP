using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    public class MailUser
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        public Guid MailUserID { get; set; }
        /// <summary>
        /// 用户IP
        /// </summary>
        public string UserIP { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 是否在线
        /// </summary>
        [Editable(false)]
        public bool IsOnline { get; set; }
    }
}
