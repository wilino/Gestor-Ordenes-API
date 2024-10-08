using System;
using GestorOrdenes.Dominio.Entidades;
using GestorOrdenes.Servicios.DTOs;

namespace GestorOrdenes.Servicios.Interfaces
{
    public interface IOrdenService
    {
        Task CrearOrden(CrearOrdenDto ordenDto);
        Task<OrdenDto> ObtenerPorId(int id);
    }
}

