using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class DetalleOrdenReposicione
{
    public int DetalleOrdenReposicionId { get; set; }

    public int OrdenReposicionId { get; set; }

    public int ProductoId { get; set; }

    public int Cantidad { get; set; }

    public virtual OrdenReposicione OrdenReposicion { get; set; } = null!;

    public virtual Producto Producto { get; set; } = null!;
}
