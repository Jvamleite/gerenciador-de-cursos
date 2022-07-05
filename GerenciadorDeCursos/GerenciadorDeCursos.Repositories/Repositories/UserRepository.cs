using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteAsync(string username)
        {
            User user = await FindByUsernameAsync(username);

            if (user == null)
                throw new ArgumentException("Username inválido");

            _context.Remove(user);
            await _context.SaveChangesAsync();

        }

        public async Task<List<User>> FindByRoleAsync(Roles role)
        {
            List<User> usersByRole = await _context.Users.Where(p => p.Role == role).ToListAsync();

            return !usersByRole.Any() ? throw new Exception("Não há usuários com o role selecionado") : usersByRole;
        }

        public async Task<User> FindByUsernameAsync(string username)
        {
            User usersByRole = await _context.Users.FirstOrDefaultAsync(p => p.Username == username);

            return usersByRole == null ? throw new Exception("Não há usuários com o username escolhido") : usersByRole;
        }

        public async Task<List<User>> GetAllAsync()
        {
            List<User> users = await _context.Users.AsNoTracking().ToListAsync();

            return !users.Any() ? throw new Exception("Não há usuários para listar") : users;
        }
    }
}