﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models.DatabaseModels;

namespace trmgr.Models.ViewModels
{
    public class UserVm
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string StreetAddress { get; set; }
        public string Appartment { get; set; }
        public City City { get; set; }
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
