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
                LastName = _faker.Person.LastName.ToLower(),
                CPF = _faker.Person.Cpf(),
                Email = _faker.Person.Email,
            };
        }

        public CreateUserRequest Build()
        {
            return _instance;
        }

        public CreateUserRequestBuilder WithNameInvalid()
        {
            this._instance.Name = _faker.Person.FirstName.ToLower().Replace("a", _faker.Random.String2(1,"&%#")) + _faker.Random.Digits(2).ToString();
            return this;
        }

        public CreateUserRequestBuilder WithLastNameInvalid()
        {
            this._instance.LastName = _faker.Person.LastName.ToLower().Replace("a", _faker.Random.String2(1, "&%#")) + _faker.Random.Digits(2).ToString();
            return this;
        }

        public CreateUserRequestBuilder WithCPFInvalid()
        {
            this._instance.CPF = _faker.Person.Cpf() + _faker.Random.String2(4, "@#$1");
            return this;
        }

        public CreateUserRequestBuilder WithEmailInvalid()
        {
            this._instance.Email = _faker.Internet.Email().Replace("@", "");
            return this;
        }

        
    }
}