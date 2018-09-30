using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Tournament
{
    public class WeightCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        public decimal MinWeight { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        public decimal MaxWeight { get; set; }
        public bool Absolute { get; set; }
    }
}
