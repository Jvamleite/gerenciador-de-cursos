using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface IUpdateStatusCouseUseCase
    {
        Task<ResultBase> UpdateStatus();
    }
}
