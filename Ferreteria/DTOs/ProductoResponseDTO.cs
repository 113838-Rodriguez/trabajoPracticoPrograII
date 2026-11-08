namespace Ferreteria.DTOs;

public class ProductoResponseDTO
{
    public int ProductoID { get; set; }

    public string Codigo { get; set; } = string.Empty;

    public string Descripcion { get; set; } = string.Empty;

    public string? Marca { get; set; }

    public int CategoriaProductoID { get; set; }

    public string CategoriaProductoDescripcion { get; set; } = string.Empty;

    public int TipoProductoID { get; set; }

    public string TipoProductoDescripcion { get; set; } = string.Empty;

    public bool Activo { get; set; }
}
