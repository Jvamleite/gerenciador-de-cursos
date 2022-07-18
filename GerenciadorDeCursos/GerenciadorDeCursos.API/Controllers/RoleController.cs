using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {

        private readonly ICreateRoleUseCase _createRoleUseCase;

        public RoleController(ICreateRoleUseCase createRoleUseCase)
        {
            _createRoleUseCase = createRoleUseCase;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
            return response.Sucess? CreatedAtAction(nameof(Get), response.Data) : BadRequest(response.Message);
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
