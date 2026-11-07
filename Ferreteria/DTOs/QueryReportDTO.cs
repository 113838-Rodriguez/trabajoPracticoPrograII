namespace Ferreteria.DTOs
{
    public class QRProductosSinVentasDTO //PABLO
    {
        /*
        SELECT  p.Codigo,
                p.Descripcion,
                SUM(s.CantidadActual) 'StockActual',
                hp.Precio 'PrecioUnitario',
                SUM(s.CantidadActual) * hp.Precio 'CapitalInmovilizado'
        FROM PRODUCTOS p
        JOIN STOCK s
        JOIN HISTORIAL_PRECIOS hp                
        */
        public string Codigo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int StockActual { get; set; }
        public decimal Precio { get; set; }
        public decimal CapitalInmovilizado { get; set; }
    }
    public class QRStockbySucursalDTO //MAXI
    {
    }
    public class QREmpleadosySucursalesDTO //PABLO
    {
        /*
         SELECT
                s.Descripcion 'Sucursal',
                CONCAT(YEAR(f.FechaFactura), ' - ', UPPER(LEFT(DATENAME(MONTH, f.FechaFactura), 1)), LOWER(SUBSTRING(DATENAME(MONTH, f.FechaFactura), 2, 20))) 'Periodo',        
                CONCAT(e.Apellido, ', ', e.Nombre) 'Empleado',
                COUNT(f.FacturaID) 'CantidadFacturas',
                SUM(f.Total) 'TotalVentas'
        FROM FACTURAS f
        JOIN EMPLEADOS e        
        JOIN SUCURSALES s    
         */
        public string Descripcion { get; set; } = null!;
        public DateOnly Periodo { get; set; }
        public string Empleado { get; set; } = null!;
        public int CantidadFacturas { get; set; }
        public decimal Total { get; set; }
    }

    public class QRFacturacionTipoClienteDTO //MAXI
    {
    }

    public class QREntregasAtrasadasDTO //PABLO
    {
        /*
             SELECT
                    'Debemos al cliente' 'Tipo',
                    op.OrdenPedidoID 'NumeroOrden',
                    COALESCE(c.RazonSocial, c.Apellido + ', ' + c.Nombre) 'ClienteProveedor',
                    ep.Descripcion 'EstadoActual',
                    op.FechaEntregaEstimada,
                    DATEDIFF(day, op.FechaEntregaEstimada, @FechaReferencia) 'DiasAtraso',
                    SUM(dop.Cantidad) 'UnidadesPendientes'
            FROM ORDEN_PEDIDOS op
            JOIN CLIENTES c           
            JOIN ESTADO_PEDIDOS ep
            JOIN DETALLE_ORDEN_PEDIDOS dop
        UNION
            SELECT
                    'Nos debe el proveedor' 'Tipo',
                    orp.OrdenReposicionID 'NumeroOrden',
                    pr.RazonSocial 'ClienteProveedor',
                    er.Descripcion 'EstadoActual',
                    orp.FechaEntregaEstimada,
                    DATEDIFF(day, orp.FechaEntregaEstimada, @FechaReferencia) 'DiasAtraso',
                    SUM(dor.Cantidad) 'UnidadesPendientes'
            FROM ORDEN_REPOSICIONES orp
            JOIN PROVEEDORES pr
            JOIN ESTADO_REPOSICIONES er
            JOIN DETALLE_ORDEN_REPOSICIONES dor
         */
        public string Tipo { get; set; } = null!;
        public int NumeroOrden { get; set; }
        public string NombreClienteProveedor { get; set; } = null!;
        public string EstadoActual { get; set; } = null!;
        public DateOnly? FechaEntregaEstimada { get; set; }
        public DateOnly? DiasAtraso { get; set; }
        public int UnidadesPendientes { get; set; }
    }

    public class QRStockMinWithFilterDTO //MAXI
    {
    }
}