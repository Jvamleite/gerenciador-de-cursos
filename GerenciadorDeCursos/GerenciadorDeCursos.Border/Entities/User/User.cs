using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
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

        public UserResponse CreateCreateUserReponse()
        {
            UserResponse userResponse = new UserResponse();
            userResponse.Id = Id;
            userResponse.Username = Username;
            userResponse.Role = Role;
            return userResponse;
        }
    }
}