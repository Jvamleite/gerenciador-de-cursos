using GerenciadorDeCursos.Border.Entities.CourseEntities;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.Shared;
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

        public async Task AddAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            Course course = _context.Courses.FirstOrDefault(c => c.Id == id);

            if (course == null)
                throw new Exception("Não há cursos com esse id");

            _context.Remove(course);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            IEnumerable<Course> courses = await _context.Courses.ToListAsync();

            return courses.Any() ? courses : throw new Exception("Não há cursos para listar");
        }

        public async Task<IEnumerable<Course>> GetCourseByStatusAsync(Status status)
        {
            IEnumerable<Course> courses = await _context.Courses.Where(p => p.Status == status).ToListAsync();

            return courses.Any() ? courses : throw new Exception($"Não há cursos com status {status}");
        }

        public async Task UpdateStatusCourseAsync()
        {
            IEnumerable<Course> courses = await GetAllAsync();

            if (!courses.Any())
                throw new Exception("Não cursos para atualizar o status");

            foreach (Course course in courses)
                course.Status = course.GetStatus();

            await _context.SaveChangesAsync();
        }

        
    }
}