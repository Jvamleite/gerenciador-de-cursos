using FluentAssertions;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.UseCases.CourseUseCase;
using Microsoft.Extensions.Logging;
using Moq;
using System.Threading.Tasks;

namespace GerenciadorDeCursos.Tests.UseCases.CourseTests
{
    public class CreateCourseUseCaseTest
    {
        private readonly CreateCourseUseCase _usecase;
        private readonly Mock<ICourseRepository> _courseRepositoryMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public CreateCourseUseCaseTest()
        {
            _courseRepositoryMock = new Mock<ICourseRepository>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _usecase = new CreateCourseUseCase(
                _courseRepositoryMock.Object,
                Mock.Of<ILogger<CreateCourseUseCase>>(),
                _userRepositoryMock.Object);
        }

        //[Fact]
        public async Task ExecuteReturnSucess()
        {
            //Arrange
            var request = new CreateCourseRequestBuilder().Build();
            var course = new CreateCourseBuilder()
                                    .WithRequest(request)
                                    .Build();

            _courseRepositoryMock.Setup(f => f.AddCourseAsync(course));

            //Act
            var result = await _usecase.CreateCourseAsync(request);

            //Assert
            result.Data.Should().BeEquivalentTo(course);
            result.Sucess.Should().BeTrue();
        }
    }
}