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