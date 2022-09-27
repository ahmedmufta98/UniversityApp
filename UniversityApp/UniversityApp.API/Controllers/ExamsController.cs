using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/exams")]
    [ApiController]
    [Authorize]
    public class ExamsController : BaseController<int, UniversityApp.Application.Models.Exam, UniversityApp.Domain.Entities.Exam>
    {
        public ExamsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
