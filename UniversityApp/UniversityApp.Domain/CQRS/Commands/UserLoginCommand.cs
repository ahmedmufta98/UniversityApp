using MediatR;
using UniversityApp.Domain.Responses;

namespace UniversityApp.Domain.CQRS.Commands
{
    public class UserLoginCommand : IRequest<AuthResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public UserLoginCommand()
        {

        }
        public UserLoginCommand(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
