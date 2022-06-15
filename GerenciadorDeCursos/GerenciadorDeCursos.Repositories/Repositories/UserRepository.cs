using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Repositories;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        List<User> users = new List<User>();

        public void Add(User user)
        {
            users.Add(user);
        }
    }
}
