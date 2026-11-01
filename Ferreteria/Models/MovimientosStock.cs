using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class MovimientosStock
{
    public int MovimientoStockId { get; set; }

    public int ProductoId { get; set; }

    public int SucursalId { get; set; }

    public int TipoMovimientoStockId { get; set; }

    public DateTime FechaMovimiento { get; set; }

    public int Cantidad { get; set; }

    public string? Observaciones { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual TipoMovimientosStock TipoMovimientoStock { get; set; } = null!;
}
