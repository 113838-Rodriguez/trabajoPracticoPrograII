using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ferreteria.Models;

public partial class FerreteriaContext : DbContext
{
    public FerreteriaContext()
    {
    }

    public FerreteriaContext(DbContextOptions<FerreteriaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Barrio> Barrios { get; set; }

    public virtual DbSet<CategoriaProducto> CategoriaProductos { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<Contacto> Contactos { get; set; }

    public virtual DbSet<ContactoEmpleado> ContactoEmpleados { get; set; }

    public virtual DbSet<ContactoProveedore> ContactoProveedores { get; set; }

    public virtual DbSet<DescuentoMayorista> DescuentoMayoristas { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<DetalleFactura> DetalleFacturas { get; set; }

    public virtual DbSet<DetalleIngresosStock> DetalleIngresosStocks { get; set; }

    public virtual DbSet<DetalleOrdenPedido> DetalleOrdenPedidos { get; set; }

    public virtual DbSet<DetalleOrdenReposicione> DetalleOrdenReposiciones { get; set; }

    public virtual DbSet<DetalleTransferenciasStock> DetalleTransferenciasStocks { get; set; }

    public virtual DbSet<Domicilio> Domicilios { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EstadoPedido> EstadoPedidos { get; set; }

    public virtual DbSet<EstadoReposicione> EstadoReposiciones { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<HistorialPrecio> HistorialPrecios { get; set; }

    public virtual DbSet<IngresosStock> IngresosStocks { get; set; }

    public virtual DbSet<MovimientosStock> MovimientosStocks { get; set; }

    public virtual DbSet<OrdenPedido> OrdenPedidos { get; set; }

    public virtual DbSet<OrdenReposicione> OrdenReposiciones { get; set; }

    public virtual DbSet<PlanCuota> PlanCuotas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Provincia> Provincias { get; set; }

    public virtual DbSet<Puesto> Puestos { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    public virtual DbSet<TipoCliente> TipoClientes { get; set; }

    public virtual DbSet<TipoContacto> TipoContactos { get; set; }

    public virtual DbSet<TipoMovimientosStock> TipoMovimientosStocks { get; set; }

    public virtual DbSet<TipoProducto> TipoProductos { get; set; }

    public virtual DbSet<TransferenciasStock> TransferenciasStocks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=FERRETERIA_TRONKA;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Barrio>(entity =>
        {
            entity.HasKey(e => e.BarrioId).HasName("PK_Barrio");

            entity.ToTable("BARRIOS");

            entity.Property(e => e.BarrioId).HasColumnName("BarrioID");
            entity.Property(e => e.CiudadId).HasColumnName("CiudadID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Barrios)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Barrio_Ciudad");
        });

        modelBuilder.Entity<CategoriaProducto>(entity =>
        {
            entity.HasKey(e => e.CategoriaProductoId).HasName("PK_CategoriaProducto");

            entity.ToTable("CATEGORIA_PRODUCTOS");

            entity.Property(e => e.CategoriaProductoId).HasColumnName("CategoriaProductoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK_Ciudad");

            entity.ToTable("CIUDADES");

            entity.Property(e => e.CiudadId).HasColumnName("CiudadID");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");

            entity.HasOne(d => d.Provincia).WithMany(p => p.Ciudades)
                .HasForeignKey(d => d.ProvinciaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Ciudad_Provincia");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK_Cliente");

            entity.ToTable("CLIENTES");

            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cuil)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.DomicilioId).HasColumnName("DomicilioID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TipoClienteId).HasColumnName("TipoClienteID");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.DomicilioId)
                .HasConstraintName("FK_Cliente_Domicilio");

            entity.HasOne(d => d.TipoCliente).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.TipoClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente_TipoCliente");
        });

        modelBuilder.Entity<Compra>(entity =>
        {
            entity.HasKey(e => e.CompraId).HasName("PK_Compra");

            entity.ToTable("COMPRAS");

            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.NumeroComprobante)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.Compras)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Compra_Proveedor");
        });

        modelBuilder.Entity<Contacto>(entity =>
        {
            entity.HasKey(e => e.ContactoId).HasName("PK_Contacto");

            entity.ToTable("CONTACTOS");

            entity.Property(e => e.ContactoId).HasColumnName("ContactoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.TipoContactoId).HasColumnName("TipoContactoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacto_Cliente");

            entity.HasOne(d => d.TipoContacto).WithMany(p => p.Contactos)
                .HasForeignKey(d => d.TipoContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Contacto_TipoContacto");
        });

        modelBuilder.Entity<ContactoEmpleado>(entity =>
        {
            entity.HasKey(e => e.ContactoEmpleadoId).HasName("PK_ContactoEmpleado");

            entity.ToTable("CONTACTO_EMPLEADOS");

            entity.Property(e => e.ContactoEmpleadoId).HasColumnName("ContactoEmpleadoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.TipoContactoId).HasColumnName("TipoContactoID");

            entity.HasOne(d => d.Empleado).WithMany(p => p.ContactoEmpleados)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoEmpleado_Empleado");

            entity.HasOne(d => d.TipoContacto).WithMany(p => p.ContactoEmpleados)
                .HasForeignKey(d => d.TipoContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoEmpleado_TipoContacto");
        });

        modelBuilder.Entity<ContactoProveedore>(entity =>
        {
            entity.HasKey(e => e.ContactoProveedorId).HasName("PK_ContactoProveedor");

            entity.ToTable("CONTACTO_PROVEEDORES");

            entity.Property(e => e.ContactoProveedorId).HasColumnName("ContactoProveedorID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.TipoContactoId).HasColumnName("TipoContactoID");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.ContactoProveedores)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoProveedor_Proveedor");

            entity.HasOne(d => d.TipoContacto).WithMany(p => p.ContactoProveedores)
                .HasForeignKey(d => d.TipoContactoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ContactoProveedor_TipoContacto");
        });

        modelBuilder.Entity<DescuentoMayorista>(entity =>
        {
            entity.HasKey(e => e.DescuentoMayoristaId).HasName("PK_DescuentoMayorista");

            entity.ToTable("DESCUENTO_MAYORISTAS");

            entity.Property(e => e.DescuentoMayoristaId).HasColumnName("DescuentoMayoristaID");
            entity.Property(e => e.PorcentajeDescuento).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.HasKey(e => e.DetalleCompraId).HasName("PK_DetalleCompra");

            entity.ToTable("DETALLE_COMPRAS");

            entity.Property(e => e.DetalleCompraId).HasColumnName("DetalleCompraID");
            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Compra).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.CompraId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Compra");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCompra_Producto");
        });

        modelBuilder.Entity<DetalleFactura>(entity =>
        {
            entity.HasKey(e => e.DetalleFacturaId).HasName("PK_DetalleFactura");

            entity.ToTable("DETALLE_FACTURAS");

            entity.Property(e => e.DetalleFacturaId).HasColumnName("DetalleFacturaID");
            entity.Property(e => e.DescuentoMayoristaId).HasColumnName("DescuentoMayoristaID");
            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.PrecioUnitario).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.DescuentoMayorista).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.DescuentoMayoristaId)
                .HasConstraintName("FK_DetalleFactura_DescuentoMayorista");

            entity.HasOne(d => d.Factura).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.FacturaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Factura");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleFacturas)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleFactura_Producto");
        });

        modelBuilder.Entity<DetalleIngresosStock>(entity =>
        {
            entity.HasKey(e => e.DetalleIngresoStockId).HasName("PK_DetalleIngresoStock");

            entity.ToTable("DETALLE_INGRESOS_STOCK");

            entity.Property(e => e.DetalleIngresoStockId).HasColumnName("DetalleIngresoStockID");
            entity.Property(e => e.IngresoStockId).HasColumnName("IngresoStockID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.IngresoStock).WithMany(p => p.DetalleIngresosStocks)
                .HasForeignKey(d => d.IngresoStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleIngresoStock_IngresoStock");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleIngresosStocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleIngresoStock_Producto");
        });

        modelBuilder.Entity<DetalleOrdenPedido>(entity =>
        {
            entity.HasKey(e => e.DetalleOrdenPedidoId).HasName("PK_DetalleOrdenPedido");

            entity.ToTable("DETALLE_ORDEN_PEDIDOS");

            entity.Property(e => e.DetalleOrdenPedidoId).HasColumnName("DetalleOrdenPedidoID");
            entity.Property(e => e.OrdenPedidoId).HasColumnName("OrdenPedidoID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.DetalleOrdenPedidos)
                .HasForeignKey(d => d.OrdenPedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenPedido_OrdenPedido");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleOrdenPedidos)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenPedido_Producto");
        });

        modelBuilder.Entity<DetalleOrdenReposicione>(entity =>
        {
            entity.HasKey(e => e.DetalleOrdenReposicionId).HasName("PK_DetalleOrdenReposicion");

            entity.ToTable("DETALLE_ORDEN_REPOSICIONES");

            entity.Property(e => e.DetalleOrdenReposicionId).HasColumnName("DetalleOrdenReposicionID");
            entity.Property(e => e.OrdenReposicionId).HasColumnName("OrdenReposicionID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.OrdenReposicion).WithMany(p => p.DetalleOrdenReposiciones)
                .HasForeignKey(d => d.OrdenReposicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenReposicion_OrdenReposicion");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleOrdenReposiciones)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleOrdenReposicion_Producto");
        });

        modelBuilder.Entity<DetalleTransferenciasStock>(entity =>
        {
            entity.HasKey(e => e.DetalleTransferenciaStockId).HasName("PK_DetalleTransferenciaStock");

            entity.ToTable("DETALLE_TRANSFERENCIAS_STOCK");

            entity.Property(e => e.DetalleTransferenciaStockId).HasColumnName("DetalleTransferenciaStockID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.TransferenciaStockId).HasColumnName("TransferenciaStockID");

            entity.HasOne(d => d.Producto).WithMany(p => p.DetalleTransferenciasStocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleTransferenciaStock_Producto");

            entity.HasOne(d => d.TransferenciaStock).WithMany(p => p.DetalleTransferenciasStocks)
                .HasForeignKey(d => d.TransferenciaStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleTransferenciaStock_TransferenciaStock");
        });

        modelBuilder.Entity<Domicilio>(entity =>
        {
            entity.HasKey(e => e.DomicilioId).HasName("PK_Domicilio");

            entity.ToTable("DOMICILIOS");

            entity.Property(e => e.DomicilioId).HasColumnName("DomicilioID");
            entity.Property(e => e.BarrioId).HasColumnName("BarrioID");
            entity.Property(e => e.Calle)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Departamento)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Piso)
                .HasMaxLength(10)
                .IsUnicode(false);

            entity.HasOne(d => d.Barrio).WithMany(p => p.Domicilios)
                .HasForeignKey(d => d.BarrioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Domicilio_Barrio");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.EmpleadoId).HasName("PK_Empleado");

            entity.ToTable("EMPLEADOS");

            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Cuil)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.Dni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("DNI");
            entity.Property(e => e.DomicilioId).HasColumnName("DomicilioID");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PuestoId).HasColumnName("PuestoID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.DomicilioId)
                .HasConstraintName("FK_Empleado_Domicilio");

            entity.HasOne(d => d.Puesto).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.PuestoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Puesto");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Empleado_Sucursal");
        });

        modelBuilder.Entity<EstadoPedido>(entity =>
        {
            entity.HasKey(e => e.EstadoPedidoId).HasName("PK_EstadoPedido");

            entity.ToTable("ESTADO_PEDIDOS");

            entity.Property(e => e.EstadoPedidoId).HasColumnName("EstadoPedidoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EstadoReposicione>(entity =>
        {
            entity.HasKey(e => e.EstadoReposicionId).HasName("PK_EstadoReposicion");

            entity.ToTable("ESTADO_REPOSICIONES");

            entity.Property(e => e.EstadoReposicionId).HasColumnName("EstadoReposicionID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaId).HasName("PK_Factura");

            entity.ToTable("FACTURAS");

            entity.Property(e => e.FacturaId).HasColumnName("FacturaID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EmpleadoId).HasColumnName("EmpleadoID");
            entity.Property(e => e.NumeroFactura)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.OrdenPedidoId).HasColumnName("OrdenPedidoID");
            entity.Property(e => e.PlanCuotasId).HasColumnName("PlanCuotasID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Cliente");

            entity.HasOne(d => d.Empleado).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.EmpleadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Empleado");

            entity.HasOne(d => d.OrdenPedido).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.OrdenPedidoId)
                .HasConstraintName("FK_Factura_OrdenPedido");

            entity.HasOne(d => d.PlanCuotas).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.PlanCuotasId)
                .HasConstraintName("FK_Factura_PlanCuotas");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Factura_Sucursal");
        });

        modelBuilder.Entity<HistorialPrecio>(entity =>
        {
            entity.HasKey(e => e.HistorialPrecioId).HasName("PK_HistorialPrecio");

            entity.ToTable("HISTORIAL_PRECIOS");

            entity.Property(e => e.HistorialPrecioId).HasColumnName("HistorialPrecioID");
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");

            entity.HasOne(d => d.Producto).WithMany(p => p.HistorialPrecios)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HistorialPrecio_Producto");
        });

        modelBuilder.Entity<IngresosStock>(entity =>
        {
            entity.HasKey(e => e.IngresoStockId).HasName("PK_IngresoStock");

            entity.ToTable("INGRESOS_STOCK");

            entity.Property(e => e.IngresoStockId).HasColumnName("IngresoStockID");
            entity.Property(e => e.CompraId).HasColumnName("CompraID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

            entity.HasOne(d => d.Compra).WithMany(p => p.IngresosStocks)
                .HasForeignKey(d => d.CompraId)
                .HasConstraintName("FK_IngresoStock_Compra");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.IngresosStocks)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_IngresoStock_Sucursal");
        });

        modelBuilder.Entity<MovimientosStock>(entity =>
        {
            entity.HasKey(e => e.MovimientoStockId).HasName("PK_MovimientoStock");

            entity.ToTable("MOVIMIENTOS_STOCK");

            entity.Property(e => e.MovimientoStockId).HasColumnName("MovimientoStockID");
            entity.Property(e => e.FechaMovimiento).HasColumnType("datetime");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.TipoMovimientoStockId).HasColumnName("TipoMovimientoStockID");

            entity.HasOne(d => d.Producto).WithMany(p => p.MovimientosStocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoStock_Producto");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.MovimientosStocks)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoStock_Sucursal");

            entity.HasOne(d => d.TipoMovimientoStock).WithMany(p => p.MovimientosStocks)
                .HasForeignKey(d => d.TipoMovimientoStockId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_MovimientoStock_TipoMovimientoStock");
        });

        modelBuilder.Entity<OrdenPedido>(entity =>
        {
            entity.HasKey(e => e.OrdenPedidoId).HasName("PK_OrdenPedido");

            entity.ToTable("ORDEN_PEDIDOS");

            entity.Property(e => e.OrdenPedidoId).HasColumnName("OrdenPedidoID");
            entity.Property(e => e.ClienteId).HasColumnName("ClienteID");
            entity.Property(e => e.EstadoPedidoId).HasColumnName("EstadoPedidoID");

            entity.HasOne(d => d.Cliente).WithMany(p => p.OrdenPedidos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenPedido_Cliente");

            entity.HasOne(d => d.EstadoPedido).WithMany(p => p.OrdenPedidos)
                .HasForeignKey(d => d.EstadoPedidoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenPedido_EstadoPedido");
        });

        modelBuilder.Entity<OrdenReposicione>(entity =>
        {
            entity.HasKey(e => e.OrdenReposicionId).HasName("PK_OrdenReposicion");

            entity.ToTable("ORDEN_REPOSICIONES");

            entity.Property(e => e.OrdenReposicionId).HasColumnName("OrdenReposicionID");
            entity.Property(e => e.EstadoReposicionId).HasColumnName("EstadoReposicionID");
            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");

            entity.HasOne(d => d.EstadoReposicion).WithMany(p => p.OrdenReposiciones)
                .HasForeignKey(d => d.EstadoReposicionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenReposicion_EstadoReposicion");

            entity.HasOne(d => d.Proveedor).WithMany(p => p.OrdenReposiciones)
                .HasForeignKey(d => d.ProveedorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrdenReposicion_Proveedor");
        });

        modelBuilder.Entity<PlanCuota>(entity =>
        {
            entity.HasKey(e => e.PlanCuotasId).HasName("PK_PlanCuotas");

            entity.ToTable("PLAN_CUOTAS");

            entity.Property(e => e.PlanCuotasId).HasColumnName("PlanCuotasID");
            entity.Property(e => e.PorcentajeInteres).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK_Producto");

            entity.ToTable("PRODUCTOS");

            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.CategoriaProductoId).HasColumnName("CategoriaProductoID");
            entity.Property(e => e.Codigo)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");

            entity.HasOne(d => d.CategoriaProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_CategoriaProducto");

            entity.HasOne(d => d.TipoProducto).WithMany(p => p.Productos)
                .HasForeignKey(d => d.TipoProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Producto_TipoProducto");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.ProveedorId).HasName("PK_Proveedor");

            entity.ToTable("PROVEEDORES");

            entity.Property(e => e.ProveedorId).HasColumnName("ProveedorID");
            entity.Property(e => e.Cuil)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("CUIL");
            entity.Property(e => e.DomicilioId).HasColumnName("DomicilioID");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(150)
                .IsUnicode(false);

            entity.HasOne(d => d.Domicilio).WithMany(p => p.Proveedores)
                .HasForeignKey(d => d.DomicilioId)
                .HasConstraintName("FK_Proveedor_Domicilio");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity.HasKey(e => e.ProvinciaId).HasName("PK_Provincia");

            entity.ToTable("PROVINCIAS");

            entity.Property(e => e.ProvinciaId).HasColumnName("ProvinciaID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Puesto>(entity =>
        {
            entity.HasKey(e => e.PuestoId).HasName("PK_Puesto");

            entity.ToTable("PUESTOS");

            entity.Property(e => e.PuestoId).HasColumnName("PuestoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK_Stock");

            entity.ToTable("STOCK");

            entity.Property(e => e.StockId).HasColumnName("StockID");
            entity.Property(e => e.ProductoId).HasColumnName("ProductoID");
            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Producto");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Stocks)
                .HasForeignKey(d => d.SucursalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stock_Sucursal");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK_Sucursal");

            entity.ToTable("SUCURSALES");

            entity.Property(e => e.SucursalId).HasColumnName("SucursalID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DomicilioId).HasColumnName("DomicilioID");

            entity.HasOne(d => d.Domicilio).WithMany(p => p.Sucursales)
                .HasForeignKey(d => d.DomicilioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Sucursal_Domicilio");
        });

        modelBuilder.Entity<TipoCliente>(entity =>
        {
            entity.HasKey(e => e.TipoClienteId).HasName("PK_TipoCliente");

            entity.ToTable("TIPO_CLIENTES");

            entity.Property(e => e.TipoClienteId).HasColumnName("TipoClienteID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoContacto>(entity =>
        {
            entity.HasKey(e => e.TipoContactoId).HasName("PK_TipoContacto");

            entity.ToTable("TIPO_CONTACTOS");

            entity.Property(e => e.TipoContactoId).HasColumnName("TipoContactoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoMovimientosStock>(entity =>
        {
            entity.HasKey(e => e.TipoMovimientoStockId).HasName("PK_TipoMovimientoStock");

            entity.ToTable("TIPO_MOVIMIENTOS_STOCK");

            entity.Property(e => e.TipoMovimientoStockId).HasColumnName("TipoMovimientoStockID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TipoProducto>(entity =>
        {
            entity.HasKey(e => e.TipoProductoId).HasName("PK_TipoProducto");

            entity.ToTable("TIPO_PRODUCTOS");

            entity.Property(e => e.TipoProductoId).HasColumnName("TipoProductoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TransferenciasStock>(entity =>
        {
            entity.HasKey(e => e.TransferenciaStockId).HasName("PK_TransferenciaStock");

            entity.ToTable("TRANSFERENCIAS_STOCK");

            entity.Property(e => e.TransferenciaStockId).HasColumnName("TransferenciaStockID");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.SucursalDestinoId).HasColumnName("SucursalDestinoID");
            entity.Property(e => e.SucursalOrigenId).HasColumnName("SucursalOrigenID");

            entity.HasOne(d => d.SucursalDestino).WithMany(p => p.TransferenciasStockSucursalDestinos)
                .HasForeignKey(d => d.SucursalDestinoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferenciaStock_SucursalDestino");

            entity.HasOne(d => d.SucursalOrigen).WithMany(p => p.TransferenciasStockSucursalOrigens)
                .HasForeignKey(d => d.SucursalOrigenId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TransferenciaStock_SucursalOrigen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
