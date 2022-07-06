using Bogus;
using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Student : User
    {
        private readonly Faker _faker = new Faker("pt-BR");

        public Guid RegistrationNumber { get; set; }

        public IEnumerable<Course> EnrolledCourses { get; set; }

        public Student()
        { }

        public Student(string name, Roles role, bool isAdmin = false)
        {
            Id = Guid.NewGuid();
            RegistrationNumber = Guid.NewGuid();
            Username = _faker.Internet.UserName(name);
            Password = _faker.Internet.Password(10, true, @"^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Role = role;
            IsAdmin = isAdmin;
        }

    }
}
