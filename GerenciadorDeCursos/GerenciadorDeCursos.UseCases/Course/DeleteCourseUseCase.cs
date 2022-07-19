using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCases
{
    public class DeleteCourseUseCase : IDeleteCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseUseCase(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ResultBase> DeleteCourseAsync(Guid id)
        {
            try
            {
                await _courseRepository.DeleteAsync(id);

                return new ResultBase();
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}