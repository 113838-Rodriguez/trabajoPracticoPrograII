using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DetalleTransferenciasStock
{
    public int DetalleTransferenciaStockId { get; set; }

    public int TransferenciaStockId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual Producto Producto { get; set; } = null!;

    public virtual TransferenciasStock TransferenciaStock { get; set; } = null!;
}
