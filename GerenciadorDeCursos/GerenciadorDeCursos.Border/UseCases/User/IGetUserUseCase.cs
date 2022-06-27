using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IGetUserUseCase
    {
        Task<ResultBase> GetAll();

        Task<ResultBase> GetByRole(Roles role);
    }
}