using FluentValidation;
using NotificationApi.Events;

namespace NotificationApi.Dtos
{
    public class OrderConfirmedValidator : AbstractValidator<OrderConfirmed>
    {
        public OrderConfirmedValidator()
        {
            RuleFor(x => x.PedidoId)
                        .NotEmpty().WithMessage("O PedidoId é obrigatório.");

            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome do usuário é obrigatório.")
                .MinimumLength(3).WithMessage("O nome do usuário deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.NomePedido)
                .NotEmpty().WithMessage("O nome do pedido é obrigatório.")
                .MinimumLength(3).WithMessage("O nome do pedido deve ter pelo menos 3 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O e-mail é obrigatório estar preenchido.")
                .EmailAddress().WithMessage("O e-mail deve ser válido.");

            RuleFor(x => x.DescricaoPedido)
                .NotEmpty().WithMessage("A descrição do pedido é obrigatória.");

        }
    }
}