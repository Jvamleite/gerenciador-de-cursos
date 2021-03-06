using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IGetRoleUseCase
    {
        Task<ResultBase> GetAllRoles();

        Task<ResultBase> GetRoleById(Guid id);
    }
}