using Bogus;
using Bogus.Extensions.Brazil;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class TeacherBuilder
    {
        private readonly Teacher _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public TeacherBuilder()
        {
            _instance = new Teacher()
            {
                Id = Guid.Parse("e045a3fa-11ba-4955-b25d-5ef362211e2e"),
                Name = _faker.Person.FirstName,
                LastName = _faker.Person.LastName,
                Email = _faker.Person.Email,
                CPF = _faker.Person.Cpf(),
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(),
                IsAdmin = false
            };
        }

        public Teacher Build()
        {
            return _instance;
        }

        public TeacherBuilder WithRequest(CreateUserRequest request)
        {
            _instance.Username = _faker.Internet.UserName(request.Name);
            return this;
        }

        public TeacherBuilder WithUsername(string username)
        {
            _instance.Username = username;
            return this;
        }
    }
}