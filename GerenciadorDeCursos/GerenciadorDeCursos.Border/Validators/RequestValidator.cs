using FluentValidation;
using GerenciadorDeCursos.Border.DTOs.UserDtos.Request;
using System.Text.RegularExpressions;

namespace GerenciadorDeCursos.Border.Validators
{
    public class RequestValidator : AbstractValidator<CreateUserRequest>
    {
        public RequestValidator()
        {
            RuleFor(p => p.Name)
                .Must(BeAValidName)
                    .WithMessage("Name inválido");
            RuleFor(p => p.LastName)
                .Must(BeAValidName)
                    .WithMessage("LastName inválido");
            RuleFor(p => p.Email)
                .EmailAddress()
                    .WithMessage("Email inválido");
            RuleFor(p => p.CPF)
                .Must(BeAValidCpf)
                    .WithMessage("Cpf inválido");
        }

        private static bool BeAValidName(string name)
        {
            return Regex.IsMatch(name, @"^[\w'\-,.][^0-9_!¡?÷?¿/\\+=@#$%ˆ&*(){}|~<>;:[\]]{2,}$");
        }

        private static bool BeAValidCpf(string cpf)
        {
            return CpfCnpjValidator.ValidationCpfCnpj(cpf);
        }
    }
}