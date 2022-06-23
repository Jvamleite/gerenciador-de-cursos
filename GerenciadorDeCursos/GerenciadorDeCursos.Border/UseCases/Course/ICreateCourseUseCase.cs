using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface ICreateCourseUseCase 
    {
        Task<ResultBase> CreateCourseAsync(CreateCourseRequest createCourseRequest);
    }
}
