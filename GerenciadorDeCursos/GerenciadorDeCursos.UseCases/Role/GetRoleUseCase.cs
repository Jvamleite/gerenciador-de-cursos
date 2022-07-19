using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.Role
{
    public class GetRoleUseCase : IGetRoleUseCase
    {
        private readonly IRoleRepository _roleRepository;

        public GetRoleUseCase(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResultBase> GetAllRoles()
        {
            try
            {
                var roles = await _roleRepository.GetAllAsync();
                return new ResultBase(roles);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        public async Task<ResultBase> GetRoleById(Guid id)
        {
            try
            {
                var role = await _roleRepository.GetRoleById(id);
                return new ResultBase(role);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}