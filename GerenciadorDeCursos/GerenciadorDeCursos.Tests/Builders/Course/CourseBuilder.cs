using Bogus;
using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.CourseBuilder
{
    public class CourseBuilder
    {
        private readonly Course _instace;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CourseBuilder()
        {
            _instace = new Course {
                Id = Guid.NewGuid(),
                Título = _faker.Name.ToString(),
                DataInicial = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                DataFinal = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1)),
                Status = _faker.PickRandom<Status>()
            };
        }

        public Course Build()
        {
            return _instace;
        }
    }
}
