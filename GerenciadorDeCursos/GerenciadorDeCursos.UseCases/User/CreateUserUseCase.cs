using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using GerenciadorDeCursos.Border.DTOs.CreateUserRequest;

namespace GerenciadorDeCursos.UseCases.UserUseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<CreateUserUseCase> _logger;

        public CreateUserUseCase(IUserRepository userRepository, ILogger<CreateUserUseCase> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }

        public async Task<ResultBase> CreateUserAsync(CreateUserRequest createUserRequest, Roles role)
        {
            try
            {
                if (role == Roles.Aluno)
                {
                    var createdStudent = new Student(createUserRequest.Name, role);
                    await _userRepository.AddStudentAsync(createdStudent);
                    return new ResultBase(createdStudent);
                }
                else 
                {
                    var createdTeacher = new Teacher();
                    await _userRepository.AddTeacherAsync(createdTeacher);
                    return new ResultBase(createdTeacher);
                }            
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}