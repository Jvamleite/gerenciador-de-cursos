using Bogus;
using GerenciadorDeCursos.Border.DTOs.CourseDtos.Request;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.CourseBuilder
{
    public class CreateCourseRequestBuilder
    {
        private readonly CreateCourseRequest _instace;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CreateCourseRequestBuilder()
        {
            _instace = new CreateCourseRequest()
            {
                Title = _faker.Name.ToString(),
                InitialData = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                FinalData = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1))
            };
        }

        public CreateCourseRequest Build()
        {
            return _instace;
        }
    }
}