using MediatR;

namespace UniversityApp.Domain.CQRS.Commands
{
    public class CreateUserCommand : IRequest<UniversityApp.Domain.Entities.User>
    {
        public UniversityApp.Domain.Entities.User User { get; set; }
        public string Password { get; set; }
        public CreateUserCommand()
        {

        }
        public CreateUserCommand(UniversityApp.Domain.Entities.User user, string password)
        {
            User = user;
            Password = password;
        }
    }
}
