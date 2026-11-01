using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class EstadoPedido
{
    public int EstadoPedidoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<OrdenPedido> OrdenPedidos { get; set; } = new List<OrdenPedido>();
}
