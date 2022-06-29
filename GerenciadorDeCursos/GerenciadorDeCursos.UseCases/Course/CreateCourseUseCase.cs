﻿using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.Entities.Course;
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
                _logger.LogWarning("Curso não encontrado, criando curso");
                Course createdCourse = new Course(createCourseRequest.Título, createCourseRequest.DataInicial, createCourseRequest.DataFinal);
                Course addedCourse = await _courseRepository.AddCourseAsync(createdCourse);
                return new ResultBase(addedCourse.CreateCourseResponse());
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}