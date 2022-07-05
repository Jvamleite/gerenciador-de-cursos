using GerenciadorDeCursos.Border.DTOs.Course.Response;
using GerenciadorDeCursos.Border.Entities.CourseEntities.Enums;
using GerenciadorDeCursos.Border.Entities.UserEntities;
using System;
using System.Collections.Generic;

namespace GerenciadorDeCursos.Border.Entities.CourseEntities
{
    public class Course
    {
        private readonly DateTime dateNow = DateTime.Now;

        public Guid Id { get; set; }

        public string Título { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public Status Status { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public Course()
        { }

        public Course(string título, DateTime dataInicial, DateTime dataFinal)
        {
            Id = Guid.NewGuid();
            Título = título;
            DataInicial = dataInicial;
            DataFinal = dataFinal;
            Status = 0;
        }

        public Status GetStatus()
        {
            if (CourseIsOnGoing())
                return Status.EmAndamento;
            else if (CourseIsFinished())
                return Status.Concluido;
            else return Status.Previsto;
        }

        private bool CourseIsOnGoing()
        {
            return (dateNow > DataInicial && dateNow < DataFinal);
        }

        private bool CourseIsFinished()
        {
            return (dateNow > DataFinal);
        }

        public CourseResponse CreateCourseResponse()
        {
            CourseResponse courseResponse = new CourseResponse();
            courseResponse.Id = Id;
            courseResponse.Título = Título;
            courseResponse.DataInicial = DataInicial;
            courseResponse.DataFinal = DataFinal;
            courseResponse.Status = Status;
            return courseResponse;
        }
    }
}