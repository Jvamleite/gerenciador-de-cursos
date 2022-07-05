using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.User;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCases
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultBase> GetAllAsync()
        {
            try
            {
                List<User> users = await _userRepository.GetAllAsync();

                var userResponseList = CreateUserResponseList(users);

                return new ResultBase(userResponseList);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        public async Task<ResultBase> GetByRoleAsync(Roles role)
        {
            try
            {
                List<User> users = await _userRepository.FindByRoleAsync(role);

                List<UserResponse> usersByRole = CreateUserResponseList(users);

                return new ResultBase(usersByRole);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        private static List<UserResponse> CreateUserResponseList(List<User> users)
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