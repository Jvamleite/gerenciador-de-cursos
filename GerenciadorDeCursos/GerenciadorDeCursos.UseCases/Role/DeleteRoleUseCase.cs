using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.RoleUseCases
{
    public class DeleteRoleUseCase : IDeleteRoleUseCase
    {
        private readonly IRoleRepository _roleRepository;
        public DeleteRoleUseCase(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResultBase> DeleteRoleById(Guid id)
        {
            try
            {
                await _roleRepository.DeleteRoleAsync(id);
                return new ResultBase();
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}
