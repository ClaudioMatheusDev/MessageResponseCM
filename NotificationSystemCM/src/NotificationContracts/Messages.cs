using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NotificationContracts;

public class UsuarioCadastradoEvent
{
    public Guid UsuarioId { get; set; }
    public string Nome { get; set; }
    public DateTime DataCadastro { get; set; }
    public string Email { get; set; }

}

public class PedidoConfirmadoEvent
{
    public Guid PedidoId { get; set; }
    public string Nome { get; set; } = null!;
    public string NomePedido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DescricaoPedido { get; set; } = null!;
    public DateTime DataConfirmacao { get; set; }
    public int VersaoEvento { get; set; }

}