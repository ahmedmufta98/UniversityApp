using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        User? GetUserByUsernameAndPassword(string username, string password);
        Task<User> Create(User entity, string password);

        Task<User?> GetById(int id);
    }
}
