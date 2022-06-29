using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
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

        public async Task<ResultBase> CreateUserAsync(RegisterUserRequest request, Roles role)
        {
            try
            {
                _logger.LogWarning("Verificando se o usuário já existe no banco de dados");

                User user = await _userRepository.FindByUsernameAsync(request.Username);
                if (user != null)
                    return new ResultBase(false, "Usuário já existe!");

                _logger.LogWarning("Usuário não encontrado, criando usuário");
                User createdUser = new User(request.Username, request.Password, role);

                User addedUser = await _userRepository.AddAsync(createdUser);

                UserResponse response = addedUser.CreateCreateUserReponse();

                return new ResultBase(response);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}