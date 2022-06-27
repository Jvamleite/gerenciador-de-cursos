using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using Serilog;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCases
{
    public class CreateUserUseCase : ICreateUserUseCase
    {
        private readonly IUserRepository _userRepositoy;
        private readonly ILogger _logger;

        public CreateUserUseCase(IUserRepository userRepositoy)
        {
            _userRepositoy = userRepositoy;
        }

        public async Task<ResultBase> CreateUser(RegisterUserRequest request, Roles role)
        {
            try
            {
                _logger.Warning("Verificando se o usuário já existe no banco de dados");
                User user = await _userRepositoy.FindByUsername(request.Username);
                if (user != null)
                {
                    return new ResultBase(false, "Usuário já existe!");
                }
                _logger.Warning("Usuário não encontrado, criando usuário");
                User createdUser = new User(request.Username, request.Password, role);
                User addedUser = await _userRepositoy.Add(createdUser);
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