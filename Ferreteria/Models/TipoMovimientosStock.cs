using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class TipoMovimientosStock
{
    public int TipoMovimientoStockId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<MovimientosStock> MovimientosStocks { get; set; } = new List<MovimientosStock>();
}
