using MediatR;
using UniversityApp.Domain.Entities;

namespace UniversityApp.Domain.CQRS.Commands
{
    public class CreateUserCommand : IRequest<User>
    {
        public User User { get; set; }
        public string Password { get; set; }

        public CreateUserCommand(User user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
