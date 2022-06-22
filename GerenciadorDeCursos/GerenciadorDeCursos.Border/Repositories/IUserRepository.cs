using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<List<User>> GetAll();
        Task<User> FindByUsername(string username);
        Task<List<User>> FindByRole(Roles role);
        Task<bool> DeleteByUsername(string username);
    }
}
