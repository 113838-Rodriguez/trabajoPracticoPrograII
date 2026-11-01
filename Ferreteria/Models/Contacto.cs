using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Contacto
{
    public int ContactoId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int ClienteId { get; set; }

    public int TipoContactoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual TipoContacto TipoContacto { get; set; } = null!;
}
