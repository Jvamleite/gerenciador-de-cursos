using Bogus;
using GerenciadorDeCursos.Border.DTOs.User.Response;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class User
    {
        private readonly Faker _faker = new Faker("pt-BR");

        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }

        public bool IsAdmin { get; set; }

        public User()
        { }

        public User(string name, Roles role, bool isAdmin = false)
        {
            Id = Guid.NewGuid();
            Username = _faker.Internet.UserName(name);
            Password = _faker.Internet.Password(10, true, @"^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");
            Role = role;
            IsAdmin = isAdmin;
        }

        public CreateUserResponse CreateCreateUserReponse()
        {
            var userResponse = new CreateUserResponse();
            userResponse.Username = Username;
            userResponse.Password = Password;
            return userResponse;
        }
    }
}