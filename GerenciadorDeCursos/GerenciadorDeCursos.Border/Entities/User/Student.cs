using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Student : User
    {
        public Guid RegistrationNumber { get; set; }

        public IEnumerable<Course> EnrolledCourses { get; set; }

        public Student()
        { }

        public Student(string name, Roles role) : base(name, role)
        {
            RegistrationNumber = Guid.NewGuid();
        }

        public GetStudentResponse CreateGetStudentResponse()
        {
            var studentResponse = new GetStudentResponse();
            studentResponse.Username = this.Username;
            studentResponse.Courses = this.EnrolledCourses;
            studentResponse.RegistrationNumber = this.RegistrationNumber;
            return studentResponse;
        }
    }
}