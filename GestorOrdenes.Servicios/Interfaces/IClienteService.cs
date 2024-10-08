using System;
using GestorOrdenes.Dominio.Entidades;

namespace GestorOrdenes.Servicios.Interfaces
{
    public interface IClienteService
    {
        Task<Cliente> ObtenerClientePorId(int id);
        Task<List<Cliente>> ObtenerTodosLosClientes();
        Task CrearCliente(Cliente cliente);
    }
}

