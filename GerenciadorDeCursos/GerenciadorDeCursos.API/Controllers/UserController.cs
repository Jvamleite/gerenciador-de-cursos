using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
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
        private readonly ILogger<UserController> _logger;

        public UserController(ICreateUserUseCase createUserUseCase,
                              IGetUserUseCase getUserUseCase,
                              IDeleteUserUseCase deleteUserUseCase,
                              ILogger<UserController> logger)
        {
            _createUserUseCase = createUserUseCase;
            _getUserUseCase = getUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResultBase result = await _getUserUseCase.GetAllAsync();
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetByRoleAsync(Roles role)
        {
            ResultBase result = await _getUserUseCase.GetByRoleAsync(role);
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserRequest createUserRequest, Roles role)
        {
            _logger.LogWarning($"Iniciando a criação de um novo usuário");
            ResultBase result = await _createUserUseCase.CreateUserAsync(createUserRequest, role);
            if (!result.Sucess)
            {
                _logger.LogWarning("Falha ao tentar criar o usuário: " + result.Message);
                return BadRequest(result.Message);
            }
            _logger.LogWarning("Usuário criado com sucesso");
            return CreatedAtAction(nameof(GetAll), result.Data);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string username)
        {
            ResultBase result = await _deleteUserUseCase.DeleteAsync(username);
            return result.Sucess ? NoContent() : BadRequest(result.Message);
        }
    }
}