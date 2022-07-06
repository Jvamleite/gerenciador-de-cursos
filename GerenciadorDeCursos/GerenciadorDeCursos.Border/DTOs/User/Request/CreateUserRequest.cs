using GerenciadorDeCursos.Border.Entities.User.Enums;

namespace GerenciadorDeCursos.Border.DTOs.User.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }
    }
}
