using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class GenderCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public int GenderCategoryGroupId { get; set; }
        public IEnumerable<WeightCategory> WeightCategories { get; set; }
    }
}
