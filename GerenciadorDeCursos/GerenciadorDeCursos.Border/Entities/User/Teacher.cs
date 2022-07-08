using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Teacher : User
    {
        public IEnumerable<Course> Courses { get; set; }

        public Teacher()
        { }

        public Teacher(string name, string lastName, string email, string cpf) : base(name, lastName, email, cpf)
        {
        }

        public GetTeacherResponse CreateGetTeacherResponse()
        {
            var teacherResponse = new GetTeacherResponse();
            teacherResponse.Username = this.Username;
            teacherResponse.Courses = this.Courses;
            return teacherResponse;
        }
    }
}