using Bogus;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using GerenciadorDeCursos.Tests.Builders.UserBuilder;
using GerenciadorDeCursos.Tests.Utils;
using System;
using System.Collections.Generic;

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
                Id = Guid.NewGuid(),
                Teacher = (IEnumerable<Teacher>) ListFactory.Generate(() => new TeacherBuilder().Build(), min: 1),
                Student = (IEnumerable<Student>) ListFactory.Generate(() => new StudentBuilder().Build(), min: 1)
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

        public RoleBuilder WithName(string name)
        {
            _instance.Name = name;
            return this;
        }
    }
}