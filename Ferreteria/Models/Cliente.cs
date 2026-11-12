using System;
using System.Collections.Generic;

namespace Ferreteria.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Apellido { get; set; }

    public string? RazonSocial { get; set; }

    public string? Cuil { get; set; }

    public string? Dni { get; set; }

    public DateOnly FechaAlta { get; set; }

    public int TipoClienteId { get; set; }

    public int? DomicilioId { get; set; }
    public bool Activo { get; set; } = true;

    public virtual ICollection<Contacto> Contactos { get; set; } = new List<Contacto>();

    public virtual Domicilio? Domicilio { get; set; }

    public virtual ICollection<Factura> Facturas { get; set; } = new List<Factura>();

    public virtual ICollection<OrdenPedido> OrdenPedidos { get; set; } = new List<OrdenPedido>();

    public virtual TipoCliente TipoCliente { get; set; } = null!;
}
