using System;
namespace GestorOrdenes.Servicios.Excepciones
{
    public class ClienteNoEncontradoException : Exception
    {
        public ClienteNoEncontradoException(int clienteId)
            : base($"El cliente con ID {clienteId} no fue encontrado.")
        {
        }
    }
}

