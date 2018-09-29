using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models;
using trmgr.Models.DatabaseModels;

namespace trmgr.DAL
{
    public class ApplicationSeeder
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public ApplicationSeeder(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task SeedAsync()
        {
            await EnsureRoleExistsAsync(Roles.Competitor);
            await EnsureRoleExistsAsync(Roles.Organizer);
        }
        
        private async Task EnsureRoleExistsAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            if (role == null)
            {
                role = new IdentityRole(roleName) { NormalizedName = roleName.ToUpper() };
                _context.Roles.Add(role);
                await _context.SaveChangesAsync();
            }
        }
    }
}
