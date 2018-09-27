using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string StreetAddress { get; set; }
        public string Appartment { get; set; }
        public City City { get; set; }
        public Belt Level { get; set; }
        public Division Division { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        public decimal Weight { get; set; }
        public int Age { get; set; }
    }
}
