using GerenciadorDeCursos.Border.Entities;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task<User> Add(User user);
    }
}
