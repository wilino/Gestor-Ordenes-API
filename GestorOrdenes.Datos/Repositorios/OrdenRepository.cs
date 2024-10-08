using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Dominio.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace GestorOrdenes.Datos.Repositorios
{
    public class OrdenRepository : IOrdenRepository
    {
        private readonly ApplicationDbContext _context;

        public OrdenRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CrearOrden(Orden orden)
        {
            await _context.Ordenes.AddAsync(orden);
            await _context.SaveChangesAsync();
        }

        public async Task<Orden> ObtenerPorId(int id)
        {
            return await _context.Ordenes
                .Include(o => o.Cliente) 
                .Include(o => o.DetallesOrden)
                .ThenInclude(d => d.Producto) // Incluir los productos en los detalles
                .FirstOrDefaultAsync(o => o.Id == id);
        }


        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

    }

}

