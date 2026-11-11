using System.ComponentModel.DataAnnotations;

namespace Ferreteria.DTOs
{
    public class CreateClienteDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(100)]
        public string? Apellido { get; set; }

        [MaxLength(150)]
        public string? RazonSocial { get; set; }

        [MaxLength(13)]
        public string? Cuil { get; set; }

        [MaxLength(10)]
        public string? Dni { get; set; }

        [Required]
        public int TipoClienteId { get; set; }

        public int? DomicilioId { get; set; }
        public bool EstaActivo { get; set; } = true;
    }
}
