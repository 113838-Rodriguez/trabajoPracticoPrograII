using System.ComponentModel.DataAnnotations;

public class UpdateUsuarioDTO
{
    [Required]
    [MaxLength(50)]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    public int RolId { get; set; }

    public int? EmpleadoId { get; set; }

    public bool Activo { get; set; }
}