using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class StudentResponseBuilder
    {
        private readonly GetStudentResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public StudentResponseBuilder()
        {
            _instance = new GetStudentResponse
            {
                RegistrationNumber = Guid.NewGuid(),
                Username = _faker.Internet.UserName(),
                Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()
            };
        }

        public GetStudentResponse Build()
        {
            return _instance;
        }

        public StudentResponseBuilder WithStudent(Student students)
        {
            _instance.RegistrationNumber = students.RegistrationNumber;
            _instance.Username = students.Username;
            _instance.Courses = students.EnrolledCourses;
            return this;
        }
    }
}