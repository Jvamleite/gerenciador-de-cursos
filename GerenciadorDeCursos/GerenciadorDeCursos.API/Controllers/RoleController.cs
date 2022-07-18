using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly ICreateRoleUseCase _createRoleUseCase;
        private readonly IGetRoleUseCase _getRoleUseCase;

        public RoleController(ICreateRoleUseCase createRoleUseCase, IGetRoleUseCase getRoleUseCase)
        {
            _createRoleUseCase = createRoleUseCase;
            _getRoleUseCase = getRoleUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var response = await _getRoleUseCase.GetAllRoles();
            return response.Sucess ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest createRoleRequest)
        {
            var response = await _createRoleUseCase.CreateRole(createRoleRequest);
            return response.Sucess ? CreatedAtAction(nameof(Get), response.Data) : BadRequest(response.Message);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}