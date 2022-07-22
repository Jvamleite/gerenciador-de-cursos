using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.RoleBuilder;
using GerenciadorDeCursos.Tests.Utils;
using GerenciadorDeCursos.UseCases.RoleUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.RoleTests
{
    public class GetRolesUseCaseTest
    {
        private readonly Mock<IRoleRepository> _roleRepositoryMock;
        private readonly GetRoleUseCase _useCase;

        public GetRolesUseCaseTest()
        {
            _roleRepositoryMock = new Mock<IRoleRepository>();
            _useCase = new GetRoleUseCase(_roleRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_GetAllRoles_ReturnsSucess()
        {
            //Arrange
            var roles = ListFactory.Generate(() => new RoleBuilder().Build(), min: 2, max: 2);
            var rolesResponse = new GetRoleResponseBuilder().WithListOfRoles(roles).Build();

            _roleRepositoryMock.Setup(p => p.GetAllAsync())
                .ReturnsAsync(roles);

            //Act
            var result = await _useCase.GetAllRoles();

            //Assert
            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(rolesResponse);
        }

        [Fact]
        public async Task Execute_GetAllRoles_ReturnsException()
        {
            //Arrange
            var exception = new Exception("Não há roles para listar");

            _roleRepositoryMock.Setup(p => p.GetAllAsync())
                .Throws(exception);

            //Act
            var result = await _useCase.GetAllRoles();

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }

        [Fact]
        public async Task Execute_GetRolesById_ReturnsSucess()
        {
            //Arrange
            var id = Guid.NewGuid();
            var role = new RoleBuilder().WithId(id).Build();

            _roleRepositoryMock.Setup(p => p.GetRoleByIdAsync(id))
                .ReturnsAsync(role);

            //Act
            var result = await _useCase.GetRoleById(id);

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(role);
        }

        [Fact]
        public async Task Execute_GetRolesById_ReturnsException()
        {
            //Arrange
            var id = Guid.NewGuid();
            var exception = new Exception("Não há roles com esse id");

            _roleRepositoryMock.Setup(p => p.GetRoleByIdAsync(id))
                .Throws(exception);

            //Act
            var result = await _useCase.GetRoleById(id);

            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }
    }
}