using System.ComponentModel.DataAnnotations;

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
        public int TipoClienteId { get; set; }
        public string TipoClienteDescripcion { get; set; } = string.Empty;

        public DomicilioResponseDTO? Domicilio { get; set; }
    }
    public class ClienteDTO
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Apellido { get; set; }

        [StringLength(150)]
        public string? RazonSocial { get; set; }

        [RegularExpression(@"^\d{2}-?\d{8}-?\d$")]
        public string? Cuil { get; set; }

        [RegularExpression(@"^\d{7,8}$")]
        public string? Dni { get; set; }

        [Range(1, int.MaxValue)]
        public int TipoClienteId { get; set; }

        // El domicilio es opcional.
        public CreateDomicilioDTO? Domicilio { get; set; }
    }    

    public class ReactivarClienteDTO
    {
        [Required(ErrorMessage = "El DNI es obligatorio.")]
        [RegularExpression(@"^\d{7,8}$",
            ErrorMessage = "El DNI debe contener entre 7 y 8 números.")]
        public string Dni { get; set; } = string.Empty;
    }

    //TipoCliente
    public class TipoClienteDTO
    {
        public int TipoClienteId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }
}