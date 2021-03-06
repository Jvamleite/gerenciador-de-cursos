using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IDeleteUserUseCase
    {
        Task<ResultBase> DeleteteacherAsync(string username);

        Task<ResultBase> DeleteStudentAsync(Guid registrationNumber);
    }
}