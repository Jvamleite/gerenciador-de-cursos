using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class TeacherResponseBuilder
    {
        private readonly GetTeacherResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public TeacherResponseBuilder()
        {
            _instance = new GetTeacherResponse
            {
                Username = _faker.Internet.UserName(),
                Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()

            };
        }

        public GetTeacherResponse Build()
        {
            return _instance;
        }

        public TeacherResponseBuilder WithTeacher(Teacher teacher)
        {

            _instance.Username = teacher.Username;
            _instance.Courses = teacher.Courses;
            return this;
        }
    }
}