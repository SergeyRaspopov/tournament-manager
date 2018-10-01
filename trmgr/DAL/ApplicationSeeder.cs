using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using trmgr.Models.DatabaseModels;
using trmgr.Models.DatabaseModels.Organization;

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

            await CreateOrganizer("sergey", "Tango123!", "test@test.ser");
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

        private async Task CreateOrganizer(string userName, string password, string emailAddress)
        {
            var organizer = await _userManager.FindByEmailAsync(emailAddress);
            if (organizer == null)
            {
                organizer = new ApplicationUser() { UserName = userName, Email = emailAddress };
                await _userManager.CreateAsync(organizer, password);
            }
            if (!await _userManager.IsInRoleAsync(organizer, Roles.Organizer))
            {
                await _userManager.AddToRoleAsync(organizer, Roles.Organizer);
            }
        }
    }
}
