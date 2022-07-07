using GerenciadorDeCursos.Border.DTOs.CourseDtos.Request;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface ICreateCourseUseCase
    {
        Task<ResultBase> CreateCourseAsync(CreateCourseRequest createCourseRequest);
    }
}