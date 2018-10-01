using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class GenderCategory
    {
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
    }
}
