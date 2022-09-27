using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Infrastructure.OAuthProvider
{
    public class AuthProvider : IAuthProvider
    {
        public string CreateToken(User user)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey1234567891"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:59720",
                audience: "http://localhost:59720",
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
