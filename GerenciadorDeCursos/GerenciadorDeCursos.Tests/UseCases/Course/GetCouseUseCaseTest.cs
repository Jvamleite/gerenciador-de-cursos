using FluentAssertions;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Utils;
using GerenciadorDeCursos.UseCases.CourseUseCases;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.CourseTests
{
    public class GetCouseUseCaseTest
    {
        private readonly GetCourseUseCase _useCase;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        public GetCouseUseCaseTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _useCase = new GetCourseUseCase(_courseRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_GetAll_RetunsSucess()
        {
            //Arrange
            var courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1);

            _courseRepositoryMock.Setup(f => f.GetAllAsync())
                .ReturnsAsync(courses);

            //Act
            var result = await _useCase.GetAllAsync();

            //Assert
            result.Data.Should().BeEquivalentTo(courses);
            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_GetAll_ReturnsException()
        {
            //Arrange
            var exception = new Exception("não há cursos para listar");

            _courseRepositoryMock.Setup(f => f.GetAllAsync())
                .ThrowsAsync(exception);

            //Act
            var result = await _useCase.GetAllAsync();

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message.ToString());
        }

        [Fact]
        public async Task Execute_GetCourseByStatus_RetunsSucess()
        {
            //Arrange
            var courses = ListFactory.Generate(() => new CreateCourseBuilder().Build(), min: 1);

            _courseRepositoryMock.Setup(f => f.GetCourseByStatusAsync(Status.Previsto))
                .ReturnsAsync(courses);

            //Act
            var result = await _useCase.GetCourseByStatusAsync(Status.Previsto);

            //Assert
            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(courses);
        }

        [Fact]
        public async Task Execute_GetCourseByStatus_ReturnException()
        {
            //Arrange
            var exception = new Exception("Não há cursos com status EmAndamento");

            _courseRepositoryMock.Setup(f => f.GetCourseByStatusAsync(Status.EmAndamento))
                .ThrowsAsync(exception);

            //Act
            var result = await _useCase.GetCourseByStatusAsync(Status.EmAndamento);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message.ToString());
        }
    }
}