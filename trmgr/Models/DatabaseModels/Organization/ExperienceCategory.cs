using System.ComponentModel.DataAnnotations;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class ExperienceCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int ExperienceCategoryGroupId { get; set; }
    }
}
