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
            _instance = ListFactory.Generate(() => new CourseResponseBuilder().Build(), min: 2, max: 2);
            
        }

        public List<CourseResponse> Build()
        {
            return _instance;
        }

        public CourseResponseListBuilder WithListOfCourses(List<Course> courses)
        {
            for (int i = 0; i < 2; i++)
            {
                _instance[i].Id = courses[i].Id;
                _instance[i].Title = courses[i].Title;
                _instance[i].FinalData = courses[i].FinalData;
                _instance[i].InitialData = courses[i].InitialData;
                _instance[i].Teacher = courses[i].Teacher.Name;
                _instance[i].Status = courses[i].Status;
                _instance[i].PositionsFree = courses[i].NumeroDeVagas;
            }

            return this;
        }
    }
}