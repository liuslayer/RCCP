using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailClient
{
    public class MailTableAssemble
    {
        public int PageNumber { get; set; }
        public int rowsPerPage { get; set; }
        public int MailCount { get; set; }
        public int PageCount { get; set; }
        public List<MailTable> MailTableList { get; set; }
        public string MailType { get; set; }
    }
}
