using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Linq;
using NXS.Core.Auth;
using NXS.Core.Models;
using NXS.Core.Helpers;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;
using NXS.Helpers;

namespace NXS.Controllers
{

    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<NxsUser> _userManager;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IConfiguration _configuration;

        private readonly string _secetKey;

        public AuthController(UserManager<NxsUser> userManager,
                                IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;

            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };

            _secetKey = _configuration.GetValue<string>("AuthOptions:Key");
        }

        // POST api/auth/login
        [HttpPost("login")]
        public async Task<IActionResult> Post([FromBody]CredentialsResource model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByEmailAsync(model.UserName);

            if (user == null)
            {
                return BadRequest("User not found");
            }

            var isSucceeded = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!isSucceeded)
            {
				return BadRequest("The password is not correct");
            }

			var claims = new List<Claim>
			{
			    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Sid, user.Id),
			    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			var userRoles = await _userManager.GetRolesAsync(user);
			if (userRoles != null)
			{
				if (userRoles.Contains("Admin"))
				{
                    claims.Add(new Claim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.AdminRole));
				}
				else
				{
					claims.Add(new Claim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess));
				}

				var userRole = userRoles.FirstOrDefault();
				if (!string.IsNullOrEmpty(userRole))
				{
					claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole));
				}
			}

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtIssuerOptions:Key"]));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

			var token = new JwtSecurityToken(_configuration["JwtIssuerOptions:Issuer"],
			  _configuration["JwtIssuerOptions:Issuer"],
			  claims,
			  expires: DateTime.Now.AddDays(10),
			  signingCredentials: creds);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
             
            var response = new
            {
                userName = model.UserName,
				auth_token = jwtToken
            };
 
            return Ok(response);
        }


        private async Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password)
        {
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
            {
                await Task.FromResult<ClaimsIdentity>(null);
            }

            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                var userRoles = await _userManager.GetRolesAsync(user);
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName)
                    
                };
                if(userRoles != null) {
                    var userRole = userRoles.FirstOrDefault();
                    if(!string.IsNullOrEmpty(userRole)){
						claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, userRole));
                    }
                }

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
 
            return await Task.FromResult<ClaimsIdentity>(null);;
        }
    }
}