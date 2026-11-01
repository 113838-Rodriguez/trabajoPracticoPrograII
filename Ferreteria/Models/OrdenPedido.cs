using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class OrdenPedido
{
    public int OrdenPedidoId { get; set; }

    public int ClienteId { get; set; }

    public int EstadoPedidoId { get; set; }

    public DateOnly FechaPedido { get; set; }

    public DateOnly? FechaEntregaEstimada { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleOrdenPedido> DetalleOrdenPedidos { get; set; } = new List<DetalleOrdenPedido>();

    public virtual EstadoPedido EstadoPedido { get; set; } = null!;

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
