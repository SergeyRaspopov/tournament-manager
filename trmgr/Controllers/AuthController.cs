using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using trmgr.Models;
using trmgr.Models.DatabaseModels;
using trmgr.Models.ViewModels;

namespace trmgr.Controllers
{
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private IConfiguration _configuration;

        public AuthController(UserManager<ApplicationUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromBody]RegisterVm vm)
        {
            try
            {
                var user = new ApplicationUser() { UserName = vm.UserName, Email = vm.EmailAddress };
                var result = await _userManager.CreateAsync(user, vm.Password);
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody]LoginRequestVm vm)
        {
            try
            {
                var user = await _userManager.FindByNameAsync(vm.UserName);
                var isValidPassword = await _userManager.CheckPasswordAsync(user, vm.Password);
                if (isValidPassword)
                {
                    var expDate = new DateTimeOffset(DateTime.Now.AddDays(1));
                    var exp = expDate.ToUnixTimeSeconds();
                    var token = CreateToken(vm.UserName, exp);
                    var userVm = Mapper.Map<UserVm>(user);
                    var loginRes = new LoginResponseVm() { User = userVm, AccessToken = token, ExpireAt = exp };
                    HttpContext.Response.Cookies.Append("access_token", token, new CookieOptions() { HttpOnly = true, Expires = expDate });
                    return Ok(loginRes);
                }
                return BadRequest("User or password is invalid.");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string CreateToken(string userName, long exp)
        {
            var claims = GetClaims(userName, exp);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwt:SecretKey").Value));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var payload = new JwtPayload(claims);
            var jwt = new JwtSecurityToken(header, payload);
            var jwtHandler = new JwtSecurityTokenHandler();
            return jwtHandler.WriteToken(jwt);
        }

        private Claim[] GetClaims(string userName, long exp)
        {
            return new Claim[]
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, exp.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["jwt:iss"]),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["jwt:aud"])
            };
        }
    }
}
