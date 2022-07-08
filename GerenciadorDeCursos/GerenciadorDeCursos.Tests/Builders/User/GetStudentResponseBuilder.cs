using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class GetStudentResponseBuilder
    {
        private readonly List<GetStudentResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public GetStudentResponseBuilder()
        {
            _instance = new List<GetStudentResponse>
            {
                new GetStudentResponse
                {
                    RegistrationNumber = Guid.NewGuid(),
                    Username = _faker.Internet.UserName(),
                    Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()
                },
                new GetStudentResponse
                {
                    RegistrationNumber = Guid.NewGuid(),
                    Username = _faker.Internet.UserName(),
                    Courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1).AsEnumerable()
                },
            };
        }

        public List<GetStudentResponse> Build()
        {
            return _instance;
        }

        public GetStudentResponseBuilder WithListOfStudents(List<Student> students)
        {
            for(int i = 0; i < 2 ; i++)
            {
                this._instance.ElementAt(i).RegistrationNumber = students.ElementAt(i).RegistrationNumber;
                this._instance.ElementAt(i).Username = students.ElementAt(i).Username;
                this._instance.ElementAt(i).Courses = students.ElementAt(i).EnrolledCourses;
            }

            return this;
        }
    }
}
