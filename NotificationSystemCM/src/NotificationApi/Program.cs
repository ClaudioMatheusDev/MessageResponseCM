using MassTransit;

var builder = WebApplication.CreateBuilder(args);

var rabbitHost = builder.Configuration.GetSection("MassTransit:RabbitMq:Host").Value;
var vhost = builder.Configuration.GetSection("MassTransit:RabbitMq:VirtualHost").Value ?? "/";
var username = builder.Configuration.GetSection("MassTransit:RabbitMq:Username").Value;
var password = builder.Configuration.GetSection("MassTransit:RabbitMq:Password").Value;
var retryCount = builder.Configuration.GetValue<int>("MassTransit:RetryCount");

builder.Services.AddMassTransit(x =>
{
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(rabbitHost, vhost, h =>
        {
            h.Username(username);
            h.Password(password);
        });
    });
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();