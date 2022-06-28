using System;

namespace GerenciadorDeCursos.Border.DTOs.Course.Request
{
    public class CreateCourseRequest
    {
        public string Título { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }
    }
}