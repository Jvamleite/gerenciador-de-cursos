using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface IGetCourseUseCase
    {
        Task<ResultBase> GetAll();
    }
}