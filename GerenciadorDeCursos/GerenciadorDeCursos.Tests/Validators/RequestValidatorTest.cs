using FluentAssertions;
using FluentValidation;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Border.Validators;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.Validators
{
    public class RequestValidatorTest
    {
        private readonly IValidator<CreateUserRequest> _validator;

        public RequestValidatorTest()
        {
            _validator = new RequestValidator();
        }

        [Fact]
        public async Task Execute_ReturnsSucess()
        {
            //Arrange
            var request = new CreateUserRequestBuilder()
                .Build();

            //Action
            var validation = await _validator.ValidateAsync(request);

            //Assert
            validation.IsValid.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_ReturnsErrorWhenNameIsInvalid()
        {
            //Arrange
            var request = new CreateUserRequestBuilder()
                            .WithNameInvalid()
                            .Build();

            //Act
            var validation = await _validator.ValidateAsync(request);


            //Assert
            validation.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Execute_ReturnsErrorWhenLastNameIsInvalid()
        {
            //Arrange
            var request = new CreateUserRequestBuilder()
                            .WithLastNameInvalid()
                            .Build();

            //Act
            var validation = await _validator.ValidateAsync(request);


            //Assert
            validation.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Execute_ReturnsErrorWhenEmailIsInvalid()
        {
            //Arrange
            var request = new CreateUserRequestBuilder()
                            .WithEmailInvalid()
                            .Build();

            //Act
            var validation = await _validator.ValidateAsync(request);


            //Assert
            validation.IsValid.Should().BeFalse();
        }

        [Fact]
        public async Task Execute_ReturnsErrorWhenCPFIsInvalid()
        {
            //Arrange
            var request = new CreateUserRequestBuilder()
                            .WithCPFInvalid()
                            .Build();

            //Act
            var validation = await _validator.ValidateAsync(request);


            //Assert
            validation.IsValid.Should().BeFalse();
        }

    }
}
