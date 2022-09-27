using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/answers")]
    [ApiController]
    [Authorize]
    public class AnswersController : BaseController<int, UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>
    {
        public AnswersController(IMediator mediator) : base(mediator)
        {
        }
    }
}
