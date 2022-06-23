using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCase
{
    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        private readonly ICourseRepository courseRepository;
        public CreateCourseUseCase(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        public async Task<ResultBase> CreateCourseAsync(CreateCourseRequest createCourseRequest)
        {
            try
            {
                Course createdCourse = new Course(createCourseRequest.Título,createCourseRequest.DataInicial,createCourseRequest.DataFinal);
                Course addedCourse = await courseRepository.AddCourseAsync(createdCourse);
                return new ResultBase(addedCourse.CreateCourseResponse());
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}
