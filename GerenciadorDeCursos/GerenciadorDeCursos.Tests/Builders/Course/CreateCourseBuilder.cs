using Bogus;
using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;

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
                Título = _faker.Name.ToString(),
                DataInicial = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                DataFinal = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1)),
                Status = Status.Previsto
            };
        }

        public Course Build()
        {
            return _instance;
        }

        public CreateCourseBuilder WithRequest(CreateCourseRequest request)
        {
            this._instance.Título = request.Título;
            this._instance.DataInicial = request.DataInicial;
            this._instance.DataFinal = request.DataFinal;
            return this;
        }
    }
}