using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class UserResponseBuilder
    {
        private readonly UserResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public UserResponseBuilder()
        {
            _instance = new UserResponse()
            {
                Id = Guid.NewGuid(),
                Username = _faker.Internet.UserName(),
                Role = Roles.Aluno
            };
        }

        public UserResponse Build()
        {
            return _instance;
        }

        public UserResponseBuilder WithUser(User user)
        {
            this._instance.Id = user.Id;
            this._instance.Username = user.Username;
            this._instance.Role = user.Role;
            return this;
        }
    }
}