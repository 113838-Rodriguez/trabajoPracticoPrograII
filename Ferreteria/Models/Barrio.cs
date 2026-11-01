using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Barrio
{
    public int BarrioId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CiudadId { get; set; }

    public virtual Ciudade Ciudad { get; set; } = null!;

    public virtual ICollection<Domicilio> Domicilios { get; set; } = new List<Domicilio>();
}
