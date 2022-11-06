using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Application.APIRequests;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Domain.Responses;

namespace UniversityApp.API.Controllers
{
    [Route("api/tokens")]
    [ApiController]
    public class TokensController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenRepository _tokenRepository;
        private readonly IAuthProvider _authProvider;
        private readonly IUserRepository _userRepository;

        public TokensController(IMediator mediator, ITokenRepository tokenRepository, IAuthProvider authProvider, IUserRepository userRepository)
        {
            _mediator = mediator;
            _tokenRepository = tokenRepository;
            _authProvider = authProvider;
            _userRepository = userRepository;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
        {
            AuthResponse authResponse = null;
            authResponse = await _mediator.Send(new UserLoginCommand(request.Username, request.Password));

            return authResponse is not null ? Ok(authResponse) : Unauthorized();
        }
    }
}
