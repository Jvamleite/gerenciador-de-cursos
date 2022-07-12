using GerenciadorDeCursos.Border.DTOs.CourseDtos.Request;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCase
{
    public class CreateCourseUseCase : ICreateCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CreateCourseUseCase> _logger;

        public CreateCourseUseCase(ICourseRepository courseRepository, ILogger<CreateCourseUseCase> logger)
        {
            _courseRepository = courseRepository;
            _logger = logger;
        }

        public async Task<ResultBase> CreateCourseAsync(CreateCourseRequest createCourseRequest)
        {
            try
            {
                _logger.LogWarning("Verificando se Curso já existe");
                await VerifyIfCourseAlreadyExist(createCourseRequest);

                _logger.LogWarning("Curso não encontrado, criando curso");
                Course createdCourse = new Course(createCourseRequest.Title, createCourseRequest.InitialData, createCourseRequest.FinalData);

                await _courseRepository.AddAsync(createdCourse);

                return new ResultBase(createdCourse.CreateCourseResponse());
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        private async Task VerifyIfCourseAlreadyExist(CreateCourseRequest createCourseRequest)
        {
            IEnumerable<Course> courses = await _courseRepository.GetAllAsync();
            foreach (var course in courses)
            {
                if (createCourseRequest.Title == course.Title)
                    throw new Exception("Já existe um curso com esse title");
            }
        }
    }
}