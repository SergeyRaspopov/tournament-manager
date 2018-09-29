using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.DAL;
using trmgr.Models.DatabaseModels;

namespace trmgr.Services
{
    public class ApplicationService
    {
        private ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<IEnumerable<Province>> GetProvincesAsync(int countryId)
        {
            return await _context.Provinces.Where(p => p.Country.Id == countryId).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(int provinceId)
        {
            return await _context.Cities.Where(c => c.Province.Id == provinceId).ToListAsync();
        }
    }
}
