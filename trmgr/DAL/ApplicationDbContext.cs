using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models;
using trmgr.Models.DatabaseModels;
using trmgr.Models.DatabaseModels.Tournament;

namespace trmgr.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }

        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<GenderCategory> GenderCaegories { get; set; }
        public DbSet<WeightCategory> WeightCategories { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<Tournament> Tournament { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
