using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User.Enums;

namespace GerenciadorDeCursos.Border.Entities.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public User(string username, string password, Roles role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public UserResponse CreateCreateUserReponse()
        {
            UserResponse userResponse = new UserResponse();
            userResponse.Username = Username;
            userResponse.Role = Role;
            return userResponse;
        }
    }
}