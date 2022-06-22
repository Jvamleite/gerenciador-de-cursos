using FluentValidation;
using GerenciadorDeCursos.Border.DTOs.UserDTOs.Request;
using System.Text.RegularExpressions;

namespace GerenciadorDeCursos.Border.Validators
{
    public class UserValidator : AbstractValidator<RegisterUserRequest>
    {
        public UserValidator()
        {
            RuleFor(p => p.Username)
                    .NotNull()
                    .WithMessage("É obrigatório um username")
                    .MinimumLength(8)
                    .WithMessage("Username precisa de no mínimo 8 caracteres")
                    .MaximumLength(20)
                    .WithMessage("Username pode ter no máximo 20 caracteres")
                    .Must(BeUserName)
                    .WithMessage("Username inválido, o username não pode conter caracteres especiais");
            RuleFor(p => p.Password)
                    .NotNull()
                    .WithMessage("É obrigatório uma senha")
                    .MinimumLength(8)
                    .WithMessage("A senha precisa de no mínimo 8 caracteres")
                    .MaximumLength(20)
                    .WithMessage("A senha pode ter no máximo 20 caracteres")
                    .Must(BePassword)
                    .WithMessage("Senha inválida, a senha deve ter no mínimo: um caractere especial, uma letra maiscula, uma letra minuscula e um número");
        }

        private static bool BeUserName(string username)
        {
            return Regex.IsMatch(username, @"^(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
        }
        private static bool BePassword(string password)
        {
            return Regex.IsMatch(password, @"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
        }

    }
}
