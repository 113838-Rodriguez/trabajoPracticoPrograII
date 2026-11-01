using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class CategoriaProducto
{
    public int CategoriaProductoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
