using Bogus;
using GerenciadorDeCursos.Border.DTOs.CourseDtos.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.CourseBuilder
{
    public class CourseResponseListBuilder
    {
        private readonly List<CourseResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CourseResponseListBuilder()
        {
            _instance = new List<CourseResponse>
            {
                new CourseResponse
                {
                    Id = Guid.NewGuid(),
                    Título = _faker.Name.ToString(),
                    DataInicial = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                    DataFinal = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1)),
                    Status = Status.Previsto,
                },
                new CourseResponse
                {
                    Id = Guid.NewGuid(),
                    Título = _faker.Name.ToString(),
                    DataInicial = _faker.Date.Between(DateTime.Today, DateTime.Today.AddYears(1)),
                    DataFinal = _faker.Date.Between(DateTime.Today.AddMonths(1), DateTime.Today.AddYears(1)),
                    Status = Status.Previsto,
                }
            };
        }

        public List<CourseResponse> Build()
        {
            return _instance;
        }

        public CourseResponseListBuilder WithListOfCourses(List<Course> courses)
        {
            for (int i = 0; i < 2; i++)
            {
                this._instance.ElementAt(i).Id = courses.ElementAt(i).Id;
                this._instance.ElementAt(i).Título = courses.ElementAt(i).Título;
                this._instance.ElementAt(i).DataFinal = courses.ElementAt(i).DataFinal;
                this._instance.ElementAt(i).DataInicial = courses.ElementAt(i).DataInicial;
            }

            return this;
        }
    }
}