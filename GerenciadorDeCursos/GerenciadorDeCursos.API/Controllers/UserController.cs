using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase,IGetUserUseCase getUserUseCase,IDeleteUserUseCase deleteUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _getUserUseCase = getUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResultBase result = await _getUserUseCase.GetAll();
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetByRole(Roles role)
        {
            ResultBase result = await _getUserUseCase.GetByRole(role);
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest createUserRequest, Roles role)
        {
            ResultBase result = await _createUserUseCase.CreateUser(createUserRequest,role);
            return result.Sucess ? CreatedAtAction(nameof(GetAll),result.Data) : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string username)
        {
            ResultBase result = await _deleteUserUseCase.DeleteUserByUsername(username);
            return result.Sucess ? NoContent() : BadRequest(result.Message);
        }
    }
}
