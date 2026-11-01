using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class EstadoReposicione
{
    public int EstadoReposicionId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<OrdenReposicione> OrdenReposiciones { get; set; } = new List<OrdenReposicione>();
}
