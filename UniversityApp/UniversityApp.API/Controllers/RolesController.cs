using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.API.Controllers.BaseController;

namespace UniversityApp.API.Controllers
{
    [Route("api/roles")]
    [ApiController]
    [Authorize]
    public class RolesController : BaseController<string, UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>
    {
        public RolesController(IMediator mediator) : base(mediator)
        {
        }
    }
}
