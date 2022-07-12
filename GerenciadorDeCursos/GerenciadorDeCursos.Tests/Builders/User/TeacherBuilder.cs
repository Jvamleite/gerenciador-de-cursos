using Bogus;
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
            this._instance.Username = _faker.Internet.UserName(request.Name);
            return this;
        }
    }
}