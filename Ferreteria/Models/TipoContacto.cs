using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class TipoContacto
{
    public int TipoContactoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<ContactoEmpleado> ContactoEmpleados { get; set; } = new List<ContactoEmpleado>();

    public virtual ICollection<ContactoProveedore> ContactoProveedores { get; set; } = new List<ContactoProveedore>();

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();
}
