using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using System;

namespace GerenciadorDeCursos.Border.DTOs.CourseDtos.Response
{
    public class CourseResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public DateTime InitialData { get; set; }

        public DateTime FinalData { get; set; }

        public Status Status { get; set; }
    }
}