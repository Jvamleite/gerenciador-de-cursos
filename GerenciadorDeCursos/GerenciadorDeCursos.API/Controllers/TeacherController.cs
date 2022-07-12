using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;

        public TeacherController(IGetUserUseCase getUserUseCase, IDeleteUserUseCase deleteUserUseCase)
        {
            _getUserUseCase = getUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getUserUseCase.GetAllteachersAsync();
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteByUsername(string username)
        {
            var result = await _deleteUserUseCase.DeleteteacherAsync(username);
            return result.Sucess ? NoContent() : BadRequest(result.Message);
        }
    }
}