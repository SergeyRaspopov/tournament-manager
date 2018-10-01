using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class GenderCategoryGroup
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public IEnumerable<GenderCategory> GenderCategories { get; set; }
    }
}
