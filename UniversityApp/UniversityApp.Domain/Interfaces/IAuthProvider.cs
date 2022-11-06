using System.CodeDom.Compiler;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Responses;

namespace UniversityApp.Domain.Interfaces
{
    public interface IAuthProvider
    {
        Task<AuthResponse> CreateToken(User user);
    }
}
