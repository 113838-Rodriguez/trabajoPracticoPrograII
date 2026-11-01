using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class TipoProducto
{
    public int TipoProductoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
