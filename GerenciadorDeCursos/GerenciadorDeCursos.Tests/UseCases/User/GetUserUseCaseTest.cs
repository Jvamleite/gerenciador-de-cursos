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
            var studentsResponse = new StudentResponseBuilderList().WithListOfStudents(students).Build();

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
        public async Task Execute_GetAllteacher_ReturnsSucess()
        {
            //Arrange
            var teachers = ListFactory.Generate(() => new TeacherBuilder().Build(), min: 2, max: 2);
            var teachersResponse = new TeacherResponseBuilderList().WithListOfteacher(teachers).Build();

            _userRepositoryMock.Setup(f => f.GetAllteachersAsync())
                .ReturnsAsync(teachers);

            //Act
            var result = await _useCase.GetAllteachersAsync();

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(teachersResponse);
        }

        [Fact]
        public async Task Execute_GetAllteachers_ReturnsException()
        {
            //Arrange
            var exception = new Exception("não há professores para listar");

            _userRepositoryMock.Setup(f => f.GetAllteachersAsync())
                .Throws(exception);

            //Act
            var result = await _useCase.GetAllteachersAsync();

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }

        [Fact]
        public async Task Execute_GetStudentByRegistrationNumber_ReturnsSucess()
        {
            //Arrange
            var registrationNumber = Guid.NewGuid();
            var student = new StudentBuilder().WithRegistrationNumber(registrationNumber).Build();
            var studentResponse = new StudentResponseBuilder().WithStudent(student).Build();
            

            _userRepositoryMock.Setup(f => f.GetByRegistrationNumberAsync(registrationNumber))
                .ReturnsAsync(student);

            //Act
            var result = await _useCase.GetStudentByRegistrationNumberAsync(registrationNumber);

            //Assert

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(studentResponse);
            
        }

        [Fact]
        public async Task Execute_GetStudentByRegistrationNumber_ReturnsException()
        {
            //Arrange
            var registrationNumber = Guid.NewGuid();
            var exception = new Exception($"Não há nenhum estudante com o número de matrícula {registrationNumber}");


            _userRepositoryMock.Setup(f => f.GetByRegistrationNumberAsync(registrationNumber))
                .Throws(exception);

            //Act
            var result = await _useCase.GetStudentByRegistrationNumberAsync(registrationNumber);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message); 

        }
    }
}