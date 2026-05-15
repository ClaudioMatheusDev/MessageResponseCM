namespace NotificationApi.Events
{
    public class OrderConfirmed
    {
        public Guid PedidoId { get; set; }
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public string NomePedido { get; set; } = null!;
        public string DescricaoPedido { get; set; } = null!;
        public string Email { get; set; } = null!;
    }
}
