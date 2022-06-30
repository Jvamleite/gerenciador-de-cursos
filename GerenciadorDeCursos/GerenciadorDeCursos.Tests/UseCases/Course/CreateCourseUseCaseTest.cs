using FluentAssertions;
using GerenciadorDeCursos.Border.Entities.Course;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.UseCases.CourseUseCase;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.CourseTests
{
    public class CreateCourseUseCaseTest
    {
        private readonly CreateCourseUseCase _usecase;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;

        public CreateCourseUseCaseTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _usecase = new CreateCourseUseCase(
                _courseRepositoryMock.Object, 
                Mock.Of<ILogger<CreateCourseUseCase>>());
        }

        [Fact]
        public async Task ReturnResultSucess()
        {
            //Arrange
            var request = new CreateCourseRequestBuilder().Build();
            var course = new CourseBuilder().Build();

            _courseRepositoryMock.Setup(f => f.AddCourseAsync(course))
                .ReturnsAsync(new Course(request.Título,request.DataInicial,request.DataFinal));

            //Act
            var result = await _usecase.CreateCourseAsync(request);

            result.Should().BeEquivalentTo(course);
        }
    }
}
