using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
        }
    }
}