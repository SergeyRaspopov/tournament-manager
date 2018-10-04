using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class ExperienceCategoryGroup
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public IEnumerable<ExperienceCategory> ExperienceCategories { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
