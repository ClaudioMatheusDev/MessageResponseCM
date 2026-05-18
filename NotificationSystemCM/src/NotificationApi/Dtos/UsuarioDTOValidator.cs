using FluentValidation;

namespace NotificationApi.Dtos
{
         /// <summary>
        /// UsuarioDTOValidator é uma classe de validação para o DTO de usuário, utilizando FluentValidation para garantir que os dados do usuário sejam válidos antes de serem processados. 
        /// Ele verifica se o nome não está vazio e tem pelo menos 3 caracteres, e se o e-mail é válido e não está vazio.
        /// </summary>
    public class UsuarioDTOValidator : AbstractValidator<UsuarioDTO>
    {
        public UsuarioDTOValidator() { 
        RuleFor(x => x.Nome).NotEmpty().WithMessage("O nome é obrigatório.").MinimumLength(3).WithMessage("O nome deve conter pelo menos 3 caracteres.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("O e-mail é obrigatório.").EmailAddress().WithMessage("E-mail inválido.");

        }
    }
}
