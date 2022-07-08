namespace GerenciadorDeCursos.Border.DTOs.UserDtos.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }
    }
}