using Bogus;
using Bogus.Extensions.Brazil;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using GerenciadorDeCursos.Tests.Utils;

namespace GerenciadorDeCursos.Tests.Builders.UserBuilder
{
    public class CreateUserRequestBuilder
    {
        private readonly CreateUserRequest _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public CreateUserRequestBuilder()
        {
            _instance = new CreateUserRequest()
            {
                Name = _faker.Person.FirstName.ToLower(),
                CPF = _faker.Person.Cpf(),
                Email = _faker.Person.Email,
            };
        }

        public CreateUserRequest Build()
        {
            return _instance;
        }
    }
}