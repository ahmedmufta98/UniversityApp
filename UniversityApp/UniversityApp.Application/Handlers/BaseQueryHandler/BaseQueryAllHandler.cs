using MediatR;
using UniversityApp.Domain.CQRS.Queries.BaseQuery;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Application.Handlers.BaseQueryHandler
{
    public record BaseQueryAllHandler<Tkey, Tmodel> : IRequestHandler<BaseQueryAll<Tmodel>, List<Tmodel>> where Tmodel : class
    {
        private readonly IBaseGetRepository<Tkey, Tmodel> _repository;
        public BaseQueryAllHandler(IBaseGetRepository<Tkey, Tmodel> repository)
        {
            _repository = repository;
        }
        public async Task<List<Tmodel>> Handle(BaseQueryAll<Tmodel> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAll();
        }
    }
}
