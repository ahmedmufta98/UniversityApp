using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Infrastructure.OAuthProvider
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IConfiguration _configuration;
        public AuthProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Token:SigningKey")));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Token:Issuer"),
                audience: _configuration.GetValue<string>("Token:Audience"),
                claims: new List<Claim>()
                {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim(ClaimTypes.Role, user.RoleId),
                    new Claim("UserId", user.Id.ToString())
                },
                expires: DateTime.Now.AddMinutes(5),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}
