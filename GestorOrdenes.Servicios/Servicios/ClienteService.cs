using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Dominio.Interfaces;
using GestorOrdenes.Servicios.Excepciones;
using GestorOrdenes.Servicios.Interfaces;
using GestorOrdenes.Servicios.Validaciones;

namespace GestorOrdenes.Servicios.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> ObtenerClientePorId(int id)
        {
            var cliente = await _clienteRepository.ObtenerPorId(id);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException(id);
            }
            return cliente;
        }

        public async Task<List<Cliente>> ObtenerTodosLosClientes()
        {
            return await _clienteRepository.ObtenerTodos();
        }

        public async Task CrearCliente(Cliente cliente)
        {
            ValidarCliente.ValidarNombre(cliente.Nombre);

            ValidarCliente.ValidarCorreoElectronico(cliente.CorreoElectronico);

            await _clienteRepository.Agregar(cliente);
        }
    }
}

