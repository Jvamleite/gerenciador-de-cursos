using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ICreateRoleUseCase _createRoleUseCase;
        private readonly IGetRoleUseCase _getRoleUseCase;
        private readonly IDeleteRoleUseCase _deleteRoleUseCase;

        public RoleController(ICreateRoleUseCase createRoleUseCase, IGetRoleUseCase getRoleUseCase, IDeleteRoleUseCase deleteRoleUseCase)
        {
            _createRoleUseCase = createRoleUseCase;
            _getRoleUseCase = getRoleUseCase;
            _deleteRoleUseCase = deleteRoleUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _getRoleUseCase.GetAllRoles();
            return response.Sucess ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetRoleById(Guid id)
        {
            var response = await _getRoleUseCase.GetRoleById(id);
            return response.Sucess ? Ok(response.Data) : BadRequest(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest createRoleRequest)
        {
            var response = await _createRoleUseCase.CreateRole(createRoleRequest);
            return response.Sucess ? CreatedAtAction(nameof(GetAllRoles), response.Data) : BadRequest(response.Message);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteRoleById(Guid id)
        {
            var response = await _deleteRoleUseCase.DeleteRoleById(id);
            return response.Sucess ? NoContent() : BadRequest(response.Data);
        }
    }
}