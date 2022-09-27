using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/questions")]
    [ApiController]
    [Authorize]
    public class QuestionsController : BaseController<int, UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>
    {
        public QuestionsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
