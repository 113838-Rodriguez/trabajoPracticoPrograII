using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class IngresosStock
{
    public int IngresoStockId { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int? CompraId { get; set; }

    public int SucursalId { get; set; }

    public virtual Compra? Compra { get; set; }

    public virtual ICollection<DetalleIngresosStock> DetalleIngresosStocks { get; set; } = new List<DetalleIngresosStock>();

    public virtual Sucursale Sucursal { get; set; } = null!;
}
