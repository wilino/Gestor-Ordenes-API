using System;
namespace GestorOrdenes.Servicios.DTOs
{
    public class OrdenDto
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaOrden { get; set; }

        // Detalles de la orden simplificados
        public List<DetalleOrdenDto> DetallesOrden { get; set; }
    }

}

