﻿using RCCP.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogServer.Model
{

    public class AlarmLogAssemble
    {
        public int PageNumber { get; set; }
        public int rowsPerPage { get; set; }
        public int LogCount { get; set; }
        public int PageCount { get; set; }
        public List<AlarmLog> AlarmLogList { get; set; }
    }
}
