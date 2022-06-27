using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);

        Task<IEnumerable<Course>> GetAllAsync();

        Task<Course> GetByCourseStatusAsync(Status status);
    }
}