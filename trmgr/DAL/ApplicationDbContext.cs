﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using trmgr.Models.DatabaseModels;
using trmgr.Models.DatabaseModels.Organization;

namespace trmgr.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }

        public DbSet<AgeCategoryGroup> AgeCategoryGroups { get; set; }
        public DbSet<AgeCategory> AgeCategories { get; set; }
        public DbSet<ExperienceCategoryGroup> ExperienceCategoryGroups { get; set; }
        public DbSet<ExperienceCategory> ExperienceCategories { get; set; }
        public DbSet<GenderCategoryGroup> GenderCategoryGroups { get; set; }
        public DbSet<GenderCategory> GenderCaegories { get; set; }
        public DbSet<WeightCategoryGroup> WeightCategoryGroups { get; set; }
        public DbSet<WeightCategory> WeightCategories { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Bracket> Brackets { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
