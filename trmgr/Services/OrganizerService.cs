using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using trmgr.DAL;
using trmgr.Models.DatabaseModels.Organization;

namespace trmgr.Services
{
    public class OrganizerService
    {
        private ApplicationDbContext _context;

        public OrganizerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AgeCategory>> GetAgeCategoriesAsync()
        {
            return await _context.AgeCategories.ToListAsync();
        }

        public async Task<IEnumerable<GenderCategory>> GetGenderCategoriesAsync()
        {
            return await _context.GenderCaegories.ToListAsync();
        }

        public async Task<IEnumerable<WeightCategory>> GetWeightCategoriesAsync()
        {
            return await _context.WeightCategories.ToListAsync();
        }
    }
}
