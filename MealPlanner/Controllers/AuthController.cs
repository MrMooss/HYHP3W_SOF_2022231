﻿using MealPlanner.Models;
using MealPlanner.Models.AuthModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MealPlanner.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<SiteUser> _userManager;

        public AuthController(UserManager<SiteUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var user = await _userManager.FindByEmailAsync(model.UserEmail);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.NameId, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email)
                };
                foreach (var role in await _userManager.GetRolesAsync(user))
                {
                    claim.Add(new Claim(ClaimTypes.Role, role));
                }
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("nagyonhosszutitkoskodhelye"));
                var token = new JwtSecurityToken(
                 issuer: "http://www.security.org", audience: "http://www.security.org",
                 claims: claim, expires: DateTime.Now.AddYears(1),
                 signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );
                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPut]
        public async Task<IActionResult> InsertUser([FromBody] RegisterModel model)
        {
            var user = new SiteUser
            {
                UserName = model.UserName,
                Email = model.UserEmail,
                SecurityStamp = Guid.NewGuid().ToString(),
                ProfilePictureUrl = model.PhotoUrl,
                EmailConfirmed = true
            };
            var response = await _userManager.CreateAsync(user, model.Password);
            Debug.WriteLine(response.Succeeded);
            await _userManager.AddToRoleAsync(user, "NormalUser");
            return Ok();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet]
        public async Task<IActionResult> GetUserInfos()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            if (user != null)
            {
                return Ok(new
                {
                    Id = user.Id,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhotoUrl = user.ProfilePictureUrl,
                    Roles = await _userManager.GetRolesAsync(user)
                });
            }
            return Unauthorized();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpDelete]
        public async Task<IActionResult> DeleteMyself()
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Ok();
            }
            return BadRequest();
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] RegisterModel model)
        {
            var user = _userManager.Users.FirstOrDefault(t => t.Email == this.User.Identity.Name);
            user.Email = model.UserEmail;
            user.UserName = model.UserEmail;
            user.ProfilePictureUrl = model.PhotoUrl;
            if (!(model.Password == null || model.Password.Length == 0))
            {
                await _userManager.RemovePasswordAsync(user);
                await _userManager.AddPasswordAsync(user, model.Password);
            }
            await _userManager.UpdateAsync(user);
            return Ok();
        }
    }
}