using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;
        private readonly IGetUserUseCase _getUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase,IGetUserUseCase getUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
            _getUserUseCase = getUserUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResultBase result = await _getUserUseCase.GetAll();
            return result.Sucess ? Ok(result.Data) : BadRequest(result.Message);
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
