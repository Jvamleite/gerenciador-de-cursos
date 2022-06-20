using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.DTOs.Out;
using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCase
{
    public class CreateUserUseCase : ICreateUserUseCase {

        private readonly IUserRepository _userRepositoy;

        public CreateUserUseCase(IUserRepository userRepositoy)
        {
            _userRepositoy = userRepositoy; 
        }

        public async Task<ResultBase> CreateUser(CreateUserRequest request, Roles role) {
            try
            {
                User user = await _userRepositoy.FindByUsername(request.Username);
                if (user != null)
                {
                    return new ResultBase(false, "Usuário já existe!");
                }
                User createdUser = new User(request.Username, request.Password, role);
                User addedUser = await _userRepositoy.Add(createdUser);
                UserResponse response = addedUser.CreateCreateUserReponse();
                return new ResultBase(response);
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}
