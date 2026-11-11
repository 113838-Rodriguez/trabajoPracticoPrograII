namespace Ferreteria.DTOs
{
    public class QRProductosSinVentasDTO //PABLO
    {
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int StockActual { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal CapitalInmovilizado { get; set; }
    }
    public class QRStockbySucursalDTO //MAXI
    {
        public string Codigo { get; set; } = null!;
        public string Sucursal { get; set; } = null!;
        public int CantidadActual { get; set; }
        public string Producto { get; set; } = null!;
        public int StockMinimo { get; set; }
    }
    public class QREmpleadosySucursalesDTO //PABLO
    {        
        public string Sucursal { get; set; } = null!;
        public string Periodo { get; set; } = null!;
        public string Empleado { get; set; } = null!;
        public int CantidadFacturas { get; set; }
        public decimal TotalVentas { get; set; }
    }
    public class SucursalComboDTO
    {
        public int SucursalID { get; set; }
        public string Descripcion { get; set; } = null!;
    }
    public class EmpleadoComboDTO
    {
        public int EmpleadoID { get; set; }
        public string Nombre { get; set; } = null!;
    }

    public class QRFacturacionTipoClienteDTO //MAXI
    {
        public string TipoCliente { get; set; } = null!;
        public int CantidadFacturas { get; set; }
        public decimal TotalFacturado { get; set; }
        public decimal PromedioPorFactura { get; set; }
    }

    public class QREntregasAtrasadasDTO //PABLO
    {
        public string Tipo { get; set; } = null!;
        public int NumeroOrden { get; set; }
        public string ClienteProveedor { get; set; } = null!;
        public string EstadoActual { get; set; } = null!;
        public DateOnly FechaEntregaEstimada { get; set; }
        public int DiasAtraso { get; set; }
        public int UnidadesPendientes { get; set; }
    }

    public class QRStockMinWithFilterDTO //MAXI
    {
        public string Sucursal { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public string Producto { get; set; } = null!;
        public int CantidadActual { get; set; }
        public int StockMinimo { get; set; }
        public int FaltanteReposicion { get; set; }
    }
}