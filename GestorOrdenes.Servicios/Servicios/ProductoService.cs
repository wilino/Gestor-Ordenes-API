using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Dominio.Interfaces;
using GestorOrdenes.Servicios.Excepciones;
using GestorOrdenes.Servicios.Interfaces;
using GestorOrdenes.Servicios.Validaciones;

public class ProductoService : IProductoService
{
    private readonly IProductoRepository _productoRepository;

    public ProductoService(IProductoRepository productoRepository)
    {
        _productoRepository = productoRepository;
    }

    public async Task<Producto> ObtenerProductoPorId(int id)
    {
        var producto = await _productoRepository.ObtenerPorId(id);
        if (producto == null)
        {
            throw new ProductoNoEncontradoException(id);
        }
        return producto;
    }

    public async Task<List<Producto>> ObtenerTodosLosProductos()
    {
        return await _productoRepository.ObtenerTodos();
    }

    public async Task CrearProducto(Producto producto)
    {
        ValidarProducto.ValidarNombre(producto.Nombre);

        ValidarProducto.ValidarPrecio(producto.Precio);

        ValidarProducto.ValidarCantidadStock(producto.CantidadStock);

        await _productoRepository.Agregar(producto);
    }

    public async Task ActualizarStock(int productoId, int cantidad)
    {
        var producto = await _productoRepository.ObtenerPorId(productoId);
        if (producto == null)
        {
            throw new ProductoNoEncontradoException(productoId);
        }

        if (cantidad < 0)
        {
            throw new ArgumentException("La cantidad no puede ser negativa.");
        }

        await _productoRepository.ActualizarStock(productoId, cantidad);
    }
}

