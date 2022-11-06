using MediatR;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Domain.Responses;

namespace UniversityApp.Application.Handlers.CommandHandlers
{
    public record UserLoginCommandHandler : IRequestHandler<UserLoginCommand, AuthResponse>
    {
        private readonly IUserRepository _repository;
        private readonly IAuthProvider _authProvider;
        private readonly ITokenRepository _tokenRepository;
        public UserLoginCommandHandler(IUserRepository repository, IAuthProvider authProvider, ITokenRepository tokenRepository)
        {
            _repository = repository;
            _authProvider = authProvider;
            _tokenRepository = tokenRepository;
        }

        public async Task<AuthResponse> Handle(UserLoginCommand request, CancellationToken cancellationToken)
        {
            var user = _repository.GetUserByUsernameAndPassword(request.Username, request.Password);

            return await Task.Run(() => _authProvider.CreateToken(user));
        }
    }
}
