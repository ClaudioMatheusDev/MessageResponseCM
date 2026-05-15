using MassTransit;
using Microsoft.AspNetCore.Mvc;
using NotificationApi.Events;
using NotificationContracts;

namespace NotificationApi.Controllers;

[ApiController]
[Route("notifications")]
public class NotificationsController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;
    public NotificationsController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }


    [HttpPost("user-registered")]
    public async Task<IActionResult> User_RegisteredAsync([FromBody] UserRegistered dto)
    {
        var evento = new UsuarioCadastradoEvent
        {
            UsuarioId = dto.UsuarioId,
            Nome = dto.Nome,
            Email = dto.Email,
            DataCadastro = DateTime.UtcNow
        };

        await _publishEndpoint.Publish(evento);

        return Accepted();
    }

    [HttpPost("pedido-confirmado")]
    public async Task<IActionResult> PedidoConfirmado([FromBody] OrderConfirmed dto)
    {
        var evento = new PedidoConfirmadoEvent
        {
            PedidoId = dto.PedidoId,
            Nome = dto.Nome,
            NomePedido = dto.NomePedido,
            Email = dto.Email,
            DescricaoPedido = dto.DescricaoPedido,
            DataConfirmacao = DateTime.UtcNow,
            VersaoEvento = 1
        };

        await _publishEndpoint.Publish(evento);

        return Accepted();
    }
}