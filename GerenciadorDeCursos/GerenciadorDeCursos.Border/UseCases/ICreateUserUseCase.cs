using GerenciadorDeCursos.Border.DTOs.In;
using GerenciadorDeCursos.Shared.Models;

namespace GerenciadorDeCursos.Border.UseCases
{
    public interface ICreateUserUseCase
    {
        ResultBase CreateUser(CreateUserRequest request);
    }
}
