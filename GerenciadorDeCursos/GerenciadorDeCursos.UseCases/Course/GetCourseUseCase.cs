using GerenciadorDeCursos.Border.DTOs.Course.Response;
using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
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
                Course course = await _courseRepository.GetByCourseStatusAsync(status);

                return new ResultBase(course.CreateCourseResponse());
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