using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Factura
{
    public int FacturaId { get; set; }

    public DateOnly FechaFactura { get; set; }

    public string NumeroFactura { get; set; } = null!;

    public decimal Total { get; set; }

    public int ClienteId { get; set; }

    public int? PlanCuotasId { get; set; }

    public int? OrdenPedidoId { get; set; }

    public int SucursalId { get; set; }

    public int EmpleadoId { get; set; }

    public virtual Cliente Cliente { get; set; } = null!;

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual Empleado Empleado { get; set; } = null!;

    public virtual OrdenPedido? OrdenPedido { get; set; }

    public virtual PlanCuota? PlanCuotas { get; set; }

    public virtual Sucursale Sucursal { get; set; } = null!;
}
