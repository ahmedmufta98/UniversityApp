using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UniversityApp.Application.Handlers.BaseCommandHandler;
using UniversityApp.Application.Handlers.BaseQueryHandler;
using UniversityApp.Application.Handlers.CommandHandlers;
using UniversityApp.Application.Models;
using UniversityApp.Domain.CQRS.Commands;
using UniversityApp.Domain.CQRS.Commands.BaseCommand;
using UniversityApp.Domain.CQRS.Queries.BaseQuery;
using UniversityApp.Domain.Interfaces;
using UniversityApp.Infrastructure.OAuthProvider;
using UniversityApp.Infrastructure.Persistence;
using UniversityApp.Infrastructure.Services;

namespace UniversityApp.Infrastructure.DependencyInjection
{
    public static class DependencyInjection
    {
        public static void AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("dbConnection")));
        }

        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Answer>, BaseCRUDRepository<int, Answer, UniversityApp.Domain.Entities.Answer>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Exam>, BaseCRUDRepository<int, Exam, UniversityApp.Domain.Entities.Exam>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Professor>, BaseCRUDRepository<int, Professor, UniversityApp.Domain.Entities.Professor>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Question>, BaseCRUDRepository<int, Question, UniversityApp.Domain.Entities.Question>>();
            services.AddScoped<IBaseGetRepository<string, UniversityApp.Application.Models.Role>, BaseCRUDRepository<string, Role, UniversityApp.Domain.Entities.Role>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Student>, BaseCRUDRepository<int, Student, UniversityApp.Domain.Entities.Student>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.Subject>, BaseCRUDRepository<int, Subject, UniversityApp.Domain.Entities.Subject>>();
            services.AddScoped<IBaseGetRepository<int, UniversityApp.Application.Models.User>, BaseCRUDRepository<int, User, UniversityApp.Domain.Entities.User>>();

            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>, BaseCRUDRepository<int, UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Exam, UniversityApp.Domain.Entities.Exam>, BaseCRUDRepository<int, Exam, UniversityApp.Domain.Entities.Exam>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>, BaseCRUDRepository<int, UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>, BaseCRUDRepository<int, UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>>();
            services.AddScoped<IBaseCRUDRepository<string, UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>, BaseCRUDRepository<string, UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>, BaseCRUDRepository<int, UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>, BaseCRUDRepository<int, UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>>();
            services.AddScoped<IBaseCRUDRepository<int, UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>, BaseCRUDRepository<int, UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IExamStudentQuestionRepository, ExamStudentQuestionRepository>();

            services.AddSingleton<IAuthProvider, AuthProvider>();
        }

        public static void ConfigureOAuth(this IServiceCollection services)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = "http://localhost:59720",
                    ValidAudience = "http://localhost:59720",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secretKey1234567891"))
                };
            });
        }

        public static void EnableCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CORS", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRequest<UniversityApp.Application.Models.Answer>, BaseQueryParam<int, UniversityApp.Application.Models.Answer>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Answer>>, BaseQueryAll<UniversityApp.Application.Models.Answer>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>, UniversityApp.Application.Models.Answer>, BaseCommandHandler<int, UniversityApp.Application.Models.Answer, UniversityApp.Domain.Entities.Answer>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Answer>, UniversityApp.Application.Models.Answer>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Answer>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Answer>, List<UniversityApp.Application.Models.Answer>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Answer>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Exam>, BaseQueryParam<int, UniversityApp.Application.Models.Exam>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Exam>>, BaseQueryAll<UniversityApp.Application.Models.Exam>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Exam, UniversityApp.Domain.Entities.Exam>, UniversityApp.Application.Models.Exam>, BaseCommandHandler<int, UniversityApp.Application.Models.Exam, UniversityApp.Domain.Entities.Exam>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Exam>, UniversityApp.Application.Models.Exam>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Exam>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Exam>, List<UniversityApp.Application.Models.Exam>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Exam>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Professor>, BaseQueryParam<int, UniversityApp.Application.Models.Professor>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Professor>>, BaseQueryAll<UniversityApp.Application.Models.Professor>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>, UniversityApp.Application.Models.Professor>, BaseCommandHandler<int, UniversityApp.Application.Models.Professor, UniversityApp.Domain.Entities.Professor>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Professor>, UniversityApp.Application.Models.Professor>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Professor>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Professor>, List<UniversityApp.Application.Models.Professor>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Professor>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Question>, BaseQueryParam<int, UniversityApp.Application.Models.Question>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Question>>, BaseQueryAll<UniversityApp.Application.Models.Question>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>, UniversityApp.Application.Models.Question>, BaseCommandHandler<int, UniversityApp.Application.Models.Question, UniversityApp.Domain.Entities.Question>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Question>, UniversityApp.Application.Models.Question>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Question>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Question>, List<UniversityApp.Application.Models.Question>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Question>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Role>, BaseQueryParam<string, UniversityApp.Application.Models.Role>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Role>>, BaseQueryAll<UniversityApp.Application.Models.Role>>();
            services.AddScoped<IRequestHandler<BaseCommand<string, UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>, UniversityApp.Application.Models.Role>, BaseCommandHandler<string, UniversityApp.Application.Models.Role, UniversityApp.Domain.Entities.Role>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<string, UniversityApp.Application.Models.Role>, UniversityApp.Application.Models.Role>, BaseQueryParamHandler<string, UniversityApp.Application.Models.Role>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Role>, List<UniversityApp.Application.Models.Role>>, BaseQueryAllHandler<string, UniversityApp.Application.Models.Role>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Student>, BaseQueryParam<int, UniversityApp.Application.Models.Student>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Student>>, BaseQueryAll<UniversityApp.Application.Models.Student>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>, UniversityApp.Application.Models.Student>, BaseCommandHandler<int, UniversityApp.Application.Models.Student, UniversityApp.Domain.Entities.Student>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Student>, UniversityApp.Application.Models.Student>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Student>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Student>, List<UniversityApp.Application.Models.Student>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Student>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.Subject>, BaseQueryParam<int, UniversityApp.Application.Models.Subject>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.Subject>>, BaseQueryAll<UniversityApp.Application.Models.Subject>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>, UniversityApp.Application.Models.Subject>, BaseCommandHandler<int, UniversityApp.Application.Models.Subject, UniversityApp.Domain.Entities.Subject>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.Subject>, UniversityApp.Application.Models.Subject>, BaseQueryParamHandler<int, UniversityApp.Application.Models.Subject>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.Subject>, List<UniversityApp.Application.Models.Subject>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.Subject>>();

            services.AddScoped<IRequest<UniversityApp.Application.Models.User>, BaseQueryParam<int, UniversityApp.Application.Models.User>>();
            services.AddScoped<IRequest<List<UniversityApp.Application.Models.User>>, BaseQueryAll<UniversityApp.Application.Models.User>>();
            services.AddScoped<IRequestHandler<BaseCommand<int, UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>, UniversityApp.Application.Models.User>, BaseCommandHandler<int, UniversityApp.Application.Models.User, UniversityApp.Domain.Entities.User>>();
            services.AddScoped<IRequestHandler<BaseQueryParam<int, UniversityApp.Application.Models.User>, UniversityApp.Application.Models.User>, BaseQueryParamHandler<int, UniversityApp.Application.Models.User>>();
            services.AddScoped<IRequestHandler<BaseQueryAll<UniversityApp.Application.Models.User>, List<UniversityApp.Application.Models.User>>, BaseQueryAllHandler<int, UniversityApp.Application.Models.User>>();
            services.AddScoped<IRequestHandler<CreateUserCommand, UniversityApp.Domain.Entities.User>, CreateUserCommandHandler>();
            services.AddScoped<IRequestHandler<UserLoginCommand, string>, UserLoginCommandHandler>();
            services.AddTransient<IRequest<string>, UserLoginCommand>();
            services.AddTransient<IRequest<UniversityApp.Domain.Entities.User>, CreateUserCommand>();
        }
    }
}
