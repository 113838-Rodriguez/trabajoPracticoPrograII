namespace Ferreteria.DTOs
{
    public class ClienteResponseDTO
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string? Apellido { get; set; }

        public string? RazonSocial { get; set; }

        public string? Cuil { get; set; }

        public string? Dni { get; set; }

        public DateOnly FechaAlta { get; set; }

        public string TipoClienteDescripcion { get; set; } = string.Empty;

        public int? DomicilioId { get; set; }
        public bool EstaActivo { get; set; }
    }
}
