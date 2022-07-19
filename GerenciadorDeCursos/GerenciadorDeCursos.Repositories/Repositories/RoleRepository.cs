using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repositories.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DataContext _context;

        public RoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddRoleAsync(Role role)
        {
            await _context.Roles.AddAsync(role);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(p => p.Id == id);
            if (role is null)
                throw new Exception("Não há roles com esse id");
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            var roles = await _context.Roles.ToListAsync();
            return roles.Any() ? roles : throw new Exception("Não há roles para listar"); 
        }

        public Task<Role> GetRoleByIdAsync(Guid id)
        {
            var role = _context.Roles.FirstOrDefaultAsync(p => p.Id == id);
            return role ?? throw new Exception("Não há roles com esse id");
        }
    }
}