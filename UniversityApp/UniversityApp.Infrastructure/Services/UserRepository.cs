using AutoMapper;
using System.Security.Cryptography;
using System.Text;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Infrastructure.Persistence;

namespace UniversityApp.Infrastructure.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public UserRepository(IMapper mapper, ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public User? GetUserByUsernameAndPassword(string username, string password)
        {
            User entity = _context.Users.FirstOrDefault(u => u.Username == username);

            if (entity is not null)
            {
                var hash = GenerateHash(entity.PasswordSalt, password);

                if (hash == entity.PasswordHash)
                {
                    return entity;
                }
            }

            return null;
        }

        private static string GenerateSalt()
        {
            RNGCryptoServiceProvider rng = new();
            byte[] buff = new byte[16];
            rng.GetBytes(buff);

            return Convert.ToBase64String(buff);
        }

        private static string GenerateHash(string passwordSalt, string password)
        {
            byte[] src = Convert.FromBase64String(passwordSalt);
            byte[] bytes = Encoding.Unicode.GetBytes(password);
            byte[] dst = new byte[src.Length + bytes.Length];

            System.Buffer.BlockCopy(src, 0, dst, 0, src.Length);
            System.Buffer.BlockCopy(bytes, 0, dst, src.Length, bytes.Length);

            HashAlgorithm algorithm = HashAlgorithm.Create("SHA1");
            byte[] inArray = algorithm.ComputeHash(dst);
            return Convert.ToBase64String(inArray);
        }

        public async Task<User> Create(UniversityApp.Domain.Entities.User entity, string password)
        {
            entity.PasswordSalt = GenerateSalt();
            entity.PasswordHash = GenerateHash(entity.PasswordSalt, password);

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
    }
}
