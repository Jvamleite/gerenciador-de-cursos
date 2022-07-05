using Bogus;
using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class UserBuilder
    {
        private readonly User _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public UserBuilder()
        {
            _instance = new User()
            {
                Id = Guid.NewGuid(),
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(),
                Role = Roles.Aluno
            };    
        }

        public User Build()
        {
            return _instance;
        }
    }
}
