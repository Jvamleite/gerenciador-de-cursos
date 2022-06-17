using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
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

        public async Task<User> Add(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> DeleteByUsername(string username)
        {
            try
            {
                User user = await _context.Users.FirstOrDefaultAsync(p => p.Username == username);
                _context.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (NullReferenceException ex)
            {
                return false;
            }
            
        }

        public async Task<List<User>> FindByRole(Roles role)
        {
            return await _context.Users.Where(p => p.Role == role).ToListAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await _context.Users.AsNoTracking().ToListAsync();
        }
       
    }
}
