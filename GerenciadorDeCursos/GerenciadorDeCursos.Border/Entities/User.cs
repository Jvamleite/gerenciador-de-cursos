using GerenciadorDeCursos.Border.Enums;

namespace GerenciadorDeCursos.Border.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public Roles Role { get; set; }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }


}
