using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json.Serialization;
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
        private readonly ILogger _logger;

        public UserController(ICreateUserUseCase createUserUseCase,IGetUserUseCase getUserUseCase,IDeleteUserUseCase deleteUserUseCase, ILogger logger)
        {
            _createUserUseCase = createUserUseCase;
            _getUserUseCase = getUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
            _logger = logger;
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
            _logger.Warning($"Iniciando a criação de um novo usuário");
            ResultBase result = await _createUserUseCase.CreateUser(createUserRequest,role);
            if(!result.Sucess)
            {
                _logger.Warning("Falha ao tentar criar o usuário: " + result.Message);
                return BadRequest(result.Message);
            }
            _logger.Warning("Usuário criado com sucesso");
            return CreatedAtAction(nameof(GetAll), result.Data);
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
