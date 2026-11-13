using System.ComponentModel.DataAnnotations;

namespace Ferreteria.DTOs
{
    public class DomicilioResponseDTO
    {
        public int DomicilioId { get; set; }

        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string? Piso { get; set; }
        public string? Departamento { get; set; }

        public int BarrioId { get; set; }
        public string Barrio { get; set; } = string.Empty;

        public int CiudadId { get; set; }
        public string Ciudad { get; set; } = string.Empty;

        public int ProvinciaId { get; set; }
        public string Provincia { get; set; } = string.Empty;
    }
    public class CreateDomicilioDTO
    {
        [Required(ErrorMessage = "La calle es obligatoria.")]
        [StringLength(100)]
        public string Calle { get; set; } = string.Empty;

        [Required(ErrorMessage = "El número es obligatorio.")]
        [StringLength(10)]
        public string Numero { get; set; } = string.Empty;

        [StringLength(10)]
        public string? Piso { get; set; }

        [StringLength(10)]
        public string? Departamento { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Debe seleccionar un barrio válido.")]
        public int BarrioId { get; set; }
    }
    public class ProvinciaDTO
    {
        public int ProvinciaId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
    }

    public class CiudadDTO
    {
        public int CiudadId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string? CodigoPostal { get; set; }
        public int ProvinciaId { get; set; }
    }
    public class BarrioDTO
    {
        public int BarrioId { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public int CiudadId { get; set; }
    }
}
