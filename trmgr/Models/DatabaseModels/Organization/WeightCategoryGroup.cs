using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class WeightCategoryGroup
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public IEnumerable<WeightCategory> WeightCategories { get; set; }
        public string ApplicationUserId { get; set; }
    }
}
