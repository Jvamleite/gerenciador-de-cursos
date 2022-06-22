using GerenciadorDeCursos.Border.Entities.Course.Enums;
using System;

namespace GerenciadorDeCursos.Border.Entities.Course
{
    public class Course
    {
        public int Id { get; set; }

        public string Título { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public Status Status { get; set; }
    }
}
