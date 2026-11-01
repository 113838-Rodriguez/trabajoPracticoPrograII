using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class TransferenciasStock
{
    public int TransferenciaStockId { get; set; }

    public int SucursalOrigenId { get; set; }

    public int SucursalDestinoId { get; set; }

    public DateOnly FechaTransferencia { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<DetalleTransferenciasStock> DetalleTransferenciasStocks { get; set; } = new List<DetalleTransferenciasStock>();

    public virtual Sucursale SucursalDestino { get; set; } = null!;

    public virtual Sucursale SucursalOrigen { get; set; } = null!;
}
