using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class OrdenReposicione
{
    public int OrdenReposicionId { get; set; }

    public int ProveedorId { get; set; }

    public int EstadoReposicionId { get; set; }

    public DateOnly FechaOrden { get; set; }

    public DateOnly? FechaEntregaEstimada { get; set; }

    public virtual ICollection<DetalleOrdenReposicione> DetalleOrdenReposiciones { get; set; } = new List<DetalleOrdenReposicione>();

    public virtual EstadoReposicione EstadoReposicion { get; set; } = null!;

    public virtual Proveedore Proveedor { get; set; } = null!;
}
