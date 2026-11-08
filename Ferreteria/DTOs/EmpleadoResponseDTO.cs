namespace Ferreteria.Models
{
    public class EmpleadoResponseDTO
    {
        public int EmpleadoId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Apellido { get; set; } = string.Empty;

        public string Dni { get; set; } = string.Empty;

        public string? Cuil { get; set; }

        public DateOnly FechaIngreso { get; set; }

        public int PuestoId { get; set; }

        public int? DomicilioId { get; set; }

        public int SucursalId { get; set; }
    }
}