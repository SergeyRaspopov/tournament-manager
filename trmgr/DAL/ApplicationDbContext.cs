using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models;

namespace trmgr.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Affiliation> Affiliations { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
