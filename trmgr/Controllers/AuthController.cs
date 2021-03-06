﻿using AutoMapper;
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
                await _userManager.AddToRoleAsync(user, Roles.Competitor);
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
                var roles = await _userManager.GetRolesAsync(user);
                var isValidPassword = await _userManager.CheckPasswordAsync(user, vm.Password);
                if (isValidPassword)
                {
                    var expiresIn = 24 * 60 * 60;//1 day
                    var expDate = new DateTimeOffset(DateTime.Now.AddSeconds(expiresIn));
                    var exp = expDate.ToUnixTimeSeconds();
                    var token = CreateToken(user.Id, exp, roles);
                    var userVm = Mapper.Map<UserVm>(user);
                    userVm.Roles = roles;
                    var loginRes = new LoginResponseVm() { User = userVm, AccessToken = token, ExpiresIn = expiresIn };
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

        private string CreateToken(string userId, long exp, IEnumerable<string> roles)
        {
            var claims = GetClaims(userId, exp, roles);
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("jwt:SecretKey").Value));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);
            var payload = new JwtPayload(claims);
            var jwt = new JwtSecurityToken(header, payload);
            var jwtHandler = new JwtSecurityTokenHandler();
            return jwtHandler.WriteToken(jwt);
        }

        private IEnumerable<Claim> GetClaims(string userId, long exp, IEnumerable<string> roles)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userId),
                new Claim(JwtRegisteredClaimNames.Nbf, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString()),
                new Claim(JwtRegisteredClaimNames.Exp, exp.ToString()),
                new Claim(JwtRegisteredClaimNames.Iss, _configuration["jwt:iss"]),
                new Claim(JwtRegisteredClaimNames.Aud, _configuration["jwt:aud"])
            };
            claims.AddRange(roles.Select(r => new Claim("roles", r)));
            return claims;
        }
    }
}
