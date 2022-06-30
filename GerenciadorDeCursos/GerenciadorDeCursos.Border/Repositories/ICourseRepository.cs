using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository
    {
        Task AddCourseAsync(Course course);

        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course> GetByCourseStatusAsync(Status status);

        Task<bool> UpdateStatusCourseAsync();

        Task<bool> DeleteAsync(Guid id);
    }
}