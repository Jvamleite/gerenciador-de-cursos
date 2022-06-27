using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICreateCourseUseCase _createCourseUseCase;

        public CourseController(ICreateCourseUseCase createCourseUseCase)
        {
            _createCourseUseCase = createCourseUseCase;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest createCourseRequest)
        {
            ResultBase response = await _createCourseUseCase.CreateCourseAsync(createCourseRequest);
            return response.Sucess ? CreatedAtAction(nameof(Get), response.Data) : BadRequest(response.Message);
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