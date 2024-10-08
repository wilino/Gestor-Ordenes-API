using System;
namespace GestorOrdenes.Servicios.DTOs
{
	public class CrearOrdenDto
	{
        public int ClienteId { get; set; }


        public List<CrearDetalleOrdenDto> DetallesOrden { get; set; }
    }
}

