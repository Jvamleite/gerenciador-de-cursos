using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        [HttpPost]
        public async Task<IActionResult> CreateARequest([FromBody] CreateUserRequest createUserRequest)
        {
            var result = _createUserUseCase.CreateUserAsync(createUserRequest);
            return Ok(result);
        }

    }
}
