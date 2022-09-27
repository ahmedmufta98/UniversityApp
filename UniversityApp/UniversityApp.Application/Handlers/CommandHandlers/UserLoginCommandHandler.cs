using MediatR;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Application.Handlers.CommandHandlers
{
    public record UserLoginCommandHandler : IRequestHandler<UserLoginCommand, string>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthProvider _authProvider;
        public UserLoginCommandHandler(IUserRepository repository, IAuthProvider authProvider)
        {
            _repository = repository;
            _authProvider = authProvider;
        }

        public async Task<string> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetUserByUsernameAndPassword(request.Username, request.Password);

            return user is not null ? await Task.Run(() => _authProvider.CreateToken(user)) : await Task.Run(() => string.Empty);
        }
    }
}
