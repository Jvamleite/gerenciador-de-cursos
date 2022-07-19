using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.UseCases.CourseUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.CourseTests
{
    public class DeleteCourseUseCaseTest
    {
        private readonly DeleteCourseUseCase _usecase;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        public DeleteCourseUseCaseTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _usecase = new DeleteCourseUseCase(_courseRepositoryMock.Object);
        }

        [Fact]
        public async Task ExecuteReturnsSucess()
        {
            //Arrange
            var id = Guid.NewGuid();

            _courseRepositoryMock.Setup(f => f.DeleteAsync(id));

            //Act
            var result = await _usecase.DeleteCourseAsync(id);

            //Assert
            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task ExecuteReturnsException()
        {
            //Arrange
            var id = Guid.NewGuid();
            var exception = new Exception("Não há cursos com esse id");

            _courseRepositoryMock.Setup(f => f.DeleteAsync(id))
                .Throws(exception);

            //Act
            var result = await _usecase.DeleteCourseAsync(id);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().Be(exception.Message);
        }
    }
}