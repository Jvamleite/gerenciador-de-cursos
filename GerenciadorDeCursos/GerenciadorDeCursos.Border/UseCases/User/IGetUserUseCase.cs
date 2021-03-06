using GerenciadorDeCursos.Shared.Models;
using System;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.UseCases.User
{
    public interface IGetUserUseCase
    {
        Task<ResultBase> GetAllStudentsAsync();

        Task<ResultBase> GetAllteachersAsync();

        Task<ResultBase> GetStudentByRegistrationNumberAsync(Guid registrationNumber);
    }
}