using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Proveedore
{
    public int ProveedorId { get; set; }

    public string RazonSocial { get; set; } = null!;

    public string? Cuil { get; set; }

    public DateOnly FechaAlta { get; set; }

    public int? DomicilioId { get; set; }

    public virtual ICollection<Compra> Compras { get; set; } = new List<Compra>();

    public virtual ICollection<ContactoProveedore> ContactoProveedores { get; set; } = new List<ContactoProveedore>();

    public virtual Domicilio? Domicilio { get; set; }

    public virtual ICollection<OrdenReposicione> OrdenReposiciones { get; set; } = new List<OrdenReposicione>();
}
