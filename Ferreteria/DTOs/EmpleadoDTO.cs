
using System.ComponentModel.DataAnnotations;

namespace Ferreteria.Models
{
    public class CreateEmpleadoDTO
    {
        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(100)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        public string Dni { get; set; } = string.Empty;

        public string? Cuil { get; set; }

        [Required]
        public DateOnly FechaIngreso { get; set; }

        [Range(1, int.MaxValue)]
        public int PuestoId { get; set; }

        public int? DomicilioId { get; set; }

        [Range(1, int.MaxValue)]
        public int SucursalId { get; set; }
    }
}
