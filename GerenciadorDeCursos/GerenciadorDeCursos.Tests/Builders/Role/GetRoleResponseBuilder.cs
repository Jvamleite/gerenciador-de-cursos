using Bogus;
using GerenciadorDeCursos.Border.DTOs.User.Response;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Utils;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Tests.Builders.RoleBuilder
{
    public class GetRoleResponseBuilder
    {
        private readonly List<RoleResponse> _instance;
        private readonly Faker _faker = FakerPtBr.CreateFaker();

        public GetRoleResponseBuilder()
        {
            _instance = ListFactory.Generate(() => new RoleResponseBuilder().Build(), min: 2, max: 2);
        }

        public List<RoleResponse> Build()
        {
            return _instance;
        }

        public GetRoleResponseBuilder WithListOfRoles(List<Role> roles)
        {
            for (int i = 0; i < _instance.Count; i++)
            {
                _instance[i].Id = roles[i].Id;
                _instance[i].Name = roles[i].Name;
            }

            return this;
        }
    }
}