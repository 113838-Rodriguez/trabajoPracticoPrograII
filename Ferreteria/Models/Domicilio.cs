using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Domicilio
{
    public int DomicilioId { get; set; }

    public string Calle { get; set; } = null!;

    public string Numero { get; set; } = null!;

    public string? Piso { get; set; }

    public string? Departamento { get; set; }

    public int BarrioId { get; set; }

    public virtual Barrio Barrio { get; set; } = null!;

    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Proveedore> Proveedores { get; set; } = new List<Proveedore>();

    public virtual ICollection<Sucursale> Sucursales { get; set; } = new List<Sucursale>();
}
