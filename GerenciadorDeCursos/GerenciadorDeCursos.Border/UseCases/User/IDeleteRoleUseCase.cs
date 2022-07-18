using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IDeleteRoleUseCase
    {
        Task<ResultBase> DeleteRoleById(Guid id);
    }
}
