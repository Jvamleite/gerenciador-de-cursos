using GerenciadorDeCursos.Border.DTOs.Out;
using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCase
{

    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultBase> GetAll()
        {
            List<UserResponse> userResponseList;
            try
            {
                List<User> users = await _userRepository.GetAll();
                userResponseList = CreateUserResponseList(users);
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
            return new ResultBase(userResponseList);
        }

        public async Task<ResultBase> GetByRole(Roles role)
        {
            List<UserResponse> usersByRole;
            List<User> users;
            try
            {
                users = await _userRepository.FindByRole(role);
                usersByRole = CreateUserResponseList(users);
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
            return new ResultBase(usersByRole);
        }

        private List<UserResponse> CreateUserResponseList(List<User> users)
        {
            List<UserResponse> userResponseList = new List<UserResponse>();
            foreach (User user in users)
            {
                UserResponse userResponse = user.CreateCreateUserReponse();
                userResponseList.Add(userResponse);
            }
            return userResponseList;
        }
    }
}
