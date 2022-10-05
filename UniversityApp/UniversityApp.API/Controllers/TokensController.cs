using MediatR;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Application.APIRequests;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.Entities;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Infrastructure.Extensions;

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
            string token = await _mediator.Send(new UserLoginCommand(request.Username, request.Password));
            var refreshToken = await _tokenRepository.GenerateRefreshToken(User.GetUserId());
            SetRefreshToken(refreshToken);
            return token != string.Empty ? Ok(token) : Unauthorized();
        }

        [HttpPost]
        [Route("refresh")]
        public async Task<IActionResult> RefreshAccesToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            var currentToken = await _tokenRepository.GetRefreshTokenByUserId(User.GetUserId());
            if (currentToken is not null)
            {
                if (!currentToken.Token.Equals(refreshToken))
                    return Unauthorized("INVALID_REFRESH_TOKEN");
                else if (currentToken.TokenExpires < DateTime.Now)
                    return Unauthorized("TOKEN_EXPIRED");

                var user = await _userRepository.GetById(User.GetUserId());
                if(user is not null)
                {
                    string token = _authProvider.CreateToken(user);
                    var newRefreshToken = await _tokenRepository.GenerateRefreshToken(User.GetUserId());
                    SetRefreshToken(newRefreshToken);

                    return Ok(token);
                }
                else
                {
                    return NotFound("USER_NOT_FOUND");
                }
            }
            return Unauthorized("INVALID_TOKEN");
        }

        private void SetRefreshToken(RefreshToken refreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = refreshToken.TokenExpires
            };

            Response.Cookies.Append("refreshToken", refreshToken.Token, cookieOptions);
        }
    }
}
