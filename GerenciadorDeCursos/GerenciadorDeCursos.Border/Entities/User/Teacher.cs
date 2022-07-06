using Bogus;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Teacher : User
    {
        public IEnumerable<Course> Courses { get; set; }

        public Teacher(string name, Roles role) : base(name,role)
        {
            
        }
    }
}
