using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
        Task<List<User>> GetAll();
        Task<List<User>> FindByRole(Roles role);
    }
}
