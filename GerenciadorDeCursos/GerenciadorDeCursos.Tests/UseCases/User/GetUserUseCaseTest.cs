using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.Tests.Utils;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.User
{
    public class GetUserUseCaseTest
    {
        private readonly GetUserUseCase _useCase;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public GetUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _useCase = new GetUserUseCase(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_GetAllStudents_ReturnsSucess()
        {
            //Arrange
            var students = ListFactory.Generate(() => new StudentBuilder().Build(), min: 2, max: 2);
            var studentsResponse = new GetStudentResponseBuilder().WithListOfStudents(students).Build();

            _userRepositoryMock.Setup(f => f.GetAllStudentsAsync())
                .ReturnsAsync(students);

            //Act
            var result = await _useCase.GetAllStudentsAsync();

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(studentsResponse);
        }

        [Fact]
        public async Task Execute_GetAllStudents_ReturnsException()
        {
            //Arrange
            var exception = new Exception("não há alunos para listar");

            _userRepositoryMock.Setup(f => f.GetAllStudentsAsync())
                .Throws(exception);

            //Act
            var result = await _useCase.GetAllStudentsAsync();

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }

        [Fact]
        public async Task Execute_GetAllTeacher_ReturnsSucess()
        {
            //Arrange
            var teachers = ListFactory.Generate(() => new TeacherBuilder().Build(), min: 2, max: 2);
            var teachersResponse = new GetTeacherResponseBuilder().WithListOfTeacher(teachers).Build();

            _userRepositoryMock.Setup(f => f.GetAllTeachersAsync())
                .ReturnsAsync(teachers);

            //Act
            var result = await _useCase.GetAllTeachersAsync();

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(teachersResponse);
        }

        [Fact]
        public async Task Execute_GetAllTeachers_ReturnsException()
        {
            //Arrange
            var exception = new Exception("não há professores para listar");

            _userRepositoryMock.Setup(f => f.GetAllTeachersAsync())
                .Throws(exception);

            //Act
            var result = await _useCase.GetAllTeachersAsync();

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }
    }
}