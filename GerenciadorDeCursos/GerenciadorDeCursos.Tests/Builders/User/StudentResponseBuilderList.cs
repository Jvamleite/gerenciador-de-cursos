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
    public class StudentResponseBuilderList
    {
        private readonly List<GetStudentResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public StudentResponseBuilderList()
        {
            _instance = ListFactory.Generate(() => new StudentResponseBuilder().Build(), min: 2, max: 2);
            
        }

        public List<GetStudentResponse> Build()
        {
            return _instance;
        }

        public StudentResponseBuilderList WithListOfStudents(List<Student> students)
        {
            for (int i = 0; i < 2; i++)
            {
                _instance[i].RegistrationNumber = students[i].RegistrationNumber;
                _instance[i].Username = students[i].Username;
               _instance[i].Courses = students[i].EnrolledCourses;
            }

            return this;
        }
    }
}