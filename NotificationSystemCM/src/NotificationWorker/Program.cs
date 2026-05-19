using MassTransit;
using NotificationWorker.Consumers;

using FluentEmail.Core;
using FluentEmail.Smtp;


var builder = Host.CreateApplicationBuilder(args);

// Lê as configurações do SMTP do appsettings.json
var smtpHost = builder.Configuration.GetValue<string>("Smtp:Host");
var smtpPort = builder.Configuration.GetValue<int>("Smtp:Port");
var smtpSender = builder.Configuration.GetValue<string>("Smtp:Sender");

// Configura o FluentEmail para usar o SMTP com as variáveis lidas do appsettings.json
builder.Services
    .AddFluentEmail(smtpSender)
    .AddSmtpSender(new System.Net.Mail.SmtpClient(smtpHost)
    {
        Port = smtpPort,
        EnableSsl = false
    });

// Lê as configurações do RabbitMQ do appsettings.json
var rabbitHost = builder.Configuration.GetSection("MassTransit:RabbitMq:Host").Value;
var vhost = builder.Configuration.GetSection("MassTransit:RabbitMq:VirtualHost").Value ?? "/";
var username = builder.Configuration.GetSection("MassTransit:RabbitMq:Username").Value;
var password = builder.Configuration.GetSection("MassTransit:RabbitMq:Password").Value;

// Registra os consumers e configura o host com as variáveis corretas
builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UsuarioCadastradoConsumer>();
    x.AddConsumer<PedidoConfirmadoConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitHost, vhost, h =>
        {
            h.Username(username);
            h.Password(password);
        });

        cfg.ReceiveEndpoint("queue-usuario-cadastrado", e =>
        {
            e.ConfigureConsumer<UsuarioCadastradoConsumer>(context);
        });

        cfg.ReceiveEndpoint("queue-pedido-confirmado", e =>
        {
            e.ConfigureConsumer<PedidoConfirmadoConsumer>(context);
        });
    });
});

var host = builder.Build();
host.Run();