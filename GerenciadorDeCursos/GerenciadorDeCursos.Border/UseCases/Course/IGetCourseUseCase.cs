using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface IGetCourseUseCase
    {
        Task<ResultBase> GetAllAsync();

        Task<ResultBase> GetCourseByStatusAsync(Status status);
    }
}