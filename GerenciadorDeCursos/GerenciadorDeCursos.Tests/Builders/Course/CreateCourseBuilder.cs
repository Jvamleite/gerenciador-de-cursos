using Bogus;
using GerenciadorDeCursos.Border.DTOs.CourseDtos.Request;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.CourseBuilder
{
    public class CreateCourseBuilder
    {
        private readonly Course _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CreateCourseBuilder()
        {
            _instance = new Course
            {
                Id = Guid.NewGuid(),
                Title = _faker.Name.ToString(),
                InitialData = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                FinalData = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1)),
                Status = Status.Previsto,
                Students = ListFactory.Generate(() => new StudentBuilder().Build(), min: 1).AsEnumerable(),
                Teacher = new TeacherBuilder().Build(),
                teacherId = Guid.Parse("e045a3fa-11ba-4955-b25d-5ef362211e2e")
            };
        }

        public Course Build()
        {
            return _instance;
        }

        public CreateCourseBuilder WithRequest(CreateCourseRequest request)
        {
            this._instance.Title = request.Title;
            this._instance.InitialData = request.InitialData;
            this._instance.FinalData = request.FinalData;
            return this;
        }
    }
}