using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.UserTests
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

        [Fact]
        public async Task ExecuteReturnsSucess()
        {
            //Arrange
            var username = "username";

            _userRepositoryMock.Setup(f => f.DeleteAsync(username));

            //Act
            var result = await _useCase.DeleteAsync(username);

            //Assert
            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task ExecuteReturnsException()
        {
            //Arrange
            var username = "username";
            var exception = new Exception("Não há usuários com o username escolhido");

            _userRepositoryMock.Setup(f => f.DeleteAsync(username))
                .Throws(exception);

            //Act
            var result = await _useCase.DeleteAsync(username);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().Be(exception.Message);
        }
    }
}