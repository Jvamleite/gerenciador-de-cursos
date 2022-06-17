using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Border.Enums;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases
{
    public interface ICreateUserUseCase
    {
        Task<ResultBase> CreateUser(CreateUserRequest request, Roles role);
    }
}
