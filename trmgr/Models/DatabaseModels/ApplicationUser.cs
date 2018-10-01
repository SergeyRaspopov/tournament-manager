using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using trmgr.Models.DatabaseModels.Organization;

namespace trmgr.Models.DatabaseModels
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(50)]
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        public string StreetAddress { get; set; }
        public string Appartment { get; set; }
        public City City { get; set; }
        [Column(TypeName = "decimal(4,1)")]
        public decimal Weight { get; set; }
        public int Age { get; set; }
        public Club Club { get; set; }


        //organizer stuff
        public IEnumerable<AgeCategoryGroup> AgeCategories { get; set; }
        public IEnumerable<ExperienceCategoryGroup> ExperienceCategories { get; set; }
        public IEnumerable<GenderCategoryGroup> GenderCategories { get; set; }
        public IEnumerable<WeightCategoryGroup> WeightCategories { get; set; }
        public IEnumerable<Tournament> Tournaments { get; set; }
    }
}
