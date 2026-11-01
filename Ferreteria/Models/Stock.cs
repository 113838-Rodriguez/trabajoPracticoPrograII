using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Stock
{
    public int StockId { get; set; }

    public int ProductoId { get; set; }

    public int SucursalId { get; set; }

    public int CantidadActual { get; set; }

    public int StockMinimo { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;
}
