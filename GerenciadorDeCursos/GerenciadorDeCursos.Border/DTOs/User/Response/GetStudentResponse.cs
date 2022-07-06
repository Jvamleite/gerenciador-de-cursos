using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.DTOs.UserDTOs.Response
{
    public class GetStudentResponse
    {
        public Guid RegistrationNumber { get; set; }

        public string Username { get; set; }

        public IEnumerable<Course> Courses { get; set; }


    }
}