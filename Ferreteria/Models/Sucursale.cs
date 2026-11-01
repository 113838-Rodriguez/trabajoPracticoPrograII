using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Sucursale
{
    public int SucursalId { get; set; }

    public string Descripcion { get; set; } = null!;

    public int DomicilioId { get; set; }

    public virtual Domicilio Domicilio { get; set; } = null!;

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<IngresosStock> IngresosStocks { get; set; } = new List<IngresosStock>();

    public virtual ICollection<MovimientosStock> MovimientosStocks { get; set; } = new List<MovimientosStock>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual ICollection<TransferenciasStock> TransferenciasStockSucursalDestinos { get; set; } = new List<TransferenciasStock>();

    public virtual ICollection<TransferenciasStock> TransferenciasStockSucursalOrigens { get; set; } = new List<TransferenciasStock>();
}
