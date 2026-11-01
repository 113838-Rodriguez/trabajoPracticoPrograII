using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DetalleIngresosStock
{
    public int DetalleIngresoStockId { get; set; }

    public int IngresoStockId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual IngresosStock IngresoStock { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
