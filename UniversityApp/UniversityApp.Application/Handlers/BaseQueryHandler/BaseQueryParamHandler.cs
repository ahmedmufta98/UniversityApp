using MediatR;
using UniversityApp.Domain.CQRS.Queries.BaseQuery;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.Application.Handlers.BaseQueryHandler
{
    public record BaseQueryParamHandler<Tkey, Tmodel> : IRequestHandler<BaseQueryParam<Tkey, Tmodel>, Tmodel> where Tmodel : class
    {
        private readonly IBaseGetRepository<Tkey, Tmodel> _repository;
        public BaseQueryParamHandler(IBaseGetRepository<Tkey, Tmodel> repository)
        {
            _repository = repository;
        }

        public async Task<Tmodel> Handle(BaseQueryParam<Tkey, Tmodel> request, CancellationToken cancellationToken)
        {
            return await _repository.GetById(request.Param);
        }
    }
}
