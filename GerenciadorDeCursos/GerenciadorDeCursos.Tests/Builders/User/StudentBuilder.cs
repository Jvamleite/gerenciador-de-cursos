using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class StudentBuilder
    {
        private readonly Student _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public StudentBuilder()
        {
            _instance = new Student
            {
                Id = Guid.Parse("b5303c62-3148-48d1-8f69-b31c4fc7167d"),
                RegistrationNumber = Guid.Parse("c0be006e-73a5-4d12-8bd0-2cb326ca4a9e"),
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(),
                IsAdmin = false
            };
        }

        public Student Build()
        {
            return _instance;
        }

        public StudentBuilder WithRequest(CreateUserRequest request)
        {
            this._instance.Username = _faker.Internet.UserName(request.Name);
            return this;
        }
    }
}