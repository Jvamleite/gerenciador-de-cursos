using GerenciadorDeCursos.Border.UseCases.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IGetUserUseCase _getUserUseCase;
        private readonly IDeleteUserUseCase _deleteUserUseCase;

        public StudentController(IGetUserUseCase getUserUseCase,IDeleteUserUseCase deleteUserUseCase)
        {
            _getUserUseCase = getUserUseCase;
            _deleteUserUseCase = deleteUserUseCase;

        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _getUserUseCase.GetAllStudentsAsync();
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpGet("{registrationNumber:Guid}")]
        public async Task<IActionResult> GetbyRegistrationNumber(Guid registrationNumber)
        {
            var result = await _getUserUseCase.GetStudentByRegistrationNumberAsync(registrationNumber);
            return result.Sucess ? Ok(result.Data) : NotFound(result.Message);
        }

        [HttpDelete("{registrationNumber:Guid}")]
        public async Task<IActionResult> DeleteByRegistrationNumber(Guid registrationNumber)
        {
            var result = await _deleteUserUseCase.DeleteStudentAsync(registrationNumber);
            return result.Sucess ? NoContent() : BadRequest(result.Message);
        }
    }
}
