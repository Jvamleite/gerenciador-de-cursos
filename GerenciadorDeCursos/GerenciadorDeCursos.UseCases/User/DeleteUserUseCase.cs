using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCases
{

    public class DeleteUserUseCase : IDeleteUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public DeleteUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultBase> DeleteUserByUsername(string username)
        {
            ResultBase result = new ResultBase();
            try
            {
                result.Sucess = await _userRepository.DeleteByUsername(username);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
            return result;
        }
    }
}
