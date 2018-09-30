using System.Collections.Generic;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class Bracket
    {
        public int Id { get; set; }
        public bool NoGi { get; set; }
        public WeightCategory WeightClass { get; set; }
        public AgeCategory AgeCategory { get; set; }
        public GenderCategory Gender { get; set; }
        public ExperienceCategory Experience { get; set; }
        public IEnumerable<Match> Matches { get; set; }
    }
}
