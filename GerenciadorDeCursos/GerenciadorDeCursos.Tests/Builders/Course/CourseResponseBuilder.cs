using Bogus;
using GerenciadorDeCursos.Border.DTOs.CourseDtos.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.CourseBuilder
{
    public class CourseResponseBuilder
    {
        private readonly CourseResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CourseResponseBuilder()
        {
            _instance = new CourseResponse()
            {
                Id = Guid.NewGuid(),
                Title = _faker.Company.CompanyName(),
                Teacher = _faker.Person.FirstName,
                InitialData = DateTime.Today.AddMonths(1),
                FinalData = DateTime.Today.AddMonths(2),
                Status = _faker.PickRandom<Status>(),
                PositionsFree = _faker.Random.Int()
            };
        }

        public CourseResponse Build()
        {
            return _instance;
        }

        public CourseResponseBuilder WithCourse(Course course)
        {
            _instance.Id = course.Id;
            _instance.Title = course.Title;
            _instance.InitialData = course.InitialData;
            _instance.FinalData = course.FinalData;
            _instance.Teacher = course.Teacher.Name;
            _instance.Status = course.Status;
            _instance.PositionsFree = course.NumeroDeVagas;
            return this;
        }
    }
}