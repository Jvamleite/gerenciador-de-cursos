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
        private readonly IRoleRepository _roleRepository;

        public UserRepository(DataContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        public async Task AddTeacherAsync(Teacher teacher, string roleName)
        {
            var role = await _roleRepository.GetRoleByNameAsync(roleName);
            teacher.Role = role;
            await _context.Teachers.AddAsync(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task AddStudentAsync(Student student, string roleName)
        {
            var role = await _roleRepository.GetRoleByNameAsync(roleName);
            student.Role = role;
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            var students = await _context.Students.AsNoTracking().ToListAsync();

            return !students.Any() ? throw new Exception("Não há alunos para listar") : students;
        }

        public async Task<IEnumerable<Teacher>> GetAllteachersAsync()
        {
            var teachers = await _context.Teachers.AsNoTracking().ToListAsync();

            return !teachers.Any() ? throw new Exception("Não há professores para listar") : teachers;
        }

        public async Task<Student> GetByRegistrationNumberAsync(Guid registrationNumber)
        {
            var student = await _context.Students.FirstOrDefaultAsync(p => p.RegistrationNumber == registrationNumber);
            return student ?? throw new Exception($"Não há nenhum estudante com o número de matrícula {registrationNumber}");
        }

        public async Task<Teacher> GetTeacherByUsernameAsync(string username)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(p => p.Username == username);
            return teacher ?? throw new Exception($"Username inválido");
        }

        public async Task<Teacher> GetTeacherByNameAsync(string name)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(p => p.Name == name);
            return teacher ?? throw new Exception($"Não há professor com o nome escolhido");
        }

        public async Task DeleteStudentAsync(Guid RegistrationNumber)
        {
            var student = await GetByRegistrationNumberAsync(RegistrationNumber);

            _context.Remove(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteteacherAsync(string username)
        {
            var teacher = await GetTeacherByUsernameAsync(username);

            _context.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}