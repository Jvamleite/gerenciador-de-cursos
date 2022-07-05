using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Border.Shared;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository : IRepository<Course, Task>
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task<IEnumerable<Course>> GetCourseByStatusAsync(Status status);

        Task UpdateStatusCourseAsync();

        Task<bool> DeleteAsync(Guid id);
    }
}