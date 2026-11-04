public class UsuarioResponseDTO
{
    public int UsuarioId { get; set; }

    public string NombreUsuario { get; set; } = string.Empty;

    public string Rol { get; set; } = string.Empty;

    public bool Activo { get; set; }

    public int? EmpleadoId { get; set; }
}