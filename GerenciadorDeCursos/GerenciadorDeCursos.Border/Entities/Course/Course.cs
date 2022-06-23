using GerenciadorDeCursos.Border.DTOs.Course.Response;
using GerenciadorDeCursos.Border.Entities.Course.Enums;
using System;

namespace GerenciadorDeCursos.Border.Entities.Course
{
    public class Course
    {
        private readonly DateTime dateNow = DateTime.Now;
        
        public int Id { get; set; }

        public string Título { get; set; }

        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public Status Status { get; set; }

        public Course(string título, DateTime dataInicial, DateTime dataFinal)
        {
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
            courseResponse.Título = this.Título;
            courseResponse.DataInicial = this.DataInicial;
            courseResponse.DataFinal = this.DataFinal;
            courseResponse.Status = this.Status;
            return courseResponse;
        }
    }

    
}
