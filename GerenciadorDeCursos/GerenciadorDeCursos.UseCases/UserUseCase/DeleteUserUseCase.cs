using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.UseCases.UserUseCase
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
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
            return result;
        }
    }
}
