using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/professors")]
    [ApiController]
    [Authorize]
    public class ProfessorsController : BaseController<int, UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>
    {
        public ProfessorsController(IMediator mediator) : base(mediator)
        {
        }
    }
}
