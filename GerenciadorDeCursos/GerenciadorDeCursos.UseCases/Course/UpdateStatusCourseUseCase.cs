using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCase
{
    public class UpdateStatusCourseUseCase : IUpdateStatusCouseUseCase
    {
        private readonly ICourseRepository _courseRepository;

        public UpdateStatusCourseUseCase(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ResultBase> UpdateStatus()
        {
            try
            {
                await _courseRepository.UpdateStatusCourseAsync();

                return new ResultBase(true);
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}
