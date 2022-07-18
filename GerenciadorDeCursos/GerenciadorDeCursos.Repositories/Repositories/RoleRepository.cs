using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task DeleteRole(Guid id)
        {
            var role = await _context.Roles.FirstOrDefaultAsync(p => p.Id == id);
            if (role is null)
                throw new Exception("Não há roles com esse id");
            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await _context.Roles.ToListAsync();
        }

        public Task<Role> GetRoleById(Guid id)
        {
            var role = _context.Roles.FirstOrDefaultAsync(p => p.Id == id);
            return role ?? throw new Exception("Não há roles com esse id");
        }
    }
}