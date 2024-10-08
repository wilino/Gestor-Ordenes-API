using System;
namespace GestorOrdenes.Servicios.Excepciones
{
    public class StockInsuficienteException : Exception
    {
        public StockInsuficienteException(string productoNombre, int cantidadSolicitada, int cantidadDisponible)
            : base($"Stock insuficiente para el producto '{productoNombre}'. Cantidad solicitada: {cantidadSolicitada}, cantidad disponible: {cantidadDisponible}.")
        {
        }
    }
}

