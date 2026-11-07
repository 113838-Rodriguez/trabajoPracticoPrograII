namespace Ferreteria.DTOs
{
    public class QueryReportDTO1
    {
        /*
        SELECT  p.Codigo,
                p.Descripcion,
                SUM(s.CantidadActual) 'StockActual',
                hp.Precio 'PrecioUnitario',
                SUM(s.CantidadActual) * hp.Precio 'CapitalInmovilizado'
        FROM PRODUCTOS p
        JOIN STOCK s ON p.ProductoID = s.ProductoID
        JOIN HISTORIAL_PRECIOS hp
                ON p.ProductoID = hp.ProductoID
                AND hp.FechaHasta IS NULL
        */
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int CantidadActual { get; set; }
        public decimal Precio { get; set; }
        public decimal CapitalInmovilizado { get; set; }
    }
    public class QueryReportDTO2
    {
    }
    public class QueryReportDTO3
    {
    }

    public class QueryReportDTO4
    {
    }

    public class QueryReportDTO5
    {
    }

    public class QueryReportDTO6
    {
    }
}