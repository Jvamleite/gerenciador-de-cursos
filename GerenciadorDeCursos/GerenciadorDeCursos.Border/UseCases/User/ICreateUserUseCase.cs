using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface ICreateUserUseCase
    {
        Task<ResultBase> CreateUserAsync(CreateUserRequest createUserRequest, Roles role);
    }
}