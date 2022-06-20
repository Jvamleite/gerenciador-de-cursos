using GerenciadorDeCursos.Border.Enums;

namespace GerenciadorDeCursos.Border.DTOs.Out
{
    public class UserResponse
    {
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}
