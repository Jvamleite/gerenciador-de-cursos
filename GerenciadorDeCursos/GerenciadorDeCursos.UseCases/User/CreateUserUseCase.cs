using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

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
                    var createdStudent = new Student(createUserRequest.Name,
                                                     createUserRequest.LastName,
                                                     createUserRequest.Email,
                                                     createUserRequest.CPF);

                    await _userRepository.AddStudentAsync(createdStudent);
                    return new ResultBase(createdStudent.CreateCreateUserReponse());
                }
                else
                {
                    var createdteacher = new Teacher(createUserRequest.Name,
                                                     createUserRequest.LastName,
                                                     createUserRequest.Email,
                                                     createUserRequest.CPF);

                    await _userRepository.AddTeacherAsync(createdteacher);
                    return new ResultBase(createdteacher.CreateCreateUserReponse());
                }
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}