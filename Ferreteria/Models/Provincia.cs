using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Provincia
{
    public int ProvinciaId { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Ciudade> Ciudades { get; set; } = new List<Ciudade>();
}
