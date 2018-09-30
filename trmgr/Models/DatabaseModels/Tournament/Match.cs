using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Tournament
{
    public class Match
    {
        public int Id { get; set; }
        public int SeedNumber { get; set; }
        public ApplicationUser Competitor1 { get; set; }
        public ApplicationUser Competitor2 { get; set; }
        public Match WinnerMatch { get; set; }
        public byte Score1 { get; set; }
        public byte Score2 { get; set; }
        public byte Advantages1 { get; set; }
        public byte Advantages2 { get; set; }
        public byte Penalties1 { get; set; }
        public byte Penalties2 { get; set; }
        public bool IsCompetitor1DQed { get; set; }
        public bool IsCompetitor2DQed { get; set; }
    }
}
