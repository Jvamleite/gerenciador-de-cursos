using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IGetUserUseCase
    {
        Task<ResultBase> GetAllAsync();

        Task<ResultBase> GetByRoleAsync(Roles role);
    }
}