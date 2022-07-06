using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Roles Role { get; set; }

        public bool IsAdmin { get; set; }

        public User()
        { }

        public User(string username, string password, Roles role)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
            Role = role;
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