using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models
{
    public class Match
    {
        public ApplicationUser First { get; set; }
        public ApplicationUser Second { get; set; }
    }
}
