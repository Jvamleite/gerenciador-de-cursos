using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using System;

namespace GerenciadorDeCursos.Border.DTOs.CourseDtos.Response
{
    public class CourseResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Teacher { get; set; }

        public DateTime InitialData { get; set; }

        public DateTime FinalData { get; set; }

        public Status Status { get; set; }

        public int PositionsFree { get; set; }
    }
}