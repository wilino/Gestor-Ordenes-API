using System;
using GestorOrdenes.Dominio.Entidades;

namespace GestorOrdenes.Dominio.Interfaces
{
    public interface IProductoRepository
    {
        Task<Producto> ObtenerPorId(int id);
        Task<List<Producto>> ObtenerTodos();
        Task ActualizarStock(int productoId, int cantidad);
        Task Agregar(Producto producto);
    }
}

