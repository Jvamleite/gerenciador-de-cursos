using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases
{
    public interface IDeleteUserUseCase
    {
        Task<ResultBase> DeleteUserByUsername(string username);
    }
}
