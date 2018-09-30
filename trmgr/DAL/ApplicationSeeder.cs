using Microsoft.AspNetCore.Identity;
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

            await EnsureGenderCategoriesExistAsync(1, "Male");
            await EnsureGenderCategoriesExistAsync(2, "Female");
            await EnsureGenderCategoriesExistAsync(3, "All");
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

        private async Task EnsureGenderCategoriesExistAsync(int categoryId, string categoryName)
        {
            var category = await _context.GenderCaegories.FirstOrDefaultAsync(gc => gc.Name == categoryName);
            if (category == null)
            {
                category = new GenderCategory() { Id = categoryId, Name = categoryName };
                _context.Add(category);
                await _context.SaveChangesAsync();
            }
        }
    }
}
