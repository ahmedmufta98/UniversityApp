using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/subjects")]
    [ApiController]
    [Authorize]
    public class SubjectsController : BaseController<int, UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>
    {
        public SubjectsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
