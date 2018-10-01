using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class AgeCategoryGroup
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        public IEnumerable<AgeCategory> AgeCategories { get; set; }
    }
}
