using MediatR;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Application.Handlers.CommandHandlers
{
    public record CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UniversityApp.Domain.Entities.User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Domain.Entities.User?> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                return await _repository.Create(request.User, request.Password);
            }
            catch
            {
                return await Task.FromResult<Domain.Entities.User>(null);
            }
        }
    }
}
