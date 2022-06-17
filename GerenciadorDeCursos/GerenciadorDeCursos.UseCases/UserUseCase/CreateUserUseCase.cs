using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.DTOs.Out;
using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;

namespace GerenciadorDeCursos.UseCases.UserUseCase
{
    public class CreateUserUseCase : ICreateUserUseCase {

        private readonly IUserRepository _userRepositoy;

        public CreateUserUseCase(IUserRepository userRepositoy)
        {
            _userRepositoy = userRepositoy; 
        }

        public ResultBase CreateUser(CreateUserRequest request, Roles role) {
            ResultBase result = new ResultBase();
            CreateUserResponse userResponse = new CreateUserResponse();
            User createdUser = new User(request.Username,request.Password);
            _userRepositoy.Add(createdUser);
            userResponse.Username = createdUser.Username;
            userResponse.Role = role;
            result.Data = userResponse;
            return result;
        }
    }
}
