using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Application.APIRequests;
using UniversityApp.Domain.CQRS.Commands;

namespace UniversityApp.API.Controllers
{
    [Route("api/tokens")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TokensController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            string token = await _mediator.Send(new UserLoginCommand(request.Username, request.Password));
            return token != string.Empty ? Ok(token) : Unauthorized();
        }
    }
}
