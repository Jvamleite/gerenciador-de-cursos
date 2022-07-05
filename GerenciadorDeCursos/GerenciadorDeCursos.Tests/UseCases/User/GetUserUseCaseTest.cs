using FluentAssertions;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Response;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using GerenciadorDeCursos.Border.Entities.User.Enums;
using GerenciadorDeCursos.Border.Repositories;
using GerenciadorDeCursos.Tests.Builders.CourseBuilder;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.Tests.Utils;
using GerenciadorDeCursos.UseCases.CourseUseCases;
using GerenciadorDeCursos.UseCases.UserUseCases;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GerenciadorDeCursos.Tests.UseCases.UserTests
{
    public class GetUserUseCaseTest
    {
        private readonly GetUserUseCase _useCase;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public GetUserUseCaseTest()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _useCase = new GetUserUseCase(_userRepositoryMock.Object);
        }

        [Fact]
        public async Task Execute_GetAll_RetunsSucess()
        {
            //Arrange
            var users = ListFactory.Generate(() => new UserBuilder().Build(), min: 1);
            var userResponseList = new List<UserResponse>();

            foreach (var user in users)
            {
               var userResponse = new UserResponseBuilder().WithUser(user).Build();
               userResponseList.Add(userResponse);
            }

            _userRepositoryMock.Setup(f => f.GetAllAsync())
                .ReturnsAsync(users);

            //Act
            var result = await _useCase.GetAllAsync();

            //Assert
            result.Data.Should().BeEquivalentTo(userResponseList);
            result.Sucess.Should().BeTrue();
        }

        [Fact]
        public async Task Execute_GetAll_ReturnsException()
        {
            //Arrange
            var exception = new Exception("não há usuários para listar");

            _userRepositoryMock.Setup(f => f.GetAllAsync())
                .ThrowsAsync(exception);

            //Act
            var result = await _useCase.GetAllAsync();

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message.ToString());
        }

        [Fact]
        public async Task Execute_GetUsersByRole_RetunsSucess()
        {
            //Arrange
            var users = ListFactory.Generate(() => new UserBuilder().Build(), min: 1);
            var userResponseList = new List<UserResponse>();

            foreach (var user in users)
            {
                var userResponse = new UserResponseBuilder().WithUser(user).Build();
                userResponseList.Add(userResponse);
            }

            _userRepositoryMock.Setup(f => f.FindByRoleAsync(Roles.Aluno))
                .ReturnsAsync(users);

            //Act
            var result = await _useCase.GetByRoleAsync(Roles.Aluno);

            //Assert
            result.Sucess.Should().BeTrue();
            result.Data.Should().BeEquivalentTo(userResponseList);
        }

        [Fact]
        public async Task Execute_GetCourseByStatus_ReturnException()
        {
            //Arrange
            var exception = new Exception("Não há usuários com o role selecionado");

            _userRepositoryMock.Setup(f => f.FindByRoleAsync(Roles.Aluno))
                .ThrowsAsync(exception);

            //Act
            var result = await _useCase.GetByRoleAsync(Roles.Aluno);

            //Assert
            result.Sucess.Should().BeFalse();
            result.Message.Should().BeEquivalentTo(exception.Message.ToString());
        }
    }
}