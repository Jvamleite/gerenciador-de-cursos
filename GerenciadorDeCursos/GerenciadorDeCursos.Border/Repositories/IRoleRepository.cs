using GerenciadorDeCursos.Border.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IRoleRepository
    {
        Task AddRoleAsync(Role role);

        Task<IEnumerable<Role>> GetAllAsync();

        Task<Role> GetRoleByIdAsync(Guid id);

        Task DeleteRoleAsync(Guid id);
    }
}