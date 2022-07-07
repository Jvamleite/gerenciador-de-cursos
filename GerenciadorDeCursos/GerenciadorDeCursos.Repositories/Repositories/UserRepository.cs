using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddTeacherAsync(Teacher teacher)
        {
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _context.Students.AsNoTracking().ToListAsync();

            return !students.Any() ? throw new Exception("Não há alunos para listar") : students;
        }

        public async Task<IEnumerable<Teacher>> GetAllTeachersAsync()
        {
            var teachers = await _context.Teachers.AsNoTracking().ToListAsync();

            return !teachers.Any() ? throw new Exception("Não há professores para listar") : teachers;
        }

        public async Task<Student> GetByRegistrationNumberAsync(Guid registrationNumber)
        {
            var student = await _context.Students.FirstOrDefaultAsync(p => p.RegistrationNumber == registrationNumber);
            return student ?? throw new Exception($"Não há nenhum estudante com o número de matrícula {registrationNumber}");
        }

        private async Task<Teacher> GetTeacherByUsernameAsync(string username)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(p => p.Username == username);
            return teacher ?? throw new Exception($"Username inválido");
        }

        public async Task DeleteStudentAsync(Guid RegistrationNumber)
        {
            var student = await GetByRegistrationNumberAsync(RegistrationNumber);

            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTeacherAsync(string username)
        {
            var teacher = await GetTeacherByUsernameAsync(username);

            _context.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}