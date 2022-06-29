using GerenciadorDeCursos.Border.DTOs.Course.Request;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Border.UseCases.Course;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        public CourseController(ICreateCourseUseCase createCourseUseCase, IGetCourseUseCase getCourseUseCase,IUpdateStatusCouseUseCase updateStatusCouseUseCase,IDeleteCourseUseCase deleteCourseUseCase)
        {
            _createCourseUseCase = createCourseUseCase;
            _getCourseUseCase = getCourseUseCase;
            _updateStatusCouseCase = updateStatusCouseUseCase;
            _deleteCourseUseCase = deleteCourseUseCase;
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
            ResultBase response = await _createCourseUseCase.CreateCourseAsync(createCourseRequest);
            return response.Sucess ? CreatedAtAction(nameof(GetAll), response.Data) : BadRequest(response.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put()
        {
            ResultBase response = await _updateStatusCouseCase.UpdateStatus();
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