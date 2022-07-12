using Bogus;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class CreateUserResponseBuilder
    {
        private readonly CreateUserResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CreateUserResponseBuilder()
        {
            _instance = new CreateUserResponse
            {
                Username = _faker.Internet.UserName(),
                Password = _faker.Internet.Password(),
            };
        }

        public CreateUserResponse Build()
        {
            return _instance;
        }

        public CreateUserResponseBuilder WithUser(User user)
        {
            this._instance.Username = user.Username;
            this._instance.Password = user.Password;
            return this;
        }
    }
}