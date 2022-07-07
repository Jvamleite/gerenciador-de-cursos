using GerenciadorDeCursos.Border.DTOs.CourseDtos.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.CourseUseCases
{
    public class GetCourseUseCase : IGetCourseUseCase
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseUseCase(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ResultBase> GetAllAsync()
        {
            try
            {
                IEnumerable<Course> courses = await _courseRepository.GetAllAsync();

                return new ResultBase(CreateCourseResponseList(courses));
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        public async Task<ResultBase> GetCourseByStatusAsync(Status status)
        {
            try
            {
                IEnumerable<Course> courses = await _courseRepository.GetCourseByStatusAsync(status);

                return new ResultBase(CreateCourseResponseList(courses));
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        private List<CourseResponse> CreateCourseResponseList(IEnumerable<Course> courses)
        {
            List<CourseResponse> courseResponses = new List<CourseResponse>();
            foreach (Course course in courses)
            {
                var courseResponse = course.CreateCourseResponse();
                courseResponses.Add(courseResponse);
            }

            return courseResponses;
        }
    }
}