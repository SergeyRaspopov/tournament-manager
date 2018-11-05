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
    public class AddressService
    {
        private ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            return await _context.Countries.ToListAsync();
        }

        //public async Task<IEnumerable<

        public async Task<IEnumerable<Province>> GetStatesAsync(int countryId)
        {
            return await _context.Provinces.Where(p => p.Country.Id == countryId).ToListAsync();
        }

        public async Task<IEnumerable<City>> GetCitiesAsync(int stateId)
        {
            return await _context.Cities.Where(c => c.Province.Id == stateId).ToListAsync();
        }

        public async Task<IEnumerable<Club>> GetClubsAsync(int cityId)
        {
            return await _context.Clubs.Where(c => c.City.Id == cityId).ToListAsync();
        }
    }
}
