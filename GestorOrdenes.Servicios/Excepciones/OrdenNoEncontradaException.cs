using System;
namespace GestorOrdenes.Servicios.Excepciones
{
    public class OrdenNoEncontradaException : Exception
    {
        public OrdenNoEncontradaException(int ordenId)
            : base($"La orden con ID {ordenId} no fue encontrada.")
        {
        }
    }
}

