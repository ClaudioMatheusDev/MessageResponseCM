namespace NotificationApi.Dtos
{
    public class UsuarioDTO
    {
       public Guid IdUsuario { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string SobreNome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
