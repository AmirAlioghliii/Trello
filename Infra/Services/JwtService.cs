using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Trello_.Data;
using Trello_.Models;

namespace Trello_.Services
{
    public class JwtService:IJwtService
    {
        private readonly IConfiguration _config;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public JwtService(IConfiguration configuration, UserManager<ApplicationUser> userManager, ApplicationDbContext context, RoleManager<ApplicationRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
            _config = configuration;
        }

        public async Task<string> GetTokenAsync(ApplicationUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(_config["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(await GetValidClaims(user)),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _config["JWT:Issuer"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<Claim>> GetValidClaims(ApplicationUser user)
        {
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
            };
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoleIds = await _context.UserRoles.Where(u=>u.UserId==user.Id).Select(u=>u.RoleId).ToListAsync();
            var roleNames = await _context.ApplicationRoles.Where(c => userRoleIds.Contains(c.Id)).Select(d => d.Name).ToListAsync();
            claims.AddRange(userClaims);
            foreach (var userRole in roleNames)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
                var role = await _roleManager.FindByNameAsync(userRole);
                if (role == null) continue;
                var roleClaims = await _roleManager.GetClaimsAsync(role);
                claims.AddRange(roleClaims);
            }

           
            return claims;
        }
    }

    
}
