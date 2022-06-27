using GerenciadorDeCursos.Border.Entities.User.Enums;

namespace GerenciadorDeCursos.Border.DTOs.UserDTOs.Response
{
    public class UserResponse
    {
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}