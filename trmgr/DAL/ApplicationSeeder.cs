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
            
        }
        
        
    }
}
