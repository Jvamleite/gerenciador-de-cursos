using GerenciadorDeCursos.Border.Entities.CourseEntities;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Teacher : User
    {
        public IEnumerable<Course> Courses { get; set; }

        public Teacher() 
        { }
    }
}
