using GerenciadorDeCursos.Border.Entities.CourseEntities;
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

    }
}
