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
        private AddressService _applicationService;

        public AddressController(AddressService applicationService)
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

        //public async Task<IActionResult> States()
        //{
        //    try
        //    {
        //        var states 
        //    }
        //}

        [HttpGet("[action]/{countryId}")]
        public async Task<IActionResult> States([FromRoute] int countryId)
        {
            try
            {
                var states = await _applicationService.GetStatesAsync(countryId);
                return Ok(states);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{stateId}")]
        public async Task<IActionResult> Cities([FromRoute] int stateId)
        {
            try
            {
                var cities = await _applicationService.GetCitiesAsync(stateId);
                return Ok(cities);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
