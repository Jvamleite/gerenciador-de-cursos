using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Border.UseCases.User;
using GerenciadorDeCursos.Shared.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;

namespace GerenciadorDeCursos.UseCases.UserUseCases
{
    public class GetUserUseCase : IGetUserUseCase
    {
        private readonly IUserRepository _userRepository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultBase> GetAllStudentsAsync()
        {
            try
            {
                var students = await _userRepository.GetAllStudentsAsync();

                var studentResponseList = CreateStudentResponseList(students);

                return new ResultBase(studentResponseList);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        public async Task<ResultBase> GetAllTeachersAsync()
        {
            try
            {
                var teachers = await _userRepository.GetAllTeachersAsync();

                var teacherResponseList = CreateTeacherResponseList(teachers);

                return new ResultBase(teacherResponseList);
            }
            catch (Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        public async Task<ResultBase> GetStudentByRegistrationNumberAsync(Guid registrationNumber)
        {
            try
            {
                var student = await _userRepository.GetByRegistrationNumberAsync(registrationNumber);
                return new ResultBase(student.CreateGetStudentResponse());
            }
            catch(Exception ex)
            {
                return new ResultBase(false, ex.Message);
            }
        }

        private static IEnumerable<GetStudentResponse> CreateStudentResponseList(IEnumerable<Student> students)
        {
            var  studentResponseList = new List<GetStudentResponse>();

            foreach (var student in students)
            {
                var studentResponse = student.CreateGetStudentResponse();
                studentResponseList.Add(studentResponse);
            }

            return studentResponseList;
        }
        private static IEnumerable<GetTeacherResponse> CreateTeacherResponseList(IEnumerable<Teacher> teachers)
        {
            var teacherResponseList = new List<GetTeacherResponse>();

            foreach (var teacher in teachers)
            {
                var teacherResponse = teacher.CreateGetTeacherResponse();
                teacherResponseList.Add(teacherResponse);
            }

            return teacherResponseList;
        }

        
    }
}