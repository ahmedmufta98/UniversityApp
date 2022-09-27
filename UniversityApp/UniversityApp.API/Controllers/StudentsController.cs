using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/students")]
    [ApiController]
    [Authorize]
    public class StudentsController : BaseController<int, UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>
    {
        public StudentsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
