using GerenciadorDeCursos.Border.DTOs.User.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.RoleUseCases
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
                return new ResultBase(CreateRoleResponseList(roles));
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
                var role = await _roleRepository.GetRoleByIdAsync(id);
                return new ResultBase(role);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        private IEnumerable<RoleResponse> CreateRoleResponseList(IEnumerable<Role> roles)
        {
            var response = new List<RoleResponse>();
            foreach(var role in roles)
            {
                var roleResponse = role.CreateRoleResponse();
                response.Add(roleResponse);
            }
            return response;

        }
    }
}