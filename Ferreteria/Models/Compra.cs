using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Compra
{
    public int CompraId { get; set; }

    public int ProveedorId { get; set; }

    public DateOnly FechaCompra { get; set; }

    public string NumeroComprobante { get; set; } = null!;

    public decimal Total { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<IngresosStock> IngresosStocks { get; set; } = new List<IngresosStock>();

    public virtual Proveedore Proveedor { get; set; } = null!;
}
