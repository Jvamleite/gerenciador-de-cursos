using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.UseCases.RoleUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.Role
{
    public class DeleteRoleUseCaseTest
    {
        private readonly Mock<IRoleRepository> _roleRepositoryMock;
        private readonly DeleteRoleUseCase _useCase;

        public DeleteRoleUseCaseTest()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _useCase = new DeleteRoleUseCase(_roleRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_ReturnsSucess()
        {
            //Arrange
            var id = Guid.NewGuid();

            _roleRepositoryMock.Setup(p => p.DeleteRoleAsync(id));

            //Act
            var result = await _useCase.DeleteRoleById(id);

            //Assert
            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_ReturnsException()
        {
            //Arrange
            var id = Guid.NewGuid();
            var exception = new Exception("Não há cursos com esse id");

            _roleRepositoryMock.Setup(p => p.DeleteRoleAsync(id))
                .Throws(exception);

            //Act
            var result = await _useCase.DeleteRoleById(id);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }
    }
}