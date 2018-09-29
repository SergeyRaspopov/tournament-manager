using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models;

namespace trmgr.DAL
{
    public class ApplicationSeeder
    {
        private ApplicationDbContext _context;

        public ApplicationSeeder(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await EnsureRoleExistsAsync("Competitor");
            await EnsureRoleExistsAsync("Organizer");
        }
        
        private async Task EnsureRoleExistsAsync(string roleName)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
            if (role == null)
            {
                _context.Roles.Add(new IdentityRole(roleName));
                await _context.SaveChangesAsync();
            }
        }
    }
}
