using System;

namespace GerenciadorDeCursos.Border.DTOs.CourseDtos.Request
{
    public class CreateCourseRequest
    {
        public string Title { get; set; }

        public DateTime InitialData { get; set; }

        public DateTime FinalData { get; set; }
    }
}