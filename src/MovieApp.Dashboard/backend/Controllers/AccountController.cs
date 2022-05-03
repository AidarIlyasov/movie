using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MovieApp.Infrastructure.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace MovieApp.backend.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("/dashboard/account/")]
    public class AccountController: ControllerBase
    {
        private readonly ApplicationContext _context;
        
        public AccountController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost("token")]
        public IActionResult Token([FromForm] string email, [FromForm] string password)
        {
            var identity = GetIdentity(email, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = "Invalid username or password." });
            }
 
            var now = DateTime.UtcNow;
            // creating a new JWT-token
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.Lifetime)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
 
            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };
 
            return Ok(response);
        }
 
        private ClaimsIdentity GetIdentity(string email, string password)
        {
            var user = _context.Users
                .Include(u => u.Role)
                .FirstOrDefault(x => x.Email == email && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name)
                };
                var claimsIdentity =
                    new ClaimsIdentity(claims, "Token", 
                        ClaimsIdentity.DefaultNameClaimType,
                        ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }
            
            return null;
        }
    }
}