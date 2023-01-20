﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Entities.Model
{
    public class ExecutiveModel
    {
        public int ExecutiveId { get; set; }
        public string ExecutiveFirstName { get; set; }
        public string ExecutiveLastName { get; set; }
        public string ExecutiveEmail { get; set; }
        public string ExecutiveContact { get; set; }
        public string ExecutiveBranch { get; set; }
    }
}
