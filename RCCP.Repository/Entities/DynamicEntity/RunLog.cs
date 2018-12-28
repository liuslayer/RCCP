using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    public class RunLog
    {
        [Key]
        public long ID { get; set; }
        /// <summary>
        /// 操作类型:1系统 2界面
        /// </summary>
        public int OperationType { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OperationTime { get; set; }
        /// <summary>
        /// 操作人员
        /// </summary>
        public string Operator { get; set; }
        /// <summary>
        /// 操作内容
        /// </summary>
        public string OperationContent { get; set; }
    }
}
