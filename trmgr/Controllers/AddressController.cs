using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models.DatabaseModels;
using trmgr.Services;

namespace trmgr.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AddressController : Controller
    {
        private ApplicationService _applicationService;

        public AddressController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }
        
        [HttpGet("[action]")]
        public async Task<IActionResult> Countries()
        {
            try
            {
                var countries = await _applicationService.GetCountriesAsync();
                return Ok(countries);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{countryId}")]
        public async Task<IActionResult> Provinces([FromRoute] int countryId)
        {
            try
            {
                var provinces = await _applicationService.GetProvincesAsync(countryId);
                return Ok(provinces);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{provinceId}")]
        public async Task<IActionResult> Cities([FromRoute] int provinceId)
        {
            try
            {
                var cities = await _applicationService.GetCitiesAsync(provinceId);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
