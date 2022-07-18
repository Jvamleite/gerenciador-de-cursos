using GerenciadorDeCursos.Border.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface IUserRepository
    {
        Task AddTeacherAsync(Teacher teacher);

        Task AddStudentAsync(Student student);

        Task<IEnumerable<Student>> GetAllStudentsAsync();

        Task<IEnumerable<Teacher>> GetAllteachersAsync();

        Task<Teacher> GetTeacherByUsernameAsync(string username);

        Task<Student> GetByRegistrationNumberAsync(Guid registrationNumber);

        Task<Teacher> GetTeacherByNameAsync(string name);

        Task DeleteStudentAsync(Guid RegistrationNumber);

        Task DeleteteacherAsync(string username);
    }
}