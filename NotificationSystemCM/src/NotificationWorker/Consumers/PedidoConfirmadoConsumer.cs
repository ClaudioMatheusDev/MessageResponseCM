using MassTransit;
using NotificationContracts; 

public class PedidoConfirmadoConsumer : IConsumer<PedidoConfirmadoEvent>
{
    // Logger para registrar as informa��es do evento
    private readonly ILogger<PedidoConfirmadoConsumer> _logger;

    // Inje��o de depend�ncia do logger
    public PedidoConfirmadoConsumer(ILogger<PedidoConfirmadoConsumer> logger)
    {
        _logger = logger;
    }

    // M�todo que � chamado quando um evento PedidoConfirmadoEvent � consumido
    public Task Consume(ConsumeContext<PedidoConfirmadoEvent> context)
    {
        var msg = context.Message;
        _logger.LogInformation("Pedido confirmado: {PedidoId} - {Nome} - {NomePedido} - {Email} - {DescricaoPedido} - {DataConfirmacao} - Vers�o {VersaoEvento}",
            msg.PedidoId, msg.Nome, msg.NomePedido, msg.Email, msg.DescricaoPedido, msg.DataConfirmacao, msg.VersaoEvento);
        return Task.CompletedTask;
    }
}