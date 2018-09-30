using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class AgeCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Range(0, 150)]
        public byte MaxAge { get; set; }
        [Range(0, 150)]
        public byte MinAge { get; set; }
    }
}
