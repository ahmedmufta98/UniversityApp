using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.Interfaces
{
    public interface IAuthProvider
    {
        string CreateToken(User user);
    }
}
