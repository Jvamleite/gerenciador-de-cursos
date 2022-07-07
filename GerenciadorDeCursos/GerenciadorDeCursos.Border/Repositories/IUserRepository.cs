using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task AddTeacherAsync(Teacher teacher);

        Task AddStudentAsync(Student student);

        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<IEnumerable<Teacher>> GetAllTeachersAsync();

        Task<Student> GetByRegistrationNumberAsync(Guid registrationNumber);

        Task DeleteStudentAsync(Guid RegistrationNumber);

        Task DeleteTeacherAsync(string username);

    }
}