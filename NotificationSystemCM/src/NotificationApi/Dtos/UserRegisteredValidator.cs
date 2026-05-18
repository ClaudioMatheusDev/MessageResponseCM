using FluentValidation;
using NotificationApi.Events;

namespace NotificationApi.Dtos
{
    public class UserRegisteredValidator : AbstractValidator<UserRegistered>
    {
        public UserRegisteredValidator()
        {
            RuleFor(x => x.UsuarioId).NotEmpty().WithMessage("O UsuárioId é obrigatório.");

            RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.")
                .MinimumLength(3).WithMessage("O nome deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O E-mail não é valido")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");
        }
    }
}