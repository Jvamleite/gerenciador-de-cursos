using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class GetTeacherResponseBuilder
    {
        private readonly List<GetTeacherResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public GetTeacherResponseBuilder()
        {
            _instance = new List<GetTeacherResponse>
            {
                new GetTeacherResponse
                {
                    Username = _faker.Internet.UserName(),
                    Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()
                },
                new GetTeacherResponse
                {
                    Username = _faker.Internet.UserName(),
                    Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()
                },
            };
        }

        public List<GetTeacherResponse> Build()
        {
            return _instance;
        }

        public GetTeacherResponseBuilder WithListOfTeacher(List<Teacher> teachers)
        {
            for (int i = 0; i < 2; i++)
            {
                this._instance.ElementAt(i).Username = teachers.ElementAt(i).Username;
                this._instance.ElementAt(i).Courses = teachers.ElementAt(i).Courses;
            }

            return this;
        }
    }
}