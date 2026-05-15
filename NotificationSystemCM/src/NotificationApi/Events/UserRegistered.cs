namespace NotificationApi.Events
{
    public class UserRegistered
    {
        public Guid UsuarioId { get; set; }
        public string Nome { get; set; } = null!;
        public string Email { get; set; } = null!;
    }

}
