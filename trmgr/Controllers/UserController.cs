using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models.ViewModels;

namespace trmgr.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        [Authorize]
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateProfile(UserVm userVm)
        {
            try
            {
                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
