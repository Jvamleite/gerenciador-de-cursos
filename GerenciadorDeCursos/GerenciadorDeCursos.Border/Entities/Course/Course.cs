using GerenciadorDeCursos.Border.DTOs.CourseDtos.Response;
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

        public string Title { get; set; }

        public DateTime InitialData { get; set; }

        public DateTime FinalData { get; set; }

        public Status Status { get; set; }

        public Guid TeacherId { get; set; }

        public Teacher Teacher { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int NumeroDeVagasLivres { get; set; }

        public Course()
        { }

        public Course(string title, DateTime dataInicial, DateTime dataFinal)
        {
            Id = Guid.NewGuid();
            Title = title;
            InitialData = dataInicial;
            FinalData = dataFinal;
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
            return (dateNow > InitialData && dateNow < FinalData);
        }

        private bool CourseIsFinished()
        {
            return (dateNow > FinalData);
        }

        public CourseResponse CreateCourseResponse()
        {
            CourseResponse courseResponse = new CourseResponse();
            courseResponse.Id = Id;
            courseResponse.Title = Title;
            courseResponse.InitialData = InitialData;
            courseResponse.FinalData = FinalData;
            courseResponse.Status = Status;
            return courseResponse;
        }
    }
}