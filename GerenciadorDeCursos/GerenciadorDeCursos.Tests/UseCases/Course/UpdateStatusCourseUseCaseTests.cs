using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.UseCases.CourseUseCase;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.CourseTests
{
    public class UpdateStatusCourseUseCaseTests
    {
        private readonly UpdateStatusCourseUseCase _useCase;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        public UpdateStatusCourseUseCaseTests()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _useCase = new UpdateStatusCourseUseCase(_courseRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_UpdateCourseUseCase_ReturnsSucess()
        {
            //Arrange

            _courseRepositoryMock.Setup(f => f.UpdateStatusCourseAsync());

            //Act
            var result = await _useCase.UpdateStatusAsync();

            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_UpdateCourseUseCase_ReturnException()
        {
            //Arrange
            var exception = new Exception("Não cursos para atualizar o status");

            _courseRepositoryMock.Setup(f => f.UpdateStatusCourseAsync())
                .Throws(exception);

            //Act
            var result = await _useCase.UpdateStatusAsync();

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message);
        }
    }
}