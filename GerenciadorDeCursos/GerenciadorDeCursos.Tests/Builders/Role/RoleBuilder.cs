using Bogus;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.RoleBuilder
{
    public class RoleBuilder
    {
        private readonly Role _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public RoleBuilder()
        {
            _instance = new Role()
            {
                Name = _faker.Name.ToString(),
                Id = Guid.NewGuid()
            };
        }

        public Role Build()
        {
            return _instance;
        }

        public RoleBuilder WithId(Guid id)
        {
            _instance.Id = id;
            return this;
        }
    }
}