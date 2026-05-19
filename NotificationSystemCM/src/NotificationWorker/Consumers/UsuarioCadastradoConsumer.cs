using MassTransit;
using NotificationContracts;
using FluentEmail.Core;

namespace NotificationWorker.Consumers;

public class UsuarioCadastradoConsumer : IConsumer<UsuarioCadastradoEvent>
{
    private readonly ILogger<UsuarioCadastradoConsumer> _logger;
    private readonly IFluentEmail _email;

    public UsuarioCadastradoConsumer(ILogger<UsuarioCadastradoConsumer> logger, IFluentEmail email)
    {
        _logger = logger;
        _email = email;
    }

    public async Task Consume(ConsumeContext<UsuarioCadastradoEvent> context)
    {
        var msg = context.Message;
        _logger.LogInformation(
            "Usuário cadastrado: {UsuarioId} - {Nome} - {Email} em {DataCadastro}",
            msg.UsuarioId, msg.Nome, msg.Email, msg.DataCadastro
        );

        // Monta e envia e-mail de boas-vindas
        var subject = "Bem-vindo ao nosso sistema!";
        var body = $"Olá {msg.Nome},<br>Sua conta foi criada com sucesso em {msg.DataCadastro:dd/MM/yyyy HH:mm}.";

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
            _logger.LogInformation("E-mail enviado com sucesso para {Email}", msg.Email);
        }
    }
}