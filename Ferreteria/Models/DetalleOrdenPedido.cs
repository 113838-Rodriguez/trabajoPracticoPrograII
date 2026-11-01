using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DetalleOrdenPedido
{
    public int DetalleOrdenPedidoId { get; set; }

    public int OrdenPedidoId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual OrdenPedido OrdenPedido { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
