using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Microsoft.Extensions.Logging;
using Moq;

namespace GerenciadorDeCursos.Tests.UseCases.UserTests
{
    public class CreateUserUseCaseTest
    {
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly CreateUserUseCase _useCase;

        public CreateUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _useCase = new CreateUserUseCase(
                _userRepositoryMock.Object,
                Mock.Of<ILogger<CreateUserUseCase>>());
        }
    }
}