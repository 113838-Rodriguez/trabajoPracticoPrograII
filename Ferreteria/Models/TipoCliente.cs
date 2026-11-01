using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class TipoCliente
{
    public int TipoClienteId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
}
