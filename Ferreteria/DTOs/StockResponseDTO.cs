using System;
using System.Collections.Generic;
using System.Text;

namespace Ferreteria.DTOs
{
    public class StockResponseDTO
    {
        public int StockId { get; set; }

        public int ProductoId { get; set; }
        public string CodigoProducto { get; set; } = string.Empty;
        public string DescripcionProducto { get; set; } = string.Empty;
        public bool ProductoActivo { get; set; }

        public int SucursalId { get; set; }
        public string Sucursal { get; set; } = string.Empty;

        public int CantidadActual { get; set; }
        public int StockMinimo { get; set; }
        public bool BajoMinimo { get; set; }
    }
}
