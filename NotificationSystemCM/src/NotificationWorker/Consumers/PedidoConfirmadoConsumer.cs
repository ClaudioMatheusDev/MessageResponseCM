using MassTransit;
using NotificationContracts;
using FluentEmail.Core;


namespace NotificationWorker.Consumers;

public class PedidoConfirmadoConsumer : IConsumer<PedidoConfirmadoEvent>
{
    private readonly ILogger<PedidoConfirmadoConsumer> _logger;
    private readonly IFluentEmail _email;

    public PedidoConfirmadoConsumer(ILogger<PedidoConfirmadoConsumer> logger, IFluentEmail email)
    {
        _logger = logger;
        _email = email;
    }

    public async Task Consume(ConsumeContext<PedidoConfirmadoEvent> context)
    {
        var msg = context.Message;
        _logger.LogInformation(
            "Pedido confirmado: {PedidoId} - {Nome} - {NomePedido} - {Email} - {DescricaoPedido} - {DataConfirmacao} - Versão {VersaoEvento}",
            msg.PedidoId, msg.Nome, msg.NomePedido, msg.Email, msg.DescricaoPedido, msg.DataConfirmacao, msg.VersaoEvento
        );

        // Monta e envia e-mail de confirmação de pedido
        var subject = "Seu pedido foi confirmado!";
        var body = $@"Olá {msg.Nome},<br>
        Seu pedido <strong>{msg.NomePedido}</strong> foi confirmado em {msg.DataConfirmacao:dd/MM/yyyy HH:mm}.<br>
        Descrição: {msg.DescricaoPedido}";

        var response = await _email
            .To(msg.Email)
            .Subject(subject)
            .Body(body, isHtml: true)
            .SendAsync();

        if (!response.Successful)
        {
            _logger.LogError("Falha ao enviar e-mail para {Email}: {Erro}", msg.Email,
                string.Join(", ", response.ErrorMessages));
        }
        else
        {
            _logger.LogInformation("E-mail de pedido enviado para {Email}", msg.Email);
        }
    }
}