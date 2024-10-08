using System;
using GestorOrdenes.Dominio.Entidades;

namespace GestorOrdenes.Servicios.Interfaces
{
    public interface IProductoService
    {
        Task<Producto> ObtenerProductoPorId(int id);
        Task<List<Producto>> ObtenerTodosLosProductos();
        Task ActualizarStock(int productoId, int cantidad);
    }
}

