using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.DTOs.Out;
using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;

namespace GerenciadorDeCursos.UseCases.UserUseCase
{
    public class CreateUserUseCase : ICreateUserUseCase {
        public ResultBase CreateUser(CreateUserRequest request) {
            ResultBase result = new ResultBase();
            CreateUserResponse userResponse = new CreateUserResponse();
            User createdUser = new User(request.Name,request.Password,request.Role);
            userResponse.Name = createdUser.Name;
            userResponse.Role = createdUser.Role;
            result.Data = createdUser;
            return result;
        }
    }
}
