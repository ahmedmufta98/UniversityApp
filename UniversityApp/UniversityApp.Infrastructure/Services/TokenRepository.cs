using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using UniversityApp.Application.Models;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Infrastructure.OAuthProvider;
using UniversityApp.Infrastructure.Persistence;

namespace UniversityApp.Infrastructure.Services
{
    public class TokenRepository : ITokenRepository
    {
        private readonly ApplicationDbContext _context;
        public TokenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> GenerateRefreshToken(int userId)
        {
            RefreshToken refreshToken = new()
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                TokenExpires = DateTime.Now.AddDays(1),
                TokenCreated = DateTime.Now,
                UserId = userId
            };

            await SaveRefreshToken(refreshToken);

            return refreshToken;
        }

        public async Task<RefreshToken> GetRefreshTokenByUserId(int userId)
        {
            var refreshToken = await _context.RefreshTokens.FirstOrDefaultAsync(x => x.UserId == userId);
            return refreshToken is not null ? await Task.Run(() => refreshToken) : await Task.FromResult<RefreshToken>(null);
        }

        public async Task<RefreshToken> SaveRefreshToken(RefreshToken refreshToken)
        {
            await _context.RefreshTokens.AddAsync(refreshToken);
            await _context.SaveChangesAsync();

            return refreshToken;
        }
    }
}
