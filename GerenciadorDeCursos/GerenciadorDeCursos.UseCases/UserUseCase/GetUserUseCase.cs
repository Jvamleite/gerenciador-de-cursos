using GerenciadorDeCursos.Border.DTOs.Out;
using GerenciadorDeCursos.Border.Entities;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
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
            ResultBase result = new ResultBase();
            List<User> users = await _userRepository.GetAll();
            List<CreateUserResponse> createUserResponseList = CreateUserResponseList(users);
            result.Data = createUserResponseList;
            return result;
        }

        public async Task<ResultBase> GetByRole(Roles role)
        {
            List<User> usersByRole = await _userRepository.FindByRole(role);
            return new ResultBase(usersByRole);
        }

        private List<CreateUserResponse> CreateUserResponseList(List<User> users)
        {
            List<CreateUserResponse> createUserResponseList = new List<CreateUserResponse>();
            foreach (User user in users)
            {
                CreateUserResponse createUserResponse = user.CreateCreateUserReponse();
                createUserResponseList.Add(createUserResponse);
            }
            return createUserResponseList
        }
    }
}
