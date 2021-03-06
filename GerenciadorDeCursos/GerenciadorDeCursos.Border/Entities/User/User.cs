using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using SecureIdentity.Password;
using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class User
    {
        private readonly string password = new Faker().Internet.Password(10, false);

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public Guid RoleId { get; set; }

        public Role Role { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public User()
        { }

        public User(string name, string lastName, string email, string cpf, bool isAdmin = false)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            Email = email;
            CPF = cpf;
            Username = (name + "_" + lastName).Replace(" ", "_");
            Password = PasswordHasher.Hash(password);
            IsAdmin = isAdmin;
        }

        public CreateUserResponse CreateCreateUserReponse()
        {
            var userResponse = new CreateUserResponse();
            userResponse.Username = Username;
            userResponse.Password = password;
            return userResponse;
        }
    }
}