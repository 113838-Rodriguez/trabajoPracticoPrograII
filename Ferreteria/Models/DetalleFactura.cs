using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DetalleFactura
{
    public int DetalleFacturaId { get; set; }

    public int FacturaId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public int? DescuentoMayoristaId { get; set; }

    public virtual DescuentoMayorista? DescuentoMayorista { get; set; }

    public virtual Factura Factura { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
