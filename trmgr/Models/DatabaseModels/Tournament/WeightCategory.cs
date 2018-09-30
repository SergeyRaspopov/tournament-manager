using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Tournament
{
    public class WeightCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public bool Absolute { get; set; }
    }
}
