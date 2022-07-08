using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class User
    {
        private readonly Faker _faker = new Faker("pt_BR");

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User()
        { }

        public User(string name, string lastName,string email,string cpf, bool isAdmin = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Email = email;
            CPF = cpf;
            Username = name + "_" + lastName;
            Password = _faker.Internet.Password(10, true, "^(?=.*?[A - Z])(?=.*?[a - z])(?=.*?[0 - 9])(?=.*?[#?!@$%^&*-]).{8,}$");
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