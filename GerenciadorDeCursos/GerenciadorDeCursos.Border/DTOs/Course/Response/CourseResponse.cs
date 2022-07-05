using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using System;

namespace GerenciadorDeCursos.Border.DTOs.Course.Response
{
    public class CourseResponse
    {
        public Guid Id { get; set; }

        public string Título { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public Status Status { get; set; }
    }
}