using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.Course
{
    public interface IDeleteCourseUseCase
    {
        Task<ResultBase> DeleteCourseAsync(Guid id);
    }
}
