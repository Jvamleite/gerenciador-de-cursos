using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Course>> GetAllAsync();

        Task AddCourseAsync(Course course);

        Task<IEnumerable<Course>> GetCourseByStatusAsync(Status status);

        Task UpdateStatusCourseAsync();

        Task DeleteAsync(Guid id);
    }
}