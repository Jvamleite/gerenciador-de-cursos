using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repositories.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly DataContext _context;

        public CourseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Course> AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            IEnumerable<Course> courses = await _context.Courses.ToListAsync();
            return courses.Any() ? courses : throw new Exception("Não há cursos para listar");
        }

        public async Task<Course> GetByCourseStatusAsync(Status status)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(x => x.Status == status);
            return course == null ? throw new Exception($"Não há cursos com status {status}") : course;
        }
    }
}