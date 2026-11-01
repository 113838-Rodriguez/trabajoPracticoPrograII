using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DescuentoMayorista
{
    public int DescuentoMayoristaId { get; set; }

    public int CantidadDesde { get; set; }

    public int? CantidadHasta { get; set; }

    public decimal PorcentajeDescuento { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();
}
