using GerenciadorDeCursos.Border.Entities.User.Enums;
using System;

namespace GerenciadorDeCursos.Border.DTOs.UserDTOs.Response
{
    public class UserResponse
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public Roles Role { get; set; }
    }
}