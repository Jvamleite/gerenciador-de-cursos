using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);

        Task<List<User>> GetAllAsync();

        Task<User> FindByUsernameAsync(string username);

        Task<List<User>> FindByRoleAsync(Roles role);

        Task<bool> DeleteByUsernameAsync(string username);
    }
}