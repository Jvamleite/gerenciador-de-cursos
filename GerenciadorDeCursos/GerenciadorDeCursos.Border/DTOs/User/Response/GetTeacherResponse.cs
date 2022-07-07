using GerenciadorDeCursos.Border.Entities.CourseEntities;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.DTOs.UserDtos.Response
{
    public class GetTeacherResponse
    {
        public string Username { get; set; }

        public IEnumerable<Course> Courses { get; set; }
    }
}
