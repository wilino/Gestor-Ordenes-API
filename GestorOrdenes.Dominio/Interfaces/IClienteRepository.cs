using System;
using GestorOrdenes.Dominio.Entidades;

namespace GestorOrdenes.Dominio.Interfaces
{
    public interface IClienteRepository
    {
        Task<Cliente> ObtenerPorId(int id);
        Task<List<Cliente>> ObtenerTodos();
        Task Agregar(Cliente cliente);
    }

    
}

