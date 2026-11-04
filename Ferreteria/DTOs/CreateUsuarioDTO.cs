using System.ComponentModel.DataAnnotations;

public class CreateUsuarioDTO
{
    [Required]
    [MaxLength(50)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    [Required]
    public int RolId { get; set; }

    public int? EmpleadoId { get; set; }
}