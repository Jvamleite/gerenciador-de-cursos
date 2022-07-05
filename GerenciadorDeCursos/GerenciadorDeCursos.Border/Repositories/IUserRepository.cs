using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository : IRepository<User, Task>
    {
        Task<IEnumerable<User>> GetAllAsync();

        Task<User> FindByUsernameAsync(string username);

        Task<List<User>> FindByRoleAsync(Roles role);

        Task DeleteAsync(string username);
    }
}