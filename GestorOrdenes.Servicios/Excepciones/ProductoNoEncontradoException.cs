using System;
namespace GestorOrdenes.Servicios.Excepciones
{
    public class ProductoNoEncontradoException : Exception
    {
        public ProductoNoEncontradoException(int productoId)
            : base($"El producto con ID {productoId} no fue encontrado.")
        {
        }
    }
}

