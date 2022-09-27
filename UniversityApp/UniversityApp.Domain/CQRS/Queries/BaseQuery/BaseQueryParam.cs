using MediatR;

namespace UniversityApp.Domain.CQRS.Queries.BaseQuery
{
    public class BaseQueryParam<Tkey, Tmodel> : IRequest<Tmodel>
    {
        public Tkey? Param { get; set; }

        public BaseQueryParam(Tkey? param = default)
        {
            Param = param;
        }
    }
}
