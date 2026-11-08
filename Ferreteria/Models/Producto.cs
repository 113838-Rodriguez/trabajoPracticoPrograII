using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Producto
{
    public int ProductoId { get; set; }

    public string Codigo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public string? Marca { get; set; }

    public int CategoriaProductoId { get; set; }

    public int TipoProductoId { get; set; }

    public bool Activo { get; set; }

    public virtual CategoriaProducto CategoriaProducto { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompras { get; set; } = new List<DetalleCompra>();

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; set; } = new List<DetalleFactura>();

    public virtual ICollection<DetalleIngresosStock> DetalleIngresosStocks { get; set; } = new List<DetalleIngresosStock>();

    public virtual ICollection<DetalleOrdenPedido> DetalleOrdenPedidos { get; set; } = new List<DetalleOrdenPedido>();

    public virtual ICollection<DetalleOrdenReposicione> DetalleOrdenReposiciones { get; set; } = new List<DetalleOrdenReposicione>();

    public virtual ICollection<DetalleTransferenciasStock> DetalleTransferenciasStocks { get; set; } = new List<DetalleTransferenciasStock>();

    public virtual ICollection<HistorialPrecio> HistorialPrecios { get; set; } = new List<HistorialPrecio>();

    public virtual ICollection<MovimientosStock> MovimientosStocks { get; set; } = new List<MovimientosStock>();

    public virtual ICollection<Stock> Stocks { get; set; } = new List<Stock>();

    public virtual TipoProducto TipoProducto { get; set; } = null!;
}
