using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCCP.Repository.Entities
{
    public class ErrLog
    {
        [Key]
        public long ID { get; set; }
        public int ErrType { get; set; }
        public DateTime ErrTime { get; set; }
        public string ErrClass { get; set; }
        public string ErrMethod { get; set; }
        public string ErrContent { get; set; }
    }
}
