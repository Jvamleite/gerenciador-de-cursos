using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases
{
    public interface IGetUserUseCase
    {
        Task<ResultBase> GetAll();
    }
}
