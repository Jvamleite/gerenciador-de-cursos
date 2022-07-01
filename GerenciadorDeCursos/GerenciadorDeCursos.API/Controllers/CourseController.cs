using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICreateCourseUseCase _createCourseUseCase;
        private readonly IGetCourseUseCase _getCourseUseCase;
        private readonly IUpdateStatusCouseUseCase _updateStatusCouseCase;
        private readonly IDeleteCourseUseCase _deleteCourseUseCase;
        private readonly ILogger<CourseController> _logger;

        public CourseController(ICreateCourseUseCase createCourseUseCase,
                                IGetCourseUseCase getCourseUseCase,
                                IUpdateStatusCouseUseCase updateStatusCouseUseCase,
                                IDeleteCourseUseCase deleteCourseUseCase,
                                ILogger<CourseController> logger)
        {
            _createCourseUseCase = createCourseUseCase;
            _getCourseUseCase = getCourseUseCase;
            _updateStatusCouseCase = updateStatusCouseUseCase;
            _deleteCourseUseCase = deleteCourseUseCase;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ResultBase response = await _getCourseUseCase.GetAllAsync();
            return response.Sucess ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpGet("{status}")]
        public async Task<IActionResult> GetByStatus(Status status)
        {
            ResultBase response = await _getCourseUseCase.GetCourseByStatusAsync(status);
            return response.Sucess ? Ok(response.Data) : BadRequest(response.Message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest createCourseRequest)
        {
            _logger.LogWarning("Iniciando a criação de um nono curso");
            ResultBase response = await _createCourseUseCase.CreateCourseAsync(createCourseRequest);
            if (!response.Sucess)
            {
                _logger.LogWarning("Falha ao tentar criar curso: " + response.Message);
                return BadRequest(response.Message);
            }

            _logger.LogWarning("Curso criado com sucesso");
            return CreatedAtAction(nameof(GetAll), response.Data);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStatusCourse()
        {
            ResultBase response = await _updateStatusCouseCase.UpdateStatusAsync();
            return response.Sucess ? Ok() : BadRequest(response.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            ResultBase response = await _deleteCourseUseCase.DeleteCourseAsync(id);
            return response.Sucess ? NoContent() : BadRequest(response.Message);
        }
    }
}