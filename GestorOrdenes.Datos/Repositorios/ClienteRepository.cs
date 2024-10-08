using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestorOrdenes.Datos.Repositorios
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _context;

        public ClienteRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Cliente> ObtenerPorId(int id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        public async Task<List<Cliente>> ObtenerTodos()
        {
            return await _context.Clientes.ToListAsync();
        }

        public async Task Agregar(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }
    }
}

