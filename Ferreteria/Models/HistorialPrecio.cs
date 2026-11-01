using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class HistorialPrecio
{
    public int HistorialPrecioId { get; set; }

    public int ProductoId { get; set; }

    public decimal Precio { get; set; }

    public DateOnly FechaDesde { get; set; }

    public DateOnly? FechaHasta { get; set; }

    public virtual Producto Producto { get; set; } = null!;
}
