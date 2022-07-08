using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.User
{
    public class DeleteUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly DeleteUserUseCase _useCase;

        public DeleteUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _useCase = new DeleteUserUseCase(_userRepositoryMock.Object);
        }

        [Fact] public async Task Execute_DeleteStudentAsync_ReturnsSucess()
        {
            //Arrange
            var student = new StudentBuilder().Build();

            _userRepositoryMock.Setup(f => f.DeleteStudentAsync(student.RegistrationNumber));

            //Act
            var result = await _useCase.DeleteStudentAsync(student.RegistrationNumber);

            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_DeleteStudentAsync_ReturnsException()
        {
            //Arrange
            var student = new StudentBuilder().Build();
            var exception = new Exception($"Não há nenhum estudante com o número de matrícula {student.RegistrationNumber}");

            _userRepositoryMock.Setup(f => f.DeleteStudentAsync(student.RegistrationNumber))
                .Throws(exception);

            //Act
            var result = await _useCase.DeleteStudentAsync(student.RegistrationNumber);

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }

        [Fact]
        public async Task Execute_DeleteTeacherAsync_ReturnsSucess()
        {
            //Arrange
            var teacher = new TeacherBuilder().Build();

            _userRepositoryMock.Setup(f => f.DeleteTeacherAsync(teacher.Username));

            //Act
            var result = await _useCase.DeleteTeacherAsync(teacher.Username);

            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_DeleteTeacherAsync_ReturnsException()
        {
            //Arrange
            var teacher = new TeacherBuilder().Build();
            var exception = new Exception($"Username inválido");

            _userRepositoryMock.Setup(f => f.DeleteTeacherAsync(teacher.Username))
                .Throws(exception);

            //Act
            var result = await _useCase.DeleteTeacherAsync(teacher.Username);

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }


    }
}
