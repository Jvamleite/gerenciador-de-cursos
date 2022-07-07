using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public RequestController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> CreateARequest([FromBody] CreateUserRequest createUserRequest, Roles role)
        {
            var result = await _createUserUseCase.CreateUserAsync(createUserRequest,role);
            return result.Sucess ? Ok(result.Data) : BadRequest(result.Message);
        }

    }
}
