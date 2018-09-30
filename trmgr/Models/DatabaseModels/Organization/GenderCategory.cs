using System.ComponentModel.DataAnnotations.Schema;

namespace trmgr.Models.DatabaseModels.Organization
{
    public class GenderCategory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
