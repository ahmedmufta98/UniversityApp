using MediatR;

namespace UniversityApp.Domain.CQRS.Queries.BaseQuery
{
    public class BaseQueryAll<Tmodel> : IRequest<List<Tmodel>>
    {
    }
}
