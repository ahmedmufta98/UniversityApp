using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;
using UniversityApp.Application.Models;
using UniversityApp.Domain.CQRS.Commands;

namespace UniversityApp.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    [Authorize]
    public class UsersController : BaseController<int, UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UsersController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("")]
        public override async Task<IActionResult> Create([FromBody] User request)
        {

            if (!ModelState.IsValid)
                return BadRequest("INVALID_REQUEST");

            return Ok(await _mediator.Send(new CreateUserCommand(_mapper.Map<Domain.Entities.User>(request), request.Password)));
        }
    }
}
