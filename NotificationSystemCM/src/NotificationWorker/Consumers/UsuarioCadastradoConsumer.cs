using MassTransit;
using NotificationContracts;

namespace NotificationWorker.Consumers;
public class UsuarioCadastradoConsumer : IConsumer<UsuarioCadastradoEvent>
{
    // Logger para registrar as informa��es do evento
    private readonly ILogger<UsuarioCadastradoConsumer> _logger;

    // Inje��o de depend�ncia do logger
    public UsuarioCadastradoConsumer(ILogger<UsuarioCadastradoConsumer> logger)
    {
        _logger = logger;
    }

    // Consume o evento de usu�rio cadastrado e loga as informa��es

    public Task Consume(ConsumeContext<UsuarioCadastradoEvent> context)
    {
        var msg = context.Message;
        _logger.LogInformation("Usu�rio cadastrado: {UsuarioId} - {Nome} - {Email} em {DataCadastro}",
            msg.UsuarioId, msg.Nome, msg.Email, msg.DataCadastro);
        return Task.CompletedTask;
    }
}