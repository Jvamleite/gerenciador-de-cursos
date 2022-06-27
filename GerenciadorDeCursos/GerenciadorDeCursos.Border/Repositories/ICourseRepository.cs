using GerenciadorDeCursos.Border.Entities.Course;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);
        Task<IEnumerable<Course>> GetAllAsync();
    }
}