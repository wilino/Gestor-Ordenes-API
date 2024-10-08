using GestorOrdenes.Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Storage;

namespace GestorOrdenes.Dominio.Interfaces
{
    public interface IOrdenRepository
    {
        Task CrearOrden(Orden orden);
        Task<Orden> ObtenerPorId(int id);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}

