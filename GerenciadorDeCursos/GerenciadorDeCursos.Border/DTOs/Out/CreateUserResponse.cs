using GerenciadorDeCursos.Border.Enums;

namespace GerenciadorDeCursos.Border.DTOs.Out
{
    public class CreateUserResponse
    {
        public string Username { get; set; }
        public Roles Role { get; set; }
    }
}
