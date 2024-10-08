using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Servicios.DTOs;

namespace GestorOrdenes.Servicios.Validaciones
{
    public static class ValidarOrden
    {
        public static void ValidarClienteExistente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("El cliente no existe.");
            }
        }

        public static void ValidarStockProducto(Producto producto, int cantidadSolicitada)
        {
            if (producto == null)
            {
                throw new ArgumentException("El producto no existe.");
            }

            if (producto.CantidadStock < cantidadSolicitada)
            {
                throw new ArgumentException($"Stock insuficiente para el producto {producto.Nombre}. Solo quedan {producto.CantidadStock} unidades.");
            }
        }

        public static void ValidarDetallesOrden(List<CrearDetalleOrdenDto> detalles)
        {
            if (detalles == null || detalles.Count == 0)
            {
                throw new ArgumentException("La orden debe contener al menos un producto.");
            }
        }
    }
}

