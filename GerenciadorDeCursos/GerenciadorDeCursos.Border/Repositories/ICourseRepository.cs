using GerenciadorDeCursos.Border.Entities.Course;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Border.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);
    }
}
