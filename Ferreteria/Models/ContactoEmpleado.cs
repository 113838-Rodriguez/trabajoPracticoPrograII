using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class ContactoEmpleado
{
    public int ContactoEmpleadoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int EmpleadoId { get; set; }

    public int TipoContactoId { get; set; }

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual TipoContacto TipoContacto { get; set; } = null!;
}
