using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Domain.CQRS.Commands.BaseCommand;
using UniversityApp.Domain.CQRS.Queries.BaseQuery;
using UniversityApp.Domain.Enums;

namespace UniversityApp.API.Controllers.BaseController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<Tkey, Tmodel, Tdb> : ControllerBase where Tmodel : class where Tdb : class
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("")]
        public virtual async Task<IActionResult> Create([FromBody] Tmodel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(await _mediator.Send(new BaseCommand<Tkey, Tmodel, Tdb>(CommandType.Post, default, model)));
        }

        [HttpGet]
        [Route("")]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new BaseQueryAll<Tmodel>()));
        }

        [HttpGet]
        [Route("{id}")]
        public virtual async Task<IActionResult> GetById(Tkey id)
        {
            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _mediator.Send(new BaseQueryParam<Tkey, Tmodel>(id)));
        }

        [HttpPut]
        [Route("{id}")]
        public virtual async Task<IActionResult> Update(Tkey id, [FromBody] Tmodel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _mediator.Send(new BaseCommand<Tkey, Tmodel, Tdb>(CommandType.Put, id, model)));
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual async Task<IActionResult> Delete(Tkey id)
        {
            if (id is null)
                return BadRequest("INVALID PARAMETER");

            return Ok(await _mediator.Send(new BaseCommand<Tkey, Tmodel, Tdb>(CommandType.Delete, id)));
        }
    }
}
