using AutoMapper;

namespace UniversityApp.Application.Mapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper()
        {
            //MAP MODELS TO DB ENTITIES
            CreateMap<UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Exam, UniversityApp.Domain.Entities.Exam>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.ExamStudentQuestion, UniversityApp.Domain.Entities.ExamStudentQuestion>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>().ReverseMap();
            CreateMap<UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>().ReverseMap();
        }
    }
}
