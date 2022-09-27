using MediatR;
using UniversityApp.Domain.CQRS.Commands.BaseCommand;
using UniversityApp.Domain.Enums;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Application.Handlers.BaseCommandHandler
{
    public record BaseCommandHandler<Tkey, Tmodel, Tdb> : IRequestHandler<BaseCommand<Tkey, Tmodel, Tdb>, Tmodel> where Tmodel : class where Tdb : class
    {
        private readonly IBaseCRUDRepository<Tkey, Tmodel, Tdb> _repository;
        public BaseCommandHandler(IBaseCRUDRepository<Tkey, Tmodel, Tdb> repository)
        {
            _repository = repository;
        }

        public async Task<Tmodel> Handle(BaseCommand<Tkey, Tmodel, Tdb> request, CancellationToken cancellationToken)
        {
            switch (request.Command)
            {
                case CommandType.Post:
                    return await _repository.Create(request.ModelRequest);

                case CommandType.Put:
                    return await _repository.Update(request.Id, request.ModelRequest);

                case CommandType.Delete:
                    return await _repository.Delete(request.Id);
            }

            return default;
        }
    }
}
