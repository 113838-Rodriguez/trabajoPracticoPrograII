using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ferreteria.DTOs
{
    public class ProductoRequestDTO
    {
        [Required]
        [StringLength(30)]
        public string Codigo { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Descripcion { get; set; } = string.Empty;

        [StringLength(100)]
        public string? Marca { get; set; }

        public int CategoriaProductoId { get; set; }

        public int TipoProductoId { get; set; }
    }
}
