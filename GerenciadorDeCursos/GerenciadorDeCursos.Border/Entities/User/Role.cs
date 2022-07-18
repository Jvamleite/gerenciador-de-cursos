﻿using System;

namespace GerenciadorDeCursos.Border.Entities.UserEntities
{
    public class Role
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Role(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}