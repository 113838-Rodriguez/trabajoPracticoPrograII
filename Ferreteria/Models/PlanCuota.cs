using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class PlanCuota
{
    public int PlanCuotasId { get; set; }

    public int CantidadCuotas { get; set; }

    public decimal PorcentajeInteres { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();
}
