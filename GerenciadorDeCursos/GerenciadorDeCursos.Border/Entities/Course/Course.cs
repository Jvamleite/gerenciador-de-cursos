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

        private Status GetStatus()
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
    }

    
}
