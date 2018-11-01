using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class DivisionGroup
    {
        public int Id { get; set; }
        public IEnumerable<AgeCategory> AgeCategories { get; set; }
        public IEnumerable<ExperienceCategory> ExperienceCategories { get; set; }
        public IEnumerable<WeightCategory> WeightCategories { get; set; }
        public GenderCategory GenderCategory { get; set; }
    }
}
