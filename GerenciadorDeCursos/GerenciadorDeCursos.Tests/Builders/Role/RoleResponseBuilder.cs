using Bogus;
using GerenciadorDeCursos.Border.DTOs.User.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;
using System;

namespace GerenciadorDeCursos.Tests.Builders.RoleBuilder
{
    public class RoleResponseBuilder
    {
        private readonly RoleResponse _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public RoleResponseBuilder()
        {
            _instance = new RoleResponse()
            {
                Id = Guid.NewGuid(),
                Name = _faker.Random.String()
            };
        }

        public RoleResponse Build()
        {
            return _instance;
        }

        public RoleResponseBuilder WithRole(Role role)
        {
            _instance.Name = role.Name;
            _instance.Id = role.Id;

            return this;
        }
    }
}