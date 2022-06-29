using FluentValidation;
using GerenciadorDeCursos.Border.DTOs.Course.Request;
using System;

namespace GerenciadorDeCursos.Border.Validators
{
    public class CourseValidator : AbstractValidator<CreateCourseRequest>
    {
        public CourseValidator()
        {
            RuleFor(p => p.Título)
                .NotNull()
                    .WithMessage("O Título é obrigatório")
                .MinimumLength(8)
                    .WithMessage("Mínimo de 8 caracteres para título")
                .MaximumLength(70)
                    .WithMessage("Máximo de 70 caracteres para título");
            RuleFor(p => p.DataInicial)
                .NotNull()
                    .WithMessage("A Data Inicial é obrigatória")
                .Must(BeAValidInitialDate)
                    .WithMessage("A Data Inicial não pode ser hoje e não pode ultrapassar um ano a partir de hoje");
            RuleFor(p => p.DataFinal)
                .NotNull()
                    .WithMessage("A data final é obrigatória")
                .Must(BeAValidFinalDate)
                    .WithMessage("A data final não pode ser hoje, deve ultrapassar no mínimo um mês e não pode ser de mais de um ano");
        }

        private static bool BeAValidInitialDate(DateTime dateTime)
        {
            return dateTime < DateTime.Today.AddYears(1) && dateTime > DateTime.Today;
        }

        private static bool BeAValidFinalDate(DateTime dateTime)
        {
            return (dateTime < DateTime.Today.AddYears(1) && dateTime > DateTime.Today.AddDays(30));
        }
    }
}