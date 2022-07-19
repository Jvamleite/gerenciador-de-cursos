using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid StudentId { get; set; }

        public Student Student { get; set; }

        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public Role() {}

        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}