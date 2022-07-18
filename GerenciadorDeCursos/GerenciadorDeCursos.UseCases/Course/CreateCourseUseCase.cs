using GerenciadorDeCursos.Border.DTOs.CourseDtos.Request;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCase
{
    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateCourseUseCase> _logger;

        public CreateCourseUseCase(ICourseRepository courseRepository, ILogger<CreateCourseUseCase> logger, IUserRepository userRepository)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _userRepository = userRepository;
        }

        public async Task<ResultBase> CreateCourseAsync(CreateCourseRequest createCourseRequest)
        {
            try
            {
                var teacher = await _userRepository.GetTeacherByNameAsync(createCourseRequest.TeachersName);

                _logger.LogWarning("Curso não encontrado, criando curso");
                var createdCourse = new Course(createCourseRequest.Title, createCourseRequest.InitialData, createCourseRequest.FinalData, teacher, createCourseRequest.NumeroDeVagas);

                await _courseRepository.AddCourseAsync(createdCourse);

                return new ResultBase(createdCourse.CreateCourseResponse());
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}