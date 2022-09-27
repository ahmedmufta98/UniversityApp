using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniversityApp.Domain.Interfaces;

namespace UniversityApp.API.Controllers
{
    [Route("api/exams/{examId:int}")]
    [ApiController]
    [Authorize]
    public class ExamsStudentsQuestionsController : ControllerBase
    {
        private readonly IExamStudentQuestionRepository _repository;
        public ExamsStudentsQuestionsController(IExamStudentQuestionRepository repository)
        {
            _repository = repository;
        }
    }
}
