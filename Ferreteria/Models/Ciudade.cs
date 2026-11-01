using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Ciudade
{
    public int CiudadId { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? CodigoPostal { get; set; }

    public int ProvinciaId { get; set; }

    public virtual ICollection<Barrio> Barrios { get; set; } = new List<Barrio>();

    public virtual Provincia Provincia { get; set; } = null!;
}
