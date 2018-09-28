﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels
{
    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public Affiliation Affiliation { get; set; }
    }
}
