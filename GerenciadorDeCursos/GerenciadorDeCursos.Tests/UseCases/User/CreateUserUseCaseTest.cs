using FluentAssertions;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.UserTest
{
    public class CreateUserUseCaseTest
    {
        private readonly CreateUserUseCase _useCase;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public CreateUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _useCase = new CreateUserUseCase(_userRepositoryMock.Object, Mock.Of<ILogger<CreateUserUseCase>>());
        }

        
        public async Task Execute_CreateUserAsync_CreateStudent_ReturnsSucess()
        {
            //Arrange
            var createUserRequest = new CreateUserRequestBuilder().Build();
            var student = new StudentBuilder().WithRequest(createUserRequest).Build();
            var response = new CreateUserResponseBuilder().WithUser(student).Build();

            _userRepositoryMock.Setup(f => f.AddStudentAsync(student));

            //Act
            var result = await _useCase.CreateUserAsync(createUserRequest, Roles.Aluno);

            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(response);
        }
    }
}
