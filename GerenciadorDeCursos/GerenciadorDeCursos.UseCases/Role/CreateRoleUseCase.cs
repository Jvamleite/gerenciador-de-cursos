using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.RoleUseCase
{
    public class CreateRoleUseCase : ICreateRoleUseCase
    {
        private readonly IRoleRepository _roleRepository;

        public CreateRoleUseCase(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<ResultBase> CreateRole(CreateRoleRequest createRoleRequest)
        {
            try
            {
                var role = new Role(createRoleRequest.RoleName);
                await _roleRepository.AddRoleAsync(role);
                return new ResultBase(role.CreateRoleResponse());
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}