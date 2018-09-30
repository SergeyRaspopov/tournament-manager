using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Tournament
{
    public class Bracket
    {
        public int Id { get; set; }
        public bool NoGi { get; set; }
        public WeightCategory WeightClass { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public GenderCategory Gender { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
