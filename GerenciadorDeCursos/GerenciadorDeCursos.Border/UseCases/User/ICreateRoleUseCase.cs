using GerenciadorDeCursos.Border.DTOs.User.Request;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Shared.Models;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface ICreateRoleUseCase
    {
        Task<ResultBase> CreateRole(CreateRoleRequest createRoleRequest);
    }
}
