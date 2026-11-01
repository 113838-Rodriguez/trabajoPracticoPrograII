using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class ContactoProveedore
{
    public int ContactoProveedorId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int ProveedorId { get; set; }

    public int TipoContactoId { get; set; }

    public virtual Proveedore Proveedor { get; set; } = null!;

    public virtual TipoContacto TipoContacto { get; set; } = null!;
}
