using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task AddTeacherAsync(Teacher teacher);

        Task AddStudentAsync(Student student);

        Task<IEnumerable<User>> GetAllAsync();

        Task<User> FindByUsernameAsync(string username);

        Task<List<User>> FindByRoleAsync(Roles role);

        Task DeleteAsync(string username);
    }
}