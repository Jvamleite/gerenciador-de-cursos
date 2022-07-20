using GerenciadorDeCursos.Border.DTOs.User.Response;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<Student> Student { get; set; }

        public IEnumerable<Teacher> Teacher { get; set; }

        public Role()
        { }

        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public RoleResponse CreateRoleResponse()
        {
            var response = new RoleResponse();
            response.Name = this.Name;
            response.Id = this.Id;
            return response;
        }
    }
}