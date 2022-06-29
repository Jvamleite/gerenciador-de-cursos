using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.UseCases.CourseUseCase;
using GerenciadorDeCursos.UseCases.CourseUseCases;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class UseCasesConfig
    {
        public static void ConfigureUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
            services.AddScoped<IGetUserUseCase, GetUserUseCase>();
            services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
            services.AddScoped<ICreateCourseUseCase, CreateCourseUseCase>();
            services.AddScoped<IGetCourseUseCase, GetCourseUseCase>();
            services.AddScoped<IUpdateStatusCouseUseCase, UpdateStatusCourseUseCase>();
            services.AddScoped<IDeleteCourseUseCase, DeleteCourseUseCase>();
        }
    }
}