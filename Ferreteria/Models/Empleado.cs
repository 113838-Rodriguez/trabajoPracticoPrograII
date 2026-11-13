using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Dni { get; set; } = null!;

    public string? Cuil { get; set; }

    public DateOnly FechaIngreso { get; set; }

    public int PuestoId { get; set; }

    public int? DomicilioId { get; set; }

    public int SucursalId { get; set; }

    public virtual ICollection<ContactoEmpleado> ContactoEmpleados { get; set; } = new List<ContactoEmpleado>();

    public virtual Domicilio? Domicilio { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual Puesto Puesto { get; set; } = null!;

    public virtual Sucursale Sucursal { get; set; } = null!;

    public virtual Usuario? Usuario { get; set; }

    public bool Activo { get; set; }
}
