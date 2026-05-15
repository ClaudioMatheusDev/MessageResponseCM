namespace NotificationContracts;

public class UsuarioCadastradoEvent
{
    public Guid UsuarioId { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string SobreNome { get; set; } = null!;
    public DateTimeOffset DataCadastro { get; set; } = null!;
    public string Email { get; set; } = null!;

}

public class PedidoConfirmadoEvent
{
    public Guid PedidoId { get; set; } = null!;
    public Guid UsuarioId { get; set; } = null!;
    public string Nome { get; set; } = null!;
    public string NomePedido { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string DescricaoPedido { get; set; } = null!;
    public DateTimeOffset DataConfirmacao { get; set; } = null!;
    public int VersaoEvento { get; set; } = null!;

}