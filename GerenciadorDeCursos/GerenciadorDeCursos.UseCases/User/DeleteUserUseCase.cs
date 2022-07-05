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

        public async Task<ResultBase> DeleteAsync(string username)
        {
            ResultBase result = new ResultBase();
            try
            {
                await _userRepository.DeleteAsync(username);

                return result;
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }
    }
}