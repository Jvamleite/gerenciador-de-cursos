using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IDeleteUserUseCase
    {
        Task<ResultBase> DeleteAsync(string username);
    }
}