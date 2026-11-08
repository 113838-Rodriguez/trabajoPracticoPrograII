
using Ferreteria.DTOs;
using Ferreteria.Models;
using Ferreteria.Repositories.Interfaces;
using Ferreteria.Services.Interfaces;

namespace Ferreteria.Services
{
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _repository;

        public ProductoService(IProductoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ProductoResponseDTO>> GetAllAsync()
        {
            var productos = await _repository.GetAllAsync();

            return productos.Select(p => MapToResponse(p)).ToList(); //Convertir a DTO
        }

        // CONSULTAR POR ID
        public async Task<ProductoResponseDTO?> GetByIdAsync(int id, bool activoOnly)
        {
            var producto = await _repository.GetByIdAsync(id);

            if (producto == null || activoOnly == true)
            {
                return null;
            }

            return MapToResponse(producto);
        }

        // CONSULTAR POR CODIGO
        public async Task<ProductoResponseDTO?> GetByCodigoAsync(string codigo, bool activoOnly)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código es obligatorio.");

            var producto = await _repository.GetByCodigoAsync(codigo.Trim());

            if (producto == null || activoOnly == true)
            {
                return null;
            }

            return MapToResponse(producto);
        }

        // ALTA
        public async Task<ProductoResponseDTO> CreateAsync(CreateProductoDTO dto)
        {
            string codigo = dto.Codigo.Trim();

            if (string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            string descripcion = dto.Descripcion.Trim();

            // Validar código duplicado
            await ValidateCodigoOrIdAsync(codigo);

            // Validar relaciones
            await ValidateReferenciasAsync(
                dto.CategoriaProductoId,
                dto.TipoProductoId
            );

            // Crear entidad
            Producto producto = new()
            {
                Codigo = codigo,
                Descripcion = descripcion,
                Marca = string.IsNullOrWhiteSpace(dto.Marca)
                    ? null
                    : dto.Marca.Trim(),
                CategoriaProductoId = dto.CategoriaProductoId,
                TipoProductoId = dto.TipoProductoId,
                Activo = true
            };

            await _repository.AddAsync(producto);

            // Recuperar producto con sus relaciones
            var creado = await _repository.GetByIdAsync(producto.ProductoId);

            if (creado == null)
                throw new InvalidOperationException(
                    "No se pudo recuperar el producto creado.");

            return MapToResponse(creado);
        }

        // MODIFICACION
        public async Task<ProductoResponseDTO?> UpdateAsync(int id, UpdateProductoDTO dto)
        {
            var producto = await _repository.GetByIdAsync(id);

            if (producto == null || !producto.Activo)
                return null;

            // Validar código duplicado, excluyendo el propio producto
            await ValidateCodigoOrIdAsync(dto.Codigo.Trim(), id);

            // Validar relaciones
            await ValidateReferenciasAsync(
                dto.CategoriaProductoId,
                dto.TipoProductoId
            );

            if (string.IsNullOrWhiteSpace(dto.Descripcion))
            {
                throw new ArgumentException("La descripción es obligatoria.");
            }

            // Actualizar propiedades
            producto.Codigo = dto.Codigo.Trim();
            producto.Descripcion = dto.Descripcion.Trim();
            producto.Marca = string.IsNullOrWhiteSpace(dto.Marca)
                ? null
                : dto.Marca.Trim();
            producto.CategoriaProductoId = dto.CategoriaProductoId;
            producto.TipoProductoId = dto.TipoProductoId;

            await _repository.UpdateAsync(producto);

            var actualizado = await _repository.GetByIdAsync(id);

            if (actualizado == null)
                throw new InvalidOperationException(
                    "No se pudo recuperar el producto modificado.");

            return MapToResponse(actualizado);
        }

        // BAJA LOGICA
        public async Task<bool> DeleteAsync(int id)
        {
            var producto = await _repository.GetByIdAsync(id);

            if (producto == null || !producto.Activo)
                return false;

            producto.Activo = false;

            await _repository.UpdateAsync(producto);

            return true;
        }

        // VALIDACIONES AUXILIARES

        private async Task ValidateCodigoOrIdAsync(string codigo, int? productoId = null)
        {
            if (string.IsNullOrWhiteSpace(codigo))
                throw new ArgumentException("El código es obligatorio.");

            codigo = codigo.Trim();

            if (await _repository.ExistsCodigoOrIdAsync(codigo, productoId))
                throw new InvalidOperationException(
                    "Ya existe un producto con el código indicado.");
        }

        private async Task ValidateReferenciasAsync(
            int categoriaProductoId,
            int tipoProductoId)
        {
            if (!await _repository.ExistsCategoriaProductoAsync(
                categoriaProductoId))
            {
                throw new ArgumentException(
                    "La categoría de producto indicada no existe.");
            }

            if (!await _repository.ExistsTipoProductoAsync(
                tipoProductoId))
            {
                throw new ArgumentException(
                    "El tipo de producto indicado no existe.");
            }
        }

        // MAPEO ENTIDAD -> DTO

        private static ProductoResponseDTO MapToResponse(Producto producto)
        {
            return new ProductoResponseDTO
            {
                ProductoID = producto.ProductoId,
                Codigo = producto.Codigo,
                Descripcion = producto.Descripcion,
                Marca = producto.Marca,

                CategoriaProductoID = producto.CategoriaProductoId,
                CategoriaProductoDescripcion =
                    producto.CategoriaProducto?.Descripcion ?? string.Empty,

                TipoProductoID = producto.TipoProductoId,
                TipoProductoDescripcion =
                    producto.TipoProducto?.Descripcion ?? string.Empty,

                Activo = producto.Activo
            };
        }
    }
}
