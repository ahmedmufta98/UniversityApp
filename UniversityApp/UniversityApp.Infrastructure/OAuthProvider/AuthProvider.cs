using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Domain.Responses;

namespace UniversityApp.Infrastructure.OAuthProvider
{
    public class AuthProvider : IAuthProvider
    {
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository _tokenRepository;
        public AuthProvider(IConfiguration configuration, ITokenRepository tokenRepository)
        {
            _configuration = configuration;
            _tokenRepository = tokenRepository;
        }

        public async Task<AuthResponse> CreateToken(User user)
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


            RefreshToken refreshToken = await _tokenRepository.GenerateRefreshToken(user.Id);

            AuthResponse authResponse = new()
            {
                AccessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions),
                RefreshToken = refreshToken.Token,
                RefreshTokenCreated = refreshToken.TokenCreated,
                RefreshTokenExpires = refreshToken.TokenExpires,
                UserId = user.Id,
                Role = user.RoleId
            };

            return authResponse;
        }
    }
}
