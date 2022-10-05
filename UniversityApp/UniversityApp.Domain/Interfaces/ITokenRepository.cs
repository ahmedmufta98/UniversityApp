using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.Interfaces
{
    public interface ITokenRepository
    {
        Task<RefreshToken> SaveRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GenerateRefreshToken(int userId);
        Task<RefreshToken> GetRefreshTokenByUserId(int userId);
    }
}
