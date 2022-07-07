using GerenciadorDeCursos.Border.Entities.CourseEntities;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.DTOs.UserDtos.Response
{
    public class GetStudentResponse
    {
        public Guid RegistrationNumber { get; set; }

        public string Username { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}